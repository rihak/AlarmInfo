using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AlarmInfo
{
    public partial class FormAlarmInfo : Form
    {
        public string pathAEsDefault = @".\AEs\";
        public string pathAEs;
        public string[] filesAEs;

        public string[] messagesText;
        public Dictionary<string, string> message2Id;
        public Dictionary<string, string> id2Name;
        public Dictionary<string, string> id2InputTag;
        public Dictionary<string, string> id2AckTag;

        public FormAlarmInfo()
        {
            InitializeComponent();
            InitializeAEs();
        }

        public void InitializeAEs()
        {

            var appSettings = ConfigurationManager.AppSettings;
            pathAEs = appSettings["pathAEs"] ?? pathAEsDefault;

            if (!Directory.Exists(pathAEs))
            {
                MessageBox.Show($"{pathAEs} directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
                System.Environment.Exit(1);
                return;
            }

            filesAEs = [.. Directory.GetFiles(pathAEs, "*.xml").Select(file => Path.GetFileNameWithoutExtension(file))];


            if (filesAEs == null || filesAEs.Length == 0)
            {
                MessageBox.Show($"{pathAEs} directory is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
                System.Environment.Exit(1);
                return;
            }

            foreach (string file in filesAEs)
            {
                ComboBoxAE.Items.Add(file);
            }
        }

        private void ComboBoxAE_TextUpdate(object sender, EventArgs e)
        {
            if (ComboBoxAE.Text == "")
            {
                ComboBoxAE.Items.Clear();
                ComboBoxAE.Items.AddRange(filesAEs);
                ComboBoxAE.SelectedIndex = -1;
            }
            else
            {
                string query = ComboBoxAE.Text;
                string[] filtered = filesAEs.Where(s => s.ToLower().Contains(query.ToLower())).ToArray();
                ComboBoxAE.Items.Clear();
                ComboBoxAE.Items.AddRange(filtered);
                ComboBoxAE.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                ComboBoxAE.SelectedIndex = -1;
                ComboBoxAE.Text = query;
                ComboBoxAE.Select(ComboBoxAE.Text.Length, 0);
            }
        }

        private void ComboBoxAE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') { return; }

            if (ActiveControl != null)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            e.Handled = true;
        }

        private void ComboBoxAE_TextChanged(object sender, EventArgs e)
        {
            ComboBoxMessage.Text = "";
            resetFields();
        }

        private void ComboBoxAE_SelectedValueChanged(object sender, EventArgs e)
        {
            if (filesAEs.Contains(ComboBoxAE.Text))
            {
                loadMaps();
            }
        }

        private void ComboBoxMessage_TextUpdate(object sender, EventArgs e)
        {
            if (ComboBoxMessage.Text == "")
            {
                ComboBoxMessage.Items.Clear();
                ComboBoxMessage.Items.AddRange(messagesText);
                ComboBoxMessage.SelectedIndex = -1;
            }
            else
            {
                string query = ComboBoxMessage.Text;
                string[] filtered = messagesText.Where(s => s.ToLower().Contains(query.ToLower())).ToArray();
                ComboBoxMessage.Items.Clear();
                ComboBoxMessage.Items.AddRange(filtered);
                ComboBoxMessage.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                ComboBoxMessage.SelectedIndex = -1;
                ComboBoxMessage.Text = query;
                ComboBoxMessage.Select(ComboBoxMessage.Text.Length, 0);
            }
        }

        private void ComboBoxMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') { return; }

            if (ActiveControl != null)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            e.Handled = true;
        }

        private void ComboBoxMessage_SelectedValueChanged(object sender, EventArgs e)
        {
            fillFields();
        }

        private void loadMaps()
        {
            // Read XML content into string
            string xmlPath = $"{pathAEs}{ComboBoxAE.Text}.xml";
            string xmlContent = File.ReadAllText(xmlPath);

            // Initialize XML object with namespace
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlContent);
            XmlNode root = xml.DocumentElement;
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xml.NameTable);
            nsManager.AddNamespace("ns", root.NamespaceURI);


            // Load Message To ID Map

            messagesText = null;
            message2Id = new Dictionary<string, string>();
            ComboBoxMessage.Items.Clear();

            XmlNodeList messages = xml.SelectNodes("//ns:FTAeDetectorCommand/ns:Messages/ns:Message", nsManager);

            foreach (XmlNode message in messages)
            {
                string id = message.Attributes["id"].Value;
                XmlNodeList messageTexts = message.SelectNodes("ns:Msgs/ns:Msg", nsManager);

                foreach (XmlNode messageText in messageTexts)
                {
                    string cleanText = Regex.Replace(Regex.Replace(messageText.InnerText, @"\t|\n|\r", ""), @"\s\s+", " ");
                    if (messageText.InnerText != null && !message2Id.ContainsKey(cleanText))
                    {
                        message2Id.Add(cleanText, id);
                    }
                }
            }

            messagesText = message2Id.Keys.ToArray();


            // Load ID To X Maps

            id2Name = new Dictionary<string, string>();
            id2InputTag = new Dictionary<string, string>();
            id2AckTag = new Dictionary<string, string>();

            XmlNodeList alarms = root.SelectNodes("//ns:FTAeDetectorCommand[ns:Operation='WriteConfig']/ns:FTAlarmElements/ns:FTAlarmElement", nsManager);

            foreach (XmlNode alarm in alarms)
            {
                string name = alarm.Attributes.GetNamedItem("name").Value;
                string messageId = alarm.SelectSingleNode("ns:DiscreteElement/ns:MessageID", nsManager)?.InnerText;
                string inputTag = alarm.SelectSingleNode("ns:DiscreteElement/ns:DataItem", nsManager)?.InnerText;
                string ackTag = alarm.SelectSingleNode("ns:DiscreteElement/ns:HandshakeTags/ns:AckedDataItem", nsManager)?.InnerText;

                if (!string.IsNullOrEmpty(messageId))
                {
                    if (!string.IsNullOrEmpty(inputTag) && !id2InputTag.ContainsKey(messageId))
                    {
                        id2InputTag.Add(messageId, inputTag);
                    }
                    if (!string.IsNullOrEmpty(ackTag) && !id2AckTag.ContainsKey(messageId))
                    {
                        id2AckTag.Add(messageId, ackTag);
                    }
                    if (!string.IsNullOrEmpty(name) && !id2Name.ContainsKey(messageId))
                    {
                        id2Name.Add(messageId, name);
                    }
                }

            }

            ComboBoxMessage.Items.AddRange(messagesText);
        }

        private void resetFields()
        {
            TextBoxAlarmName.Text = "";
            TextBoxInputTag.Text = "";
            TextBoxAckTag.Text = "";
        }

        private void fillFields()
        {
            resetFields();

            if (ComboBoxMessage.Text == "" || !message2Id.ContainsKey(ComboBoxMessage.Text))
            {
                return;
            }
            string id = message2Id[ComboBoxMessage.Text];
            if (id != null)
            {
                if (id2Name.ContainsKey(id))
                {
                    TextBoxAlarmName.Text = id2Name[id];
                }
                if (id2InputTag.ContainsKey(id))
                {
                    TextBoxInputTag.Text = id2InputTag[id];
                }
                if (id2AckTag.ContainsKey(id))
                {
                    TextBoxAckTag.Text = id2AckTag[id];
                }
            }
        }

    }
}
