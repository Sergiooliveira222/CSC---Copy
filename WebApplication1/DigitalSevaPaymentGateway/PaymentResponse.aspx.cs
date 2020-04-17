using BridgePG;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.DigitalSevaPaymentGateway
{
    public partial class PaymentResponse : System.Web.UI.Page
    {
        public string bridgeResponseMessage = "Error ", drcResponse = "Error", walletResponseMessage = "", status_message = "", merchant_txn = "", txn_status = "", txn_status_message = "", merchant_txn_date_time = "", csc_txn = "", product_id = "", product_name = "", merchant_id = "", csc_id = "", txn_amount = "", pay_to_email = "", amount_parameter = "", txn_mode = "", txn_type = "", merchant_receipt_no = "", csc_share_amount = "", Currency = "", Discount = "", param_1 = "", param_2 = "", param_3 = "", param_4 = "";

        protected void Page_Load(object sender, EventArgs e)
        {


            NameValueCollection nvc = Request.Form;
            if (!string.IsNullOrEmpty(nvc["bridgeResponseMessage"]))
            {

                bridgeResponseMessage = nvc["bridgeResponseMessage"];
                string strPrivateKey = ConfigurationManager.AppSettings["PRIVATE_KEY"];
                string strPublicKey = ConfigurationManager.AppSettings["PUBLIC_KEY"];
                strPrivateKey = Base64Decode(strPrivateKey);
                strPublicKey = Base64Decode(strPublicKey);
                Crypto.privateKey = strPrivateKey;
                drcResponse = Crypto.decrypt(bridgeResponseMessage, strPrivateKey, strPublicKey, true);
                TextBox1.Text = drcResponse;

                string[] arr = drcResponse.Split("|".ToCharArray());
                for (int i = 0; i < arr.Length; i++)
                {
                    string[] arr2 = arr[i].Split("=".ToCharArray());
                    if (arr2[0] == "merchant_txn") merchant_txn = arr2[1];
                    if (arr2[0] == "merchant_txn_date_time") merchant_txn_date_time = arr2[1];
                    if (arr2[0] == "csc_txn") csc_txn = arr2[1];
                    if (arr2[0] == "product_id") product_id = arr2[1];
                    if (arr2[0] == "product_name") product_name = arr2[1];
                    if (arr2[0] == "merchant_id") merchant_id = arr2[1];
                    if (arr2[0] == "csc_id") csc_id = arr2[1];
                    if (arr2[0] == "txn_amount") txn_amount = arr2[1];
                    if (arr2[0] == "pay_to_email") pay_to_email = arr2[1];
                    if (arr2[0] == "amount_parameter") amount_parameter = arr2[1];
                    if (arr2[0] == "txn_mode") txn_mode = arr2[1];
                    if (arr2[0] == "txn_type") txn_type = arr2[1];
                    if (arr2[0] == "merchant_receipt_no") merchant_receipt_no = arr2[1];
                    if (arr2[0] == "csc_share_amount") csc_share_amount = arr2[1];
                    if (arr2[0] == "Currency") Currency = arr2[1];
                    if (arr2[0] == "Discount") Discount = arr2[1];
                    if (arr2[0] == "status_message") status_message = arr2[1];
                    if (arr2[0] == "txn_status") txn_status = arr2[1];
                    if (arr2[0] == "txn_status_message") txn_status_message = arr2[1];
                    if (arr2[0] == "param_1") param_1 = arr2[1];
                    if (arr2[0] == "param_2") param_2 = arr2[1];
                    if (arr2[0] == "param_3") param_3 = arr2[1];
                    if (arr2[0] == "param_4") param_4 = arr2[1];
                }



            }
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}