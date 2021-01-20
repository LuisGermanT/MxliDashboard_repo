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
    public partial class inventory : System.Web.UI.Page
    {
        int xIndice = 0;
        string xFilter = "SITE";
        string xClass = "All";
        int noActualizar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxV_SelectedIndexChanged);
            this.ASPxComboBoxGV.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxGV_SelectedIndexChanged);
            this.ASPxComboBoxVsmInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxVsmInContent_SelectedIndexChanged);
            this.ASPxComboBoxCellInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxCellInContent_SelectedIndexChanged);
            this.ASPxComboBoxMrpInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxMrpInContent_SelectedIndexChanged);
            this.ASPxComboBoxPfepInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxPfepInContent_SelectedIndexChanged);
            loadUpdate();
            if (!Page.IsPostBack)
            {
                chartDefault(0,"SITE", "All",0);
            }
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

        protected void cmbox_DataBoundMrp(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxMrpInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
        }            

        protected void cmbox_DataBoundPfep(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxPfepInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxPfepInContent.SelectedIndex = 0;
        }

        protected void grid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Total")
            {
                decimal price = (decimal)e.GetListSourceFieldValue("totQty");
                decimal quantity = (decimal)e.GetListSourceFieldValue("Price");
                e.Value = price * quantity;
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
                    ASPxComboBoxVsmInContent.SelectedIndex = 0;
                    ASPxComboBoxCellInContent.SelectedIndex = 0;
                    ASPxComboBoxMrpInContent.SelectedIndex = 0;
                    ASPxComboBoxPfepInContent.SelectedIndex = 0;
                    chartDefault(0, "SITE", "All", 0);
                }
                else
                {
                    xIndice = ASPxComboBoxV.SelectedIndex;
                    if (ASPxComboBoxVsmInContent.SelectedIndex > 0)
                    {
                        xFilter = "VSM";
                        xClass = ASPxComboBoxVsmInContent.SelectedItem.ToString();
                    }
                    if (ASPxComboBoxCellInContent.SelectedIndex > 0)
                    {
                        xFilter = "CELL";
                        xClass = ASPxComboBoxCellInContent.SelectedItem.ToString();
                    }
                    if (ASPxComboBoxMrpInContent.SelectedIndex > 0)
                    {
                        xFilter = "MRP";
                        xClass = ASPxComboBoxMrpInContent.SelectedItem.ToString();
                    }
                    if (ASPxComboBoxPfepInContent.SelectedIndex > 0)
                    {
                        xFilter = "PFEP";
                        xClass = ASPxComboBoxPfepInContent.SelectedItem.ToString();
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
                ASPxComboBoxVsmInContent.SelectedIndex = 0;
                ASPxComboBoxCellInContent.SelectedIndex = 0;
                ASPxComboBoxMrpInContent.SelectedIndex = 0;
                ASPxComboBoxPfepInContent.SelectedIndex = 0;
                noActualizar = 0;
                chartDefault(0, "SITE", "All", ASPxComboBoxGV.SelectedIndex);
            }
        }

        protected void ASPxComboBoxVsmInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noActualizar == 0)
            {
                noActualizar = 1;
                ASPxComboBoxCellInContent.SelectedIndex = 0;
                ASPxComboBoxMrpInContent.SelectedIndex = 0;
                ASPxComboBoxPfepInContent.SelectedIndex = 0;
                ASPxComboBoxGV.SelectedIndex = 0;
                noActualizar = 0;

                xIndice = ASPxComboBoxV.SelectedIndex;
                xFilter = "VSM";
                xClass = ASPxComboBoxVsmInContent.SelectedItem.ToString();
                if (ASPxComboBoxVsmInContent.SelectedIndex == 0)
                {
                    xFilter = "SITE";
                    xClass = "All";
                }
                chartDefault(xIndice, xFilter, xClass, ASPxComboBoxGV.SelectedIndex);
            }
        }

        protected void ASPxComboBoxCellInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noActualizar == 0)
            {
                noActualizar = 1;
                ASPxComboBoxVsmInContent.SelectedIndex = 0;
                ASPxComboBoxMrpInContent.SelectedIndex = 0;
                ASPxComboBoxPfepInContent.SelectedIndex = 0;
                ASPxComboBoxGV.SelectedIndex = 0;
                noActualizar = 0;

                xIndice = ASPxComboBoxV.SelectedIndex;
                xFilter = "CELL";
                xClass = ASPxComboBoxCellInContent.SelectedItem.ToString();
                if (ASPxComboBoxCellInContent.SelectedIndex == 0)
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
                ASPxComboBoxVsmInContent.SelectedIndex = 0;
                ASPxComboBoxCellInContent.SelectedIndex = 0;
                ASPxComboBoxPfepInContent.SelectedIndex = 0;
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

        protected void ASPxComboBoxPfepInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noActualizar == 0)
            {
                noActualizar = 1;
                ASPxComboBoxVsmInContent.SelectedIndex = 0;
                ASPxComboBoxCellInContent.SelectedIndex = 0;
                ASPxComboBoxMrpInContent.SelectedIndex = 0;
                ASPxComboBoxGV.SelectedIndex = 0;
                noActualizar = 0;

                xIndice = ASPxComboBoxV.SelectedIndex;
                xFilter = "PFEP";
                xClass = ASPxComboBoxPfepInContent.SelectedItem.ToString();
                if (ASPxComboBoxPfepInContent.SelectedIndex == 0)
                {
                    xFilter = "SITE";
                    xClass = "All";
                }
                chartDefault(xIndice, xFilter, xClass, ASPxComboBoxGV.SelectedIndex);
            }
        }

        protected void chartDefault(int tipo, string xType, string xFilter, int gType)
        {
            WebChartControl1.Series["Total"].Points.Clear();
            WebChartControl1.Series["Goal"].Points.Clear();
            WebChartControl1.Series["Adj"].Points.Clear();
            WebChartControl1.Series["Total"].LegendTextPattern = "";
            WebChartControl1.Series["Goal"].LegendTextPattern = "";
            WebChartControl1.Series["Adj"].Visible = true;

            string xTipo = "DAILY";
            if (tipo < 1)
            {
                xTipo = "DAILY";
            }
            if (tipo == 1)
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
                string query1 = "select top 13 * from [sta_nivel2] where smetric = 'inventory' and sfilter = '" + xType + "' and sclass = '" + xFilter + "' and stype = '" + xTipo + "' order by id desc";
                string qry1 = "select * from (" + query1 + ") q1 order by id";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt1 = dBHelper.QryManager(qry1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    double xTotal = Convert.ToDouble(dr1["factual"].ToString());
                    double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                    double xAcc = regresaAccountBalance(xType,xTipo, dr1["sdesc"].ToString());
                    WebChartControl1.Series["Total"].Points.AddPoint(dr1["sdesc"].ToString(), Math.Round((xTotal / 1000000), 2));
                    WebChartControl1.Series["Goal"].Points.AddPoint(dr1["sdesc"].ToString(), Math.Round((xGoal / 1000000), 2));
                    WebChartControl1.Series["Adj"].Points.AddPoint(dr1["sdesc"].ToString(), Math.Round((xAcc / 1000000), 2));
                    WebChartControl1.Series["Total"].Label.TextPattern = "{V: c2}M";
                    WebChartControl1.Series["Goal"].Label.TextPattern = "{V: c2}M";
                    WebChartControl1.Series["Adj"].Label.TextPattern = "{V: c2}M";
                    WebChartControl1.Series["Total"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    WebChartControl1.Series["Goal"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    WebChartControl1.Series["Adj"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                }
            }
            if (gType == 2)
            {
                WebChartControl1.Height = 400;
                double vSum = 0;
                string qry2 = "SELECT top 10 smaterial, SUM(total) as cValue FROM[DB_1033_Dashboard].[dbo].[tbl_inventario] group by smaterial order by cValue desc";
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
                    WebChartControl1.Series["Adj"].Visible = false;
                }
            }
            if (gType == 3)
            {
                WebChartControl1.Height = 200;
                string query2 = "select top 6 * from [sta_nivel2f] where smetric = 'inventory' order by id desc";
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
                    WebChartControl1.Series["Adj"].Visible = false;
                }
            }
        }

        protected void loadUpdate()
        {
            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [tbl_metricsUpdates] WHERE [reportName] = 'inventory'", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                Label1.Text =  dr1["lastUpdateText"].ToString();
            }
        }

        protected double regresaAccountBalance(string xFilter, string xType, string xDesc)
        {
            double valor = 0;
            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [tbl_thirdPoint] WHERE [smetric] = 'inventory' and sfilter = '"+xFilter+"' and stype = '"+xType+"' and sdesc = '"+xDesc+"'", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                valor = Convert.ToDouble(dr1["fvalue"].ToString());
            }
            return valor;
        }


    }
}