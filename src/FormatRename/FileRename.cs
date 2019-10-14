using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FormattedRename
{
    /// <summary>
    /// 文件重命名。
    /// 格式：文件名 v1.0_20190528_曾子凌
    /// </summary>
    public class FileRename
    {
        Regex regex = new Regex(@"(?<filename>[\S\s]+?)\s(?<version>[vV]\d+\.\d+)_(?<date>\d{8})_(?<username>\S+)");

        public void Rename(RenameParameter parameter)
        {
            if (!File.Exists(parameter.FilePath)) return;

            string newFileName = string.Empty;
            string fileName = Path.GetFileNameWithoutExtension(parameter.FilePath);

            Match match = regex.Match(fileName);
            if (match != null && match.Success)
            {
                newFileName = $"{match.Groups["filename"].Value} {IncreaseVersion(match.Groups["version"].Value)}_{DateTime.Now.ToString("yyyyMMdd")}_{match.Groups["username"].Value}{Path.GetExtension(parameter.FilePath)}";
            }
            else
            {
                newFileName = $"{fileName} v1.0_{DateTime.Now.ToString("yyyyMMdd")}_{parameter.UserName}{Path.GetExtension(parameter.FilePath)}";
            }

            string newFilePath = Path.Combine(Path.GetDirectoryName(parameter.FilePath), newFileName);
            File.Move(parameter.FilePath, newFilePath);
        }

        /// <summary>
        /// 递增版本号
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        private string IncreaseVersion(string version)
        {
            string[] parts = version.Split('.');
            return $"{parts[0]}.{Convert.ToInt16(parts[1]) + 1}";
        }
    }
}
