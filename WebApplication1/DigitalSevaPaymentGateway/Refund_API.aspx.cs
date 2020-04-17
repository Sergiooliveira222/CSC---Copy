using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.DigitalSevaPaymentGateway
{
    public partial class Refund : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        protected void btnRecon_Click(object sender, EventArgs e)
        {




        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            BridgePGUtil obj = new BridgePGUtil();
            string merchant_txn = txtMerchantTxn.Text.Trim();
            string csc_txn = txtCSCTxn.Text.Trim();
            string merchant_txn_status = "Success";
            string merchant_reference = DateTime.Now.ToFileTime().ToString();
            string refund_deduction = "F";
            string refund_mode = "F";
            string refund_type = "R";
            string refund_trigger = "M";
            string refund_reason = "Ok";
            string merchant_txn_param = "N";
            string merchant_ID = ConfigurationManager.AppSettings["MERCHANT_ID"];

            string str = obj.refund_log(merchant_ID, merchant_txn, csc_txn, merchant_txn_status, merchant_reference, refund_deduction, refund_mode, refund_type, refund_trigger, refund_reason, merchant_txn_param);
            Literal1.Text = str;
        }
    }
}