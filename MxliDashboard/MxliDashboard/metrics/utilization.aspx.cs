using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard.n3_Productivity
{
    public partial class Utilization : System.Web.UI.Page
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

        private void loadChartP01(int indice, string clase, string sFilter)
        {
            //Week range, from current week - 13 to current week
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;
            FunctionHelper.FncHelper fh = new FunctionHelper.FncHelper();
            DateTime st = fh.GetSaturday(DateTime.Now);

            WebChartControl1.Series[0].Points.Clear();
            WebChartControl1.Series[1].Points.Clear();
            WebChartControl1.Series[2].Points.Clear();
            WebChartControl1.Series[3].Points.Clear();
            WebChartControl1.SeriesSorting = DevExpress.XtraCharts.SortingMode.None;
            WebChartControl1.SeriesTemplate.SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.None;
            
            string qry = "", qryBaseline = "";
            string colName = "", prefix = "";
            string xClass = "";
            string sTblName = "", cTblName = "", aTblName = "", vTblName = "";

            //Selects filter according to user's selection, dafult filter is by week
            if (sFilter == "Week")
            {
                sTblName = "[vw_utilization_by_site_wkly] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-91).ToShortDateString() + "' AND '" + st.ToShortDateString() + "'";
                cTblName = "[vw_utilization_by_cell_wkly] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-91).ToShortDateString() + "' AND '" + st.ToShortDateString() + "' AND";
                aTblName = "[vw_utilization_by_area_wkly] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-91).ToShortDateString() + "' AND '" + st.ToShortDateString() + "' AND";
                vTblName = "[vw_utilization_by_vsm_wkly] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-91).ToShortDateString() + "' AND '" + st.ToShortDateString() + "' AND";
                colName = "TU_Week";
                prefix = "Wk";
            }
            else
            {
                sTblName = "[vw_utilization_by_site_mntly_wd] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-180).ToShortDateString() + "' AND '" + st.ToShortDateString() + "'";
                cTblName = "[vw_utilization_by_cell_mntly_wd] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-180).ToShortDateString() + "' AND '" + st.ToShortDateString() + "' AND";
                aTblName = "[vw_utilization_by_area_mntly_wd] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-180).ToShortDateString() + "' AND '" + st.ToShortDateString() + "' AND";
                vTblName = "[vw_utilization_by_vsm_mntly_wd] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-180).ToShortDateString() + "' AND '" + st.ToShortDateString() + "' AND";
                colName = "TU_Month";
                prefix = "";
            }

            //Validates filter level by site/area/cell, default filter is by site
            switch (indice)
            {
                case 1:
                    xClass = clase;
                    qry = "SELECT * FROM " + vTblName + " [TU_Group] = '" + xClass +
                          "' ORDER BY [TU_LstWkDay]";
                    qryBaseline = "SELECT Top 1 [fGoal] FROM [sta_nivel2] WHERE [sMetric] = 'Utilization' and [sClass] LIKE 'All'";
                    break;
                case 2:
                    xClass = clase;
                    qry = "SELECT * FROM " + aTblName + " [TU_Area] = '" + xClass +
                          "' ORDER BY [TU_LstWkDay]";
                    qryBaseline = "SELECT Top 1 [fGoal] FROM [sta_nivel2] WHERE [sMetric] = 'Utilization' and [sClass] LIKE '" + xClass + "'";
                    break;
                case 3:
                    xClass = clase;
                    qry = "SELECT * FROM " + cTblName + " [TU_Celda] = '" + xClass +
                          "' ORDER BY [TU_LstWkDay]";
                    qryBaseline = "SELECT Top 1 [fGoal] FROM [sta_nivel2] WHERE [sMetric] = 'Utilization' and [sClass] LIKE '" + xClass + "'";
                    break;
                default:
                    qry = "SELECT * FROM " + sTblName +
                          "  ORDER BY [TU_LstWkDay]";
                    qryBaseline = "SELECT Top 1 [fGoal] FROM [sta_nivel2] WHERE [sMetric] = 'Utilization' and [sClass] LIKE 'All'";
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

            xGoal = xGoal / 100;

            foreach (DataRow dr1 in dtPareto.Rows)
            {
                double eHrs = Convert.ToDouble(dr1["TU_DirectHrs"].ToString());
                double tHrs = Convert.ToDouble(dr1["TU_TotHrs"].ToString());
                double prod = (eHrs / tHrs);

                WebChartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(prefix + dr1[colName].ToString(), tHrs));
                WebChartControl1.Series[1].Points.Add(new DevExpress.XtraCharts.SeriesPoint(prefix + dr1[colName].ToString(), eHrs));
                WebChartControl1.Series[2].Points.Add(new DevExpress.XtraCharts.SeriesPoint(prefix + dr1[colName].ToString(), prod));
                WebChartControl1.Series[3].Points.Add(new DevExpress.XtraCharts.SeriesPoint(prefix + dr1[colName].ToString(), xGoal));

                WebChartControl1.Series[0].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                WebChartControl1.Series[1].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                WebChartControl1.Series[2].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
                WebChartControl1.Series[3].Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
            }

        }

        private void loadUpdate()
        {
            string qry = "SELECT * FROM [tbl_metricsUpdates] WHERE [reportName] = 'utilization'";
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt = dBHelper.QryManager(qry);
            foreach(DataRow dr1 in dt.Rows)
            {
                lbLUpd.Text = dr1["lastUpdateText"].ToString();
            }
        }
    }
}