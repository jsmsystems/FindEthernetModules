namespace FindModuleUSR
{
    partial class FrmServerUDP
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
            this.chkHex = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkHex
            // 
            this.chkHex.AutoSize = true;
            this.chkHex.Location = new System.Drawing.Point(100, 29);
            this.chkHex.Name = "chkHex";
            this.chkHex.Size = new System.Drawing.Size(45, 17);
            this.chkHex.TabIndex = 17;
            this.chkHex.Text = "Hex";
            this.chkHex.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Local Port";
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalPort.Location = new System.Drawing.Point(15, 25);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(60, 22);
            this.txtLocalPort.TabIndex = 12;
            this.txtLocalPort.Text = "1901";
            // 
            // txtReport
            // 
            this.txtReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReport.Location = new System.Drawing.Point(9, 120);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReport.Size = new System.Drawing.Size(522, 201);
            this.txtReport.TabIndex = 11;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(422, 14);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(106, 47);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(310, 14);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(106, 47);
            this.btnReceive.TabIndex = 18;
            this.btnReceive.Text = "Receive";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(198, 14);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(106, 47);
            this.btnSend.TabIndex = 18;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // FrmServerUDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 333);
            this.Controls.Add(this.chkHex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLocalPort);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnReceive);
            this.Name = "FrmServerUDP";
            this.Text = "FrmServerUDP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkHex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button btnSend;
    }
}