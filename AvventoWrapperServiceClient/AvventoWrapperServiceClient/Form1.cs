using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AvventoWrapperServiceClient.AvventoServiceWrapperReference;
using System.ServiceModel;
using System.Xml;
using System.Xml.Linq;
using AvventoWrapperServiceClient.AvventoServiceEvents;
using AvventoWrapperServiceClient.Helpers;

namespace AvventoWrapperServiceClient
{
    public partial class Form1 : Form
    {
        public Action<ActionResponse> ActionResponseCallback;

        public static AvventoServiceWrapperReference.AvventoServiceClient avventoServiceClient;
        private bool isConnected;

        public Form1()
        {
            InitializeComponent();
            ActionQuery.Text = ActionQuery.Text.Trim();
            isConnected = false;
            this.ActionResponseCallback = ap =>
            {

                SetGridStructure();
                this.dataGridView2.Rows.Insert(0, ap.ResponseCode, ap.Message,
                    ap.Reason);
                dataGridView2.Refresh();

                // Console.Beep();
            };
        }


        private FileDialog fileDialog = new OpenFileDialog();

        private void Form1_Load(object sender, EventArgs e)
        {
     VersionInfo versioninfo = new VersionInfo();
            Populate();
            string versionstr = ClientLoginForm.aventServiceClient.Version();
            versioninfo = XmlParser.FromXml<VersionInfo>(versionstr);
            if (versioninfo != null)
            {
                label5.Text = string.Format("Avvenot Wrapper Client Version: {0}", versioninfo.Version);
                Form1.ActiveForm.Text= string.Format("Avvenot Wrapper Client Version: {0}", versioninfo.Version);
            }


        }

        public void Populate()
        {
            Dictionary<string, string> endpointlist = new Dictionary<string, string>();
            string test = System.Configuration.ConfigurationManager.AppSettings["Test"];
            string dev = System.Configuration.ConfigurationManager.AppSettings["Dev"];
            endpointlist["Test"] = test;
            endpointlist["Dev"] = dev;

            comboBox1.DataSource = new BindingSource(endpointlist, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        public void SetActionResponseCallBack(ActionResponse actionResponse)
        {
            ActionResponseCallback(actionResponse);
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void DownloadAction(string query)
        {


            byte[] result = ClientLoginForm.aventServiceClient.DataDownloadAction(query);

            string results = Helper.DecompressData(result);
            Helper.WriteToFile("DataDownloads.txt", results);
            if (results == null)
            {
                MessageBox.Show("No Results Returned");
                return;
            }
            DataSet ds = new DataSet();

            StringReader sr = new StringReader(results);
            XmlTextReader xtr = new XmlTextReader(sr);

            ds.ReadXml(xtr);
            ds.Merge(ds, true);
            if (ds.Tables.Count > 0)
            {
                lblrow.Text = string.Format("{0} Record(s) returned", ds.Tables[0].Rows.Count);
                SetGridStructure();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Refresh();
            }
            else
            {

                lblrow.Text = string.Format("{0} Record(s) returned", 0);
            }




        }

        private void SubmitAction(string query)
        {
            try
            {
            
                var result = ClientLoginForm.aventServiceClient.SubmitAction(query);
                Helper.WriteToFile("SubmitActionResponse.txt", result);

                if (result != null)
                {
                    /*
                    SetGridStructure();
                    this.dataGridView1.Rows.Insert(0, actionresult.ResponseCode, actionresult.Message,
                        actionresult.Reason);
                    dataGridView1.Refresh();
                     */
                    DataSet ds = new DataSet();

                    StringReader sr = new StringReader(result);
                    XmlTextReader xtr = new XmlTextReader(sr);

                    ds.ReadXml(xtr);
                    ds.Merge(ds, true);
                    SetGridStructure();
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                else
                {
                    SetGridStructure();
                    MessageBox.Show("No Result");

                }
                if (string.IsNullOrEmpty(result))
                {
                    SetGridStructure();
                    MessageBox.Show("Empty Response");

                }
            }
            catch (FaultException fexp)
            {
                MessageBox.Show("Fault Occured -: " + fexp.Message);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error Occured: " + exp.Message);
            }


        }

        public void SetGridStructure()
        {

            if (dataGridView2.Columns.Count < 1)
            {

                Type t = typeof(ActionResponse);
                PropertyInfo[] pia = t.GetProperties();
                foreach (PropertyInfo pi in pia)
                {
                    if ((pi.PropertyType.IsGenericType))
                    {
                        Type typeOfColumn = pi.PropertyType.GetGenericArguments()[0];

                        dataGridView2.Columns.Add(pi.Name, pi.Name);
                    }
                    else
                        dataGridView2.Columns.Add(pi.Name, pi.Name);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {




        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            // Don't save if no data is returned
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            // Column headers
            string columnsHeader = "";
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                columnsHeader += dataGridView1.Columns[i].Name + ",";
            }
            sb.Append(columnsHeader + Environment.NewLine);
            // Go through each cell in the datagridview
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                // Make sure it's not an empty row.
                if (!dgvRow.IsNewRow)
                {
                    for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {
                        // Append the cells data followed by a comma to delimit.

                        sb.Append(dgvRow.Cells[c].Value + ",");
                    }
                    // Add a new line in the text file.
                    sb.Append(Environment.NewLine);
                }
            }
            // Load up the save file dialog with the default option as saving as a .csv file.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // If they've selected a save location...
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false))
                {
                    // Write the stringbuilder text to the the file.
                    sw.WriteLine(sb.ToString());
                }
            }
            // Confirm to the user it has been completed.
            MessageBox.Show("CSV file saved.");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult result = fileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ActionQuery.Text = System.IO.File.ReadAllText(fileDialog.FileName);

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            lblrow.Text = "";

            string query = ActionQuery.Text;
            try
            {
                var xDoc = XElement.Parse(query);



                if (xDoc.FirstNode.ToString().ToUpper().StartsWith("<DATADOWNLOAD>"))
                {

                    DownloadAction(query);

                }
                else
                {
                    SubmitAction(query);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("XML Validation Error: " + exp.Message);
                ;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ClientLoginForm.aventServiceClient.LogoutAction();
            ClientLoginForm frm = new ClientLoginForm();
            frm.Show();
            this.Hide();

        }

        private bool ExportGridViewToCsv(string filename, DataGridView gridview)
        {

            // Don't save if no data is returned
            if (gridview.Rows.Count == 0)
            {
                return false;
            }
            StringBuilder sb = new StringBuilder();
            // Column headers
            string columnsHeader = "";
            for (int i = 0; i < gridview.Columns.Count; i++)
            {
                columnsHeader += gridview.Columns[i].Name + ",";
            }
            sb.Append(columnsHeader + Environment.NewLine);
            // Go through each cell in the datagridview
            foreach (DataGridViewRow dgvRow in gridview.Rows)
            {
                // Make sure it's not an empty row.
                if (!dgvRow.IsNewRow)
                {
                    for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {
                        // Append the cells data followed by a comma to delimit.

                        sb.Append(dgvRow.Cells[c].Value + ",");
                    }
                    // Add a new line in the text file.
                    sb.Append(Environment.NewLine);
                }
            }

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, false))
            {
                // Write the stringbuilder text to the the file.
                sw.WriteLine(sb.ToString());
            }

            return true;
        }
        private void button10_Click(object sender, EventArgs e)
        {

            // Don't save if no data is returned
            if (dataGridView2.Rows.Count == 0)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            // Column headers
            string columnsHeader = "";
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                columnsHeader += dataGridView2.Columns[i].Name + ",";
            }
            sb.Append(columnsHeader + Environment.NewLine);
            // Go through each cell in the datagridview
            foreach (DataGridViewRow dgvRow in dataGridView2.Rows)
            {
                // Make sure it's not an empty row.
                if (!dgvRow.IsNewRow)
                {
                    for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {
                        // Append the cells data followed by a comma to delimit.

                        sb.Append(dgvRow.Cells[c].Value + ",");
                    }
                    // Add a new line in the text file.
                    sb.Append(Environment.NewLine);
                }
            }
            // Load up the save file dialog with the default option as saving as a .csv file.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // If they've selected a save location...
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false))
                {
                    // Write the stringbuilder text to the the file.
                    sw.WriteLine(sb.ToString());
                }
            }
            // Confirm to the user it has been completed.
            MessageBox.Show("CSV file saved.");
        }
        /*
        public class MyServiceCallback : IAvventoServiceCallback
        {


            public void OnDisplayUpdate(string response)
            {
                MessageBox.Show(string.Format("> Received callback at {0}-{1}", DateTime.Now, response));
            }

        }
        */
        private void button2_Click_1(object sender, EventArgs e)
        {
          //  var callback = new ClientLoginForm.MyServiceCallback();
           // var instanceContext = new InstanceContext(callback);


            avventoServiceClient = new AvventoServiceClient();
            ActionResponse actionResponse = new ActionResponse();
          
            try
            {
                if (comboBox1.SelectedValue != null)
                {
                    EndpointAddress endpointAddress = new EndpointAddress(comboBox1.SelectedValue.ToString());
                    avventoServiceClient.Endpoint.Address = endpointAddress;
                    string response = avventoServiceClient.LoginAction(txtUserName.Text, txtPassword.Text);
                    actionResponse = XmlParser.FromXml<ActionResponse>(response);


                }
                else
                {
                    avventoServiceClient = new AvventoServiceClient();
                    string response = avventoServiceClient.LoginAction(txtUserName.Text, txtPassword.Text);
                    actionResponse = XmlParser.FromXml<ActionResponse>(response);
                }

                if (actionResponse.ResponseCode == "0")
                {
                    //MessageBox.Show(actionResponse.Message);
                    lblLoginStatus.Text = string.Format("Connected to: {0}", actionResponse.Message);
                    isConnected = true;

                }
                else
                {
                    MessageBox.Show(actionResponse.Message);
                    isConnected = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                try
                {
                    LoadListBox();
                }
                catch (Exception exp)
                {

                    MessageBox.Show("Error Loading.." + exp.Message);
                }


            }
        }

        private void LoadListBox()
        {


            string operationsfile = "operations.csv";
            string datatypedownload = "datatypesdownloads.csv";
            string[] operations = System.IO.File.ReadAllLines(operationsfile);
            string[] datatypes = System.IO.File.ReadAllLines(datatypedownload);
            DatatypeDic(operations, listBoxAllOperations);
            DatatypeDic(datatypes, listBoxAllDataTypes);

        }

        private void DatatypeDic(string[] records, ListBox destination)
        {
            Dictionary<string, string> itemDic = new Dictionary<string, string>();

            foreach (string record in records)
            {
                string[] rec = record.Split(',');
                itemDic[rec[0].Trim()] = rec[1].Trim();
            }

            destination.DataSource = new BindingSource(itemDic, null);
            destination.DisplayMember = "Value";
            destination.ValueMember = "Key";

        }

        private void MoveListBoxItems(ListBox source, ListBox destination)
        {
            ListBox.SelectedObjectCollection sourceItems = source.SelectedItems;
            foreach (var item in sourceItems)
            {
                destination.Items.Add(item);
            }
            while (source.SelectedItems.Count > 0)
            {
                source.DataSource = null;
                //  source.Items.Remove(source.SelectedItems[0]);
            }

        }

        private void AllOpsToSelectedOps_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(listBoxAllOperations, listBoxSelectedOperations);
        }

        private void SelectedOpsToAllOps_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(listBoxSelectedOperations, listBoxAllOperations);
        }

        private void AllDataTypeToSelectedDataTypes_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(listBoxAllDataTypes, listBoxSelectedDataTypes);
        }

        private void button5_Click(object sender, EventArgs e)
        {
        
            if (!isConnected)
            {
                button2_Click_1(sender, e);
            }
            if (isConnected)
            {
                string timestr = DateTime.Now.ToString("yyyyMMddHHmmss");
                string downloadQuery = File.ReadAllText(@"templates\datadownload.xml");
                string path = Properties.Settings.Default.FilePath;
                string dir = path + @"\\" + txtUserName.Text + "_" + timestr;
                string datadownloadlogfile = dir + string.Format(@"\DataDownloadLog_{0}_.csv", timestr);
                string submitactionlogfile = dir + string.Format(@"\SubmitLog_{0}_.csv", timestr);

                System.IO.Directory.CreateDirectory(dir);
                // DataDownloadAction(downloadQuery, dir, datadownloadlogfile);
                SubmitQueryAction(submitactionlogfile);
            }


            MessageBox.Show("Operation Completed See Grid View Log for Details");
        }

        private int GetRandomQuantity(int min, int max)
        {
            Random rn = new Random();
            return rn.Next(min, max);

        }
        private void SubmitQueryAction(string submitactionlogfile)
        {
            Guid g;
            g = Guid.NewGuid();
            string MemberCode = "MAYB";
            string DealerCode = "CCM";
            string ClientCode = "LWL803";
            string orderReferenceNumber = "JSE" + g.ToString().Substring(0, 6);
            ActionResponse actionresponse = new ActionResponse();

            var displayData = FileDownloads.GetFileDownload(1, DateTime.Today, avventoServiceClient);
            // var instrumentData = FileDownloads.GetFileDownload(2, DateTime.Today, avventoServiceClient);
            // var mtm = FileDownloads.GetFileDownload(16, DateTime.Today, avventoServiceClient);
            if (displayData != null)
            {
                int i = 1;
                foreach (DataRow dr in displayData.Rows)
                {
                    actionresponse = new ActionResponse();
                    orderReferenceNumber = orderReferenceNumber + i.ToString().PadLeft(3, '0');
                    var instrumentCode = dr["FirstInstrumentCode"].ToString();
                    var Price = dr["OpeningPrice"].ToString();

                    OrderManipulation.SubmitOrder(avventoServiceClient, instrumentCode, ClientCode, "C", MemberCode,
                        DealerCode, "B", 0, GetRandomQuantity(150, 1150), 0, Price, 0, 1, orderReferenceNumber,
                        DateTime.Today,
                        out actionresponse);

                    ActionResponseCallback(actionresponse);

                }
            }
            else
            {
                MessageBox.Show("No Data Retrieved");
            }


            // ActionResponseCallback(actionresponse);

        }

        public string GetActionQuery(string query)
        {
            return "";
        }
        private bool DataDownloadAction(string downloadQuery, string dir, string logfilename)
        {
            ActionResponse actionresponse;
            foreach (KeyValuePair<string, string> item in listBoxAllDataTypes.SelectedItems)
            {

                actionresponse = new ActionResponse();
                string query = downloadQuery;


                string datatype = item.Key.ToString();
                string datatypeName = item.Value.ToString();
                query = query.Replace("@DataType", datatype);
                query = query.Replace("@DownloadDate", DateTime.Today.ToString("yyyy-MM-dd"));
                byte[] result = ClientLoginForm.aventServiceClient.DataDownloadAction(query);

                string results = Helper.DecompressData(result);
                if (results == null)
                {
                    MessageBox.Show("No Results Returned");
                    return true;
                }
                DataSet ds = new DataSet();

                StringReader sr = new StringReader(results);
                XmlTextReader xtr = new XmlTextReader(sr);

                ds.ReadXml(xtr);
                ds.Merge(ds, true);
                if (ds.Tables.Count > 0)
                {
                    string filename = dir + string.Format(@"\{0}.csv", datatypeName);
                    actionresponse.Message = string.Format("{0} Record(s) returned", ds.Tables[0].Rows.Count);
                    if (DataTableToCsv(ds.Tables[0], filename))
                    {
                        actionresponse.Message = string.Format("{0} Record(s) written to file:{1}",
                            ds.Tables[0].Rows.Count, filename);
                        ActionResponseCallback(actionresponse);
                    }
                    else
                    {
                        actionresponse.Message = string.Format(" Error writing records to file:{0}", filename);
                        ActionResponseCallback(actionresponse);
                    }


                    /*
                        lblrow.Text = 
                        SetGridStructure();
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.Refresh();
                         */
                }
                else
                {
                    lblrow.Text = string.Format("{0} Record(s) returned", 0);
                }
            }
            ExportGridViewToCsv(logfilename, dataGridView2);
            return false;
        }


        public bool DataTableToCsv(DataTable dt, string filename)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataColumn col in dt.Columns)
            {
                sb.Append(col.ColumnName + ',');
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(Environment.NewLine);

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append(row[i].ToString() + ",");
                }

                sb.Append(Environment.NewLine);
            }

            File.WriteAllText(filename, sb.ToString());
            return true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = null;
            int[] datadownloadtype = {1, 2, 3, 5, 7,8,12,14,15,16,137,138,39,141,147,300,301};

            foreach (int i in datadownloadtype)
            {
                query = string.Format(Properties.Settings.Default.DataDownloadTemplate, i, DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd"));
                byte[] result = ClientLoginForm.aventServiceClient.DataDownloadAction(query);

                string results = Helper.DecompressData(result);

                Helper.WriteToFile(string.Format("DataDownloadType_{0}.xml",i), results);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

}
