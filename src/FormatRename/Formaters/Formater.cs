using FormatRename.Formaters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FormatRename.Formaters
{
    class Formater : IFormater
    {
        Regex regexVersion = new Regex(@"[vV](?<version>\d+\.\d+)");
        Regex regexDate = new Regex(@"_(?<date>20\d{2}[10][0-9][0-3][0-9])");

        /// <summary>
        /// 格式化重命名
        /// </summary>
        /// <param name="renameParameter"></param>
        /// <returns></returns>
        public string Format(RenameParameter parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter.FilePath))
                return parameter.FilePath;

            string fileName = Path.GetFileName(parameter.FilePath);

            Match matchVersion = regexVersion.Match(fileName);

            string result;
            if (matchVersion != null && matchVersion.Success)
            {
                string newVersion = IncreaseVersion(matchVersion.Groups["version"].Value);
                result = $"{regexVersion.Replace(fileName, "v" + newVersion)}";

                if (parameter.UpdateDate)
                {
                    // 更新日期

                    result = $"{regexDate.Replace(fileName, "_" + BuildDateString())}";
                }
            }
            else
            {
                result = $"{Path.GetFileNameWithoutExtension(parameter.FilePath)} v1.0";

                if (parameter.EnabledDate)
                {
                    result += ("_" + BuildDateString());
                }

                if (!string.IsNullOrWhiteSpace(parameter.User))
                {
                    result += ("_" + parameter.User);
                }

                result += Path.GetExtension(parameter.FilePath);
            }

            return result;
        }

        /// <summary>
        /// 递增版本号
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        private string IncreaseVersion(string version)
        {
            string[] parts = version.Split('.');
            return $"{parts[0]}.{Convert.ToInt32(parts[1]) + 1}";
        }

        /// <summary>
        /// 生成日期标识
        /// </summary>
        /// <returns></returns>
        private string BuildDateString()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }
    }
}
