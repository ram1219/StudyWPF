namespace BogusMqttWinPubApp
{
    partial class MainForm
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBrokerIp = new System.Windows.Forms.TextBox();
            this.BtnConect = new System.Windows.Forms.Button();
            this.RtbLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mqtt Broker IP";
            // 
            // TxtBrokerIp
            // 
            this.TxtBrokerIp.Location = new System.Drawing.Point(147, 118);
            this.TxtBrokerIp.Name = "TxtBrokerIp";
            this.TxtBrokerIp.Size = new System.Drawing.Size(400, 28);
            this.TxtBrokerIp.TabIndex = 1;
            this.TxtBrokerIp.Text = "localhost";
            // 
            // BtnConect
            // 
            this.BtnConect.Location = new System.Drawing.Point(553, 118);
            this.BtnConect.Name = "BtnConect";
            this.BtnConect.Size = new System.Drawing.Size(91, 34);
            this.BtnConect.TabIndex = 2;
            this.BtnConect.Text = "Conect";
            this.BtnConect.UseVisualStyleBackColor = true;
            this.BtnConect.Click += new System.EventHandler(this.BtnConect_Click);
            // 
            // RtbLog
            // 
            this.RtbLog.Location = new System.Drawing.Point(22, 161);
            this.RtbLog.Name = "RtbLog";
            this.RtbLog.Size = new System.Drawing.Size(622, 289);
            this.RtbLog.TabIndex = 3;
            this.RtbLog.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 498);
            this.Controls.Add(this.RtbLog);
            this.Controls.Add(this.BtnConect);
            this.Controls.Add(this.TxtBrokerIp);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "Mqtt Fake Publisher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBrokerIp;
        private System.Windows.Forms.Button BtnConect;
        private System.Windows.Forms.RichTextBox RtbLog;
    }
}

