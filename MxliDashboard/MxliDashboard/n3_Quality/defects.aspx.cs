using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard.n3_Quality
{
    public partial class defects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxVsmInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxVsmInContent_SelectedIndexChanged);
            this.ASPxComboBoxCellInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxCellInContent_SelectedIndexChanged);
            this.ASPxComboBoxMrpInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxMrpInContent_SelectedIndexChanged);
            this.ASPxComboBoxCauseInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxCauseInContent_SelectedIndexChanged);
            if (!Page.IsPostBack)
            {
                chartDefault("SITE", "All");
            }
        }

        protected void cmbox_DataBoundMrp(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxMrpInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundVsm(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxVsmInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxVsmInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundCell(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxCellInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxCellInContent.SelectedIndex = 0;
        }
        protected void cmbox_DataBoundCause(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxCauseInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxCauseInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxVsmInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
            ASPxComboBoxCellInContent.SelectedIndex = 0;
            ASPxComboBoxCauseInContent.SelectedIndex = 0;
            if (ASPxComboBoxVsmInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("VSM", ASPxComboBoxVsmInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxCellInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxVsmInContent.SelectedIndex = 0;
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
            ASPxComboBoxCauseInContent.SelectedIndex = 0;
            if (ASPxComboBoxCellInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("CELL", ASPxComboBoxCellInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxMrpInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxVsmInContent.SelectedIndex = 0;
            ASPxComboBoxCellInContent.SelectedIndex = 0;
            ASPxComboBoxCauseInContent.SelectedIndex = 0;
            if (ASPxComboBoxMrpInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("MRP", ASPxComboBoxMrpInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxCauseInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxVsmInContent.SelectedIndex = 0;
            ASPxComboBoxCellInContent.SelectedIndex = 0;
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
            if (ASPxComboBoxCauseInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("CAUSE", ASPxComboBoxCauseInContent.SelectedItem.ToString());
            }
        }

        protected void chartDefault(string xType, string xFilter)
        {
            WebChartControl1.Series["Total"].Points.Clear();
            WebChartControl1.Series["Goal"].Points.Clear();

            string query = "SELECT top 13 id, sday, fTotal, fGoal, fAcc FROM cht_calidad WHERE smetric = 'defectos' and sType = '" + xType + "' and sfilter = '" + xFilter + "' ";
            string qry = "select * from (" + query + ") q1 order by id";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry);
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