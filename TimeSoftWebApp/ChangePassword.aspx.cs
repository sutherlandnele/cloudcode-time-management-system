using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeSoft.BusinessComponents;
using TimeSoft.DataStructures;
using System.Threading;

namespace TimeSoftWebApp
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    TextBoxUserName.Text = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            LabelErrorCurrentPassword.Visible = false;
            LabelErrorNewPassword.Visible = false;
            LabelErrorConfirmPassword.Visible = false;
            LabelMessage.Text = string.Empty;
        }

        protected void LinkButtonCancel_Click(object sender, EventArgs e)
        {
            TextBoxCurrentPassword.Text = string.Empty;
            TextBoxNewPassword.Text = string.Empty;
            TextBoxConfirmNewPassword.Text = string.Empty;
        }

        protected void LinkButtonChangePassword_Click(object sender, EventArgs e)
        {
            UserBusinessComponent userBusinesscomponent = new UserBusinessComponent(Thread.CurrentPrincipal);
            UserEntity userEntity = userBusinesscomponent.GetByUserName(HttpContext.Current.User.Identity.Name);
            if (userEntity != null)
            {
                if (userEntity.Password.CompareTo(TextBoxCurrentPassword.Text) == 0)
                {
                    if (!string.IsNullOrEmpty(TextBoxNewPassword.Text))
                    {
                        if (!string.IsNullOrEmpty(TextBoxConfirmNewPassword.Text))
                        {
                            if (TextBoxNewPassword.Text.CompareTo(TextBoxConfirmNewPassword.Text) == 0)
                            {
                                userEntity = new UserEntity();
                                userEntity.UserName = HttpContext.Current.User.Identity.Name;
                                userEntity.Password = TextBoxNewPassword.Text;
                                userBusinesscomponent.ResetPassword(userEntity);
                                LabelMessage.Text = "Your password was now changed.";

                            }
                            else
                            {
                                LabelMessage.Text = "Your password does not match. Please re-type your password";
                                LabelErrorConfirmPassword.Visible = true;
                                LabelErrorNewPassword.Visible = true;
                            }
                        }
                        else
                        {
                            LabelMessage.Text = "Please Enter confirm New Password.";
                            LabelErrorConfirmPassword.Visible = true;
                        }
                    }
                    else
                    {
                        LabelMessage.Text = "Please Enter New Password.";
                        LabelErrorNewPassword.Visible = true;
                    }
                }
                else
                {
                    LabelMessage.Text = "Your Current Password is wrong.";
                    LabelErrorCurrentPassword.Visible = true;
                }
            }
        }
    }
}