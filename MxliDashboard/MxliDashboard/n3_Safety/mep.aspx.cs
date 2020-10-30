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
        public int bandChange = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxAreaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxAreaInContent_SelectedIndexChanged);
            this.ASPxComboBoxLinInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxLinInContent_SelectedIndexChanged);
            this.ASPxComboBoxFunInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxFunInContent_SelectedIndexChanged);
            this.ASPxComboBoxIssInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxIssInContent_SelectedIndexChanged);
            this.ASPxComboBoxStaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxStaInContent_SelectedIndexChanged);
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

        protected void cmbox_DataBoundLin(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxLinInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxLinInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundFun(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxFunInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxFunInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundIss(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxIssInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxIssInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundSta(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxStaInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxStaInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxAreaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                bandChange = 1;
                ASPxComboBoxLinInContent.SelectedIndex = 0;
                ASPxComboBoxFunInContent.SelectedIndex = 0;
                ASPxComboBoxIssInContent.SelectedIndex = 0;
                ASPxComboBoxStaInContent.SelectedIndex = 0;
                bandChange = 0;
                if (ASPxComboBoxAreaInContent.SelectedIndex == 0)
                {
                    chartDefault("SITE", "All");
                }
                else
                {
                    chartDefault("VSM", ASPxComboBoxAreaInContent.SelectedItem.ToString());
                }
            }
        }

        protected void ASPxComboBoxLinInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                bandChange = 1;
                ASPxComboBoxAreaInContent.SelectedIndex = 0;
                ASPxComboBoxFunInContent.SelectedIndex = 0;
                ASPxComboBoxIssInContent.SelectedIndex = 0;
                ASPxComboBoxStaInContent.SelectedIndex = 0;
                bandChange = 0;
                if (ASPxComboBoxLinInContent.SelectedIndex == 0)
                {
                    chartDefault("SITE", "All");
                }
                else
                {
                    chartDefault("LINE", ASPxComboBoxLinInContent.SelectedItem.ToString());
                }
            }
        }

        protected void ASPxComboBoxFunInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                bandChange = 1;
                ASPxComboBoxAreaInContent.SelectedIndex = 0;
                ASPxComboBoxLinInContent.SelectedIndex = 0;
                ASPxComboBoxIssInContent.SelectedIndex = 0;
                ASPxComboBoxStaInContent.SelectedIndex = 0;
                bandChange = 0;
                if (ASPxComboBoxFunInContent.SelectedIndex == 0)
                {
                    chartDefault("SITE", "All");
                }
                else
                {
                    chartDefault("FUNCTION", ASPxComboBoxFunInContent.SelectedItem.ToString());
                }
            }
        }

        protected void ASPxComboBoxIssInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                bandChange = 1;
                ASPxComboBoxAreaInContent.SelectedIndex = 0;
                ASPxComboBoxLinInContent.SelectedIndex = 0;
                ASPxComboBoxFunInContent.SelectedIndex = 0;
                ASPxComboBoxStaInContent.SelectedIndex = 0;
                bandChange = 0;
                if (ASPxComboBoxIssInContent.SelectedIndex == 0)
                {
                    chartDefault("SITE", "All");
                }
                else
                {
                    chartDefault("ISSUE", ASPxComboBoxIssInContent.SelectedItem.ToString());
                }
            }
        }

        protected void ASPxComboBoxStaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                bandChange = 1;
                ASPxComboBoxAreaInContent.SelectedIndex = 0;
                ASPxComboBoxLinInContent.SelectedIndex = 0;
                ASPxComboBoxFunInContent.SelectedIndex = 0;
                ASPxComboBoxIssInContent.SelectedIndex = 0;
                bandChange = 0;
                if (ASPxComboBoxStaInContent.SelectedIndex == 0)
                {
                    chartDefault("SITE", "All");
                }
                else
                {
                    chartDefault("STATUS", ASPxComboBoxStaInContent.SelectedItem.ToString());
                }
            }
        }

        protected void chartDefault(string xType, string xFilter)
        {
            WebChartControl1.Series["Total"].Points.Clear();
            WebChartControl1.Series["Goal"].Points.Clear();

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("SELECT sday, fTotal, fGoal, fAcc FROM cht_seguridad WHERE smetric = 'meps' and sType = '" + xType + "' and sfilter = '" + xFilter + "' order by id", conn1);
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