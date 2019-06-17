namespace FindModuleUSR
{
    partial class FrmClientUDP
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.txtComando = new System.Windows.Forms.TextBox();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkHex = new System.Windows.Forms.CheckBox();
            this.rdIPDestino = new System.Windows.Forms.RadioButton();
            this.rdBroadCast = new System.Windows.Forms.RadioButton();
            this.rdAny = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(425, 65);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(106, 25);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtReport
            // 
            this.txtReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReport.Location = new System.Drawing.Point(12, 118);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReport.Size = new System.Drawing.Size(519, 203);
            this.txtReport.TabIndex = 1;
            // 
            // txtComando
            // 
            this.txtComando.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComando.Location = new System.Drawing.Point(12, 65);
            this.txtComando.Multiline = true;
            this.txtComando.Name = "txtComando";
            this.txtComando.Size = new System.Drawing.Size(407, 47);
            this.txtComando.TabIndex = 4;
            this.txtComando.Text = "FF 01 01 02";
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemotePort.Location = new System.Drawing.Point(262, 28);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.Size = new System.Drawing.Size(60, 22);
            this.txtRemotePort.TabIndex = 1;
            this.txtRemotePort.Text = "1901";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Remote Port";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(425, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(106, 47);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(15, 28);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(143, 22);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "192.168.1.255";
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalPort.Location = new System.Drawing.Point(359, 28);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(60, 22);
            this.txtLocalPort.TabIndex = 2;
            this.txtLocalPort.Text = "1901";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Local Port";
            // 
            // chkHex
            // 
            this.chkHex.AutoSize = true;
            this.chkHex.Location = new System.Drawing.Point(425, 95);
            this.chkHex.Name = "chkHex";
            this.chkHex.Size = new System.Drawing.Size(45, 17);
            this.chkHex.TabIndex = 5;
            this.chkHex.Text = "Hex";
            this.chkHex.UseVisualStyleBackColor = true;
            // 
            // rdIPDestino
            // 
            this.rdIPDestino.AutoSize = true;
            this.rdIPDestino.Checked = true;
            this.rdIPDestino.Location = new System.Drawing.Point(15, 10);
            this.rdIPDestino.Name = "rdIPDestino";
            this.rdIPDestino.Size = new System.Drawing.Size(74, 17);
            this.rdIPDestino.TabIndex = 6;
            this.rdIPDestino.TabStop = true;
            this.rdIPDestino.Text = "IP Destino";
            this.rdIPDestino.UseVisualStyleBackColor = true;
            this.rdIPDestino.CheckedChanged += new System.EventHandler(this.rdIPDestino_CheckedChanged);
            // 
            // rdBroadCast
            // 
            this.rdBroadCast.AutoSize = true;
            this.rdBroadCast.Location = new System.Drawing.Point(168, 12);
            this.rdBroadCast.Name = "rdBroadCast";
            this.rdBroadCast.Size = new System.Drawing.Size(74, 17);
            this.rdBroadCast.TabIndex = 7;
            this.rdBroadCast.TabStop = true;
            this.rdBroadCast.Text = "BroadCast";
            this.rdBroadCast.UseVisualStyleBackColor = true;
            // 
            // rdAny
            // 
            this.rdAny.AutoSize = true;
            this.rdAny.Location = new System.Drawing.Point(168, 33);
            this.rdAny.Name = "rdAny";
            this.rdAny.Size = new System.Drawing.Size(43, 17);
            this.rdAny.TabIndex = 8;
            this.rdAny.TabStop = true;
            this.rdAny.Text = "Any";
            this.rdAny.UseVisualStyleBackColor = true;
            // 
            // FrmClientUDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 333);
            this.Controls.Add(this.rdAny);
            this.Controls.Add(this.rdBroadCast);
            this.Controls.Add(this.rdIPDestino);
            this.Controls.Add(this.chkHex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocalPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtRemotePort);
            this.Controls.Add(this.txtComando);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Name = "FrmClientUDP";
            this.Text = "Client UDP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.TextBox txtComando;
        private System.Windows.Forms.TextBox txtRemotePort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkHex;
        private System.Windows.Forms.RadioButton rdIPDestino;
        private System.Windows.Forms.RadioButton rdBroadCast;
        private System.Windows.Forms.RadioButton rdAny;
    }
}

