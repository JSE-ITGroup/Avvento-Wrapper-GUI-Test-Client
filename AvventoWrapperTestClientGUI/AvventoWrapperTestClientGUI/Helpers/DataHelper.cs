using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventoWrapperTestClientGUI.Helpers
{
    internal class DataHelper
    {
        public void GetValueFromDataTable(DataTable dt, string columnName, string lookupValue, string returnFeid)
        {
            IEnumerable<Int32> countryIDs = dt
                    .AsEnumerable()
                    .Where(row => row.Field<String>(columnName) == lookupValue)
                    .Select(row => row.Field<Int32>(returnFeid));
        }
    }
}
