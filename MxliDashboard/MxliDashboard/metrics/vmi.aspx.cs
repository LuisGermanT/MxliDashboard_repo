using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard.n3_Inventory
{
    public partial class vmi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxSupInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxSupInContent_SelectedIndexChanged);
            if (!Page.IsPostBack)
            {
                chartDefault("SITE", "All");
            }
        }

        protected void cmbox_DataBoundSup(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxSupInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxSupInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxSupInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ASPxComboBoxSupInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("SUPPLIER", ASPxComboBoxSupInContent.SelectedItem.ToString());
            }
        }

        protected void chartDefault(string xType, string xFilter)
        {
            WebChartControl1.Series["Total"].Points.Clear();
            WebChartControl1.Series["Goal"].Points.Clear();

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("SELECT sday, fTotal, fGoal, fAcc FROM cht_inventario WHERE smetric = 'vmi' and sType = '" + xType + "' and sfilter = '" + xFilter + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xTotal = Convert.ToDouble(dr1["fTotal"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                WebChartControl1.Series["Total"].Points.AddPoint(dr1["sday"].ToString(), xTotal);
                WebChartControl1.Series["Goal"].Points.AddPoint(dr1["sday"].ToString(), xGoal);
            }
        }


    }
}