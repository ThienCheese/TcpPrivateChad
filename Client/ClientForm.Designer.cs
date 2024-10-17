namespace Client
{
    partial class ClientForm
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
            textBoxLog = new RichTextBox();
            button1 = new Button();
            textBoxMessage = new RichTextBox();
            button3 = new Button();
            textBoxUsername = new TextBox();
            textBoxRecipient = new TextBox();
            SuspendLayout();
            // 
            // textBoxLog
            // 
            textBoxLog.Location = new Point(12, 104);
            textBoxLog.Name = "textBoxLog";
            textBoxLog.Size = new Size(620, 226);
            textBoxLog.TabIndex = 0;
            textBoxLog.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(667, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonConnect_Click;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(12, 365);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(620, 57);
            textBoxMessage.TabIndex = 2;
            textBoxMessage.Text = "";
            // 
            // button3
            // 
            button3.Location = new Point(667, 365);
            button3.Name = "button3";
            button3.Size = new Size(111, 50);
            button3.TabIndex = 1;
            button3.Text = "Send";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonSend_Click;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(12, 12);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.PlaceholderText = "Enter your username";
            textBoxUsername.Size = new Size(355, 27);
            textBoxUsername.TabIndex = 3;
            // 
            // textBoxRecipient
            // 
            textBoxRecipient.Location = new Point(12, 55);
            textBoxRecipient.Name = "textBoxRecipient";
            textBoxRecipient.PlaceholderText = "Enter your friend username";
            textBoxRecipient.Size = new Size(355, 27);
            textBoxRecipient.TabIndex = 3;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxRecipient);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxMessage);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(textBoxLog);
            Name = "ClientForm";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox textBoxLog;
        private Button button1;
        private RichTextBox textBoxMessage;
        private Button button3;
        private TextBox textBoxUsername;
        private TextBox textBoxRecipient;
    }
}
