namespace FindModuleUSR
{
    partial class FrmFindDeviceUSR
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
            this.grpSearcModules = new System.Windows.Forms.GroupBox();
            this.btnSearch_TCP232 = new System.Windows.Forms.Button();
            this.btnSearch_AllDevices = new System.Windows.Forms.Button();
            this.lstListDevices = new System.Windows.Forms.ListView();
            this.colDeviceIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabHexStream = new System.Windows.Forms.TabPage();
            this.txtHexStream = new System.Windows.Forms.TextBox();
            this.tabOperationLog = new System.Windows.Forms.TabPage();
            this.txtOperationLog = new System.Windows.Forms.TextBox();
            this.tabControlReport = new System.Windows.Forms.TabControl();
            this.btnClientUDP = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnServerUDP = new System.Windows.Forms.Button();
            this.grpSearcModules.SuspendLayout();
            this.tabHexStream.SuspendLayout();
            this.tabOperationLog.SuspendLayout();
            this.tabControlReport.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSearcModules
            // 
            this.grpSearcModules.Controls.Add(this.btnSearch_TCP232);
            this.grpSearcModules.Controls.Add(this.btnSearch_AllDevices);
            this.grpSearcModules.Controls.Add(this.lstListDevices);
            this.grpSearcModules.Location = new System.Drawing.Point(12, 12);
            this.grpSearcModules.Name = "grpSearcModules";
            this.grpSearcModules.Size = new System.Drawing.Size(549, 242);
            this.grpSearcModules.TabIndex = 17;
            this.grpSearcModules.TabStop = false;
            this.grpSearcModules.Text = "Search List";
            // 
            // btnSearch_TCP232
            // 
            this.btnSearch_TCP232.Location = new System.Drawing.Point(208, 197);
            this.btnSearch_TCP232.Name = "btnSearch_TCP232";
            this.btnSearch_TCP232.Size = new System.Drawing.Size(337, 42);
            this.btnSearch_TCP232.TabIndex = 12;
            this.btnSearch_TCP232.Text = "Search Devices TCP232";
            this.btnSearch_TCP232.UseVisualStyleBackColor = true;
            this.btnSearch_TCP232.Click += new System.EventHandler(this.btnSearch_TCP232_Click);
            // 
            // btnSearch_AllDevices
            // 
            this.btnSearch_AllDevices.Location = new System.Drawing.Point(3, 197);
            this.btnSearch_AllDevices.Name = "btnSearch_AllDevices";
            this.btnSearch_AllDevices.Size = new System.Drawing.Size(199, 42);
            this.btnSearch_AllDevices.TabIndex = 12;
            this.btnSearch_AllDevices.Text = "Search All Devices in LAN";
            this.btnSearch_AllDevices.UseVisualStyleBackColor = true;
            this.btnSearch_AllDevices.Click += new System.EventHandler(this.btnSearch_AllDevices_Click);
            // 
            // lstListDevices
            // 
            this.lstListDevices.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstListDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstListDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDeviceIP,
            this.colDeviceName,
            this.colMAC,
            this.colVersion});
            this.lstListDevices.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstListDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstListDevices.FullRowSelect = true;
            this.lstListDevices.GridLines = true;
            this.lstListDevices.Location = new System.Drawing.Point(3, 16);
            this.lstListDevices.MultiSelect = false;
            this.lstListDevices.Name = "lstListDevices";
            this.lstListDevices.Size = new System.Drawing.Size(543, 175);
            this.lstListDevices.TabIndex = 11;
            this.lstListDevices.TileSize = new System.Drawing.Size(168, 30);
            this.lstListDevices.UseCompatibleStateImageBehavior = false;
            this.lstListDevices.View = System.Windows.Forms.View.Details;
            // 
            // colDeviceIP
            // 
            this.colDeviceIP.Text = "Device IP";
            this.colDeviceIP.Width = 100;
            // 
            // colDeviceName
            // 
            this.colDeviceName.Text = "Device Name";
            this.colDeviceName.Width = 170;
            // 
            // colMAC
            // 
            this.colMAC.Text = "MAC";
            this.colMAC.Width = 170;
            // 
            // colVersion
            // 
            this.colVersion.Text = "Version";
            this.colVersion.Width = 70;
            // 
            // tabHexStream
            // 
            this.tabHexStream.BackColor = System.Drawing.SystemColors.Control;
            this.tabHexStream.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabHexStream.Controls.Add(this.txtHexStream);
            this.tabHexStream.Location = new System.Drawing.Point(4, 4);
            this.tabHexStream.Name = "tabHexStream";
            this.tabHexStream.Padding = new System.Windows.Forms.Padding(3);
            this.tabHexStream.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabHexStream.Size = new System.Drawing.Size(541, 287);
            this.tabHexStream.TabIndex = 1;
            this.tabHexStream.Text = "                                  Hex Stream                            ";
            // 
            // txtHexStream
            // 
            this.txtHexStream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHexStream.Location = new System.Drawing.Point(3, 3);
            this.txtHexStream.Multiline = true;
            this.txtHexStream.Name = "txtHexStream";
            this.txtHexStream.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtHexStream.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHexStream.Size = new System.Drawing.Size(533, 279);
            this.txtHexStream.TabIndex = 0;
            // 
            // tabOperationLog
            // 
            this.tabOperationLog.BackColor = System.Drawing.SystemColors.Control;
            this.tabOperationLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabOperationLog.Controls.Add(this.txtOperationLog);
            this.tabOperationLog.Location = new System.Drawing.Point(4, 4);
            this.tabOperationLog.Name = "tabOperationLog";
            this.tabOperationLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperationLog.Size = new System.Drawing.Size(541, 287);
            this.tabOperationLog.TabIndex = 0;
            this.tabOperationLog.Text = "                            Operation Log                             ";
            // 
            // txtOperationLog
            // 
            this.txtOperationLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOperationLog.Location = new System.Drawing.Point(3, 3);
            this.txtOperationLog.Multiline = true;
            this.txtOperationLog.Name = "txtOperationLog";
            this.txtOperationLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOperationLog.Size = new System.Drawing.Size(533, 279);
            this.txtOperationLog.TabIndex = 1;
            // 
            // tabControlReport
            // 
            this.tabControlReport.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlReport.Controls.Add(this.tabOperationLog);
            this.tabControlReport.Controls.Add(this.tabHexStream);
            this.tabControlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlReport.ItemSize = new System.Drawing.Size(79, 25);
            this.tabControlReport.Location = new System.Drawing.Point(0, 0);
            this.tabControlReport.Name = "tabControlReport";
            this.tabControlReport.SelectedIndex = 0;
            this.tabControlReport.Size = new System.Drawing.Size(549, 320);
            this.tabControlReport.TabIndex = 18;
            // 
            // btnClientUDP
            // 
            this.btnClientUDP.Location = new System.Drawing.Point(12, 583);
            this.btnClientUDP.Name = "btnClientUDP";
            this.btnClientUDP.Size = new System.Drawing.Size(549, 40);
            this.btnClientUDP.TabIndex = 19;
            this.btnClientUDP.Text = "Client UDP";
            this.btnClientUDP.UseVisualStyleBackColor = true;
            this.btnClientUDP.Click += new System.EventHandler(this.btnClientUDP_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControlReport);
            this.panel1.Location = new System.Drawing.Point(12, 257);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 320);
            this.panel1.TabIndex = 20;
            // 
            // btnServerUDP
            // 
            this.btnServerUDP.Location = new System.Drawing.Point(12, 629);
            this.btnServerUDP.Name = "btnServerUDP";
            this.btnServerUDP.Size = new System.Drawing.Size(549, 40);
            this.btnServerUDP.TabIndex = 19;
            this.btnServerUDP.Text = "Server UDP";
            this.btnServerUDP.UseVisualStyleBackColor = true;
            this.btnServerUDP.Click += new System.EventHandler(this.btnServerUDP_Click);
            // 
            // FrmFindDeviceUSR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 682);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnServerUDP);
            this.Controls.Add(this.btnClientUDP);
            this.Controls.Add(this.grpSearcModules);
            this.Name = "FrmFindDeviceUSR";
            this.Text = "Localizador de Dispositivos USR na LAN";
            this.grpSearcModules.ResumeLayout(false);
            this.tabHexStream.ResumeLayout(false);
            this.tabHexStream.PerformLayout();
            this.tabOperationLog.ResumeLayout(false);
            this.tabOperationLog.PerformLayout();
            this.tabControlReport.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearcModules;
        private System.Windows.Forms.ListView lstListDevices;
        private System.Windows.Forms.ColumnHeader colDeviceIP;
        private System.Windows.Forms.ColumnHeader colDeviceName;
        private System.Windows.Forms.ColumnHeader colMAC;
        private System.Windows.Forms.ColumnHeader colVersion;
        private System.Windows.Forms.Button btnSearch_AllDevices;
        private System.Windows.Forms.TabPage tabHexStream;
        private System.Windows.Forms.TabPage tabOperationLog;
        private System.Windows.Forms.TabControl tabControlReport;
        private System.Windows.Forms.TextBox txtHexStream;
        private System.Windows.Forms.TextBox txtOperationLog;
        private System.Windows.Forms.Button btnClientUDP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch_TCP232;
        private System.Windows.Forms.Button btnServerUDP;
    }
}