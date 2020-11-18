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
    public partial class Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("YTD.aspx");
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("n2_Inventory.aspx");
        }
    }
}