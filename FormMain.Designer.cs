namespace AlarmInfo
{
    partial class FormAlarmInfo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlarmInfo));
            ComboBoxAE = new ComboBox();
            ComboBoxMessage = new ComboBox();
            LabelAE = new Label();
            LabelMessage = new Label();
            LabelAlarmName = new Label();
            LabelInputTag = new Label();
            LabelAckTag = new Label();
            TextBoxAlarmName = new TextBox();
            TextBoxInputTag = new TextBox();
            TextBoxAckTag = new TextBox();
            SuspendLayout();
            // 
            // ComboBoxAE
            // 
            ComboBoxAE.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxAE.FormattingEnabled = true;
            ComboBoxAE.Location = new Point(46, 12);
            ComboBoxAE.Name = "ComboBoxAE";
            ComboBoxAE.Size = new Size(726, 23);
            ComboBoxAE.TabIndex = 0;
            ComboBoxAE.TextUpdate += ComboBoxAE_TextUpdate;
            ComboBoxAE.SelectedValueChanged += ComboBoxAE_SelectedValueChanged;
            ComboBoxAE.TextChanged += ComboBoxAE_TextChanged;
            ComboBoxAE.KeyPress += ComboBoxAE_KeyPress;
            // 
            // ComboBoxMessage
            // 
            ComboBoxMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxMessage.FormattingEnabled = true;
            ComboBoxMessage.Location = new Point(46, 41);
            ComboBoxMessage.Name = "ComboBoxMessage";
            ComboBoxMessage.Size = new Size(726, 23);
            ComboBoxMessage.TabIndex = 1;
            ComboBoxMessage.TextUpdate += ComboBoxMessage_TextUpdate;
            ComboBoxMessage.SelectedValueChanged += ComboBoxMessage_SelectedValueChanged;
            ComboBoxMessage.KeyPress += ComboBoxMessage_KeyPress;
            // 
            // LabelAE
            // 
            LabelAE.AutoSize = true;
            LabelAE.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelAE.Location = new Point(12, 14);
            LabelAE.Name = "LabelAE";
            LabelAE.Size = new Size(28, 16);
            LabelAE.TabIndex = 2;
            LabelAE.Text = "AaE";
            // 
            // LabelMessage
            // 
            LabelMessage.AutoSize = true;
            LabelMessage.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelMessage.Location = new Point(12, 43);
            LabelMessage.Name = "LabelMessage";
            LabelMessage.Size = new Size(28, 16);
            LabelMessage.TabIndex = 3;
            LabelMessage.Text = "Msg";
            // 
            // LabelAlarmName
            // 
            LabelAlarmName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelAlarmName.AutoSize = true;
            LabelAlarmName.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelAlarmName.Location = new Point(46, 72);
            LabelAlarmName.Name = "LabelAlarmName";
            LabelAlarmName.Size = new Size(42, 16);
            LabelAlarmName.TabIndex = 4;
            LabelAlarmName.Text = "Alarm";
            // 
            // LabelInputTag
            // 
            LabelInputTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelInputTag.AutoSize = true;
            LabelInputTag.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelInputTag.Location = new Point(46, 101);
            LabelInputTag.Name = "LabelInputTag";
            LabelInputTag.Size = new Size(42, 16);
            LabelInputTag.TabIndex = 5;
            LabelInputTag.Text = "Input";
            // 
            // LabelAckTag
            // 
            LabelAckTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelAckTag.AutoSize = true;
            LabelAckTag.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelAckTag.Location = new Point(46, 130);
            LabelAckTag.Name = "LabelAckTag";
            LabelAckTag.Size = new Size(42, 16);
            LabelAckTag.TabIndex = 6;
            LabelAckTag.Text = "Ackn.";
            // 
            // TextBoxAlarmName
            // 
            TextBoxAlarmName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxAlarmName.Location = new Point(94, 70);
            TextBoxAlarmName.Name = "TextBoxAlarmName";
            TextBoxAlarmName.ReadOnly = true;
            TextBoxAlarmName.Size = new Size(678, 23);
            TextBoxAlarmName.TabIndex = 7;
            // 
            // TextBoxInputTag
            // 
            TextBoxInputTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxInputTag.Location = new Point(94, 99);
            TextBoxInputTag.Name = "TextBoxInputTag";
            TextBoxInputTag.ReadOnly = true;
            TextBoxInputTag.Size = new Size(678, 23);
            TextBoxInputTag.TabIndex = 8;
            // 
            // TextBoxAckTag
            // 
            TextBoxAckTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxAckTag.Location = new Point(94, 128);
            TextBoxAckTag.Name = "TextBoxAckTag";
            TextBoxAckTag.ReadOnly = true;
            TextBoxAckTag.Size = new Size(678, 23);
            TextBoxAckTag.TabIndex = 9;
            // 
            // FormAlarmInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 161);
            Controls.Add(TextBoxAckTag);
            Controls.Add(TextBoxInputTag);
            Controls.Add(TextBoxAlarmName);
            Controls.Add(LabelAckTag);
            Controls.Add(LabelInputTag);
            Controls.Add(LabelAlarmName);
            Controls.Add(LabelMessage);
            Controls.Add(LabelAE);
            Controls.Add(ComboBoxMessage);
            Controls.Add(ComboBoxAE);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 200);
            Name = "FormAlarmInfo";
            Text = "AlarmInfo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ComboBoxAE;
        private ComboBox ComboBoxMessage;
        private Label LabelAE;
        private Label LabelMessage;
        private Label LabelAlarmName;
        private Label LabelInputTag;
        private Label LabelAckTag;
        private TextBox TextBoxAlarmName;
        private TextBox TextBoxInputTag;
        private TextBox TextBoxAckTag;
    }
}
