using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard
{
    public partial class xSettings : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings/set_aop_goals.aspx");
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings/set_forecast.aspx");
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings/set_highlights.aspx");
        }

        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings/set_actions.aspx");
        }
        protected void ASPxButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("#");
        }
        protected void ASPxButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("#");
        }

    }
}