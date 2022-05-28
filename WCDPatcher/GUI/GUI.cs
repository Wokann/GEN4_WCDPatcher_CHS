using System;
using System.Windows.Forms;
using WCDPatcher.Core.Validation;
using WCDPatcher.Core;



namespace WCDPatcher.GUI
{
    public partial class GUI : Form
    {
        /// <summary>
        /// The main UI for Wondercard Patcher
        /// </summary>
        public GUI()
        {
            InitializeComponent();
            this.Icon = (System.Drawing.Icon)Properties.Resources.ResourceManager.GetObject("irkick");
            lblromdesc.Text = "ROM描述 (" + GetDescCount() + ")";
            Mappings.AddDefaultBindings();
            PopulateInternationalVersions();

            cmbVersion.Text = (string)cmbVersion.Items[0];
            cmbLang.SelectedIndex = 0;




        }

        /// <summary>
        /// Gets a count out of 128 for the description text box length
        /// </summary>
        /// <returns></returns>
        public string GetDescCount()
        {
            return txtDesc.Text.Length.ToString() + "/128";
        }



        /// <summary>
        /// Shows a OpenFileDialog to the user, and lets them select a file
        /// </summary>
        /// <param name="Caption">The text to display at the top of the dialog</param>
        /// <param name="Filter">The OpenFileDialog filter to use</param>
        /// <returns></returns>
        public static string GetUserFile(string Caption, string Filter)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = Caption;
            OFD.Filter = Filter;
            OFD.ShowDialog();
            return OFD.FileName;
        }

        /// <summary>
        /// Allows the user to select a saving location
        /// </summary>
        /// <param name="Caption">The dialog text to display</param>
        /// <param name="Filter">The SaveFileDialog filter to use</param>
        /// <returns></returns>
        public static string SaveUserFile(string Caption, string Filter)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Title = Caption;
            SFD.Filter = Filter;
            SFD.ShowDialog();
            return SFD.FileName;
        }

        private void btnBrowseDistro_Click(object sender, System.EventArgs e)
        {
            txtDistro.Text = GetUserFile("选择配信ROM", "2008代欧奇希斯配信卡带 (*.nds)|*.nds");
            bool distroCheck = Validation.IsValidNDSROM(txtDistro.Text, false, true, true);
            if (!distroCheck) txtDistro.Text = "";
        }










        private void btnBrowseWondercard_Click(object sender, System.EventArgs e)
        {
            txtWondercard.Text = GetUserFile("选择神秘卡片文件", "神秘卡片配信卡(*.pcd)|*.pcd");


        }

        private void btnBrowseNewRom_Click(object sender, System.EventArgs e)
        {
            txtNewRom.Text = SaveUserFile("选择生成ROM的位置", "生成的ROM(*.nds)|*.nds");
        }

        bool verboseValidateFields()
        {
            string final;
            bool activate = false;
            final = "并非所有字段都是有效的\n\n";

            if (txtDesc.Text.Length > 128)
            {
                activate = true;
                final += "ROM描述过长。仅允许最多128个字符(包括return)。\n";
            }

            if (cmbLang.Text == "")
            { cmbLang.Focus(); return false; }

            if (activate)
            {
                MessageBox.Show(final, "无效字段", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }


        }

        //void LoadDataFromLoadedRomAndLoadedWonderCard();
        //{
            //System.IO.FileStream fs = new System.IO.FileStream(txtDistro.Text, System.IO.FileMode.Open);
            //string desc = Batch.get_DESC(fs);
            //string title = Batch.get_TITLE(fs);
           // string
       // }

        private void btnPatch_Click(object sender, System.EventArgs e)
        {


            string lang, distro, wcard, newRom, desc, version, title;
            bool isValidHex, existsAsVersionString, existsAsByteArray,
                changeTitle, trimROM;
            if (txtWondercard.Text == "") return;
            if (txtNewRom.Text == "") return;
            System.Collections.Generic.Dictionary<string, string> macros = new System.Collections.Generic.Dictionary<string, string>();
            BatchProcessing.PopulateMacroList(txtDistro.Text, txtWondercard.Text, ref macros);

            lang = cmbLang.Text;
            distro = BatchProcessing.ConvertMacrosInString(txtDistro.Text, macros);
            wcard = BatchProcessing.ConvertMacrosInString(txtWondercard.Text,macros);
            newRom = BatchProcessing.ConvertMacrosInString(txtNewRom.Text,macros);
            desc = BatchProcessing.ConvertMacrosInString(txtDesc.Text,macros);
            version = cmbVersion.Text;

            changeTitle = (txtInternal.Text.Length != 0);
            trimROM = chbTrim.Checked;
            title = BatchProcessing.ConvertMacrosInString(txtInternal.Text,macros);

            isValidHex = WCDPatcher.Core.IO.ByteTools.IsValidFourWORDHexString(version);
            existsAsVersionString = Mappings.DoesKeyMappingExist(version);

            existsAsByteArray = (isValidHex ? Mappings.DoesByteMappingExist(Core.IO.ByteTools.ConvertHexStringToBytes(version))
                : false);


            bool mcOv = CheckMacroOverflow(false,macros);

            if (mcOv)
            {
                if (MessageBox.Show("强制继续?溢出字段将使用原始的发行字段信息", "确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }

            if (!verboseValidateFields()) return;
            if(!Validation.IsValidNDSROM(txtDistro.Text,false,true,true) && 
                !Validation.IsValidWondercard(txtWondercard.Text,false,true)) return;

            int friendDist = 0;
            if (chbNoFriendChange.Checked) friendDist = -1;
            else { friendDist = (int)nudFriendDist.Value; }

            Core.DistroPatcher.DistroPatcher.PatchDistro(wcard, distro, newRom, lang, version, desc, friendDist, (int)this.nudSeed.Value);

            if (changeTitle) Core.DistroPatcher.NDSUtilities.SetNDSTitle(newRom, title, false);
            Core.DistroPatcher.NDSUtilities.FixAllCRC(newRom);

            if (chbTrim.Checked) Core.DistroPatcher.NDSUtilities.trimRom(newRom);

            if (!System.IO.File.Exists(newRom)) return;
            MessageBox.Show("补丁已完成。生成的ROM已输出" + newRom, "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public bool CheckMacroOverflow(bool silent,System.Collections.Generic.Dictionary<string,string> macros)
        {

            string descWMAC = BatchProcessing.ConvertMacrosInString(txtDesc.Text,macros);
            string intnmWMAC = BatchProcessing.ConvertMacrosInString(txtInternal.Text,macros);

            bool descIsOver = (descWMAC.Length > 128);
            bool intIsOver = (intnmWMAC.Length > 128);

            string finalmessage = "一旦控制符被拓展，一或多个输入的字段就超过了最大长度。\n" +
                "溢出的字段如下\n\n";

            if (descIsOver) finalmessage += "ROM描述字段(" + descWMAC.Length.ToString() + "/128)\n";
            if (intIsOver) finalmessage += "内部ROM识别符(" + intnmWMAC.Length.ToString() + "/12)";

            if (!silent && (descIsOver || intIsOver)) MessageBox.Show(finalmessage, "Field overflow", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return (descIsOver || intIsOver);


        }










        private void btnBatch_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "请选择包含神秘卡片的文件夹(*.pcd)";
            FBD.ShowDialog();
            string path = FBD.SelectedPath;

            if (!System.IO.Directory.Exists(path)) return;

            bool recursive = (MessageBox.Show("搜索所有子目录?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

            BatchProcessing.DoWonderCardFolder(recursive, path, this);
        }

        private void btnMacros_Click(object sender, EventArgs e)
        {
            string macros = "%t = 内部ROM标题（12个字符）\r\n" +
                            "%l = 原始发行语言\r\n" +
                            "%d = 原始ROM描述\r\n" +
                            "%n = 原始ROM名称（描述标题）\r\n" +
                            "%c = 原始ROM公司\r\n" +
                            "%f = 神秘卡片上级菜单名称\r\n" +
                            "%w = 神秘卡片名称（减去扩展）";


            MessageBox.Show(this, "文本控制符,可在除神秘卡片和目标游戏字段之外的所有字段中使用。\n\n" +
                macros, "控制符列表", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MessageBox.Show("是否将控制符复制到剪贴板?", "确认", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Windows.Forms.Clipboard.SetText(macros);
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            lblromdesc.Text = "ROM描述 (" + GetDescCount() + ")";
        }

        public string GetInternalCount()
        {
            return txtInternal.Text.Length + "/12";
        }

        private void txtInternal_TextChanged(object sender, EventArgs e)
        {
            lblpinternal.Text = "内部ROM识别符( " + GetInternalCount() + ")";
        }





        /// <summary>
        /// Populates cmbVersion with all region key
        /// </summary>
        public void PopulateInternationalVersions()
        {
            cmbVersion.Items.Clear();
            string[] keys = Mappings.GetKeys();

            for (int i = 0; i < keys.Length; i++)
            {
                string c = keys[i];
                cmbVersion.Items.Add(c);
            }

        }

        private void btnMacros_Click_1(object sender, EventArgs e)
        {
            btnMacros_Click(this, null);
        }

        private void chbNoFriendChange_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNoFriendChange.Checked) nudFriendDist.Enabled = false;
            if (!chbNoFriendChange.Checked) nudFriendDist.Enabled = true;
        }

        private void chbEnableSeed_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnableSeed.Checked) nudSeed.Enabled = true;
            else { nudSeed.Enabled = false; nudSeed.Value = 0; }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("该选项用于设置您的神秘卡片将用于哪些特定版本的游戏。\n" +
                "仅列表中的值为合法值，值长度为两字节，如0014 或 801D\n" +
                "如欲自定义一组值，请累加下方的值，进行十六进制运算\n\n" +
                "钻石 = 0004\n珍珠 = 0008\n白金 = 0010\n魂银 = 0001\n新进 = 8000\n\n" +
                "例如，想制作仅配信给白金和魂银的神秘礼物，值便是0010+0001=0011。\n\n不对该值进行操作将不会更改原有限制值。"
                , "帮助", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); //todo: make a forms based calulator
        }

        private void GUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }







    }
}
