using BridgePG;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.DigitalSevaPaymentGateway
{
    public partial class dec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string de = "";
            string strPrivateKey = ConfigurationManager.AppSettings["PRIVATE_KEY"];
            string strPublicKey = ConfigurationManager.AppSettings["PUBLIC_KEY"];
            string privatekey = Base64Decode(strPrivateKey);
            string PublicKey = Base64Decode(strPublicKey);
            // Crypto.privateKey = strPrivateKey;
            string drcResponse = Crypto.decrypt(de, privatekey, PublicKey, true);

        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}