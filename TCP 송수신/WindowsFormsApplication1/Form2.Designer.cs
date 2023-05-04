namespace WindowsFormsApplication1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.txtMessage = new MetroFramework.Controls.MetroTextBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.txtPort = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.txtIp = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(480, 384);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(177, 23);
            this.metroButton2.TabIndex = 15;
            this.metroButton2.Text = "Send";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMessage.Location = new System.Drawing.Point(45, 384);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(389, 23);
            this.txtMessage.TabIndex = 14;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(45, 158);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(628, 189);
            this.richTextBox.TabIndex = 13;
            this.richTextBox.Text = "";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(322, 115);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(112, 23);
            this.txtPort.TabIndex = 12;
            this.txtPort.Text = "5000";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(480, 82);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(193, 56);
            this.metroButton1.TabIndex = 10;
            this.metroButton1.Text = "Connect";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(45, 115);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(225, 23);
            this.txtIp.TabIndex = 11;
            this.txtIp.Text = "118.32.222.122";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(322, 82);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(34, 20);
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "Port";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(45, 82);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(74, 20);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "IP Address";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 451);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Form2";
            this.Text = "TCP/IP Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroTextBox txtMessage;
        private System.Windows.Forms.RichTextBox richTextBox;
        private MetroFramework.Controls.MetroTextBox txtPort;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox txtIp;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;

    }
}