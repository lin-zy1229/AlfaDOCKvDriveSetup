namespace AlfaDOCKvDrive.View
{
    partial class FormSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCompId = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.txtCompPassword = new System.Windows.Forms.TextBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkSync = new System.Windows.Forms.CheckBox();
            this.lblState = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGotoUninstall = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.Window;
            this.button3.Location = new System.Drawing.Point(356, 255);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Apply";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pictureBox1.BackgroundImage = global::AlfaDOCKvDrive.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(13, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 29);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(15, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Comp. ID";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "vDrive";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(15, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Comp. Name";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(301, 106);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(130, 20);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.Text = "admin";
            // 
            // txtCompName
            // 
            this.txtCompName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompName.Location = new System.Drawing.Point(86, 106);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(130, 20);
            this.txtCompName.TabIndex = 5;
            this.txtCompName.Text = "alfadrive";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClose.Location = new System.Drawing.Point(416, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "✖";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCompId
            // 
            this.txtCompId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompId.Location = new System.Drawing.Point(86, 132);
            this.txtCompId.Name = "txtCompId";
            this.txtCompId.Size = new System.Drawing.Size(130, 20);
            this.txtCompId.TabIndex = 5;
            this.txtCompId.Text = "279";
            // 
            // txtUserId
            // 
            this.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserId.Location = new System.Drawing.Point(301, 132);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(130, 20);
            this.txtUserId.TabIndex = 4;
            this.txtUserId.Text = "687";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(232, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Username";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(232, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "User ID";
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(1, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(443, 44);
            this.label6.TabIndex = 6;
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMinimize.Location = new System.Drawing.Point(390, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(26, 23);
            this.btnMinimize.TabIndex = 11;
            this.btnMinimize.Text = "🗕";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // txtCompPassword
            // 
            this.txtCompPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompPassword.Location = new System.Drawing.Point(86, 158);
            this.txtCompPassword.Name = "txtCompPassword";
            this.txtCompPassword.Size = new System.Drawing.Size(130, 20);
            this.txtCompPassword.TabIndex = 5;
            this.txtCompPassword.UseSystemPasswordChar = true;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserPassword.Location = new System.Drawing.Point(301, 158);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(130, 20);
            this.txtUserPassword.TabIndex = 4;
            this.txtUserPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(15, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Password";
            this.label7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(232, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Password";
            this.label8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DarkKhaki;
            this.label9.ForeColor = System.Drawing.SystemColors.Window;
            this.label9.Location = new System.Drawing.Point(224, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1, 75);
            this.label9.TabIndex = 6;
            this.label9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // chkSync
            // 
            this.chkSync.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSync.FlatAppearance.BorderColor = System.Drawing.Color.Beige;
            this.chkSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSync.ForeColor = System.Drawing.SystemColors.Window;
            this.chkSync.Location = new System.Drawing.Point(18, 255);
            this.chkSync.Name = "chkSync";
            this.chkSync.Size = new System.Drawing.Size(104, 23);
            this.chkSync.TabIndex = 14;
            this.chkSync.Text = "Sync";
            this.chkSync.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSync.UseVisualStyleBackColor = true;
            this.chkSync.CheckedChanged += new System.EventHandler(this.chkSync_CheckedChanged);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.SystemColors.Window;
            this.lblState.Location = new System.Drawing.Point(10, 60);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(38, 13);
            this.lblState.TabIndex = 32;
            this.lblState.Text = "Ready";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 46);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(444, 2);
            this.progressBar1.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DarkKhaki;
            this.label10.ForeColor = System.Drawing.SystemColors.Window;
            this.label10.Location = new System.Drawing.Point(2, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(442, 1);
            this.label10.TabIndex = 6;
            this.label10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // btnGotoUninstall
            // 
            this.btnGotoUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoUninstall.ForeColor = System.Drawing.SystemColors.Window;
            this.btnGotoUninstall.Location = new System.Drawing.Point(18, 220);
            this.btnGotoUninstall.Name = "btnGotoUninstall";
            this.btnGotoUninstall.Size = new System.Drawing.Size(104, 23);
            this.btnGotoUninstall.TabIndex = 11;
            this.btnGotoUninstall.Text = "Go to Uninstall";
            this.btnGotoUninstall.UseVisualStyleBackColor = true;
            this.btnGotoUninstall.Click += new System.EventHandler(this.btnGotoUninstall_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "alfaDOCK vDrive 1.0";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 54);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblVersion.Font = new System.Drawing.Font("Agency FB", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(188, 25);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(27, 17);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "0.01";
            this.lblVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(445, 290);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkSync);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGotoUninstall);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.txtCompPassword);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.txtCompId);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtCompName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSettings_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtCompName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCompId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.TextBox txtCompPassword;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkSync;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGotoUninstall;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblVersion;
    }
}

