using System;
using System.Collections.Generic;
using System.Configuration;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication2
{
    public partial class login : System.Web.UI.Page
    {
        public string state = "";
        public string dcrData = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["logedin"] == "true")
                {
                    LinkButton1.Text = "LogOut";
                    Button1.Visible = false;
                }
                else
                {
                    Button1.Visible = true;
                    LinkButton1.Text = "Login";
                }


            }
            catch (Exception)
            {
                LinkButton1.Text = "Login";
                Button1.Visible = true;
                Session["logedin"] = "false";
            }





            try
            {
                state = Session["state"].ToString();
                try
                {
                    if (state == Session["state"].ToString())
                        try
                        {
                            dcrData = Session["data"].ToString().Trim();
                            JObject results = JObject.Parse(Session["data"].ToString().Trim());
                            string temp = (string)results["username"];
                            if (temp == null)
                            {
                                dcrData = "<br />";
                                JObject a = JObject.Parse(Session["data"].ToString().Trim());

                                foreach (JObject o in a.First.Children<JObject>())
                                {
                                    foreach (JProperty p in o.Properties())
                                    {
                                        string name = p.Name;
                                        string value = (string)p.Value;
                                        dcrData = dcrData + name + " => " + value + "<br />";
                                    }
                                }

                                Session["username"] = (string)results["User"]["username"];

                                Session["logedin"] = "true";
                                LinkButton1.Text = "Logout";
                                Button1.Visible = false;
                            }
                            else
                            {
                                dcrData = "<br />";
                                JObject a = JObject.Parse(Session["data"].ToString().Trim());

                                foreach (JObject o in a.Children<JObject>())
                                {
                                    foreach (JProperty p in o.Properties())
                                    {
                                        string name = p.Name;
                                        string value = (string)p.Value;
                                        dcrData = dcrData + name + " => " + value + "<br />";
                                    }
                                }


                                Session["username"] = (string)results["username"];

                                Session["logedin"] = "true";
                                LinkButton1.Text = "Logout";
                                Button1.Visible = false;
                            }


                        }
                        catch (Exception)
                        {
                            Session["logedin"] = "false";
                            Button1.Visible = true;
                            LinkButton1.Text = "Login";
                        }
                }
                catch (Exception) { }
            }
            catch (Exception)
            {

                state = ConfigurationManager.AppSettings["merchant_id"] + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0') + "login.aspx";
                Session["logedin"] = "false";
                Session["page"] = "login.aspx";
                Button1.Visible = true;
            }




        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //ConfigurationManager.AppSettings["CONNECT_SERVER_URI"] = "https://connectuat.csccloud.in/account/";
            //ConfigurationManager.AppSettings["AUTHORIZATION_ENDPOINT"] = "authorize";
            //ConfigurationManager.AppSettings["TOKEN_ENDPOINT"] = "token";
            //ConfigurationManager.AppSettings["RESOURCE_URL"] = "resource";
            //ConfigurationManager.AppSettings["CLIENT_ID"] = "f7f71dff-ba04-46ed-e686-52f95841ca72";
            //ConfigurationManager.AppSettings["CLIENT_SECRET"] = "M9I73XPmlZRp";
            //ConfigurationManager.AppSettings["CLIENT_TOKEN"] = "Zor8uMvJ55m9kWUT";
            //ConfigurationManager.AppSettings["CLIENT_CALLBACK_URI"] = "https://kotak-sampoorn-uat-web.azurewebsites.net/home";
            //ConfigurationManager.AppSettings["merchant"] = "45393";https://localhost:44366/login.aspx
            ConfigurationManager.AppSettings["CLIENT_CALLBACK_URI"] = "https://localhost:44366/callback1.aspx";
            try
            {
                if (Session["state"] != null && Session["state"].ToString().Length > 0)
                {
                    string url = ConfigurationManager.AppSettings["CONNECT_SERVER_URI"] + ConfigurationManager.AppSettings["AUTHORIZATION_ENDPOINT"] + "?state=" + state + "&response_type=code&client_id=" + ConfigurationManager.AppSettings["CLIENT_ID"] + "&redirect_uri=" + ConfigurationManager.AppSettings["CLIENT_CALLBACK_URI"];

                    Response.Write(url);
                    Response.Redirect(url, true);
                }
                else
                {

                    state = ConfigurationManager.AppSettings["merchant"] + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0') + "login.aspx";
                    string url = ConfigurationManager.AppSettings["CONNECT_SERVER_URI"] + ConfigurationManager.AppSettings["AUTHORIZATION_ENDPOINT"] + "?state=" + state + "&response_type=code&client_id=" + ConfigurationManager.AppSettings["CLIENT_ID"] + "&redirect_uri=" + ConfigurationManager.AppSettings["CLIENT_CALLBACK_URI"];
                    Response.Write(url);

                    Response.Redirect(url, true);
                }
            }
            catch (Exception ex)
            {

                state = ConfigurationManager.AppSettings["merchant"] + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0') + "login.aspx";
                string url = ConfigurationManager.AppSettings["CONNECT_SERVER_URI"] + ConfigurationManager.AppSettings["AUTHORIZATION_ENDPOINT"] + "?state=" + state + "&response_type=code&client_id=" + ConfigurationManager.AppSettings["CLIENT_ID"] + "&redirect_uri=" + ConfigurationManager.AppSettings["CLIENT_CALLBACK_URI"];

                Response.Write(url);
                Response.Redirect(url, true);


            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (Session["logedin"] != "true")
            {
                Response.Redirect("login.aspx", true);

            }
            else
            {
                Session["logedin"] = "false";
                LinkButton1.Text = "Login";

            }


        }




    }
}