﻿using DevExpress.Web;
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
        int noActualizar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxAreaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxAreaInContent_SelectedIndexChanged);
            this.ASPxComboBoxMrpInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxMrpInContent_SelectedIndexChanged);
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            this.ASPxComboBoxGV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxGV_SelectedIndexChanged);
            loadUpdate();
            if (!Page.IsPostBack)
            {
                chartDefault(0,"SITE", "All",0);
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
            if (noActualizar == 0)
            {
                noActualizar = 1;
                ASPxComboBoxMrpInContent.SelectedIndex = 0;
                ASPxComboBoxGV.SelectedIndex = 0;
                noActualizar = 0;

                xIndice = ASPxComboBoxV.SelectedIndex;
                xFilter = "VSM";
                xClass = ASPxComboBoxAreaInContent.SelectedItem.ToString();
                if (ASPxComboBoxAreaInContent.SelectedIndex == 0)
                {
                    xFilter = "SITE";
                    xClass = "All";
                }
                chartDefault(xIndice, xFilter, xClass, ASPxComboBoxGV.SelectedIndex);
            }
        }


        protected void ASPxComboBoxMrpInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noActualizar == 0)
            {
                noActualizar = 1;
                ASPxComboBoxAreaInContent.SelectedIndex = 0;
                ASPxComboBoxGV.SelectedIndex = 0;
                noActualizar = 0;

                xIndice = ASPxComboBoxV.SelectedIndex;
                xFilter = "MRP";
                xClass = ASPxComboBoxMrpInContent.SelectedItem.ToString();
                if (ASPxComboBoxMrpInContent.SelectedIndex == 0)
                {
                    xFilter = "SITE";
                    xClass = "All";
                }
                chartDefault(xIndice, xFilter, xClass, ASPxComboBoxGV.SelectedIndex);
            }
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
                    ASPxComboBoxAreaInContent.SelectedIndex = 0;
                    ASPxComboBoxMrpInContent.SelectedIndex = 0;
                    chartDefault(0, "SITE", "All", 0);
                }
                else
                {
                    xIndice = ASPxComboBoxV.SelectedIndex;
                    if(ASPxComboBoxAreaInContent.SelectedIndex > 0)
                    {
                        xFilter = "VSM";
                        xClass = ASPxComboBoxAreaInContent.SelectedItem.ToString();
                    }
                    if (ASPxComboBoxMrpInContent.SelectedIndex > 0)
                    {
                        xFilter = "MRP";
                        xClass = ASPxComboBoxMrpInContent.SelectedItem.ToString();
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
                ASPxComboBoxAreaInContent.SelectedIndex = 0;
                ASPxComboBoxMrpInContent.SelectedIndex = 0;
                noActualizar = 0;
                chartDefault(0, "SITE", "All", ASPxComboBoxGV.SelectedIndex);
            }
        }

        protected void chartDefault(int tipo, string xType, string xFilter, int gType)
        {
            WebChartControl1.Series["Total"].Points.Clear();
            WebChartControl1.Series["Goal"].Points.Clear();
            WebChartControl1.Series["Total"].LegendTextPattern = "";
            WebChartControl1.Series["Goal"].LegendTextPattern = "";

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

            if (gType < 2)
            {
                WebChartControl1.Height = 200;
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
                    WebChartControl1.Series["Total"].Label.TextPattern = "{V: c2}M";
                    WebChartControl1.Series["Goal"].Label.TextPattern = "{V: c2}M";
                    WebChartControl1.Series["Total"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    WebChartControl1.Series["Goal"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    if(xGoal == 0)
                    {
                        WebChartControl1.Series["Goal"].LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                    }
                    else
                    {
                        WebChartControl1.Series["Goal"].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    }
                }
            }
            if (gType == 2)
            {
                WebChartControl1.Height = 400;
                double vSum = 0;
                string qry2 = "SELECT top 10 smaterial, SUM(fopenvalue) as cValue FROM[DB_1033_Dashboard].[dbo].[tbl_pastdue] group by smaterial order by cValue desc";
                SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
                DataTable dt2 = dBHelper2.QryManager(qry2);
                foreach (DataRow dr2 in dt2.Rows)
                {
                    double xActual = Convert.ToDouble(dr2["cValue"].ToString());
                    vSum = vSum + xActual;
                    WebChartControl1.Series["Total"].Points.AddPoint(dr2["smaterial"].ToString(), Math.Round((xActual / 1000), 2));
                    WebChartControl1.Series["Goal"].Points.AddPoint(dr2["smaterial"].ToString(), Math.Round((vSum / 1000), 2));
                    WebChartControl1.Series["Total"].Label.TextPattern = "{V: c2}K";
                    WebChartControl1.Series["Goal"].Label.TextPattern = "{V: c2}K";
                    WebChartControl1.Series["Total"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    WebChartControl1.Series["Goal"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    WebChartControl1.Series["Total"].LegendTextPattern = "Total";
                    WebChartControl1.Series["Goal"].LegendTextPattern = "Accum";
                }
            }
            if (gType == 3)
            {
                WebChartControl1.Height = 200;
                string query2 = "select top 6 * from [sta_nivel2f] where smetric = 'pastdue' order by id desc";
                string qry2 = "select * from (" + query2 + ") q1 order by id";
                SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
                DataTable dt2 = dBHelper2.QryManager(qry2);
                foreach (DataRow dr2 in dt2.Rows)
                {
                    double xActual = Convert.ToDouble(dr2["factual"].ToString());
                    double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                    WebChartControl1.Series["Total"].Points.AddPoint(dr2["scause"].ToString(), Math.Round((xActual / 1000000), 2));
                    WebChartControl1.Series["Goal"].Points.AddPoint(dr2["scause"].ToString(), Math.Round((xGoal / 1000000), 2));
                    WebChartControl1.Series["Total"].Label.TextPattern = "{V: c2}M";
                    WebChartControl1.Series["Goal"].Label.TextPattern = "{V: c2}M";
                    WebChartControl1.Series["Total"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    WebChartControl1.Series["Goal"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                }
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