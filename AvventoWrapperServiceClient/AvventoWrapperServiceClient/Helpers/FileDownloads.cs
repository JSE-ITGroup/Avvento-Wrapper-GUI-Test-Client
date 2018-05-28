using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using AvventoWrapperServiceClient.AvventoServiceWrapperReference;

namespace AvventoWrapperServiceClient.Helpers
{
    public class FileDownloads
    {
        public static DataTable GetFileDownload(int dataType, DateTime DownloadDate,AvventoServiceClient avventoServiceClient)
        {
            DataTable dt = new DataTable();
               string downloadQuery = File.ReadAllText(@"templates\datadownload.xml");
               string query = downloadQuery.Replace("@DataType", dataType.ToString());
               query = query.Replace("@DownloadDate", DownloadDate.ToString("yyyy-MM-dd"));

               byte[] result = ClientLoginForm.aventServiceClient.DataDownloadAction(query);

                string results = Helper.DecompressData(result);
                if (results == null)
                {

                    return null;
                }
                DataSet ds = new DataSet();

                StringReader sr = new StringReader(results);
                XmlTextReader xtr = new XmlTextReader(sr);

                ds.ReadXml(xtr);
                ds.Merge(ds, true);
                if (ds.Tables.Count > 0)
                {
                    dt= ds.Tables[0];
                }
                else
                {
                    dt= null;
                }
            
            return dt;

        }
    }
}
