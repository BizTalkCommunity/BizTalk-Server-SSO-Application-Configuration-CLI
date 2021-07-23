using BizTalk.Tools.SSOApplicationConfiguration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOAppConf
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 5)
            {
                Console.WriteLine("Invalid args. It must contain two args (sso file path and password)");
                return;
            }
            else
            {
                try
                {
                    string filePath = args[0];
                    string password = args[1];
                    string contactInfo = args[2];
                    string AppUserAcct = args[3];
                    string AppAdminAcct = args[4];

                    if (Utils.ImportAppFromXML(filePath, password, contactInfo, AppUserAcct, AppAdminAcct))
                        Console.WriteLine("Configuration Saved Successfully");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Cannot create App: " + ex);
                    throw ex;
                }
            }
        }
    }
}
