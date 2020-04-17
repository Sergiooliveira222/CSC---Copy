using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["Connectdata"])))
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(Session["Connectdata"].ToString().Trim());
                lblsessiondata.Text = "</br> Name : " + result["User"]["username"].Value + "<br />"
                                     + "Email Id : " + result["User"]["email"].Value + "<br />"
                                     + "CSC Id : " + result["User"]["csc_id"].Value + "<br />"
                                     + "Status :" + result["User"]["active_status"].Value + "<br />"
                                     + "Type : " + result["User"]["user_type"].Value + "<br />"
                                     + "last_active : " + result["User"]["last_active"].Value + "<br />"
                                    ;
                Session["username"] = result["User"]["csc_id"].Value;
                lblsessiondata.Visible = true;
                btnShop.Visible = true;
                btnLogOut.Visible = true;

            }
            else
            {
                btnLogin.Visible = true;
                lblsessiondata.Text = "";
                btnLogOut.Visible = false;
                btnShop.Visible = false;
            }
        }

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString().ToUpper();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //try
            //{

                // state = ConfigurationManager.AppSettings["merchant"] + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0') + "login.aspx";
                string stateID = GetUniqueKey(18);
                Session["state"] = stateID;
                string url = ConfigurationManager.AppSettings["CONNECT_SERVER_URI"] + ConfigurationManager.AppSettings["AUTHORIZATION_ENDPOINT"] + "?state=" + stateID + "&response_type=code&client_id=" + ConfigurationManager.AppSettings["CLIENT_ID"] + "&redirect_uri=" + ConfigurationManager.AppSettings["CLIENT_CALLBACK_URI"];
                Response.Redirect(url, true);
            //}
            //catch (Exception ee)
            //{
            //    Response.Write(ee.Message);
            //}
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx", false);
        }
        protected void btnShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx", false);
        }
    }
}