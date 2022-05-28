using System.Windows.Forms;

namespace WCDPatcher.Core.Validation
{
    public static class ErrorDialogs
    {
        public static DialogResult FileNotFoundBox(string filepath, MessageBoxButtons buttons, bool Severe,string extraInfoOrQuestion="")
        {
            return MessageBox.Show("选中的文件 '" + filepath + "' 无法被找到\n" +
                "请确认该文件存在并重试" + (extraInfoOrQuestion == "" ? "" : "\n\n" + extraInfoOrQuestion)
                , "文件不存在", buttons, (Severe ? MessageBoxIcon.Error : MessageBoxIcon.Exclamation));
        }

        public static DialogResult WonderCardIsInvalid(string filepath, MessageBoxButtons buttons, bool Severe, string extraInfoOrQuestion)
        {
            return MessageBox.Show("选中的神秘卡片文件 '" + filepath + "' 不符合神秘卡片标准格式，这可能是无效的神秘卡片文件\n" +
                "请确认该文件是神秘卡片文件并重试" + (extraInfoOrQuestion == "" ? "" : "\n\n" + extraInfoOrQuestion)
                , "神秘卡片验证失败", buttons, (Severe ? MessageBoxIcon.Error : MessageBoxIcon.Exclamation));
        }

        public static DialogResult NDSFileIsInvalid(string Filepath, MessageBoxButtons buttons, bool Severe, string extraInfoOrQuestion)
        {
            return MessageBox.Show("选中的文件 '" + Filepath + "' 不是一个合法的NDS ROM\n" +
                "请确认该文件是个NDS ROM并重试" + (extraInfoOrQuestion == "" ? "" : "\n\n" + extraInfoOrQuestion)
                , "NDS ROM无效", buttons, (Severe ? MessageBoxIcon.Error : MessageBoxIcon.Exclamation));
        }
    }
}
