namespace NodNetworkHelper
{
	public partial class ConfigForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) { components.Dispose(); }
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmbConfiguration = new System.Windows.Forms.ComboBox();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblConfigurationName = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtWifiAssociated = new System.Windows.Forms.TextBox();
			this.lblWifiNetworkAssociated = new System.Windows.Forms.Label();
			this.txtDNS2 = new System.Windows.Forms.TextBox();
			this.txtDNS1 = new System.Windows.Forms.TextBox();
			this.txtGateway = new System.Windows.Forms.TextBox();
			this.txtSubnetMask = new System.Windows.Forms.TextBox();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.grpIEProxy = new System.Windows.Forms.GroupBox();
			this.grpProxy = new System.Windows.Forms.GroupBox();
			this.chkByPassForLocal = new System.Windows.Forms.CheckBox();
			this.txtProxy = new System.Windows.Forms.TextBox();
			this.lblProxy = new System.Windows.Forms.Label();
			this.chkUseProxy = new System.Windows.Forms.CheckBox();
			this.lblSecondaryDNS = new System.Windows.Forms.Label();
			this.chkDHCP = new System.Windows.Forms.CheckBox();
			this.lblPrimaryDNS = new System.Windows.Forms.Label();
			this.lblGateway = new System.Windows.Forms.Label();
			this.lblSubnet = new System.Windows.Forms.Label();
			this.lblIP = new System.Windows.Forms.Label();
			this.lblNetworkAdapter = new System.Windows.Forms.Label();
			this.cmbNetworkAdapter = new System.Windows.Forms.ComboBox();
			this.btnUndo = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.txtConfigAlias = new System.Windows.Forms.TextBox();
			this.lblConfiguration = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpIEProxy.SuspendLayout();
			this.grpProxy.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbConfiguration
			// 
			this.cmbConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbConfiguration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbConfiguration.FormattingEnabled = true;
			this.cmbConfiguration.Location = new System.Drawing.Point(99, 14);
			this.cmbConfiguration.Name = "cmbConfiguration";
			this.cmbConfiguration.Size = new System.Drawing.Size(440, 23);
			this.cmbConfiguration.TabIndex = 0;
			this.cmbConfiguration.SelectedIndexChanged += new System.EventHandler(this.CmbConfigurationSelectedIndexChanged);
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnNew.FlatAppearance.BorderSize = 0;
			this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNew.Image = global::NodNetworkHelper.NodNetworkHelperResources.Hand_Add24;
			this.btnNew.Location = new System.Drawing.Point(542, 10);
			this.btnNew.Margin = new System.Windows.Forms.Padding(0);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(29, 29);
			this.btnNew.TabIndex = 1;
			this.btnNew.Tag = "\\TEste";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.BtnNewClick);
			// 
			// btnDel
			// 
			this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDel.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnDel.FlatAppearance.BorderSize = 0;
			this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDel.Image = global::NodNetworkHelper.NodNetworkHelperResources.Hand_Del24;
			this.btnDel.Location = new System.Drawing.Point(571, 10);
			this.btnDel.Margin = new System.Windows.Forms.Padding(0);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(29, 29);
			this.btnDel.TabIndex = 2;
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.BtnDelClick);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblConfigurationName);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.btnUndo);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.txtConfigAlias);
			this.panel1.Location = new System.Drawing.Point(12, 45);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(588, 345);
			this.panel1.TabIndex = 3;
			// 
			// lblConfigurationName
			// 
			this.lblConfigurationName.AutoSize = true;
			this.lblConfigurationName.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConfigurationName.Location = new System.Drawing.Point(3, 12);
			this.lblConfigurationName.Name = "lblConfigurationName";
			this.lblConfigurationName.Size = new System.Drawing.Size(36, 15);
			this.lblConfigurationName.TabIndex = 6;
			this.lblConfigurationName.Text = "Alias:";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.txtWifiAssociated);
			this.groupBox1.Controls.Add(this.lblWifiNetworkAssociated);
			this.groupBox1.Controls.Add(this.txtDNS2);
			this.groupBox1.Controls.Add(this.txtDNS1);
			this.groupBox1.Controls.Add(this.txtGateway);
			this.groupBox1.Controls.Add(this.txtSubnetMask);
			this.groupBox1.Controls.Add(this.txtIP);
			this.groupBox1.Controls.Add(this.grpIEProxy);
			this.groupBox1.Controls.Add(this.lblSecondaryDNS);
			this.groupBox1.Controls.Add(this.chkDHCP);
			this.groupBox1.Controls.Add(this.lblPrimaryDNS);
			this.groupBox1.Controls.Add(this.lblGateway);
			this.groupBox1.Controls.Add(this.lblSubnet);
			this.groupBox1.Controls.Add(this.lblIP);
			this.groupBox1.Controls.Add(this.lblNetworkAdapter);
			this.groupBox1.Controls.Add(this.cmbNetworkAdapter);
			this.groupBox1.Location = new System.Drawing.Point(6, 39);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(574, 296);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Configuration Details";
			// 
			// txtWifiAssociated
			// 
			this.txtWifiAssociated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtWifiAssociated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtWifiAssociated.Location = new System.Drawing.Point(277, 263);
			this.txtWifiAssociated.Name = "txtWifiAssociated";
			this.txtWifiAssociated.Size = new System.Drawing.Size(281, 23);
			this.txtWifiAssociated.TabIndex = 22;
			// 
			// lblWifiNetworkAssociated
			// 
			this.lblWifiNetworkAssociated.AutoSize = true;
			this.lblWifiNetworkAssociated.Location = new System.Drawing.Point(7, 267);
			this.lblWifiNetworkAssociated.Name = "lblWifiNetworkAssociated";
			this.lblWifiNetworkAssociated.Size = new System.Drawing.Size(264, 15);
			this.lblWifiNetworkAssociated.TabIndex = 17;
			this.lblWifiNetworkAssociated.Text = "&Wifi Network Associated with this Configuration:";
			// 
			// txtDNS2
			// 
			this.txtDNS2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDNS2.Location = new System.Drawing.Point(399, 76);
			this.txtDNS2.MaxLength = 15;
			this.txtDNS2.Name = "txtDNS2";
			this.txtDNS2.Size = new System.Drawing.Size(120, 23);
			this.txtDNS2.TabIndex = 15;
			this.txtDNS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtDNS1
			// 
			this.txtDNS1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDNS1.Location = new System.Drawing.Point(141, 76);
			this.txtDNS1.MaxLength = 15;
			this.txtDNS1.Name = "txtDNS1";
			this.txtDNS1.Size = new System.Drawing.Size(120, 23);
			this.txtDNS1.TabIndex = 13;
			this.txtDNS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtGateway
			// 
			this.txtGateway.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGateway.Location = new System.Drawing.Point(438, 47);
			this.txtGateway.MaxLength = 15;
			this.txtGateway.Name = "txtGateway";
			this.txtGateway.Size = new System.Drawing.Size(120, 23);
			this.txtGateway.TabIndex = 12;
			this.txtGateway.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtSubnetMask
			// 
			this.txtSubnetMask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSubnetMask.Location = new System.Drawing.Point(240, 47);
			this.txtSubnetMask.MaxLength = 15;
			this.txtSubnetMask.Name = "txtSubnetMask";
			this.txtSubnetMask.Size = new System.Drawing.Size(120, 23);
			this.txtSubnetMask.TabIndex = 11;
			this.txtSubnetMask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtIP
			// 
			this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtIP.Location = new System.Drawing.Point(54, 47);
			this.txtIP.MaxLength = 15;
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(120, 23);
			this.txtIP.TabIndex = 10;
			this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// grpIEProxy
			// 
			this.grpIEProxy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpIEProxy.Controls.Add(this.grpProxy);
			this.grpIEProxy.Controls.Add(this.chkUseProxy);
			this.grpIEProxy.Location = new System.Drawing.Point(10, 119);
			this.grpIEProxy.Name = "grpIEProxy";
			this.grpIEProxy.Size = new System.Drawing.Size(553, 136);
			this.grpIEProxy.TabIndex = 16;
			this.grpIEProxy.TabStop = false;
			this.grpIEProxy.Text = "Internet Explorer Proxy";
			// 
			// grpProxy
			// 
			this.grpProxy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpProxy.Controls.Add(this.chkByPassForLocal);
			this.grpProxy.Controls.Add(this.txtProxy);
			this.grpProxy.Controls.Add(this.lblProxy);
			this.grpProxy.Location = new System.Drawing.Point(6, 48);
			this.grpProxy.Name = "grpProxy";
			this.grpProxy.Size = new System.Drawing.Size(541, 82);
			this.grpProxy.TabIndex = 18;
			this.grpProxy.TabStop = false;
			this.grpProxy.Text = "Proxy";
			// 
			// chkByPassForLocal
			// 
			this.chkByPassForLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkByPassForLocal.Location = new System.Drawing.Point(23, 53);
			this.chkByPassForLocal.Name = "chkByPassForLocal";
			this.chkByPassForLocal.Size = new System.Drawing.Size(152, 20);
			this.chkByPassForLocal.TabIndex = 20;
			this.chkByPassForLocal.Text = "&Bypass for local address";
			// 
			// txtProxy
			// 
			this.txtProxy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtProxy.Location = new System.Drawing.Point(52, 24);
			this.txtProxy.Name = "txtProxy";
			this.txtProxy.Size = new System.Drawing.Size(483, 23);
			this.txtProxy.TabIndex = 19;
			// 
			// lblProxy
			// 
			this.lblProxy.AutoSize = true;
			this.lblProxy.Location = new System.Drawing.Point(6, 26);
			this.lblProxy.Name = "lblProxy";
			this.lblProxy.Size = new System.Drawing.Size(40, 15);
			this.lblProxy.TabIndex = 15;
			this.lblProxy.Text = "Pro&xy:";
			// 
			// chkUseProxy
			// 
			this.chkUseProxy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkUseProxy.Location = new System.Drawing.Point(6, 22);
			this.chkUseProxy.Name = "chkUseProxy";
			this.chkUseProxy.Size = new System.Drawing.Size(80, 20);
			this.chkUseProxy.TabIndex = 17;
			this.chkUseProxy.Text = "&Use Proxy";
			this.chkUseProxy.CheckedChanged += new System.EventHandler(this.ChkUseProxyCheckedChanged);
			// 
			// lblSecondaryDNS
			// 
			this.lblSecondaryDNS.AutoSize = true;
			this.lblSecondaryDNS.Location = new System.Drawing.Point(300, 79);
			this.lblSecondaryDNS.Name = "lblSecondaryDNS";
			this.lblSecondaryDNS.Size = new System.Drawing.Size(93, 15);
			this.lblSecondaryDNS.TabIndex = 27;
			this.lblSecondaryDNS.Text = "Secondary &DNS:";
			// 
			// chkDHCP
			// 
			this.chkDHCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkDHCP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkDHCP.Location = new System.Drawing.Point(433, 21);
			this.chkDHCP.Name = "chkDHCP";
			this.chkDHCP.Size = new System.Drawing.Size(135, 20);
			this.chkDHCP.TabIndex = 9;
			this.chkDHCP.Text = "Obtain IP from &DHCP";
			this.chkDHCP.CheckedChanged += new System.EventHandler(this.ChkDHCPCheckedChanged);
			// 
			// lblPrimaryDNS
			// 
			this.lblPrimaryDNS.AutoSize = true;
			this.lblPrimaryDNS.Location = new System.Drawing.Point(57, 79);
			this.lblPrimaryDNS.Name = "lblPrimaryDNS";
			this.lblPrimaryDNS.Size = new System.Drawing.Size(78, 15);
			this.lblPrimaryDNS.TabIndex = 21;
			this.lblPrimaryDNS.Text = "Primary &DNS:";
			// 
			// lblGateway
			// 
			this.lblGateway.AutoSize = true;
			this.lblGateway.Location = new System.Drawing.Point(374, 50);
			this.lblGateway.Name = "lblGateway";
			this.lblGateway.Size = new System.Drawing.Size(54, 15);
			this.lblGateway.TabIndex = 19;
			this.lblGateway.Text = "&Gateway:";
			// 
			// lblSubnet
			// 
			this.lblSubnet.AutoSize = true;
			this.lblSubnet.Location = new System.Drawing.Point(188, 50);
			this.lblSubnet.Name = "lblSubnet";
			this.lblSubnet.Size = new System.Drawing.Size(46, 15);
			this.lblSubnet.TabIndex = 17;
			this.lblSubnet.Text = "&Subnet:";
			// 
			// lblIP
			// 
			this.lblIP.AutoSize = true;
			this.lblIP.Location = new System.Drawing.Point(26, 50);
			this.lblIP.Name = "lblIP";
			this.lblIP.Size = new System.Drawing.Size(22, 15);
			this.lblIP.TabIndex = 14;
			this.lblIP.Text = "&IP:";
			// 
			// lblNetworkAdapter
			// 
			this.lblNetworkAdapter.AutoSize = true;
			this.lblNetworkAdapter.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNetworkAdapter.Location = new System.Drawing.Point(7, 21);
			this.lblNetworkAdapter.Name = "lblNetworkAdapter";
			this.lblNetworkAdapter.Size = new System.Drawing.Size(98, 15);
			this.lblNetworkAdapter.TabIndex = 1;
			this.lblNetworkAdapter.Text = "Network &Adapter:";
			// 
			// cmbNetworkAdapter
			// 
			this.cmbNetworkAdapter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbNetworkAdapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNetworkAdapter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbNetworkAdapter.FormattingEnabled = true;
			this.cmbNetworkAdapter.Location = new System.Drawing.Point(110, 18);
			this.cmbNetworkAdapter.Name = "cmbNetworkAdapter";
			this.cmbNetworkAdapter.Size = new System.Drawing.Size(317, 23);
			this.cmbNetworkAdapter.TabIndex = 8;
			// 
			// btnUndo
			// 
			this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUndo.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnUndo.FlatAppearance.BorderSize = 0;
			this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUndo.Image = global::NodNetworkHelper.NodNetworkHelperResources.Hand_Refresh24;
			this.btnUndo.Location = new System.Drawing.Point(558, 8);
			this.btnUndo.Margin = new System.Windows.Forms.Padding(0);
			this.btnUndo.Name = "btnUndo";
			this.btnUndo.Size = new System.Drawing.Size(25, 25);
			this.btnUndo.TabIndex = 24;
			this.btnUndo.UseVisualStyleBackColor = true;
			this.btnUndo.Click += new System.EventHandler(this.BtnUndoClick);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnSave.FlatAppearance.BorderSize = 0;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Image = global::NodNetworkHelper.NodNetworkHelperResources.Hand_Save24;
			this.btnSave.Location = new System.Drawing.Point(529, 8);
			this.btnSave.Margin = new System.Windows.Forms.Padding(0);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(25, 25);
			this.btnSave.TabIndex = 23;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// txtConfigAlias
			// 
			this.txtConfigAlias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConfigAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtConfigAlias.Location = new System.Drawing.Point(45, 10);
			this.txtConfigAlias.Name = "txtConfigAlias";
			this.txtConfigAlias.Size = new System.Drawing.Size(481, 23);
			this.txtConfigAlias.TabIndex = 4;
			// 
			// lblConfiguration
			// 
			this.lblConfiguration.AutoSize = true;
			this.lblConfiguration.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConfiguration.Location = new System.Drawing.Point(11, 17);
			this.lblConfiguration.Name = "lblConfiguration";
			this.lblConfiguration.Size = new System.Drawing.Size(84, 16);
			this.lblConfiguration.TabIndex = 2;
			this.lblConfiguration.Text = "Configuration:";
			// 
			// ConfigForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(609, 402);
			this.Controls.Add(this.lblConfiguration);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.cmbConfiguration);
			this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConfigForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "NodNetworkHelper Configuration";
			this.Load += new System.EventHandler(this.ConfigFormLoad);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.grpIEProxy.ResumeLayout(false);
			this.grpProxy.ResumeLayout(false);
			this.grpProxy.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbConfiguration;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtConfigAlias;
		private System.Windows.Forms.Button btnUndo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblNetworkAdapter;
		private System.Windows.Forms.ComboBox cmbNetworkAdapter;
		private System.Windows.Forms.Label lblConfiguration;
		private System.Windows.Forms.Label lblConfigurationName;
		private System.Windows.Forms.CheckBox chkDHCP;
		private System.Windows.Forms.Label lblPrimaryDNS;
		private System.Windows.Forms.Label lblGateway;
		private System.Windows.Forms.Label lblSubnet;
		private System.Windows.Forms.Label lblIP;
		private System.Windows.Forms.Label lblSecondaryDNS;
		private System.Windows.Forms.GroupBox grpIEProxy;
		private System.Windows.Forms.GroupBox grpProxy;
		private System.Windows.Forms.CheckBox chkByPassForLocal;
		private System.Windows.Forms.TextBox txtProxy;
		private System.Windows.Forms.Label lblProxy;
		private System.Windows.Forms.CheckBox chkUseProxy;
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.TextBox txtDNS2;
		private System.Windows.Forms.TextBox txtDNS1;
		private System.Windows.Forms.TextBox txtGateway;
		private System.Windows.Forms.TextBox txtSubnetMask;
		private System.Windows.Forms.TextBox txtWifiAssociated;
		private System.Windows.Forms.Label lblWifiNetworkAssociated;
	}
}