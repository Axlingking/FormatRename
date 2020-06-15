using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatRename.Formaters
{
    interface IFormater
    {
        string Format(string value, string userName);
    }
}
