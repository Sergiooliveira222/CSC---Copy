using BridgePG;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string Svalue = Session["state"].ToString();
                string Rvalue = Request.QueryString["state"].ToString();
                if (Svalue == Rvalue)
                {
                    Session["state"] = Request.QueryString["state"];
                    string secret = "12:" + ConfigurationManager.AppSettings["CLIENT_SECRET"].ToString() + "@1234";
                    Response.Write(secret + "<br/>");
                    WebRequest request =
                    WebRequest.Create(ConfigurationManager.AppSettings["CONNECT_SERVER_URI"] + ConfigurationManager.AppSettings["TOKEN_ENDPOINT"]);
                    // Set the Method property of the request to POST.
                    request.Method = "POST";

                    // Create POST data and convert it to a byte array.
                    StringBuilder postData = new StringBuilder();

                    postData.Append("code=" + Request.QueryString["code"] + "&");
                    postData.Append("client_id=" + ConfigurationManager.AppSettings["client_id"] + "&");

                    /////aes 

                    string aesSecret = "";
                    try
                    {
                        aesSecret = Crypto.AESEncrypt(secret, ConfigurationManager.AppSettings["CLIENT_TOKEN"].ToString());
                    }
                    catch (Exception ex)
                    {

                        Response.Write(ex.Message);
                    }

                    Response.Write(aesSecret);

                    /////

                    postData.Append("client_secret=" + aesSecret + "&");
                    postData.Append("grant_type=" + "authorization_code" + "&");
                    postData.Append("redirect_uri=" + ConfigurationManager.AppSettings["CLIENT_CALLBACK_URI"]);

                    string posd = postData.ToString();
                    // Response.Write(posd);
                    byte[] byteArray = Encoding.UTF8.GetBytes(posd);
                    // Set the ContentType property of the WebRequest.
                    request.ContentType = "application/x-www-form-urlencoded";
                    // Set the ContentLength property of the WebRequest.
                    request.ContentLength = byteArray.Length;
                    // Get the request stream.
                    Stream dataStream = request.GetRequestStream();
                    // Write the data to the request stream.
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    // Close the Stream object.
                    dataStream.Close();
                    // Get the response.
                    WebResponse response = request.GetResponse();
                    // Display the status.
                    // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                    // Get the stream containing content returned by the server.
                    // Response.Write(((HttpWebResponse)response).StatusDescription+"ppp");
                    dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    // Console.WriteLine(responseFromServer);
                    //  Response.Write(responseFromServer);
                    Dictionary<string, string> s = new Dictionary<string, string>();// myjson.jsonParse(responseFromServer);
                    // Response.Write("token="+ s["access_token"]);
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
                        // byte[] array = Encoding.UTF8.GetBytes(content);
                        // wri.Write(array, 0, array.Length);
                        // wri.Flush();
                        // wri.Close();
                        HttpWebResponse HttpWResp = (HttpWebResponse)req.GetResponse();
                        int resCode = (int)HttpWResp.StatusCode;
                        StreamReader reader1 = new StreamReader(HttpWResp.GetResponseStream(), System.Text.Encoding.UTF8);
                        string resultData = reader1.ReadToEnd();

                        //  if(Session["state"]  very session
                        Session["Connectdata"] = resultData;
                        // Session["logedin"] = "true";
                        // string url = Session["page"].ToString();
                        Response.Redirect("Default.aspx", true);


                        // Response.Write(resultData);
                    }
                    else
                    {
                        Response.Write("Error occurred");

                    }


                    // if (responseFromServer.Length == 0) Response.Write("Empty");
                    // Clean up the streams.
                    reader.Close();
                    dataStream.Close();
                    response.Close();



                }
                else
                {


                }

                //  Request.QueryString("code")
            }
            catch (Exception) { }



        }
    }
}