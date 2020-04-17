using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.DigitalSevaPaymentGateway
{
    public partial class Reversal_API : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        protected void btnRecon_Click(object sender, EventArgs e)
        {
            BridgePGUtil obj = new BridgePGUtil();
            string merchant_txn = txtMerchantTxn.Text.Trim();

            string merchant_date = txtMerchantDate.Text.Trim();
            string merchant_ID = ConfigurationManager.AppSettings["MERCHANT_ID"];

            string str = obj.transaction_reversal(merchant_ID, merchant_txn, merchant_date);
            Literal1.Text = str;

        }
    }
}