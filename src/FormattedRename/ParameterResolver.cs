using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatRename
{
    public class ParameterResolver
    {
        public RenameParameter Resolve(string[] args)
        { 
            RenameParameter parameter = new RenameParameter();

            if (args.Length == 1)
                // 只传一个参数时
                parameter.FilePath = args[0];
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string arg = args[i];

                    if (arg == "--file" || arg == "-f")
                        parameter.FilePath = args[i + 1];
                    else if (arg == "--user" || arg == "-u")
                        parameter.UserName = args[i + 1];
                }
            }

            return parameter;
        }
    }
}
