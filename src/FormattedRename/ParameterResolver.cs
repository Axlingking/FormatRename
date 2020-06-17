using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatRename
{
    class ParameterResolver
    {
        public RenameParameter Resolve(string[] args)
        {
            RenameParameter parameter = new RenameParameter();

            if (args.Length >= 1)
            {
                parameter.FilePath = args[0];

                for (int i = 1; i < args.Length; i++)
                {
                    string arg = args[i];

                    if (arg == "--user")
                        parameter.User = args[i + 1];
                    if (arg == "--date")
                        parameter.EnabledDate = true;
                    else if (arg == "--updatedate")
                        parameter.UpdateDate = true;
                }
            }

            return parameter;
        }
    }
}
