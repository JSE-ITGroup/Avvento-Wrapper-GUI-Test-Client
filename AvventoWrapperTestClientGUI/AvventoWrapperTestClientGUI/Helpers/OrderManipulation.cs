using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvventoWrapperTestClientGUI.AvventoServiceWrapperReference;

namespace AvventoWrapperTestClientGUI.Helpers
{
    class OrderManipulation
    {

        public static bool SubmitOrder(AvventoServiceClient avventoServiceClient, string instrumentCode, string clientAccountReference,  string clientCodeOrAccountNumber, string memberCode, string dealerCode, string buyOrSell, int icebergqty, int qty, double price, string userName, int bidType,
             int cancelFlag, string orderReferenceNumber, DateTime expiryDate, out ActionResponse actionresponse)
        {
            actionresponse = null;
            string query = System.IO.File.ReadAllText(@"templates\1.SubmitOrderClientCode.xml");
            query = query.Replace("@InstrumentCode", instrumentCode);
            query = query.Replace("@ClientAccountReference", clientAccountReference);
            query = query.Replace("@ClientCodeOrAccountNumber", clientCodeOrAccountNumber);

            query = query.Replace("@DealerCode", dealerCode);
            query = query.Replace("@MemberCode", memberCode);
            query = query.Replace("@BuyOrSell", buyOrSell);
            query = query.Replace("@Quantity",qty.ToString());
            query = query.Replace("@IceBergQuantity", icebergqty.ToString());
            query = query.Replace("@Price", price.ToString());
            query = query.Replace("@BidType", bidType.ToString());

            query = query.Replace("@ExpiryDate", expiryDate.ToString("yyyy-MM-dd"));
            query = query.Replace("@CancelFlag", cancelFlag.ToString());
            query = query.Replace("@OrderReference", orderReferenceNumber);

            string xmlresult=  avventoServiceClient.SubmitAction(query);
            actionresponse = XmlParser.FromXml<ActionResponse>(xmlresult);
            
            if (actionresponse.ResponseCode == "0")
            {
                 return true;
            }
            else
            {
                return false;
            }

        }
    }
}
