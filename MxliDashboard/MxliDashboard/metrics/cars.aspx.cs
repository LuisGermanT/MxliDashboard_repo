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
    public partial class cars : System.Web.UI.Page
    {
        int xIndice = 0;
        string xFilter = "SITE";
        string xClass = "All";
        int noActualizar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            this.ASPxComboBoxGV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxGV_SelectedIndexChanged);
            this.ASPxComboBoxPDInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxPDInContent_SelectedIndexChanged);
            this.ASPxComboBoxStaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxStaInContent_SelectedIndexChanged);
            this.ASPxComboBoxOCInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxOCInContent_SelectedIndexChanged);
            loadUpdate();
            if (!Page.IsPostBack)
            {
                chartDefault(0, "SITE", "All", 0);
            }
        }

        protected void cmbox_DataBoundPD(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxPDInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxPDInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundSta(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxStaInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxStaInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundOC(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxOCInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxOCInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noActualizar == 0)
            {
                noActualizar = 1;
                ASPxComboBoxGV.SelectedIndex = 0;
                noActualizar = 0;
                if (ASPxComboBoxV.SelectedIndex == 0)
                {
                    ASPxComboBoxPDInContent.SelectedIndex = 0;
                    ASPxComboBoxStaInContent.SelectedIndex = 0;
                    ASPxComboBoxOCInContent.SelectedIndex = 0;
                    chartDefault(0, "SITE", "All", 0);
                }
                else
                {
                    xIndice = ASPxComboBoxV.SelectedIndex;
                    if (ASPxComboBoxPDInContent.SelectedIndex > 0)
                    {
                        xFilter = "PD";
                        xClass = ASPxComboBoxPDInContent.SelectedItem.ToString();
                    }
                    if (ASPxComboBoxStaInContent.SelectedIndex > 0)
                    {
                        xFilter = "STATUS";
                        xClass = ASPxComboBoxStaInContent.SelectedItem.ToString();
                    }
                    if (ASPxComboBoxOCInContent.SelectedIndex > 0)
                    {
                        xFilter = "OC";
                        xClass = ASPxComboBoxOCInContent.SelectedItem.ToString();
                    }
                    chartDefault(xIndice, xFilter, xClass, ASPxComboBoxGV.SelectedIndex);
                }
            }
        }

        protected void ASPxComboBoxGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noActualizar == 0)
            {
                noActualizar = 1;
                ASPxComboBoxV.SelectedIndex = 0;
                ASPxComboBoxPDInContent.SelectedIndex = 0;
                ASPxComboBoxStaInContent.SelectedIndex = 0;
                ASPxComboBoxOCInContent.SelectedIndex = 0;
                noActualizar = 0;
                chartDefault(0, "SITE", "All", ASPxComboBoxGV.SelectedIndex);
            }
        }

        protected void ASPxComboBoxPDInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noActualizar == 0)
            {
                noActualizar = 1;
                ASPxComboBoxStaInContent.SelectedIndex = 0;
                ASPxComboBoxOCInContent.SelectedIndex = 0;
                ASPxComboBoxGV.SelectedIndex = 0;
                noActualizar = 0;

                xIndice = ASPxComboBoxV.SelectedIndex;
                xFilter = "PD";
                xClass = ASPxComboBoxPDInContent.SelectedItem.ToString();
                if (ASPxComboBoxPDInContent.SelectedIndex == 0)
                {
                    xFilter = "SITE";
                    xClass = "All";
                }
                chartDefault(xIndice, xFilter, xClass, ASPxComboBoxGV.SelectedIndex);
            }
        }

        protected void ASPxComboBoxStaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noActualizar == 0)
            {
                noActualizar = 1;
                ASPxComboBoxPDInContent.SelectedIndex = 0;
                ASPxComboBoxOCInContent.SelectedIndex = 0;
                ASPxComboBoxGV.SelectedIndex = 0;
                noActualizar = 0;

                xIndice = ASPxComboBoxV.SelectedIndex;
                xFilter = "STATUS";
                xClass = ASPxComboBoxStaInContent.SelectedItem.ToString();
                if (ASPxComboBoxStaInContent.SelectedIndex == 0)
                {
                    xFilter = "SITE";
                    xClass = "All";
                }
                chartDefault(xIndice, xFilter, xClass, ASPxComboBoxGV.SelectedIndex);
            }
        }

        protected void ASPxComboBoxOCInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noActualizar == 0)
            {
                noActualizar = 1;
                ASPxComboBoxPDInContent.SelectedIndex = 0;
                ASPxComboBoxStaInContent.SelectedIndex = 0;
                ASPxComboBoxGV.SelectedIndex = 0;
                noActualizar = 0;

                xIndice = ASPxComboBoxV.SelectedIndex;
                xFilter = "OC";
                xClass = ASPxComboBoxOCInContent.SelectedItem.ToString();
                if (ASPxComboBoxOCInContent.SelectedIndex == 0)
                {
                    xFilter = "SITE";
                    xClass = "All";
                }
                chartDefault(xIndice, xFilter, xClass, ASPxComboBoxGV.SelectedIndex);
            }
        }

        protected void chartDefault(int tipo, string xType, string xFilter, int gType)
        {
            WebChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            WebChartControl1.Series["PastDue"].Points.Clear();
            WebChartControl1.Series["Response"].Points.Clear();
            WebChartControl1.Series["Implemented"].Points.Clear();
            WebChartControl1.Series["Goal"].Points.Clear();

            string xTipo = "WEEKLY";
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

            if (gType < 2)
            {
                WebChartControl1.Height = 200;
                string query1 = "select top 13 * from [sta_nivel2] where smetric = 'cars' and stype = '" + xTipo + "' order by id desc";
                string qry1 = "select * from (" + query1 + ") q1 order by id";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt1 = dBHelper.QryManager(qry1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    double xTotal = Convert.ToDouble(dr1["factual"].ToString());
                    double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                    
                    if (dr1["sFilter"].ToString() == "PASTDUE")
                    {
                        WebChartControl1.Series["PastDue"].Points.AddPoint(dr1["sdesc"].ToString(), xTotal);
                        WebChartControl1.Series["PastDue"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    }
                    if (dr1["sFilter"].ToString() == "RESPONSE")
                    {
                        WebChartControl1.Series["Response"].Points.AddPoint(dr1["sdesc"].ToString(), xTotal);
                        WebChartControl1.Series["Response"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    }
                    if (dr1["sFilter"].ToString() == "IMPLEMENTED")
                    {
                        WebChartControl1.Series["Implemented"].Points.AddPoint(dr1["sdesc"].ToString(), xTotal);
                        WebChartControl1.Series["Implemented"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                        WebChartControl1.Series["Goal"].Points.AddPoint(dr1["sdesc"].ToString(), xGoal);
                        WebChartControl1.Series["Goal"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    }
                }
            }
            if (gType == 2)
            {
                WebChartControl1.Height = 400;
                double vSum = 0;
                string qry2 = "SELECT top 10 responsible, count(id) as cValue FROM[DB_1033_Dashboard].[dbo].[tbl_cars] group by responsible order by cValue desc";
                SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
                DataTable dt2 = dBHelper2.QryManager(qry2);
                foreach (DataRow dr2 in dt2.Rows)
                {
                    double xActual = Convert.ToDouble(dr2["cValue"].ToString());
                    vSum = vSum + xActual;
                    WebChartControl1.Series["Implemented"].Points.AddPoint(dr2["responsible"].ToString(), xActual);
                    WebChartControl1.Series["Goal"].Points.AddPoint(dr2["responsible"].ToString(), vSum);
                    WebChartControl1.Series["Implemented"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    WebChartControl1.Series["Goal"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    WebChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
                }
            }
            if (gType == 3)
            {
                WebChartControl1.Height = 200;
                string query2 = "select top 9 * from [sta_nivel2f] where smetric = 'cars' order by id desc";
                string qry2 = "select * from (" + query2 + ") q1 order by id";
                SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
                DataTable dt2 = dBHelper2.QryManager(qry2);
                foreach (DataRow dr2 in dt2.Rows)
                {
                    double xActual = Convert.ToDouble(dr2["factual"].ToString());
                    double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                    if (dr2["sType"].ToString() == "PASTDUE")
                    {
                        WebChartControl1.Series["PastDue"].Points.AddPoint(dr2["scause"].ToString(), xActual);
                        WebChartControl1.Series["PastDue"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    }
                    if (dr2["sType"].ToString() == "RESPONSE")
                    {
                        WebChartControl1.Series["Response"].Points.AddPoint(dr2["scause"].ToString(), xActual);
                        WebChartControl1.Series["Response"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    }
                    if (dr2["sType"].ToString() == "IMPLEMENTED")
                    {
                        WebChartControl1.Series["Implemented"].Points.AddPoint(dr2["scause"].ToString(), xActual);
                        WebChartControl1.Series["Implemented"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                        WebChartControl1.Series["Goal"].Points.AddPoint(dr2["scause"].ToString(), xGoal);
                        WebChartControl1.Series["Goal"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    }
                }
            }
        }

        protected void loadUpdate()
        {
            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [tbl_metricsUpdates] WHERE [reportName] = 'cars'", conn1);
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