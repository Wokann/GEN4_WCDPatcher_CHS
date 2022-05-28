#pragma warning disable
namespace WCDPatcher.GUI
{
    /// <summary>
    /// The main UI for Wondercard Patcher
    /// </summary>
    partial class GUI
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
            this.grpFiles = new System.Windows.Forms.GroupBox();
            this.btnBrowseNewRom = new System.Windows.Forms.Button();
            this.btnBrowseWondercard = new System.Windows.Forms.Button();
            this.btnBrowseDistro = new System.Windows.Forms.Button();
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.txtNewRom = new System.Windows.Forms.TextBox();
            this.txtDistro = new System.Windows.Forms.TextBox();
            this.txtWondercard = new System.Windows.Forms.TextBox();
            this.lblWonderCard = new System.Windows.Forms.Label();
            this.lblNewRom = new System.Windows.Forms.Label();
            this.lblDistro = new System.Windows.Forms.Label();
            this.grpDistOptions = new System.Windows.Forms.GroupBox();
            this.btnInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSeed = new System.Windows.Forms.NumericUpDown();
            this.chbEnableSeed = new System.Windows.Forms.CheckBox();
            this.chbNoFriendChange = new System.Windows.Forms.CheckBox();
            this.nudFriendDist = new System.Windows.Forms.NumericUpDown();
            this.lblpdriendDist = new System.Windows.Forms.Label();
            this.cmbVersion = new System.Windows.Forms.ComboBox();
            this.lblpversion = new System.Windows.Forms.Label();
            this.grpRomOptions = new System.Windows.Forms.GroupBox();
            this.txtInternal = new System.Windows.Forms.TextBox();
            this.lblpinternal = new System.Windows.Forms.Label();
            this.chbTrim = new System.Windows.Forms.CheckBox();
            this.lblromdesc = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnMacros = new System.Windows.Forms.Button();
            this.btnPatch = new System.Windows.Forms.Button();
            this.btnBatch = new System.Windows.Forms.Button();
            this.grpFiles.SuspendLayout();
            this.grpDistOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFriendDist)).BeginInit();
            this.grpRomOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFiles
            // 
            this.grpFiles.Controls.Add(this.btnBrowseNewRom);
            this.grpFiles.Controls.Add(this.btnBrowseWondercard);
            this.grpFiles.Controls.Add(this.btnBrowseDistro);
            this.grpFiles.Controls.Add(this.cmbLang);
            this.grpFiles.Controls.Add(this.lblRegion);
            this.grpFiles.Controls.Add(this.txtNewRom);
            this.grpFiles.Controls.Add(this.txtDistro);
            this.grpFiles.Controls.Add(this.txtWondercard);
            this.grpFiles.Controls.Add(this.lblWonderCard);
            this.grpFiles.Controls.Add(this.lblNewRom);
            this.grpFiles.Controls.Add(this.lblDistro);
            this.grpFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFiles.Location = new System.Drawing.Point(12, 11);
            this.grpFiles.Name = "grpFiles";
            this.grpFiles.Size = new System.Drawing.Size(379, 139);
            this.grpFiles.TabIndex = 0;
            this.grpFiles.TabStop = false;
            this.grpFiles.Text = "文件位置";
            // 
            // btnBrowseNewRom
            // 
            this.btnBrowseNewRom.Location = new System.Drawing.Point(340, 81);
            this.btnBrowseNewRom.Name = "btnBrowseNewRom";
            this.btnBrowseNewRom.Size = new System.Drawing.Size(26, 21);
            this.btnBrowseNewRom.TabIndex = 10;
            this.btnBrowseNewRom.Text = "...";
            this.btnBrowseNewRom.UseVisualStyleBackColor = true;
            this.btnBrowseNewRom.Click += new System.EventHandler(this.btnBrowseNewRom_Click);
            // 
            // btnBrowseWondercard
            // 
            this.btnBrowseWondercard.Location = new System.Drawing.Point(340, 54);
            this.btnBrowseWondercard.Name = "btnBrowseWondercard";
            this.btnBrowseWondercard.Size = new System.Drawing.Size(26, 21);
            this.btnBrowseWondercard.TabIndex = 9;
            this.btnBrowseWondercard.Text = "...";
            this.btnBrowseWondercard.UseVisualStyleBackColor = true;
            this.btnBrowseWondercard.Click += new System.EventHandler(this.btnBrowseWondercard_Click);
            // 
            // btnBrowseDistro
            // 
            this.btnBrowseDistro.Location = new System.Drawing.Point(340, 27);
            this.btnBrowseDistro.Name = "btnBrowseDistro";
            this.btnBrowseDistro.Size = new System.Drawing.Size(26, 21);
            this.btnBrowseDistro.TabIndex = 8;
            this.btnBrowseDistro.Text = "...";
            this.btnBrowseDistro.UseVisualStyleBackColor = true;
            this.btnBrowseDistro.Click += new System.EventHandler(this.btnBrowseDistro_Click);
            // 
            // cmbLang
            // 
            this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Items.AddRange(new object[] {
            "英语",
            "德语",
            "法语",
            "意大利语",
            "西班牙语",
            "日语",
            "韩语"});
            this.cmbLang.Location = new System.Drawing.Point(107, 108);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(229, 20);
            this.cmbLang.TabIndex = 7;
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(6, 111);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(29, 12);
            this.lblRegion.TabIndex = 6;
            this.lblRegion.Text = "语种";
            // 
            // txtNewRom
            // 
            this.txtNewRom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNewRom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtNewRom.Location = new System.Drawing.Point(107, 83);
            this.txtNewRom.Name = "txtNewRom";
            this.txtNewRom.Size = new System.Drawing.Size(229, 21);
            this.txtNewRom.TabIndex = 5;
            // 
            // txtDistro
            // 
            this.txtDistro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDistro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtDistro.Location = new System.Drawing.Point(107, 29);
            this.txtDistro.Name = "txtDistro";
            this.txtDistro.Size = new System.Drawing.Size(229, 21);
            this.txtDistro.TabIndex = 4;
            // 
            // txtWondercard
            // 
            this.txtWondercard.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtWondercard.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtWondercard.Location = new System.Drawing.Point(107, 56);
            this.txtWondercard.Name = "txtWondercard";
            this.txtWondercard.Size = new System.Drawing.Size(229, 21);
            this.txtWondercard.TabIndex = 3;
            // 
            // lblWonderCard
            // 
            this.lblWonderCard.AutoSize = true;
            this.lblWonderCard.Location = new System.Drawing.Point(6, 59);
            this.lblWonderCard.Name = "lblWonderCard";
            this.lblWonderCard.Size = new System.Drawing.Size(77, 12);
            this.lblWonderCard.TabIndex = 2;
            this.lblWonderCard.Text = "神秘卡片文件";
            // 
            // lblNewRom
            // 
            this.lblNewRom.AutoSize = true;
            this.lblNewRom.Location = new System.Drawing.Point(6, 86);
            this.lblNewRom.Name = "lblNewRom";
            this.lblNewRom.Size = new System.Drawing.Size(95, 12);
            this.lblNewRom.TabIndex = 1;
            this.lblNewRom.Text = "生成的ROM保存在";
            // 
            // lblDistro
            // 
            this.lblDistro.AutoSize = true;
            this.lblDistro.Location = new System.Drawing.Point(6, 31);
            this.lblDistro.Name = "lblDistro";
            this.lblDistro.Size = new System.Drawing.Size(83, 12);
            this.lblDistro.TabIndex = 0;
            this.lblDistro.Text = "官方配信的ROM";
            // 
            // grpDistOptions
            // 
            this.grpDistOptions.Controls.Add(this.btnInfo);
            this.grpDistOptions.Controls.Add(this.label1);
            this.grpDistOptions.Controls.Add(this.nudSeed);
            this.grpDistOptions.Controls.Add(this.chbEnableSeed);
            this.grpDistOptions.Controls.Add(this.chbNoFriendChange);
            this.grpDistOptions.Controls.Add(this.nudFriendDist);
            this.grpDistOptions.Controls.Add(this.lblpdriendDist);
            this.grpDistOptions.Controls.Add(this.cmbVersion);
            this.grpDistOptions.Controls.Add(this.lblpversion);
            this.grpDistOptions.Location = new System.Drawing.Point(12, 156);
            this.grpDistOptions.Name = "grpDistOptions";
            this.grpDistOptions.Size = new System.Drawing.Size(379, 109);
            this.grpDistOptions.TabIndex = 1;
            this.grpDistOptions.TabStop = false;
            this.grpDistOptions.Text = "配信设置";
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(317, 22);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(50, 21);
            this.btnInfo.TabIndex = 9;
            this.btnInfo.Text = "信息";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "0 = 无变化";
            // 
            // nudSeed
            // 
            this.nudSeed.Enabled = false;
            this.nudSeed.Location = new System.Drawing.Point(140, 74);
            this.nudSeed.Name = "nudSeed";
            this.nudSeed.Size = new System.Drawing.Size(52, 21);
            this.nudSeed.TabIndex = 7;
            // 
            // chbEnableSeed
            // 
            this.chbEnableSeed.AutoSize = true;
            this.chbEnableSeed.Location = new System.Drawing.Point(9, 75);
            this.chbEnableSeed.Name = "chbEnableSeed";
            this.chbEnableSeed.Size = new System.Drawing.Size(96, 16);
            this.chbEnableSeed.TabIndex = 6;
            this.chbEnableSeed.Text = "启用会话种子";
            this.chbEnableSeed.UseVisualStyleBackColor = true;
            this.chbEnableSeed.CheckedChanged += new System.EventHandler(this.chbEnableSeed_CheckedChanged);
            // 
            // chbNoFriendChange
            // 
            this.chbNoFriendChange.AutoSize = true;
            this.chbNoFriendChange.Checked = true;
            this.chbNoFriendChange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbNoFriendChange.Location = new System.Drawing.Point(206, 52);
            this.chbNoFriendChange.Name = "chbNoFriendChange";
            this.chbNoFriendChange.Size = new System.Drawing.Size(60, 16);
            this.chbNoFriendChange.TabIndex = 5;
            this.chbNoFriendChange.Text = "无变化";
            this.chbNoFriendChange.UseVisualStyleBackColor = true;
            this.chbNoFriendChange.CheckedChanged += new System.EventHandler(this.chbNoFriendChange_CheckedChanged);
            // 
            // nudFriendDist
            // 
            this.nudFriendDist.Enabled = false;
            this.nudFriendDist.Location = new System.Drawing.Point(123, 49);
            this.nudFriendDist.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudFriendDist.Name = "nudFriendDist";
            this.nudFriendDist.Size = new System.Drawing.Size(69, 21);
            this.nudFriendDist.TabIndex = 4;
            this.nudFriendDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFriendDist.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // lblpdriendDist
            // 
            this.lblpdriendDist.AutoSize = true;
            this.lblpdriendDist.Location = new System.Drawing.Point(6, 51);
            this.lblpdriendDist.Name = "lblpdriendDist";
            this.lblpdriendDist.Size = new System.Drawing.Size(113, 12);
            this.lblpdriendDist.TabIndex = 3;
            this.lblpdriendDist.Text = "好友再分享次数限制";
            // 
            // cmbVersion
            // 
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.Location = new System.Drawing.Point(84, 23);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(228, 20);
            this.cmbVersion.TabIndex = 1;
            // 
            // lblpversion
            // 
            this.lblpversion.AutoSize = true;
            this.lblpversion.Location = new System.Drawing.Point(6, 26);
            this.lblpversion.Name = "lblpversion";
            this.lblpversion.Size = new System.Drawing.Size(53, 12);
            this.lblpversion.TabIndex = 0;
            this.lblpversion.Text = "游戏版本";
            // 
            // grpRomOptions
            // 
            this.grpRomOptions.Controls.Add(this.txtInternal);
            this.grpRomOptions.Controls.Add(this.lblpinternal);
            this.grpRomOptions.Controls.Add(this.chbTrim);
            this.grpRomOptions.Controls.Add(this.lblromdesc);
            this.grpRomOptions.Controls.Add(this.txtDesc);
            this.grpRomOptions.Location = new System.Drawing.Point(12, 270);
            this.grpRomOptions.Name = "grpRomOptions";
            this.grpRomOptions.Size = new System.Drawing.Size(379, 98);
            this.grpRomOptions.TabIndex = 2;
            this.grpRomOptions.TabStop = false;
            this.grpRomOptions.Text = "ROM设置";
            // 
            // txtInternal
            // 
            this.txtInternal.Location = new System.Drawing.Point(8, 71);
            this.txtInternal.MaxLength = 12;
            this.txtInternal.Name = "txtInternal";
            this.txtInternal.Size = new System.Drawing.Size(142, 21);
            this.txtInternal.TabIndex = 4;
            this.txtInternal.Text = "DEOXYS2008";
            this.txtInternal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInternal.TextChanged += new System.EventHandler(this.txtInternal_TextChanged);
            // 
            // lblpinternal
            // 
            this.lblpinternal.AutoSize = true;
            this.lblpinternal.Location = new System.Drawing.Point(15, 54);
            this.lblpinternal.Name = "lblpinternal";
            this.lblpinternal.Size = new System.Drawing.Size(125, 12);
            this.lblpinternal.TabIndex = 3;
            this.lblpinternal.Text = "内部ROM标识符(10/12)";
            // 
            // chbTrim
            // 
            this.chbTrim.AutoSize = true;
            this.chbTrim.Location = new System.Drawing.Point(8, 18);
            this.chbTrim.Name = "chbTrim";
            this.chbTrim.Size = new System.Drawing.Size(126, 16);
            this.chbTrim.TabIndex = 2;
            this.chbTrim.Text = "压缩裁剪生成的ROM";
            this.chbTrim.UseVisualStyleBackColor = true;
            // 
            // lblromdesc
            // 
            this.lblromdesc.AutoSize = true;
            this.lblromdesc.Location = new System.Drawing.Point(223, 14);
            this.lblromdesc.Name = "lblromdesc";
            this.lblromdesc.Size = new System.Drawing.Size(89, 12);
            this.lblromdesc.TabIndex = 1;
            this.lblromdesc.Text = "ROM描述(0/128)";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(169, 29);
            this.txtDesc.MaxLength = 128;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(188, 63);
            this.txtDesc.TabIndex = 0;
            this.txtDesc.Text = "Deoxys Distribution 2008\r\nNintendo";
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // btnMacros
            // 
            this.btnMacros.Location = new System.Drawing.Point(12, 374);
            this.btnMacros.Name = "btnMacros";
            this.btnMacros.Size = new System.Drawing.Size(75, 21);
            this.btnMacros.TabIndex = 3;
            this.btnMacros.Text = "控制符列表";
            this.btnMacros.UseVisualStyleBackColor = true;
            this.btnMacros.Click += new System.EventHandler(this.btnMacros_Click_1);
            // 
            // btnPatch
            // 
            this.btnPatch.Location = new System.Drawing.Point(290, 374);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(75, 21);
            this.btnPatch.TabIndex = 4;
            this.btnPatch.Text = "打补丁!";
            this.btnPatch.UseVisualStyleBackColor = true;
            this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // btnBatch
            // 
            this.btnBatch.Location = new System.Drawing.Point(184, 374);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(100, 21);
            this.btnBatch.TabIndex = 5;
            this.btnBatch.Text = "批量打补丁";
            this.btnBatch.UseVisualStyleBackColor = true;
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 406);
            this.Controls.Add(this.btnBatch);
            this.Controls.Add(this.btnPatch);
            this.Controls.Add(this.btnMacros);
            this.Controls.Add(this.grpRomOptions);
            this.Controls.Add(this.grpDistOptions);
            this.Controls.Add(this.grpFiles);
            this.Name = "GUI";
            this.Text = "WCDPatcher(汉化者：卧看微尘/Wokann)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUI_FormClosed);
            this.grpFiles.ResumeLayout(false);
            this.grpFiles.PerformLayout();
            this.grpDistOptions.ResumeLayout(false);
            this.grpDistOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFriendDist)).EndInit();
            this.grpRomOptions.ResumeLayout(false);
            this.grpRomOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFiles;
        private System.Windows.Forms.Label lblWonderCard;
        private System.Windows.Forms.Label lblNewRom;
        private System.Windows.Forms.Label lblDistro;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Button btnBrowseDistro;
        private System.Windows.Forms.Button btnBrowseNewRom;
        private System.Windows.Forms.Button btnBrowseWondercard;
        public System.Windows.Forms.TextBox txtNewRom;
        public System.Windows.Forms.TextBox txtDistro;
        public System.Windows.Forms.TextBox txtWondercard;
        public System.Windows.Forms.ComboBox cmbLang;
        private System.Windows.Forms.GroupBox grpDistOptions;
        public System.Windows.Forms.ComboBox cmbVersion;
        private System.Windows.Forms.Label lblpversion;
        private System.Windows.Forms.Label lblpdriendDist;
        private System.Windows.Forms.GroupBox grpRomOptions;
        private System.Windows.Forms.Button btnMacros;
        private System.Windows.Forms.Button btnPatch;
        private System.Windows.Forms.Button btnBatch;
        public System.Windows.Forms.NumericUpDown nudFriendDist;
        public System.Windows.Forms.Label lblromdesc;
        public System.Windows.Forms.CheckBox chbTrim;
        public System.Windows.Forms.Label lblpinternal;
        public System.Windows.Forms.TextBox txtInternal;
        private System.Windows.Forms.CheckBox chbNoFriendChange;
        private System.Windows.Forms.CheckBox chbEnableSeed;
        public System.Windows.Forms.NumericUpDown nudSeed;
        public System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInfo;
    }
}

