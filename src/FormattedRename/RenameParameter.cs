using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatRename
{
    class RenameParameter
    {
        /// <summary>
        /// 文件名 必需参数
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 指定用户名称 --user
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// 指示启用日期 --date
        /// </summary>
        public bool EnabledDate { get; set; } = true;

        /// <summary>
        /// 指示格式化时更新日期 --updatedate
        /// </summary>
        public bool UpdateDate { get; set; } = false;
    }
}
