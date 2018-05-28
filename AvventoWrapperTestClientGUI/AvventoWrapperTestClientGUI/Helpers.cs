using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AvventoWrapperTestClientGUI
{
    public class Helper
    {
        public static ActionResponse GetActionResponse(string actionResponseXml)
        {

            XElement doc = null;
            ActionResponse actionResponse = new ActionResponse();
             ActionResponse structure = new ActionResponse();
            try
            {
                doc = XElement.Parse(actionResponseXml);
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }

            if (doc != null)
            {
                var actionresultselement = doc.Elements("ActionResponse")
                    .Elements()
                    .ToList();


                actionResponse = GetObject<ActionResponse>(structure, actionresultselement);

               
            }



            return actionResponse;
        }
        public static T GetObject<T>(T structure, List<XElement> result)
        {
            if (structure == null) //|| result == null)
            {
                return default(T);
            }

            Type type = structure.GetType();

            foreach (var element in result)
            {

                PropertyInfo prop = type.GetProperty(element.Name.LocalName);
                if (prop != null)
                {
                    prop.SetValue(structure, element.Value.Trim(), null);
                }
            }

            return (T)structure;


        }
        

        public static string DecompressData(byte[] data)
        {
            using (MemoryStream inStream = new MemoryStream())
            {
                int bytesRead = 0;
                inStream.Write(data, 0, data.Length);
                byte[] decompressed = new byte[10000000];
                inStream.Position = 0;
                using (GZipStream zip = new GZipStream(inStream, CompressionMode.Decompress))
                {
                  bytesRead=  zip.Read(decompressed, 0, decompressed.Length);
                  
                }
              
                return Encoding.ASCII.GetString(decompressed, 0, bytesRead);

            }
        }

        public static void WriteToFile(string fileName, string contents)
        {
            if (!File.Exists(fileName))
            {
                // Create a file to write to.
                using (StreamWriter sw1 = File.CreateText(fileName))
                {
                }
                

            }
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(contents);
              
            }
           
 
        }

    }

}
