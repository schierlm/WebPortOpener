using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPortOpener
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            status.Text = "Your IP: " + Request.ServerVariables["REMOTE_ADDR"];
            recaptcha.PrivateKey = ConfigurationManager.AppSettings["reCaptchaPrivateKey"];
            recaptcha.PublicKey = ConfigurationManager.AppSettings["reCaptchaPublicKey"];
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool useDomain = bool.Parse(ConfigurationManager.AppSettings["UseDomain"]);
                string domainName = ConfigurationManager.AppSettings["Domain"];
                PrincipalContext context = new PrincipalContext(useDomain ? ContextType.Domain : ContextType.Machine, domainName);

                if (context.ValidateCredentials(username.Text, password.Text))
                {
                    string ruleName = ConfigurationManager.AppSettings["RuleName"];
                    INetFwPolicy2 policy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWPolicy2"));
                    policy.Rules.Item(ruleName).RemoteAddresses += "," + Request.ServerVariables["REMOTE_ADDR"];
                    status.Text = "IP whitelisted";
                }
                else
                {
                    status.Text = "Invalid username or password";
                }
            }
            else
            {
                status.Text = "Invalid CAPTCHA entered";
            }
        }
    }
}