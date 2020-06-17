using FormatRename.Formaters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace FormatRename
{
    class Program
    {
        static void Main(string[] args)
        {
            new FileRename(new Formater()).Rename(new ParameterResolver().Resolve(args));

            #region 测试用例

            //string a1 = new Formater()
            //        .Format(new RenameParameter
            //        {
            //            FilePath = "name",
            //        });
            //string a2 = new Formater()
            //    .Format(new RenameParameter
            //    {
            //        FilePath = "name.txt",
            //        User = "User"
            //    });
            //string a3 = new Formater()
            //    .Format(new RenameParameter
            //    {
            //        FilePath = "name",
            //        User = "User",
            //        EnabledDate = false
            //    });
            //string a4 = new Formater()
            //    .Format(new RenameParameter
            //    {
            //        FilePath = "name v1.0_20200615",
            //    });
            //string a5 = new Formater()
            //    .Format(new RenameParameter
            //    {
            //        FilePath = "namev1.0_20200615",
            //    });
            //string a6 = new Formater()
            //    .Format(new RenameParameter
            //    {
            //        FilePath = "name v1.0_20200615.txt",
            //        UpdateDate = false
            //    });
            //string a7 = new Formater()
            //    .Format(new RenameParameter
            //    {
            //        FilePath = "name v1.0_20200615.txt",
            //        UpdateDate = true
            //    });

            #endregion
        }
    }
}
