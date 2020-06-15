﻿using FormatRename.Formaters;
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
            if (!File.Exists(parameter.FilePath)) return;

            string fileName = Path.GetFileNameWithoutExtension(parameter.FilePath);

            string formated = this.formater.Format(fileName, parameter.UserName);

            string newFilePath = Path.Combine(Path.GetDirectoryName(parameter.FilePath), $"{formated}{Path.GetExtension(parameter.FilePath)}");

            File.Move(parameter.FilePath, newFilePath);
        }
    }
}
