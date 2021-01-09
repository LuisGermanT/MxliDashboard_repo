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
        int xIndice = 0;
        string xFilter = "SITE";
        string xClass = "All";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxAreaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxAreaInContent_SelectedIndexChanged);
            this.ASPxComboBoxMrpInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxMrpInContent_SelectedIndexChanged);
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            loadUpdate();
            if (!Page.IsPostBack)
            {
                chartDefault(0,"SITE", "All");
            }
        }

        protected void cmbox_DataBoundArea(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxAreaInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxAreaInContent.SelectedIndex = 0;
        }


        protected void cmbox_DataBoundMrp(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxMrpInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxAreaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            xIndice = ASPxComboBoxV.SelectedIndex;
            xFilter = "VSM";
            xClass = ASPxComboBoxAreaInContent.SelectedItem.ToString();
            if (ASPxComboBoxAreaInContent.SelectedIndex == 0)
            {
                xFilter = "SITE";
                xClass = "All";
            }
            chartDefault(xIndice, xFilter, xClass);

        }


        protected void ASPxComboBoxMrpInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            xIndice = ASPxComboBoxV.SelectedIndex;
            xFilter = "MRP";
            xClass = ASPxComboBoxMrpInContent.SelectedItem.ToString();
            if (ASPxComboBoxMrpInContent.SelectedIndex == 0)
            {
                xFilter = "SITE";
                xClass = "All";
            }
            chartDefault(xIndice, xFilter, xClass);
        }

        protected void ASPxComboBoxV_SelectedIndexChanged(object sender, EventArgs e)
        {
            xIndice = ASPxComboBoxV.SelectedIndex;
            if (ASPxComboBoxV.SelectedIndex == 0)
            {
                ASPxComboBoxAreaInContent.SelectedIndex = 0;
                ASPxComboBoxMrpInContent.SelectedIndex = 0;
                chartDefault(0, "SITE", "All");
            }
            chartDefault(xIndice, xFilter, xClass);

        }

        protected void chartDefault(int tipo, string xType, string xFilter)
        {
            WebChartControl1.Series["Total"].Points.Clear();
            WebChartControl1.Series["Goal"].Points.Clear();
            WebChartControl1.Series["Planned"].Points.Clear();

            string xTipo = "weekly";
            if (tipo < 2)
            {
                xTipo = "WEEKLY";
            }
            if (tipo == 2)
            {
                xTipo = "MONTHLY";
            }
            if (tipo == 3)
            {
                xTipo = "QUARTERLY";
            }
            if (tipo == 4)
            {
                xTipo = "YEARLY";
            }

            string query1 = "select top 13 * from [sta_nivel2] where smetric = 'pastdue' and sfilter = '" + xType + "' and sclass = '" + xFilter + "' and stype = '" + xTipo + "' order by id desc";
            string qry1 = "select * from (" + query1 + ") q1 order by id";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xTotal = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                WebChartControl1.Series["Total"].Points.AddPoint(dr1["sdesc"].ToString(), Math.Round((xTotal / 1000000), 2));
                WebChartControl1.Series["Goal"].Points.AddPoint(dr1["sdesc"].ToString(), Math.Round((xGoal / 1000000), 2));
            }
        }

        protected void loadUpdate()
        {
            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [tbl_metricsUpdates] WHERE [reportName] = 'pastdue'", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                Label1.Text = dr1["lastUpdateText"].ToString();
            }
        }


    }
}