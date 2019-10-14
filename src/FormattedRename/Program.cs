using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FormattedRename
{
    class Program
    {
        static void Main(string[] args)
        { 
            new FileRename().Rename(new ParameterResolver().Resolve(args));
        }
    }
}
