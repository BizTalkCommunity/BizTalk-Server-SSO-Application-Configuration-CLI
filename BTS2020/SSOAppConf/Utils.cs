using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BizTalk.Tools.SSOApplicationConfiguration
{
    public class Utils
    {
        public static bool ImportAppFromXML(string path, string password, string appAdminAcct, string contactInfo, string appUserAcct)
        {
            XmlDocument configDoc = new XmlDocument();
            try
            {
                configDoc.LoadXml(Encryption.DecryptGeral(File.ReadAllText(@path), password));

                string appName = Path.GetFileNameWithoutExtension(@path);

                //grab fields
                XmlNodeList fields = configDoc.SelectNodes("//applicationData/add");
                ArrayList maskArray = new ArrayList();

                try
                {
                    HybridDictionary props = new HybridDictionary();

                    foreach (XmlNode field in fields)
                    {
                        props.Add(field.Attributes["key"].InnerText, field.Attributes["value"].InnerText);
                        maskArray.Add(0);
                    }

                    SSOPropBag propertiesBag = new SSOPropBag(props);

                    CreateAndEnableAppInSSO(appName, string.Empty, contactInfo, appUserAcct, appAdminAcct, propertiesBag, maskArray);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot create App: " + ex);
                    return false;
                }

                return true;
            }
            catch (XmlException)
            {
                Console.WriteLine("Password Incorrect");
                return false;
            }
        }
        
        public static void CreateAndEnableAppInSSO(string appName, string description, string ContactInfo,
           string AppUserAcct, string AppAdminAcct, SSOPropBag propertiesBag, ArrayList maskArray)
        {
            //create and enable application
            SSOConfigManager.CreateConfigStoreApplication(appName, description, ContactInfo,
                AppUserAcct, AppAdminAcct, propertiesBag, maskArray);
            //set default configuration field values
            SSOConfigManager.SetConfigProperties(appName, propertiesBag);
        }

        public static class Encryption
        {
            public static string DecryptGeral(string toDecrypt, string key)
            {
                byte[] inputBuffer = Convert.FromBase64String(toDecrypt);
                byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(key));
                TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
                {
                    Key = buffer,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                byte[] bytes = provider2.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Encoding.UTF8.GetString(bytes);
            }
        }
    }
}