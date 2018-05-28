using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AvventoWrapperServiceClient.AvventoServiceEvents;
using AvventoWrapperServiceClient.AvventoServiceWrapperReference;
using AvventoWrapperServiceClient.Helpers;

namespace AvventoWrapperServiceClient
{
    public partial class ClientLoginForm : Form
    {
        public ClientLoginForm()
        {
            InitializeComponent();
        }

        public static AvventoServiceWrapperReference.AvventoServiceClient aventServiceClient;

        private void ClientLoginForm_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> endpointlist = new Dictionary<string, string>();
            string test = System.Configuration.ConfigurationManager.AppSettings["Test"];
            string dev = System.Configuration.ConfigurationManager.AppSettings["Dev"];
            string live = System.Configuration.ConfigurationManager.AppSettings["Live"];
            endpointlist["Test"] = test;
            endpointlist["Dev"] = dev;
            endpointlist["Live"] = live;

            comboBox1.DataSource = new BindingSource(endpointlist, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }

      
        
        private void button1_Click(object sender, EventArgs e)
        {
            

            aventServiceClient = new AvventoServiceClient();
            ActionResponse actionResponse;
          
            try

            {
                if (comboBox1.SelectedValue != null)
                {
                    EndpointAddress endpointAddress = new EndpointAddress(comboBox1.SelectedValue.ToString());
                    aventServiceClient.Endpoint.Address = endpointAddress;
                    string response = aventServiceClient.LoginAction(txtUserName.Text, txtPassword.Text);

                    actionResponse = XmlParser.FromXml<ActionResponse>(response);
                    

                }
                else
                {
                    aventServiceClient = new AvventoServiceClient();
                    string response = aventServiceClient.LoginAction(txtUserName.Text, txtPassword.Text);
                    actionResponse = XmlParser.FromXml<ActionResponse>(response);

                   

                }

                if (actionResponse.ResponseCode == "0")
                {
                    Form1 form1 = new Form1();
                    form1.Show();
                    form1.lblConnection.Text = string.Format("User: {0} Connected To: {1}", txtUserName.Text, aventServiceClient.Endpoint.Address.ToString());
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(actionResponse.Message);
                }

            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AvventoServiceEvents.AvventoServiceEventsClient client;
            var callback = new AvventoEvents();
            InstanceContext context = new InstanceContext(callback);
            client = new AvventoServiceEventsClient(context);
            client.OnDisplayUpdate("");
        }

        
       

        }

  
    
}
