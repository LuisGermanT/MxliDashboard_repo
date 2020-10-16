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
    public partial class pastdue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxAreaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxAreaInContent_SelectedIndexChanged);
            this.ASPxComboBoxPlantInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxPlantInContent_SelectedIndexChanged);
            this.ASPxComboBoxMrpInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxMrpInContent_SelectedIndexChanged);
            if (!Page.IsPostBack)
            {
                chartDefault("SITE", "All");
            }
        }

        protected void cmbox_DataBoundArea(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxAreaInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxAreaInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundPlant(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxPlantInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxPlantInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundMrp(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxMrpInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxAreaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxPlantInContent.SelectedIndex = 0;
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
            if (ASPxComboBoxAreaInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("VSM", ASPxComboBoxAreaInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxPlantInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxAreaInContent.SelectedIndex = 0;
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
            if (ASPxComboBoxPlantInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("PLANT", ASPxComboBoxPlantInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxMrpInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxAreaInContent.SelectedIndex = 0;
            ASPxComboBoxPlantInContent.SelectedIndex = 0;
            if (ASPxComboBoxMrpInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("MRP", ASPxComboBoxMrpInContent.SelectedItem.ToString());
            }
        }

        protected void chartDefault(string xType, string xFilter)
        {
            WebChartControl1.Series["Total"].Points.Clear();
            WebChartControl1.Series["Goal"].Points.Clear();
            WebChartControl1.Series["Planned"].Points.Clear();

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("SELECT sday, fTotal, fGoal, fAcc FROM cht_entregas WHERE smetric = 'pastdue' and sType = '" + xType + "' and sfilter = '" + xFilter + "' ", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xTotal = Convert.ToDouble(dr1["ftotal"].ToString());
                double xGoal = Convert.ToDouble(dr1["facc"].ToString());
                double xPlanned = Convert.ToDouble(dr1["fgoal"].ToString());
                WebChartControl1.Series["Total"].Points.AddPoint(dr1["sday"].ToString(), xTotal);
                WebChartControl1.Series["Goal"].Points.AddPoint(dr1["sday"].ToString(), xPlanned);
                WebChartControl1.Series["Planned"].Points.AddPoint(dr1["sday"].ToString(), xGoal);
            }
        }


    }
}