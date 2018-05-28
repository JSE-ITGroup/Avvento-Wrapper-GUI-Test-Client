using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AvventoWrapperServiceClient.AvventoServiceEvents;

namespace AvventoWrapperServiceClient.Helpers
{
    class AvventoEvents: IAvventoServiceEventsCallback
    {

        public void DisplayNotification(string message)
        {
            MessageBox.Show(message);
        }
    }
}
