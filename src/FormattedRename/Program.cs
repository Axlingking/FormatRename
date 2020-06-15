using FormatRename.Formaters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FormatRename
{
    class Program
    {
        static void Main(string[] args)
        {
            new FileRename(new Formater())
                .Rename(new ParameterResolver().Resolve(args));

            //Console.WriteLine(new Formater().Format("name"));
            //Console.WriteLine(new Formater().Format("name v1.0"));
            //Console.WriteLine(new Formater().Format("name v1.0_20200615"));
            //Console.WriteLine(new Formater().Format("namev1.0_20200615"));
            //Console.WriteLine(new Formater().Format("name", "zzl"));
            //Console.WriteLine(new Formater().Format("name v1.0", "zzl"));
            //Console.WriteLine(new Formater().Format("name v1.0_20200615", "zzl"));
            //Console.WriteLine(new Formater().Format("namev1.0_20200615", "zzl"));

            //Console.ReadKey();
        }
    }
}
