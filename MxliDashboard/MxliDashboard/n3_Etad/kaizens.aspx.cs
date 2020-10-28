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
    public partial class kaizens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxAreaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxAreaInContent_SelectedIndexChanged);
            this.ASPxComboBoxCeldaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxCeldaInContent_SelectedIndexChanged);
            this.ASPxComboBoxCausaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxCausaInContent_SelectedIndexChanged);
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

        protected void cmbox_DataBoundCelda(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxCeldaInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxCeldaInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundCausa(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxCausaInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxCausaInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxAreaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxCeldaInContent.SelectedIndex = 0;
            ASPxComboBoxCausaInContent.SelectedIndex = 0;
            if (ASPxComboBoxAreaInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("VSM", ASPxComboBoxAreaInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxCeldaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxAreaInContent.SelectedIndex = 0;
            ASPxComboBoxCausaInContent.SelectedIndex = 0;
            if (ASPxComboBoxCeldaInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("CELL", ASPxComboBoxCeldaInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxCausaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxAreaInContent.SelectedIndex = 0;
            ASPxComboBoxCeldaInContent.SelectedIndex = 0;
            if (ASPxComboBoxCausaInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("CAUSE", ASPxComboBoxCausaInContent.SelectedItem.ToString());
            }
        }

        protected void chartDefault(string xType, string xFilter)
        {
            WebChartControl1.Series["Total"].Points.Clear();
            WebChartControl1.Series["Goal"].Points.Clear();

            string query1 = "SELECT top 13 * FROM cht_etad WHERE smetric = 'kaizens' and sType = '" + xType + "' and sfilter = '" + xFilter + "' order by id desc";
            string qry1 = "select * from (" + query1 + ") q1 order by id";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry1);
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