using BridgePG;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace WebApplication2
{
    public static class Connect
    {
        public static string PostData(string code)
        {
            StringBuilder postData = new StringBuilder();

            postData.Append("code=" + code + "&");
            postData.Append("client_id=" + ConfigurationManager.AppSettings["CLIENT_ID"] + "&");
            string secret = "12:" + ConfigurationManager.AppSettings["client_secret"].ToString() + "@1234";

            string aesSecret = "";
            try
            {
                aesSecret = Crypto.AESEncrypt(secret, ConfigurationManager.AppSettings["CLIENT_TOKEN"].ToString());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }



            postData.Append("client_secret=" + aesSecret + "&");
            postData.Append("grant_type=" + "authorization_code" + "&");
            postData.Append("redirect_uri=" + ConfigurationManager.AppSettings["CLIENT_CALLBACK_URI"]);



            return postData.ToString();
        }


        public static bool RedirectToPage(string code, ref string resource, ref string login)
        {
            WebRequest request =
                     WebRequest.Create(ConfigurationManager.AppSettings["CONNECT_SERVER_URI"] + ConfigurationManager.AppSettings["TOKEN_ENDPOINT"]);

            request.Method = "POST";


            string posd = PostData(code);

            byte[] byteArray = Encoding.UTF8.GetBytes(posd);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            WebResponse response = request.GetResponse();

            dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();


      Dictionary<string, string> s = new Dictionary<string, string>();// = myjson.jsonParse(responseFromServer);

            if (s.ContainsKey("access_token"))
            {

                string content = "";
                HttpWebRequest req = (HttpWebRequest)(HttpWebRequest.Create(ConfigurationManager.AppSettings["CONNECT_SERVER_URI"] + ConfigurationManager.AppSettings["RESOURCE_URL"]));
                req.Method = "POST";
                req.ProtocolVersion = HttpVersion.Version11;
                // req.ContentType = "application/json";
                req.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + s["access_token"]);
                req.ContentLength = content.Length;
                Stream wri = req.GetRequestStream();

                HttpWebResponse HttpWResp = (HttpWebResponse)req.GetResponse();
                int resCode = (int)HttpWResp.StatusCode;
                StreamReader reader1 = new StreamReader(HttpWResp.GetResponseStream(), System.Text.Encoding.UTF8);
                resource = reader1.ReadToEnd();


                return true;




            }
            else
            {
                reader.Close();
                dataStream.Close();
                response.Close();

                resource = "Error occurred";
                return false;


            }







        }





    }


}
