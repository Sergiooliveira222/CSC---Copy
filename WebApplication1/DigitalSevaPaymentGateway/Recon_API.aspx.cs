using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.DigitalSevaPaymentGateway
{
    public partial class Recon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecon_Click(object sender, EventArgs e)
        {
            BridgePGUtil obj = new BridgePGUtil();
            string merchant_txn = txtMerchantTxn.Text.Trim();
            string csc_txn = txtCSCTxn.Text.Trim();
            string cscuser_id = txtCscUserid.Text.Trim();
            string product_id = txtProductId.Text.Trim();
            string txn_amount = txtTxnAmount.Text.Trim();
            string merchant_date = txtMerchantDate.Text.Trim();
            string merchant_txn_status = txtMerchantTxnStatus.Text.Trim();
            string merchant_reciept = txtMerchantReciept.Text.Trim();
            string merchant_ID = ConfigurationManager.AppSettings["MERCHANT_ID"];
            string str = obj.recon_logNew(merchant_ID, merchant_txn, csc_txn, cscuser_id, product_id, txn_amount, merchant_date, merchant_txn_status, merchant_reciept, "NA", "NA");
            Literal1.Text = str;

        }
    }
}