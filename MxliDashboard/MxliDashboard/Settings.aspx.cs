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
    public partial class Settings : Page
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
            Response.Redirect("settings/set_actions.aspx");
        }

        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings/set_tierviews.aspx");
        }
        protected void ASPxButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings/set_highlights.aspx");
        }

    }
}