using System;
using System.Configuration;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSCTest
{
    [TestClass]
    public class UnitTest1
    {
  
        public UnitTest1()
        {
            ConfigurationManager.AppSettings["CONNECT_SERVER_URI"] = "https://connectuat.csccloud.in/account/";
            ConfigurationManager.AppSettings["AUTHORIZATION_ENDPOINT"] = "authorize";
            ConfigurationManager.AppSettings["TOKEN_ENDPOINT"] = "token";
            ConfigurationManager.AppSettings["RESOURCE_URL"] = "resource";
            ConfigurationManager.AppSettings["CLIENT_ID"] = "f7f71dff-ba04-46ed-e686-52f95841ca72";
            ConfigurationManager.AppSettings["CLIENT_SECRET"] = "M9I73XPmlZRp";
            ConfigurationManager.AppSettings["CLIENT_TOKEN"] = "Zor8uMvJ55m9kWUT";
            ConfigurationManager.AppSettings["CLIENT_CALLBACK_URI"] = "https://kotak-sampoorn-uat-web.azurewebsites.net/home";
            ConfigurationManager.AppSettings["merchant_id"] = "45393";
        }

        [TestMethod]
        public void TestMethod1()
        {

            string reasource = "";
            string login = "";
            string code = "Test";

            //Connect.RedirectToPage(code, ref reasource, ref login);
        }
    }
}
