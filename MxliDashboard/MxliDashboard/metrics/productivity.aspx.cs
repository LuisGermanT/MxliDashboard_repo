﻿using DevExpress.Charts.Native;
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

namespace MxliDashboard.n3_Productivity
{
    public partial class productivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadUpdate();
            if (!Page.IsPostBack)
            {
                loadChartP01(0,"","Week");
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
                string group = ASPxComboBoxGroupInContent.SelectedItem.ToString();
                loadChartP01(1, group, wk);
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

            if (ASPxComboBoxGroupInContent.SelectedIndex > 0)
            {
                idx = 1;
                filter = ASPxComboBoxGroupInContent.SelectedItem.ToString();
            }

            if (ASPxComboBoxVsmInContent.SelectedIndex > 0)
            {
                idx = 2;
                filter = ASPxComboBoxVsmInContent.SelectedItem.ToString();
            }

            if (ASPxComboBoxCellInContent.SelectedIndex > 0)
            {
                idx = 3;
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

        //Labor Productivity Charts
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
                WebChartControl1.Series[2].Points.Clear();
                WebChartControl1.Series[3].Points.Clear();
                WebChartControl1.SeriesSorting = SortingMode.None;
                WebChartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.None;

                string qry = "", query = "", qryBaseline = "";
                string colName = "";
                string xClass = "", prefix = "";
                string sTblName = "", cTblName = "", aTblName = "", vTblName = "";

                //Selects filter according to user's selection, dafult filter is by week
                if (sFilter == "Week")
                {
                    sTblName = " FROM [vw_labor_productivity_by_site_wkly] WHERE [NP_LstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "'";
                    cTblName = " FROM [vw_labor_productivity_by_cell_wkly] WHERE [NP_LstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "' AND";
                    aTblName = " FROM [vw_labor_productivity_by_area_wkly] WHERE [NP_LstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "' AND";
                    vTblName = " FROM [vw_labor_productivity_by_vsm_wkly] WHERE [NP_LstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "' AND";
                    colName = "NP_Week";
                    prefix = "Wk";
                }
                else
                {
                    sTblName = ", [NP_LstWkDay] = (SELECT TOP 1 [NP_LstWkDay] FROM tblLaborProductivity WHERE [NP_Month] = [vw_labor_productivity_by_site_mntly].[NP_Month] AND " +
                               "[NP_Year] = [vw_labor_productivity_by_site_mntly].[NP_Year] Order by [NP_LstWkDay] desc) " +
                               "FROM [vw_labor_productivity_by_site_mntly]";
                    cTblName = ", [NP_LstWkDay] = (SELECT TOP 1 [NP_LstWkDay] FROM tblLaborProductivity WHERE [NP_Month] = [vw_labor_productivity_by_cell_mntly].[NP_Month] AND[NP_Year] = [vw_labor_productivity_by_cell_mntly].[NP_Year] " +
                                " Order by[NP_LstWkDay] desc) FROM [vw_labor_productivity_by_cell_mntly] WHERE ";
                    aTblName = ", [NP_LstWkDay] = (SELECT TOP 1 [NP_LstWkDay] FROM tblLaborProductivity WHERE [NP_Month] = [vw_labor_productivity_by_area_mntly].[NP_Month] AND[NP_Year] = [vw_labor_productivity_by_area_mntly].[NP_Year]" +
                                " Order by[NP_LstWkDay] desc) FROM [vw_labor_productivity_by_area_mntly] WHERE ";
                    vTblName = ", [NP_LstWkDay] = (SELECT TOP 1 [NP_LstWkDay] FROM tblLaborProductivity WHERE [NP_Month] = [vw_labor_productivity_by_vsm_mntly].[NP_Month] AND[NP_Year] = [vw_labor_productivity_by_vsm_mntly].[NP_Year]" +
                                " Order by[NP_LstWkDay] desc) FROM [vw_labor_productivity_by_vsm_mntly] WHERE ";
                    colName = "NP_Month";
                    prefix = "";
                }

                //Validates filter level by site/area/cell, default filter is by site
                switch (indice)
                {
                    case 1:
                        xClass = clase;
                        query = "SELECT TOP 12 * " + vTblName + " [NP_Group] = '" + xClass +
                              "' ORDER BY [NP_LstWkDay] desc, [NP_Group]";
                        qry = "select * from (" + query + ") q1 order by [NP_LstWkDay] asc";
                        qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE '" + xClass + "'";
                        break;
                    case 2:
                        xClass = clase;
                        query = "SELECT TOP 12 * " + aTblName + " [NP_Area] = '" + xClass +
                              "' ORDER BY [NP_LstWkDay] desc, [NP_Area]";
                        qry = "select * from (" + query + ") q1 order by [NP_LstWkDay] asc";
                        qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE '" + xClass + "'";
                        break;
                    case 3:
                        xClass = clase;
                        query = "SELECT TOP 12 * " + cTblName + " [NP_Celda] = '" + xClass +
                              "' ORDER BY [NP_LstWkDay] desc, [NP_Celda]";
                        qry = "select * from (" + query + ") q1 order by [NP_LstWkDay] asc";
                        qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE '" + xClass + "'";
                        break;
                    default:
                        query = "SELECT TOP 12 * " + sTblName +
                              "  ORDER BY [NP_LstWkDay] desc";
                        qry = "select * from (" + query + ") q1 order by [NP_LstWkDay] asc";
                        qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE 'Site'";
                        break;
                }

                //Connection object, retrieves sql data
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dtPareto = dBHelper.QryManager(qry);
                DataTable dtBaseline = dBHelper.GetBaseLine(qryBaseline);

                double xGoal = 0;

                if (dtBaseline.Rows.Count > 0)
                {
                    Double.TryParse(dtBaseline.Rows[0]["TBP_Base"].ToString(), out xGoal);
                }

                xGoal = xGoal / 100;

                foreach (DataRow dr1 in dtPareto.Rows)
                {
                    double eHrs = Convert.ToDouble(dr1["NP_EarnedHrs"].ToString());
                    double tHrs = Convert.ToDouble(dr1["NP_TotalHrs"].ToString());
                    double prod = tHrs == 0 ? 0 : (eHrs / tHrs);

                    WebChartControl1.Series[0].Points.Add(new SeriesPoint(prefix + dr1[colName].ToString(), tHrs));
                    WebChartControl1.Series[1].Points.Add(new SeriesPoint(prefix + dr1[colName].ToString(), eHrs));
                    WebChartControl1.Series[2].Points.Add(new SeriesPoint(prefix + dr1[colName].ToString(), prod));
                    WebChartControl1.Series[3].Points.Add(new SeriesPoint(prefix + dr1[colName].ToString(), xGoal));

                    WebChartControl1.Series[0].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                    WebChartControl1.Series[1].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                    WebChartControl1.Series[2].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                    WebChartControl1.Series[3].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                }
            }
            catch(Exception ex)
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
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=productivity.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
        }

        private void loadUpdate()
        {
            try
            {
                string qry = "SELECT * FROM [tbl_metricsUpdates] WHERE [reportName] = 'lproductivity'";
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
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=productivity.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
        }

    }
}