using FormatRename.Formaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FormatRename.Formaters
{
    class Formater : IFormater
    {
        Regex regexVersion = new Regex(@"[vV](?<version>\d+\.\d+)");

        /// <summary>
        /// 格式化重命名
        /// </summary>
        /// <param name="value"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string Format(string value, string userName = "")
        {
            Match match = regexVersion.Match(value);

            string result;
            if (match != null && match.Success)
            {
                string newVersion = IncreaseVersion(match.Groups["version"].Value);
                result = $"{regexVersion.Replace(value, "v" + newVersion)}";
            }
            else
            {
                result = $"{value} v1.0_{DateTime.Now.ToString("yyyyMMdd")}{(!string.IsNullOrWhiteSpace(userName) ? "_" + userName : string.Empty)}";
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
            return $"{parts[0]}.{Convert.ToInt16(parts[1]) + 1}";
        }
    }
}
