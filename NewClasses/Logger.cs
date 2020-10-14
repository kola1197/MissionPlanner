using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner.NewClasses
{
    public class Logger
    {
        private bool loaded = false;
        private string path;

        public Logger() 
        {
            path = MainV2.defaultLoggerPath;
            System.IO.Directory.CreateDirectory(path);
            path += "\\" +DateTime.Now.ToString("dd/MMMM/yyyy_HH_mm") + ".log";
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.WriteLine(DateTime.Now.ToString("dd/MMMM/yyyy_HH:mm:ss") + ":: " + "test");
                    sw.Close();
                }
            }
            catch (Exception e) 
            {
                System.Diagnostics.Debug.WriteLine("ERROR::: "+e.ToString() );
                System.Diagnostics.Debug.WriteLine("path: " + path);
            }
        }

        public void write(string text) 
        {
            using (StreamWriter sw = new StreamWriter(path,true)) 
            {
                sw.WriteLine(DateTime.Now.ToString("dd/MMMM/yyyy_HH:mm:ss")+":: " + text);
                sw.Close();
            }
        }
    }
}
