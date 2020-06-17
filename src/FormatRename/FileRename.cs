using FormatRename.Formaters;
using System;
using System.IO;

namespace FormatRename
{
    /// <summary>
    /// 文件重命名。
    /// 格式：文件名 v1.0_20190528_曾子凌
    /// </summary>
    class FileRename
    {
        public FileRename(IFormater formater)
        {
            this.formater = formater;
        }

        IFormater formater;

        public void Rename(RenameParameter parameter)
        {
            try
            {
                if (!File.Exists(parameter.FilePath)) return;

                string formated = this.formater.Format(parameter);

                string newFilePath = Path.Combine(Path.GetDirectoryName(parameter.FilePath), formated);

                File.Move(parameter.FilePath, newFilePath);
            }
            catch (Exception ex)
            {
                LogHelper.Write(ex.Message);
            }
        }
    }
}
