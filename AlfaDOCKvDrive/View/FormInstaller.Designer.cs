namespace AlfaDOCKvDrive.View
{
    partial class FormInstaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstaller));
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtCompPassword = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtCompId = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInstall
            // 
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall.ForeColor = System.Drawing.SystemColors.Window;
            this.btnInstall.Location = new System.Drawing.Point(231, 255);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(121, 23);
            this.btnInstall.TabIndex = 24;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClose.Location = new System.Drawing.Point(416, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 23);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "✖";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Location = new System.Drawing.Point(358, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 31);
            this.label3.TabIndex = 20;
            this.label3.Text = "vDrive";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInstaller_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pictureBox1.BackgroundImage = global::AlfaDOCKvDrive.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(13, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 29);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInstaller_MouseDown);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(1, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(442, 44);
            this.label6.TabIndex = 19;
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInstaller_MouseDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 46);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(444, 2);
            this.progressBar1.TabIndex = 28;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTitle.Location = new System.Drawing.Point(18, 88);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(398, 28);
            this.lblTitle.TabIndex = 29;
            this.lblTitle.Text = "Welcome To AlfaDOCK vDrive Setup";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInstaller_MouseDown);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.SystemColors.Window;
            this.lblState.Location = new System.Drawing.Point(10, 60);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(38, 13);
            this.lblState.TabIndex = 30;
            this.lblState.Text = "Ready";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblState.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInstaller_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMinimize.Location = new System.Drawing.Point(390, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(26, 23);
            this.btnMinimize.TabIndex = 31;
            this.btnMinimize.Text = "🗕";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DarkKhaki;
            this.label10.ForeColor = System.Drawing.SystemColors.Window;
            this.label10.Location = new System.Drawing.Point(2, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(442, 1);
            this.label10.TabIndex = 32;
            this.label10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInstaller_MouseDown);
            // 
            // btnFinish
            // 
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.ForeColor = System.Drawing.SystemColors.Window;
            this.btnFinish.Location = new System.Drawing.Point(341, 255);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(92, 23);
            this.btnFinish.TabIndex = 24;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnUninstall
            // 
            this.btnUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUninstall.ForeColor = System.Drawing.SystemColors.Window;
            this.btnUninstall.Location = new System.Drawing.Point(23, 255);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(102, 23);
            this.btnUninstall.TabIndex = 24;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(226, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(226, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "User ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(9, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Comp. ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(226, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Comp. Name";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserPassword.Location = new System.Drawing.Point(295, 75);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(130, 20);
            this.txtUserPassword.TabIndex = 33;
            this.txtUserPassword.UseSystemPasswordChar = true;
            // 
            // txtCompPassword
            // 
            this.txtCompPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompPassword.Location = new System.Drawing.Point(80, 75);
            this.txtCompPassword.Name = "txtCompPassword";
            this.txtCompPassword.Size = new System.Drawing.Size(130, 20);
            this.txtCompPassword.TabIndex = 36;
            this.txtCompPassword.UseSystemPasswordChar = true;
            // 
            // txtUserId
            // 
            this.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserId.Location = new System.Drawing.Point(295, 49);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(130, 20);
            this.txtUserId.TabIndex = 34;
            this.txtUserId.Text = "687";
            // 
            // txtCompId
            // 
            this.txtCompId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompId.Location = new System.Drawing.Point(80, 49);
            this.txtCompId.Name = "txtCompId";
            this.txtCompId.Size = new System.Drawing.Size(130, 20);
            this.txtCompId.TabIndex = 37;
            this.txtCompId.Text = "279";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(295, 23);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(130, 20);
            this.txtUserName.TabIndex = 35;
            this.txtUserName.Text = "admin";
            // 
            // txtCompName
            // 
            this.txtCompName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompName.Location = new System.Drawing.Point(80, 23);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(130, 20);
            this.txtCompName.TabIndex = 38;
            this.txtCompName.Text = "alfadrive";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DarkKhaki;
            this.label9.ForeColor = System.Drawing.SystemColors.Window;
            this.label9.Location = new System.Drawing.Point(218, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1, 75);
            this.label9.TabIndex = 43;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label8);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.label7);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.txtUserPassword);
            this.groupBox.Controls.Add(this.txtCompPassword);
            this.groupBox.Controls.Add(this.txtUserId);
            this.groupBox.Controls.Add(this.txtCompId);
            this.groupBox.Controls.Add(this.txtUserName);
            this.groupBox.Controls.Add(this.txtCompName);
            this.groupBox.Controls.Add(this.label9);
            this.groupBox.Location = new System.Drawing.Point(6, 124);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(433, 108);
            this.groupBox.TabIndex = 46;
            this.groupBox.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNext.Location = new System.Drawing.Point(250, 255);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(102, 23);
            this.btnNext.TabIndex = 24;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // FormInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(445, 290);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFinish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInstaller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlfaDOCK vDrive Setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInstaller_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInstaller_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtCompPassword;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtCompId;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtCompName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnNext;
    }
}