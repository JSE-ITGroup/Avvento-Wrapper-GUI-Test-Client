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
using AvventoWrapperTestClientGUI.AvventoServiceWrapperReference;
using AvventoWrapperTestClientGUI.Helpers;

namespace AvventoWrapperTestClientGUI
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
            string cloud = System.Configuration.ConfigurationManager.AppSettings["Cloud"];
            endpointlist["Test"] = test;
            endpointlist["Dev"] = dev;
            endpointlist["Live"] = live;
            endpointlist["Cloud"] = cloud;

            comboBox1.DataSource = new BindingSource(endpointlist, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }

      
        
        private void button1_Click(object sender, EventArgs e)
        {

           // var callback = new MyServiceCallback();
           // var instanceContext = new InstanceContext(callback);
            

            

            aventServiceClient = new AvventoServiceClient();
            ActionResponse actionResponse;
            string actionResult = null;
            try

            {
                if (comboBox1.SelectedValue != null)
                {
                    EndpointAddress endpointAddress = new EndpointAddress(comboBox1.SelectedValue.ToString());
                    aventServiceClient.Endpoint.Address = endpointAddress;
                    string response = aventServiceClient.LoginAction(txtUserName.Text, txtPassword.Text);

                    actionResponse = XmlParser.FromXml<ActionResponse>(response);

                    //actionResponse = response.ParseXML<ActionResponse>();

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

            catch (FaultException exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Person> family = new List<Person>();
            Person person1 = new Person();
            person1.FirstName = "Peter";
            //person1.LastName = "Robinson";
            
     
            family.Add(person1);

            Person person2 = new Person();
            person2.FirstName = "Delane";
            //person2.LastName = "Robinson";
            family.Add(person2);

            Person person3 = new Person();
            person3.FirstName = "Milly";
            //person3.LastName = "Robinson";
            family.Add(person3);

            Person person4 = new Person();
            person4.FirstName = "Pauline";
            //person4.LastName = "Robinson";
            family.Add(person4);

            People people = new People();
            List<People> peopleList = new List<People>();
            peopleList = PopulateObject<Person, People>(family, people);

        }


        public static List<TOuput> PopulateObject<TInput, TOuput>(List<TInput> fromObjectArray, TOuput toObject)
        {
            List<TOuput> outObject = new List<TOuput>();
            TOuput tObject;
            
            foreach (TInput obj in fromObjectArray)
            {
                Type fromtype = obj.GetType();
                PropertyInfo[] properties = fromtype.GetProperties();


                TOuput ob = (TOuput)Activator.CreateInstance(typeof(TOuput));  
             
                foreach (PropertyInfo property in properties)
                {
                    var propValue = property.GetValue(obj, null);
                    var propName = property.Name;
                    var propType = property.PropertyType;
                    SetPropertyValue(propValue, propName, propType, ob);
                }


                outObject.Add(ob);


            }

            return outObject; 

        }

        public static void SetPropertyValue<T>(object propertyValue, string propertyName, Type propertyType, T toObj)
        {
            
            Type t = toObj.GetType();
            PropertyInfo prop = t.GetProperty(propertyName);

            if (prop != null)
            {

                Type type = Nullable.GetUnderlyingType(propertyType) ?? propertyType;


                if (type == typeof (String))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (bool))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (byte))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (char))
                {
                    prop.SetValue(toObj, propertyValue.ToString(), null);
                }
                else if (type == typeof (decimal))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (double))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (float))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (int))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (uint))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (long))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (ulong))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (object))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (short))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (ushort))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
                else if (type == typeof (char[]))
                {
                    prop.SetValue(toObj, propertyValue, null);
                }

                else
                {
                    prop.SetValue(toObj, propertyValue, null);
                }
            }



        }

        }

    public class Person
    {
       public string FirstName { get; set; }
       public char[] LastName { get; set; }
    }
    public class People
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
}
