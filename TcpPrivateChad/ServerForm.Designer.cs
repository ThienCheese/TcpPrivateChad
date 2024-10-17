namespace TcpPrivateChad
{
    partial class ServerForm
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
            button2 = new Button();
            SuspendLayout();
            // 
            // textBoxLog
            // 
            textBoxLog.Location = new Point(37, 76);
            textBoxLog.Name = "textBoxLog";
            textBoxLog.Size = new Size(632, 320);
            textBoxLog.TabIndex = 0;
            textBoxLog.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(694, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 42);
            button1.TabIndex = 1;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonStart_Click;
            // 
            // button2
            // 
            button2.Location = new Point(694, 76);
            button2.Name = "button2";
            button2.Size = new Size(94, 43);
            button2.TabIndex = 1;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonStop_Click;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBoxLog);
            Name = "ServerForm";
            Text = "Server";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox textBoxLog;
        private Button button1;
        private Button button2;
    }
}
