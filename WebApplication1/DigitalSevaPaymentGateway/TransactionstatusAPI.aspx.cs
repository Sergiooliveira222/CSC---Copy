using BridgePG;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1.DigitalSevaPaymentGateway
{
    public partial class TransactionstatusAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


            }

        }




        protected void btnRecon_Click(object sender, EventArgs e)
        {

            string merchant_txn = txtMerchantTxn.Text.Trim();
            string csc_txn = txtCSCTxn.Text.Trim();

            string merchant_ID = txtmerchantid.Text.Trim();

            string str = transaction_status(merchant_ID, merchant_txn, csc_txn);
            Literal1.Text = str;

        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static bool callApi(string url, string requestXML, ref string responseXML)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)(HttpWebRequest.Create(url));
                req.Method = "POST";
                req.ProtocolVersion = HttpVersion.Version11;
                req.ContentType = "application/xml";
                string content = requestXML;
                req.ContentLength = content.Length;
                Stream wri = req.GetRequestStream();
                byte[] array = Encoding.UTF8.GetBytes(content);
                wri.Write(array, 0, array.Length);
                wri.Flush();
                wri.Close();
                HttpWebResponse HttpWResp = (HttpWebResponse)req.GetResponse();
                int resCode = (int)HttpWResp.StatusCode;
                StreamReader reader = new StreamReader(HttpWResp.GetResponseStream(), System.Text.Encoding.UTF8);
                string resultData = reader.ReadToEnd();
                responseXML = resultData;
                return true;
            }
            catch (Exception ex)
            {
                responseXML = ex.Message;
                return false;
            }
        }
        public string transaction_status(string merchant_id, string merchant_txn, string csc_txn)
        {

            string data = "merchant_id=" + merchant_id + "|merchant_txn=" + merchant_txn + "|csc_txn=" + csc_txn + "|";
            string strPRIVATE_KEY = txtprivatekey.Text.Trim();
            string strPUBLIC_KEY = txtpublickey.Text.Trim();
            strPRIVATE_KEY = Base64Decode(strPRIVATE_KEY);
            strPUBLIC_KEY = Base64Decode(strPUBLIC_KEY);
            Crypto.privateKey = strPRIVATE_KEY;
            Crypto.publicKey = strPUBLIC_KEY;
            string request_data = Crypto.encrypt(data, Crypto.publicKey, Crypto.privateKey);


            string response = "";
            XmlDocument req = new XmlDocument();

            XmlNode docNode = req.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            req.AppendChild(docNode);
            XmlNode xml = req.AppendChild(req.CreateElement("xml"));
            XmlNode merchant_id_node = xml.AppendChild(req.CreateElement("merchant_id"));
            merchant_id_node.InnerXml = merchant_id;
            XmlNode request_data_node = xml.AppendChild(req.CreateElement("request_data"));
            request_data_node.InnerXml = request_data;

            //string api = "https://bridgeuat.csccloud.in/cscbridge/v2/"; // staging
            string api = "https://bridge.csccloud.in/v2/"; // staging
            string appuri = api + "transaction/status" + "/format/xml";

            callApi(appuri, req.OuterXml, ref response);



            XmlDocument responsestr = new XmlDocument();

            responsestr.LoadXml(response);

            string result = responsestr.GetElementsByTagName("response_status")[0].InnerXml;
            if (result == "Success")
            {
                string response_data = responsestr.GetElementsByTagName("response_data")[0].InnerXml;

                response = Crypto.decrypt(response_data, Crypto.privateKey, Crypto.publicKey, true);



            }

            return response;
        }
    }
}