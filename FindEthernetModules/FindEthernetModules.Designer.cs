namespace FindEthernetModules
{
    partial class FindEthernetModules
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
            this.txtMacAddress = new System.Windows.Forms.TextBox();
            this.lblMacAdress = new System.Windows.Forms.Label();
            this.btnArpList = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnSearchMacAddress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMacAddress.Location = new System.Drawing.Point(12, 25);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(154, 26);
            this.txtMacAddress.TabIndex = 0;
            this.txtMacAddress.Text = "e4-6f-13-2d-5f-a8";
            // 
            // lblMacAdress
            // 
            this.lblMacAdress.AutoSize = true;
            this.lblMacAdress.Location = new System.Drawing.Point(12, 9);
            this.lblMacAdress.Name = "lblMacAdress";
            this.lblMacAdress.Size = new System.Drawing.Size(72, 13);
            this.lblMacAdress.TabIndex = 1;
            this.lblMacAdress.Text = "Mac Address:";
            // 
            // btnArpList
            // 
            this.btnArpList.Location = new System.Drawing.Point(539, 9);
            this.btnArpList.Name = "btnArpList";
            this.btnArpList.Size = new System.Drawing.Size(111, 42);
            this.btnArpList.TabIndex = 2;
            this.btnArpList.Text = "Show Full Arp List";
            this.btnArpList.UseVisualStyleBackColor = true;
            this.btnArpList.Click += new System.EventHandler(this.btnArpList_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(12, 63);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(638, 268);
            this.txtResult.TabIndex = 0;
            // 
            // btnSearchMacAddress
            // 
            this.btnSearchMacAddress.Location = new System.Drawing.Point(172, 9);
            this.btnSearchMacAddress.Name = "btnSearchMacAddress";
            this.btnSearchMacAddress.Size = new System.Drawing.Size(99, 42);
            this.btnSearchMacAddress.TabIndex = 2;
            this.btnSearchMacAddress.Text = "Search by Mac Address";
            this.btnSearchMacAddress.UseVisualStyleBackColor = true;
            this.btnSearchMacAddress.Click += new System.EventHandler(this.button1_Click);
            // 
            // FindEthernetModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 343);
            this.Controls.Add(this.btnSearchMacAddress);
            this.Controls.Add(this.btnArpList);
            this.Controls.Add(this.lblMacAdress);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtMacAddress);
            this.Name = "FindEthernetModules";
            this.Text = "Find Ethernet Modules";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMacAddress;
        private System.Windows.Forms.Label lblMacAdress;
        private System.Windows.Forms.Button btnArpList;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnSearchMacAddress;
    }
}

