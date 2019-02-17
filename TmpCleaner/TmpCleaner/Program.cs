using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace TmpCleaner
{
    class Program
    {

       static string name = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
        static void Main(string[] args)
        {
            string tempPath = System.IO.Path.GetTempPath();

            try
            {
                Directory.Delete(tempPath, true); //true - если директория не пуста удаляем все ее содержимое
                Directory.CreateDirectory(tempPath);
            }
            catch { }
            SetAutorunValue(true);
        }


        static bool SetAutorunValue(bool autorun)
        {
            string ExePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
