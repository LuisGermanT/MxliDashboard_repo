using DevExpress.Web;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxliDashboard.FunctionHelper;
using System.Data.SqlClient;

namespace MxliDashboard
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadUpdate();
            if (!Page.IsPostBack)
            {
                loadChartP01(0, "", "Week", 0);
            }
        }

        protected void cmbox_DataBoundVsm(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("Default", "%%");
            //ListEditItem allVSM = new ListEditItem("All VSM", "%%");
            ASPxComboBoxVsmInContent.Items.Insert(0, defaultItem);
            //ASPxComboBoxVsmInContent.Items.Insert(1, allVSM);
            ASPxComboBoxVsmInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundCell(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("Default", "%%");
            //ListEditItem allCell = new ListEditItem("All Cells", "%%");
            ASPxComboBoxCellInContent.Items.Insert(0, defaultItem);
            //ASPxComboBoxCellInContent.Items.Insert(1, allCell);
            ASPxComboBoxCellInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundMrp(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("Default", "%%");
            //ListEditItem allMRP = new ListEditItem("All MRP", "%%");
            ASPxComboBoxMrpInContent.Items.Insert(0, defaultItem);
            //ASPxComboBoxMrpInContent.Items.Insert(1, allMRP);
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundFilters(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("-Select-", 9999);
            ASPxComboBoxMWInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxMWInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxVsmInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wk = "Week";

            if (ASPxComboBoxCellInContent.SelectedIndex > 0)
            {
                ASPxComboBoxCellInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxMrpInContent.SelectedIndex > 0)
            {
                ASPxComboBoxMrpInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxMWInContent.SelectedIndex > 0)
            {
                wk = ASPxComboBoxMWInContent.SelectedItem.ToString();
            }

            if (ASPxComboBoxMCInContent.SelectedIndex > 0)
            {
                ASPxComboBoxMCInContent.SelectedIndex = 0;
            }

            int idx = ASPxComboBoxVsmInContent.SelectedIndex;
            if (idx > 0)
            {
                idx = 1;

                string vsm = ASPxComboBoxVsmInContent.SelectedItem.ToString();
                loadChartP01(idx, vsm, wk, 0);
            }
            else
            {
                loadChartP01(0, "", wk, 0);
            }
        }

        protected void ASPxComboBoxCellInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wk = "Week";

            if (ASPxComboBoxVsmInContent.SelectedIndex > 0)
            {
                ASPxComboBoxVsmInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxMrpInContent.SelectedIndex > 0)
            {
                ASPxComboBoxMrpInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxMWInContent.SelectedIndex > 0)
            {
                wk = ASPxComboBoxMWInContent.SelectedItem.ToString();
            }

            if (ASPxComboBoxMCInContent.SelectedIndex > 0)
            {
                ASPxComboBoxMCInContent.SelectedIndex = 0;
            }

            int idx = ASPxComboBoxCellInContent.SelectedIndex;
            if (idx > 0)
            {
                idx = 2;

                string cell = ASPxComboBoxCellInContent.SelectedItem.ToString();
                loadChartP01(idx, cell, wk, 0);
            }
            else
            {
                loadChartP01(0, "", wk, 0);
            }
        }

        protected void ASPxComboBoxMrpInContent_SelectedIndexChanged(object sender, EventArgs e)
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

            if (ASPxComboBoxMCInContent.SelectedIndex > 0)
            {
                ASPxComboBoxMCInContent.SelectedIndex = 0;
            }

            int idx = ASPxComboBoxMrpInContent.SelectedIndex;
            if (idx > 0)
            {
                idx = 3;

                string mrp = ASPxComboBoxMrpInContent.SelectedItem.ToString();
                loadChartP01(idx, mrp, wk, 0);
            }
            else
            {
                loadChartP01(0, "", wk, 0);
            }
        }

        protected void ASPxComboBoxFiltersInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = "", wk = "";
            int idx = 0, mcFilter = 0;

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

            if (ASPxComboBoxMrpInContent.SelectedIndex > 0)
            {
                idx = 3;
                filter = ASPxComboBoxMrpInContent.SelectedItem.ToString();
            }

            if (ASPxComboBoxMCInContent.SelectedIndex > 0)
            {
                mcFilter = ASPxComboBoxMCInContent.SelectedIndex;
            }

            int sIdx = ASPxComboBoxMWInContent.SelectedIndex;
            if (sIdx > 0)
            {
                wk = ASPxComboBoxMWInContent.SelectedItem.ToString();
                loadChartP01(idx, filter, wk, mcFilter);
            }
            else
            {
                loadChartP01(idx, filter, "Week", mcFilter);
            }
        }

        protected void ASPxComboBoxMCInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wk = "Week";

            if (ASPxComboBoxCellInContent.SelectedIndex > 0)
            {
                ASPxComboBoxCellInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxMrpInContent.SelectedIndex > 0)
            {
                ASPxComboBoxMrpInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxVsmInContent.SelectedIndex > 0)
            {
                ASPxComboBoxVsmInContent.SelectedIndex = 0;
            }

            if (ASPxComboBoxMWInContent.SelectedIndex > 0)
            {
                wk = ASPxComboBoxMWInContent.SelectedItem.ToString();
            }

            int indx = ASPxComboBoxMCInContent.SelectedIndex;
            if (indx > 0)
            {
                loadChartP01(1, "", wk, indx);
            }
            else
            {
                loadChartP01(0, "", wk, 0);
            }
        }

        //Labor Productivity Charts
        private void loadChartP01(int indice, string clase, string sFilter, int mcView)
        {
            try
            {
                //Week range, from current week - 13 to current week
                int yr = DateTime.Now.Year;
                int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
                FunctionHelper.FncHelper fh = new FunctionHelper.FncHelper();
                DateTime st = fh.GetSaturday(DateTime.Now);
                string dtFrom = st.AddDays(-91).ToShortDateString();
                string dtTo = st.ToShortDateString();
                string dtFrom2 = st.AddDays(-300).ToShortDateString();
                string mnth = st.AddDays(-7).ToString("MMM", CultureInfo.InvariantCulture);

                if (semana == 53 || semana == 1)
                {
                    semana = 52;
                    yr = yr - 1;
                }
                else
                {
                    semana = semana - 1;
                }

                WebChartControl1.Series[0].Points.Clear();
                WebChartControl1.Series[1].Points.Clear();
                WebChartControl1.Series[2].Points.Clear();
                WebChartControl1.Series[3].Points.Clear();
                WebChartControl1.SeriesSorting = SortingMode.None;
                WebChartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.None;

                WebChartControl2.Series[0].Points.Clear();
                WebChartControl2.SeriesSorting = SortingMode.None;
                WebChartControl2.SeriesTemplate.SeriesPointsSorting = SortingMode.None;

                string qry = "", qry2 = "", qryBaseline = "";
                string colName = "";
                string xClass = "", prefix = "";
                string sTblName = "", cTblName = "", aTblName = "", mTblName = "", aaTblName = "", acTblName = "", amTblName = "", smTbl = "", cmTbl = "", amTbl = "", mmTbl = "", asmTbl = "", acmTbl = "", aamTbl = "", ammTbl = "";
                string qryOrder = "";

                //Selects filter according to user's selection, dafult filter is by week
                if (sFilter == "Week")
                {
                    sTblName = "[vw_ottr_by_site_wkly] WHERE [TO_sLstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "'";
                    cTblName = "[vw_ottr_by_cell_wkly] WHERE [TO_sLstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "' AND";
                    aTblName = "[vw_ottr_by_area_wkly] WHERE [TO_sLstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "' AND";
                    mTblName = "[vw_ottr_by_mrp_wkly] WHERE [TO_sLstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "' AND";
                    qryBaseline = "SELECT [fGoal] FROM [sta_nivel2] WHERE [sMetric] = 'OTTR' AND [sClass] = 'All' AND [sType] = 'Weekly' AND [sDesc] = [TO_Wk] AND [sLstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "'";
                    qryOrder = "[TO_Wk]";
                    colName = "TO_Wk";
                    prefix = "Wk";

                    aaTblName = "[vw_ottr_by_area_wkly] WHERE [TO_Yr] = " + yr + " AND [TO_Wk] = " + semana;
                    acTblName = "[vw_ottr_by_cell_wkly] WHERE [TO_Yr] = " + yr + " AND [TO_Wk] = " + semana;
                    amTblName = "[vw_ottr_by_mrp_wkly] WHERE [TO_Yr] = " + yr + " AND [TO_Wk] = " + semana;

                    smTbl = "[vw_ottr_misses_by_site_wkly] WHERE [TO_Yr] = " + yr + " AND [TO_Wk] = " + semana;
                    cmTbl = "[vw_ottr_misses_by_cell_wkly] WHERE [TO_Yr] = " + yr + " AND [TO_Wk] = " + semana;
                    amTbl = "[vw_ottr_misses_by_area_wkly] WHERE [TO_Yr] = " + yr + " AND [TO_Wk] = " + semana;
                    mmTbl = "[vw_ottr_misses_by_mrp_wkly] WHERE [TO_Yr] = " + yr + " AND [TO_Wk] = " + semana;

                    asmTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr, TO_Wk FROM " + smTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr,TO_Wk";
                    acmTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr, TO_Wk FROM " + cmTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr,TO_Wk";
                    aamTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr, TO_Wk FROM " + amTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr,TO_Wk";
                    ammTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr, TO_Wk FROM " + mmTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr,TO_Wk";

                }

                if (sFilter == "Month")
                {
                    sTblName = "[vw_ottr_by_site_mntly] WHERE [TO_sLstWkDay] BETWEEN '" + dtFrom2 + "' AND '" + dtTo + "'";
                    cTblName = "[vw_ottr_by_cell_mntly] WHERE [TO_sLstWkDay] BETWEEN '" + dtFrom2 + "' AND '" + dtTo + "' AND";
                    aTblName = "[vw_ottr_by_area_mntly] WHERE [TO_sLstWkDay] BETWEEN '" + dtFrom2 + "' AND '" + dtTo + "' AND";
                    mTblName = "[vw_ottr_by_mrp_mntly] WHERE [TO_sLstWkDay] BETWEEN '" + dtFrom2 + "' AND '" + dtTo + "' AND";
                    qryBaseline = "SELECT [fGoal] FROM [sta_nivel2] WHERE [sMetric] = 'OTTR' AND [sClass] = 'All' AND [sType] = 'Monthly' AND " +
                                    "[sDesc] = [TO_Month] AND [sLstWkDay] BETWEEN '" + dtFrom2 + "' AND '" + dtTo + "'";
                    qryOrder = "[TO_sLstWkDay]";
                    colName = "TO_Month";

                    aaTblName = "[vw_ottr_by_area_mntly] WHERE [TO_Yr] = " + yr + " AND [TO_Month] = '" + mnth + "'";
                    acTblName = "[vw_ottr_by_cell_mntly] WHERE [TO_Yr] = " + yr + " AND [TO_Month] = '" + mnth + "'";
                    amTblName = "[vw_ottr_by_mrp_mntly] WHERE [TO_Yr] = " + yr + " AND [TO_Month] = '" + mnth + "'";

                    smTbl = "[vw_ottr_misses_by_site_mntly] WHERE [TO_Yr] = " + yr + " AND [TO_Month] = '" + mnth + "'";
                    cmTbl = "[vw_ottr_misses_by_cell_mntly] WHERE [TO_Yr] = " + yr + " AND [TO_Month] = '" + mnth + "'";
                    amTbl = "[vw_ottr_misses_by_area_mntly] WHERE [TO_Yr] = " + yr + " AND [TO_Month] = '" + mnth + "'";
                    mmTbl = "[vw_ottr_misses_by_mrp_mntly] WHERE [TO_Yr] = " + yr + " AND [TO_Month] = '" + mnth + "'";

                    asmTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr, TO_Month FROM " + smTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr, TO_Month";
                    acmTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr, TO_Month FROM " + cmTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr, TO_Month";
                    aamTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr, TO_Month FROM " + amTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr, TO_Month";
                    ammTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr, TO_Month FROM " + mmTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr, TO_Month";
                }

                if (sFilter == "Year")
                {
                    sTblName = "[vw_ottr_by_site_yrly] WHERE [TO_Yr] BETWEEN " + (yr - 1) + " AND " + yr;
                    cTblName = "[vw_ottr_by_cell_yrly] WHERE [TO_Yr] BETWEEN " + (yr - 1) + " AND " + yr + " AND ";
                    aTblName = "[vw_ottr_by_area_yrly] WHERE [TO_Yr] BETWEEN " + (yr - 1) + " AND " + yr + " AND ";
                    mTblName = "[vw_ottr_by_mrp_yrly] WHERE [TO_Yr] BETWEEN " + (yr - 1) + " AND " + yr + " AND ";
                    qryBaseline = "SELECT [fGoal] FROM [sta_nivel2] WHERE [sMetric] = 'OTTR' AND [sClass] = 'All' AND [sType] = 'Yearly' AND " +
                                    "[sDesc] = [TO_Yr] AND [sDesc] BETWEEN '" + (yr - 1) + "' AND '" + yr + "'";
                    qryOrder = "[TO_sLstWkDay]";
                    colName = "TO_Yr";

                    aaTblName = "[vw_ottr_by_area_yrly] WHERE [TO_Yr] = " + yr;
                    acTblName = "[vw_ottr_by_cell_yrly] WHERE [TO_Yr] = " + yr;
                    amTblName = "[vw_ottr_by_mrp_yrly] WHERE [TO_Yr] = " + yr;

                    smTbl = "[vw_ottr_misses_by_site_yrly] WHERE [TO_Yr] = " + yr;
                    cmTbl = "[vw_ottr_misses_by_cell_yrly] WHERE [TO_Yr] = " + yr;
                    amTbl = "[vw_ottr_misses_by_area_yrly] WHERE [TO_Yr] = " + yr;
                    mmTbl = "[vw_ottr_misses_by_mrp_yrly] WHERE [TO_Yr] = " + yr;

                    asmTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr FROM " + smTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr";
                    acmTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr FROM " + cmTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr";
                    aamTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr FROM " + amTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr";
                    ammTbl = "SELECT TO_DlyCode, TO_CodeCat, SUM(Qty) as Qty, TO_Yr FROM " + mmTbl + " Group By TO_DlyCode,TO_CodeCat,TO_Yr";
                }

                if (mcView == 0)
                {
                    //Validates filter level by site/area/cell, default filter is by site
                    switch (indice)
                    {
                        case 1:
                            xClass = clase;
                            qry = "SELECT *, [AOP] = (" + qryBaseline + ") FROM " + aTblName + " [TO_rArea] = '" + xClass + "' Order by [TO_Yr], " + qryOrder + ", [TO_rArea]";
                            qry2 = "SELECT * FROM " + amTbl + " AND [TO_rArea] = '" + xClass + "' Order by [TO_Yr], [TO_rArea], [Qty] desc";
                            break;
                        case 2:
                            xClass = clase;
                            qry = "SELECT *, [AOP] = (" + qryBaseline + ")  FROM " + cTblName + " [TO_Cell] = '" + xClass + "' Order by [TO_Yr], " + qryOrder + ", [TO_Cell]";
                            qry2 = "SELECT * FROM " + cmTbl + " AND [TO_Cell] = '" + xClass + "' Order by [TO_Yr], [TO_Cell], [Qty] desc";
                            break;
                        case 3:
                            xClass = clase;
                            qry = "SELECT *, [AOP] = (" + qryBaseline + ") FROM " + mTblName + " [TO_MRP] = '" + xClass + "' Order by [TO_Yr], " + qryOrder + ", [TO_MRP]";
                            qry2 = "SELECT * FROM " + mmTbl + " AND [TO_MRP] = '" + xClass + "' Order by [TO_Yr], [TO_MRP], [Qty] desc";
                            break;
                        default:
                            qry = "SELECT *, [AOP] = (" + qryBaseline + ")  FROM " + sTblName + " Order by [TO_Yr], " + qryOrder;
                            qry2 = "SELECT * FROM " + smTbl + " Order by [TO_Yr], [Qty] desc";
                            break;
                    }
                }
                else
                {
                    prefix = "";
                    if (mcView == 1)
                    {
                        qry = "SELECT * FROM " + aaTblName + " Order by [TO_Yr], [TO_rArea]";
                        qry2 = aamTbl + " Order by [TO_Yr], [Qty] desc";
                        colName = "TO_rArea";
                    }

                    if (mcView == 2)
                    {
                        qry = "SELECT * FROM " + acTblName + " Order by [TO_Yr], [TO_Cell]";
                        qry2 = acmTbl + " Order by [TO_Yr], [Qty] desc";
                        colName = "TO_Cell";
                    }

                    if (mcView == 3)
                    {
                        qry = "SELECT * FROM " + amTblName + " Order by [TO_Yr], [TO_MRP]";
                        qry2 = ammTbl + " Order by [TO_Yr], [Qty] desc";
                        colName = "TO_MRP";
                    }
                }

                //Connection object, retrieves sql data
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dtPareto = dBHelper.QryManager(qry);
                DataTable dtPatero2 = dBHelper.QryManager(qry2);

                if (mcView == 0)
                {
                    foreach (DataRow dr1 in dtPareto.Rows)
                    {
                        double xHit = Convert.ToDouble(dr1["HIT"].ToString());
                        double xTotHrs = Convert.ToDouble(dr1["TotalOrdrs"].ToString());
                        double perc = (xHit / xTotHrs);
                        double xGoal = Convert.ToDouble(dr1["AOP"].ToString()) / 100;

                        WebChartControl1.Series[0].Points.Add(new SeriesPoint(prefix + dr1[colName].ToString(), xHit));
                        WebChartControl1.Series[1].Points.Add(new SeriesPoint(prefix + dr1[colName].ToString(), xTotHrs));
                        WebChartControl1.Series[2].Points.Add(new SeriesPoint(prefix + dr1[colName].ToString(), perc));
                        WebChartControl1.Series[3].Points.Add(new SeriesPoint(prefix + dr1[colName].ToString(), xGoal));

                        WebChartControl1.Series[0].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        WebChartControl1.Series[1].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        WebChartControl1.Series[2].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        WebChartControl1.Series[3].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                    }

                    foreach (DataRow dr1 in dtPatero2.Rows)
                    {
                        double xHit = Convert.ToDouble(dr1["Qty"].ToString());
                        WebChartControl2.Series[0].Points.Add(new SeriesPoint(dr1["TO_DlyCode"].ToString(), xHit));
                        WebChartControl2.Series[0].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                    }
                }
                else
                {
                    foreach (DataRow dr1 in dtPareto.Rows)
                    {
                        double xHit = Convert.ToDouble(dr1["HIT"].ToString());
                        double xTotHrs = Convert.ToDouble(dr1["TotalOrdrs"].ToString());
                        double perc = (xHit / xTotHrs);
                        double xGoal = 1;

                        WebChartControl1.Series[0].Points.Add(new SeriesPoint(dr1[colName].ToString(), xHit));
                        WebChartControl1.Series[1].Points.Add(new SeriesPoint(dr1[colName].ToString(), xTotHrs));
                        WebChartControl1.Series[2].Points.Add(new SeriesPoint(dr1[colName].ToString(), perc));
                        WebChartControl1.Series[3].Points.Add(new SeriesPoint(dr1[colName].ToString(), xGoal));

                        WebChartControl1.Series[0].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        WebChartControl1.Series[1].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        WebChartControl1.Series[2].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        WebChartControl1.Series[3].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                    }

                    foreach (DataRow dr1 in dtPatero2.Rows)
                    {
                        double xHit = Convert.ToDouble(dr1["Qty"].ToString());
                        WebChartControl2.Series[0].Points.Add(new SeriesPoint(dr1["TO_DlyCode"].ToString(), xHit));
                        WebChartControl2.Series[0].Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
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
                //Server.Transfer("~\\CustomErrors\\Errors.aspx?handler=OTTR.aspx&msg=" + errNum + "&errDesc=" + errDesc, true);
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=OTTR.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }

        }

        private void loadUpdate()
        {
            try
            {
                string qry = "SELECT * FROM [tbl_metricsUpdates] WHERE [reportName] = 'ottr'";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt = dBHelper.QryManager(qry);
                foreach (DataRow dr1 in dt.Rows)
                {
                    lbLUpd.Text = dr1["lastUpdateText"].ToString();
                }
            }
            catch(SqlException ex)
            {
                //https ://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/cc645603(v=sql.105)?redirectedfrom=MSDN
                int errNum = ex.Number;
                //HttpContext.Current.Items.Add("Exception", ex);
                HttpContext.Current.Session.Add("Exception", ex);
                string errDesc = ex.Message;
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=OTTR.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
           
        }
    }
}