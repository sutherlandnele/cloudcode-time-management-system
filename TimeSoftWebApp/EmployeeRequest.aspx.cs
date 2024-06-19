using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeSoftWebApp
{
    public partial class EmployeeRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            {
                if (!IsPostBack)
                {


                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
    }
}