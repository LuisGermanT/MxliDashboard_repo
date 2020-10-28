using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard.n3_Safety
{
    public partial class mep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxResInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxResInContent_SelectedIndexChanged);
            this.ASPxComboBoxStaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxStaInContent_SelectedIndexChanged);
            if (!Page.IsPostBack)
            {
                chartDefault("SITE", "All");
            }
        }

        protected void cmbox_DataBoundRes(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxResInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxResInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundSta(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxStaInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxStaInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxResInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxStaInContent.SelectedIndex = 0;
            if (ASPxComboBoxResInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("RESPONSIBLE", ASPxComboBoxResInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxStaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxResInContent.SelectedIndex = 0;
            if (ASPxComboBoxStaInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("STATUS", ASPxComboBoxStaInContent.SelectedItem.ToString());
            }
        }

        protected void chartDefault(string xType, string xFilter)
        {
            WebChartControl1.Series["Total"].Points.Clear();
            WebChartControl1.Series["Goal"].Points.Clear();

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("SELECT sday, fTotal, fGoal, fAcc FROM cht_seguridad WHERE smetric = 'mst' and sType = '" + xType + "' and sfilter = '" + xFilter + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xTotal = Convert.ToDouble(dr1["fTotal"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                WebChartControl1.Series["Total"].Points.AddPoint("W-"+ dr1["sday"].ToString(), xTotal);
                WebChartControl1.Series["Goal"].Points.AddPoint("W-" + dr1["sday"].ToString(), xGoal);
            }
        }



    }
}