using DevExpress.Web;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard.n3_Inventory
{
    public partial class scrap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadUpdate();
            if (!Page.IsPostBack)
            {
                loadChartP01(0, "", "Week");
            }
        }

        protected void cmbox_DataBoundGroup(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxGroupInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxGroupInContent.SelectedIndex = 0;
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

        protected void cmbox_DataBoundFilters(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("-Select-", 9999);
            ASPxComboBoxMWInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxMWInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxGroupInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wk = "Week";

            if (ASPxComboBoxVsmInContent.SelectedIndex > 0)
            {
                ASPxComboBoxVsmInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxCellInContent.SelectedIndex > 0)
            {
                ASPxComboBoxCellInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxMWInContent.SelectedIndex > 0)
            {
                wk = ASPxComboBoxMWInContent.SelectedItem.ToString();
            }

            int indx = ASPxComboBoxGroupInContent.SelectedIndex;
            if (indx > 0)
            {
                string vsm = ASPxComboBoxGroupInContent.SelectedItem.ToString();
                loadChartP01(1, vsm, wk);
            }
            else
            {
                loadChartP01(0, "", wk);
            }
        }

        protected void ASPxComboBoxVsmInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wk = "Week";

            if (ASPxComboBoxGroupInContent.SelectedIndex > 0)
            {
                ASPxComboBoxGroupInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxCellInContent.SelectedIndex > 0)
            {
                ASPxComboBoxCellInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxMWInContent.SelectedIndex > 0)
            {
                wk = ASPxComboBoxMWInContent.SelectedItem.ToString();
            }

            int indx = ASPxComboBoxVsmInContent.SelectedIndex;
            if (indx > 0)
            {
                string vsm = ASPxComboBoxVsmInContent.SelectedItem.ToString();
                loadChartP01(2, vsm, wk);
            }
            else
            {
                loadChartP01(0, "", wk);
            }
        }

        protected void ASPxComboBoxCellInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wk = "Week";

            if (ASPxComboBoxGroupInContent.SelectedIndex > 0)
            {
                ASPxComboBoxGroupInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxVsmInContent.SelectedIndex > 0)
            {
                ASPxComboBoxVsmInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxMWInContent.SelectedIndex > 0)
            {
                wk = ASPxComboBoxMWInContent.SelectedItem.ToString();
            }

            int idx = ASPxComboBoxCellInContent.SelectedIndex;
            if (idx > 0)
            {
                string cell = ASPxComboBoxCellInContent.SelectedItem.ToString();
                loadChartP01(3, cell, wk);
            }
            else
            {
                loadChartP01(0, "", wk);
            }
        }

        protected void ASPxComboBoxFiltersInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = "", wk = "";
            int idx = 0;

            if (ASPxComboBoxVsmInContent.SelectedIndex > 0)
            {
                idx = 1;
                filter = ASPxComboBoxVsmInContent.SelectedItem.ToString();
            }

            if (ASPxComboBoxCellInContent.SelectedIndex > 0)
            {
                idx = 2;
                filter = ASPxComboBoxCellInContent.SelectedItem.ToString();
            }

            int sIdx = ASPxComboBoxMWInContent.SelectedIndex;
            if (sIdx > 0)
            {
                wk = ASPxComboBoxMWInContent.SelectedItem.ToString();
                loadChartP01(idx, filter, wk);
            }
            else
            {
                loadChartP01(idx, filter, "Week");
            }
        }


        private void loadChartP01(int indice, string clase, string sFilter)
        {
            try
            {

                //Week range, from current week - 13 to current week
                int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
                semana = semana - 1;
                FunctionHelper.FncHelper fh = new FunctionHelper.FncHelper();
                DateTime st = fh.GetSaturday(DateTime.Now);
                string dtFrom = st.AddDays(-91).ToShortDateString();
                string dtTo = st.ToShortDateString();

                WebChartControl1.Series[0].Points.Clear();
                WebChartControl1.Series[1].Points.Clear();
                WebChartControl1.SeriesSorting = SortingMode.None;
                WebChartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.None;

                string query = "", qry = "", qryBaseline = "";
                string colName = "", prefix = "", qFilter = "";
                string xClass = "";
                string sTblName = "", cTblName = "", aTblName = "", vTblName = "";

                //Selects filter according to user's selection, dafult filter is by week
                if (sFilter == "Week")
                {
                    sTblName = " FROM [vw_scrap_weekly_by_site]";
                    aTblName = " FROM [vw_scrap_weekly_by_area] WHERE ";
                    cTblName = " FROM [vw_scrap_weekly_by_cell] WHERE ";
                    vTblName = " FROM [vw_scrap_weekly_by_vsm] WHERE ";
                    colName = "TCS_Week";
                    prefix = "Wk";
                    qFilter = "Weekly";
                }
                else
                {
                    sTblName = " FROM [vw_scrap_monthly_by_site]";
                    aTblName = " FROM [vw_scrap_monthly_by_area] WHERE ";
                    cTblName = " FROM [vw_scrap_monthly_by_cell] WHERE ";
                    vTblName = " FROM [vw_scrap_monthly_by_vsm] WHERE ";
                    colName = "sMontName";
                    prefix = "";
                    qFilter = "Monthly";
                }

                //Validates filter level by site/area/cell, default filter is by site
                switch (indice)
                {
                    case 1:
                        xClass = clase;
                        query = "SELECT TOP 12 * " + vTblName + " [TCS_Group] = '" + xClass +
                              "' ORDER BY [sLstWkDay] desc, [TCS_Group]";
                        qry = "select * from (" + query + ") q1 order by [sLstWkDay] asc";
                        qryBaseline = "SELECT * FROM [sta_nivel2] WHERE [sMetric] = 'Scrap' AND [sFilter] = 'VSM' and [sType] = '" + qFilter + "' and [sClass] = '" + xClass + "'";
                        break;
                    case 2:
                        xClass = clase;
                        query = "SELECT TOP 12 * " + aTblName + " [TCS_Area] = '" + xClass +
                              "' ORDER BY [sLstWkDay] desc, [TCS_Area]";
                        qry = "select * from (" + query + ") q1 order by [sLstWkDay] asc";
                        qryBaseline = "SELECT * FROM [sta_nivel2] WHERE [sMetric] = 'Scrap' AND [sFilter] = 'VSM' and [sType] = '" + qFilter + "' and [sClass] = '" + xClass + "'";
                        break;
                    case 3:
                        xClass = clase;
                        query = "SELECT TOP 12 * " + cTblName + " [TCS_Cell] = '" + xClass +
                              "' ORDER BY [sLstWkDay] desc, [TCS_Cell]";
                        qry = "select * from (" + query + ") q1 order by [sLstWkDay] asc";
                        qryBaseline = "SELECT * FROM [sta_nivel2] WHERE [sMetric] = 'Scrap' AND [sFilter] = 'Cell' and [sType] = '" + qFilter + "' and [sClass] = '" + xClass + "'";
                        break;
                    default:
                        query = "SELECT TOP 12 * " + sTblName +
                              "  ORDER BY [sLstWkDay] desc";
                        qry = "select * from (" + query + ") q1 order by [sLstWkDay] asc";
                        qryBaseline = "SELECT * FROM [sta_nivel2] WHERE [sMetric] = 'Scrap' AND [sFilter] = 'Site' and [sType] = '" + qFilter + "'";
                        break;
                }

                //Connection object, retrieves sql data
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dtPareto = dBHelper.QryManager(qry);
                DataTable dtBaseline = dBHelper.QryManager(qryBaseline);

                double xGoal = 0;

                if (dtBaseline.Rows.Count > 0)
                {
                    Double.TryParse(dtBaseline.Rows[0]["fGoal"].ToString(), out xGoal);
                }

                var maxVal = 0;
                if (dtPareto.Rows.Count > 0)
                {
                    maxVal = Convert.ToInt32(dtPareto.Compute("Max([TCS_Amount])", string.Empty));
                }

                AxisLabel lbaxisY = ((XYDiagram)WebChartControl1.Diagram).AxisY.Label;
                string lbFmt = "";
                int div = 0;

                if (maxVal > 999999)
                {
                    lbFmt = "{V:c2}" + " M";
                    WebChartControl1.Series[0].CrosshairLabelPattern = lbFmt;
                    WebChartControl1.Series[0].Label.TextPattern = lbFmt;
                    WebChartControl1.Series[1].CrosshairLabelPattern = lbFmt;
                    WebChartControl1.Series[1].Label.TextPattern = lbFmt;
                    lbaxisY.TextPattern = lbFmt;
                    div = 1000000;
                }
                else if (maxVal <= 999999)
                {
                    lbFmt = "{V:c2}" + " K";
                    WebChartControl1.Series[0].CrosshairLabelPattern = lbFmt;
                    WebChartControl1.Series[0].Label.TextPattern = lbFmt;
                    WebChartControl1.Series[1].CrosshairLabelPattern = lbFmt;
                    WebChartControl1.Series[1].Label.TextPattern = lbFmt;
                    lbaxisY.TextPattern = lbFmt;
                    div = 1000;
                }

                xGoal = xGoal / div;

                foreach (DataRow dr1 in dtPareto.Rows)
                {
                    double tScrap = Convert.ToDouble(dr1["TCS_Amount"].ToString());

                    tScrap = tScrap / div;

                    WebChartControl1.Series[0].Points.Add(new SeriesPoint(prefix + dr1[colName].ToString(), tScrap));
                    WebChartControl1.Series[1].Points.Add(new SeriesPoint(prefix + dr1[colName].ToString(), xGoal));
                    WebChartControl1.Series[0].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                    WebChartControl1.Series[1].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
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
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=Scrap.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
        }

        private void loadUpdate()
        {
            try
            {
                string qry = "SELECT * FROM [tbl_metricsUpdates] WHERE [reportName] = 'scrap'";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt = dBHelper.QryManager(qry);
                foreach (DataRow dr1 in dt.Rows)
                {
                    lbLUpd.Text = dr1["lastUpdateText"].ToString();
                }
            }
            catch (SqlException ex)
            {
                //https ://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/cc645603(v=sql.105)?redirectedfrom=MSDN
                int errNum = ex.Number;
                //HttpContext.Current.Items.Add("Exception", ex);
                HttpContext.Current.Session.Add("Exception", ex);
                string errDesc = ex.Message;
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=Scrap.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
        }
    }
}