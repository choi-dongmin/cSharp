namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtIp = new MetroFramework.Controls.MetroTextBox();
            this.txtPort = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new MetroFramework.Controls.MetroTextBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(43, 79);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(74, 20);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "IP Address";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(320, 79);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(34, 20);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Port";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(43, 112);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(225, 23);
            this.txtIp.TabIndex = 3;
            this.txtIp.Text = "118.32.222.122";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(320, 112);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(112, 23);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "5000";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(478, 79);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(193, 56);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Connect";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(43, 155);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(628, 189);
            this.richTextBox.TabIndex = 5;
            this.richTextBox.Text = "";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMessage.Location = new System.Drawing.Point(43, 381);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(389, 23);
            this.txtMessage.TabIndex = 6;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(478, 381);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(177, 23);
            this.metroButton2.TabIndex = 7;
            this.metroButton2.Text = "Send";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 447);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Form1";
            this.Text = "TCP/IP Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtIp;
        private MetroFramework.Controls.MetroTextBox txtPort;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.RichTextBox richTextBox;
        private MetroFramework.Controls.MetroTextBox txtMessage;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}

