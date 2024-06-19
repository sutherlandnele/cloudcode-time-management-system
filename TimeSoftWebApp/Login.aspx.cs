using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Web.Security;
using TimeSoft.BusinessComponents;
using TimeSoft.DataStructures;
using System.Threading;

namespace TimeSoftWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        // Declare the logon types as constants
        const long LOGON32_LOGON_INTERACTIVE = 2;
        const long LOGON32_LOGON_NETWORK = 3;

        // Declare the logon providers as constants
        const long LOGON32_PROVIDER_DEFAULT = 0;
        const long LOGON32_PROVIDER_WINNT50 = 3;
        const long LOGON32_PROVIDER_WINNT40 = 2;
        const long LOGON32_PROVIDER_WINNT35 = 1;

        [DllImport("advapi32.dll", EntryPoint = "LogonUser")]
        private static extern bool LogonUser(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);

        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
           // InitializeComponent();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = LinkButtonLogin.UniqueID;
            LabelMessage.Text = string.Empty;
           // TextBoxUserName.Text = ConfigurationManager.AppSettings["LoginUserName"];

        }

        private bool ValidateLogin(
         string Username,
         string Password,
         string Domain)
        {
            // This is the token returned by the API call
            // Look forward to a future article covering
            // the uses of it
            IntPtr token = new IntPtr(0);
            token = IntPtr.Zero;

            // Call the API
            if (LogonUser(
                Username,
                Domain,
                Password,
                (int)LOGON32_LOGON_NETWORK,
                (int)LOGON32_PROVIDER_DEFAULT,
                ref token))
            {
                //' Since the API returned TRUE, return TRUE to the caller
                return true;
            }
            else
            {
                //' Bad credentials, return FALSE
                return false;
            }
        }


        protected void LinkButtonLogin_Click(object sender, EventArgs e)
        {
           // string Username = this.TextBoxUserName.Text;
           // string Password = this.TextBoxPassword.Text;
            //// Pull the domain out of the web.config file
           // string Domain = ConfigurationManager.AppSettings["AccountDomain"];


            

          // if (ValidateLogin(Username, Password, Domain))
           // {
               //' Since the credentials are valid,
               //  ' redirect the user to the calling page

             //   FormsAuthentication.RedirectFromLoginPage(Username, true);

           // }
           // else
           // {
                //' Bad credentials, show an error message
             //   LabelMessage.Text = "Invalid login.";
           // }
            UserBusinessComponent userBusinesscomponent = new UserBusinessComponent(Thread.CurrentPrincipal);
            UserEntity userEntity = userBusinesscomponent.GetByUserName(TextBoxUserName.Text);
            if (userEntity != null)
            {
                if (TextBoxPassword.Text.CompareTo(userEntity.Password) == 0 )
                {
                    FormsAuthentication.RedirectFromLoginPage(TextBoxUserName.Text, true);
                }
                else
                {
                    //' Bad credentials, show an error message
                    LabelMessage.Text = "Invalid login.";
                }
            }
            else
            {
                LabelMessage.Text = "Invalid login.";
            }
        }

        protected void LinkButtonCancel_Click(object sender, EventArgs e)
        {
            TextBoxUserName.Text = string.Empty;
            TextBoxPassword.Text = string.Empty;
        }
    }
}