using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BridgePG;


namespace WebApplication2
{
    public partial class callback : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    try
        //    {



        //        if (Request.QueryString["code"].Length > 0)
        //        {
        //            Session["state"] = Request.QueryString["state"];

        //            string code = Request.QueryString["code"].ToString();
        //            string resource = "";
        //            string login = "";
        //            if (Connect.RedirectToPage(code, ref resource, ref login))
        //            {
        //                string url = Session["page"].ToString();
        //                Session["data"] = resource;
        //                Session["logedin"] = "true";
        //                Response.Redirect(url, true);
        //            }
        //        }

        //    }
        //    catch (Exception) { }



        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                //string Svalue = Session["state"].ToString();
                //string Rvalue = Request.QueryString["state"].ToString();
                //if (Svalue == Rvalue)
                //{
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
                    Dictionary<string, string> s = myjson.jsonParse(responseFromServer);
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
                        Response.Redirect("WebForm1.aspx", true);


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



                //}
                //else
                //{


                //}

                //  Request.QueryString("code")
            }
            catch (Exception) { }



        }
    }

    public static class myjson
    {

        /*
        * This method takes in JSON in the form returned by javascript's
        * JSON.stringify(Object) and returns a string->string dictionary.
        * This method may be of use when the format of the json is unknown.
        * You can modify the delimiters, etc pretty easily in the source
        * (sorry I didn't abstract it--I have a very specific use).
        */
        public static Dictionary<string, string> jsonParse(string rawjson)
        {
            Dictionary<string, string> outdict = new Dictionary<string, string>();
            StringBuilder keybufferbuilder = new StringBuilder();
            StringBuilder valuebufferbuilder = new StringBuilder();
            StringReader bufferreader = new StringReader(rawjson);

            int s = 0;
            bool reading = false;
            bool inside_string = false;
            bool reading_value = false;
            //break at end (returns -1)
            while (s >= 0)
            {
                s = bufferreader.Read();
                //opening of json
                if (!reading)
                {
                    if ((char)s == '{' && !inside_string && !reading) reading = true;
                    continue;
                }
                else
                {
                    //if we find a quote and we are not yet inside a string, advance and get inside
                    if (!inside_string)
                    {
                        //read past the quote
                        if ((char)s == '\"') inside_string = true;
                        continue;
                    }
                    if (inside_string)
                    {
                        //if we reached the end of the string
                        if ((char)s == '\"')
                        {
                            inside_string = false;
                            s = bufferreader.Read(); //advance pointer
                            if ((char)s == ':')
                            {
                                reading_value = true;
                                continue;
                            }
                            if (reading_value && (char)s == ',')
                            {
                                //we know we just ended the line, so put itin our dictionary
                                if (!outdict.ContainsKey(keybufferbuilder.ToString())) outdict.Add(keybufferbuilder.ToString(), valuebufferbuilder.ToString());
                                //and clear the buffers
                                keybufferbuilder = new StringBuilder();
                                valuebufferbuilder = new StringBuilder();
                                reading_value = false;
                            }
                            if (reading_value && (char)s == '}')
                            {
                                //we know we just ended the line, so put itin our dictionary
                                if (!outdict.ContainsKey(keybufferbuilder.ToString())) outdict.Add(keybufferbuilder.ToString(), valuebufferbuilder.ToString());
                                //and clear the buffers
                                keybufferbuilder = new StringBuilder();
                                valuebufferbuilder = new StringBuilder();
                                reading_value = false;
                                reading = false;
                                break;
                            }
                        }
                        else
                        {
                            if (reading_value)
                            {
                                valuebufferbuilder.Append((char)s);
                                continue;
                            }
                            else
                            {
                                keybufferbuilder.Append((char)s);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        switch ((char)s)
                        {
                            case ':':
                                reading_value = true;
                                break;
                            default:
                                if (reading_value)
                                {
                                    valuebufferbuilder.Append((char)s);
                                }
                                else
                                {
                                    keybufferbuilder.Append((char)s);
                                }
                                break;
                        }
                    }
                }
            }
            return outdict;
        }

    }
}