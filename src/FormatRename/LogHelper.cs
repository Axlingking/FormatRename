using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FormatRename
{
    class LogHelper
    {
        public static string LogsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        public static void Write(string content)
        {
            if (!Directory.Exists(LogsPath)) Directory.CreateDirectory(LogsPath);

            File.AppendAllLines(Path.Combine(LogsPath, $"{DateTime.Now:yyyyMMdd}.log"), new string[] { content });
        }
    }
}
