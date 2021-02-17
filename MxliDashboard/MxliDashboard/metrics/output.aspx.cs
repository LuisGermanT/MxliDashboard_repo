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
    public partial class output : System.Web.UI.Page
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
            loadUpdate();
            if (!Page.IsPostBack)
            {
                chartDefault(0, "SITE", "All", 0);
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

        protected void chartDefault(int tipo, string xType, string xFilter, int gType)
        {
            try
            {

                WebChartControl1.Series["Total"].Points.Clear();
                WebChartControl1.Series["Goal"].Points.Clear();
                WebChartControl1.Series["Total"].LegendTextPattern = "";
                WebChartControl1.Series["Goal"].LegendTextPattern = "";

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
                    string query1 = "select top 13 * from [sta_nivel2] where smetric = 'output' and sfilter = '" + xType + "' and sclass = '" + xFilter + "' and stype = '" + xTipo + "' order by id desc";
                    string qry1 = "select * from (" + query1 + ") q1 order by id";
                    SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                    DataTable dt1 = dBHelper.QryManager(qry1);
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        double xTotal = Convert.ToDouble(dr1["factual"].ToString());
                        double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                        WebChartControl1.Series["Total"].Points.AddPoint(dr1["sdesc"].ToString(), xTotal);
                        WebChartControl1.Series["Goal"].Points.AddPoint(dr1["sdesc"].ToString(), xGoal);
                        WebChartControl1.Series["Total"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                        WebChartControl1.Series["Goal"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    }
                }
                if (gType == 2)
                {
                    WebChartControl1.Height = 400;
                    double vSum = 0;
                    string qry2 = "SELECT top 10 smaterial, SUM(fTstdhrs) as cValue FROM[DB_1033_Dashboard].[dbo].[tbl_output] group by smaterial order by cValue desc";
                    SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
                    DataTable dt2 = dBHelper2.QryManager(qry2);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        double xActual = Convert.ToDouble(dr2["cValue"].ToString());
                        vSum = vSum + xActual;
                        WebChartControl1.Series["Total"].Points.AddPoint(dr2["smaterial"].ToString(), xActual);
                        WebChartControl1.Series["Goal"].Points.AddPoint(dr2["smaterial"].ToString(), vSum);
                        WebChartControl1.Series["Total"].Label.TextPattern = "{V: n0}";
                        WebChartControl1.Series["Goal"].Label.TextPattern = "{V: n0}";
                        WebChartControl1.Series["Total"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                        WebChartControl1.Series["Goal"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                        WebChartControl1.Series["Total"].LegendTextPattern = "Total";
                        WebChartControl1.Series["Goal"].LegendTextPattern = "Accum";
                    }
                }
                if (gType == 3)
                {
                    WebChartControl1.Height = 200;
                    string query2 = "select top 6 * from [sta_nivel2f] where smetric = 'output' order by id desc";
                    string qry2 = "select * from (" + query2 + ") q1 order by id";
                    SQLHelper.DBHelper dBHelper2 = new SQLHelper.DBHelper();
                    DataTable dt2 = dBHelper2.QryManager(qry2);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        double xActual = Convert.ToDouble(dr2["factual"].ToString());
                        double xGoal = Convert.ToDouble(dr2["fsum"].ToString());
                        WebChartControl1.Series["Total"].Points.AddPoint(dr2["scause"].ToString(), xActual);
                        WebChartControl1.Series["Goal"].Points.AddPoint(dr2["scause"].ToString(), xGoal);
                        WebChartControl1.Series["Total"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                        WebChartControl1.Series["Goal"].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                int errNum = -99999999;
                string errDesc = "";
                //HttpContext.Current.Items.Add("Exception", ex);
                HttpContext.Current.Session.Add("Exception", ex);

                if (ex is SqlException)
                {
                    // Handle more specific SqlException exception here.  
                    SqlException odbcExc = (SqlException)ex;
                    errNum = odbcExc.Number;
                    errDesc = odbcExc.Message;
                }
                else
                {
                    // Handle generic ones here.
                    errDesc = ex.Message;

                }
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=output.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
        }

        protected void loadUpdate()
        {
            try
            {
                string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
                SqlConnection conn1 = new SqlConnection(myCnStr1);
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM [tbl_metricsUpdates] WHERE [reportName] = 'output'", conn1);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    Label1.Text = dr1["lastUpdateText"].ToString();
                }
            }
            catch (SqlException ex)
            {
                //https ://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/cc645603(v=sql.105)?redirectedfrom=MSDN
                int errNum = ex.Number;
                //HttpContext.Current.Items.Add("Exception", ex);
                HttpContext.Current.Session.Add("Exception", ex);

                string errDesc = ex.Message;
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=output.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
        }


    }
}