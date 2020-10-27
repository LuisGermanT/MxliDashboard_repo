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
            if (!Page.IsPostBack)
            {
                loadChartP01(0, "", "Week");
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

            if (ASPxComboBoxMWInContent.SelectedIndex > 0)
            {
                wk = ASPxComboBoxMWInContent.SelectedItem.ToString();
            }

            int indx = ASPxComboBoxVsmInContent.SelectedIndex;
            if (indx > 0)
            {
                string vsm = ASPxComboBoxVsmInContent.SelectedItem.ToString();
                loadChartP01(1, vsm, wk);
            }
            else
            {
                loadChartP01(0, "", "Week");
            }
        }

        protected void ASPxComboBoxCellInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wk = "Week";

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
                loadChartP01(2, cell, wk);
            }
            else
            {
                loadChartP01(0, "", "Week");
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
            //Week range, from current week - 13 to current week
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;
            FunctionHelper.FncHelper fh = new FunctionHelper.FncHelper();
            DateTime st = fh.GetSaturday(DateTime.Now);

            chartTP01.Series["Series1"].Points.Clear();
            chartTP01.Series["Series2"].Points.Clear();
            chartTP01.Series["Series3"].Points.Clear();
            chartTP01.Series["Series4"].Points.Clear();

            string qry = "", qryBaseline = "";
            string colName = "";
            string xClass = "";
            string sTblName = "", cTblName = "", aTblName = "";

            //Selects filter according to user's selection, dafult filter is by week
            if (sFilter == "Week")
            {
                //sTblName = "[vw_utilization_by_site_wkly] WHERE [TU_Week] BETWEEN " + (semana - 12) + " AND " + semana;
                sTblName = "[vw_utilization_by_site_wkly] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-91).ToShortDateString() + "' AND '" + st.ToShortDateString() + "'";
                //cTblName = "[vw_utilization_by_cell_wkly] WHERE [TU_Week] BETWEEN " + (semana - 12) + " AND " + semana + " AND";
                cTblName = "[vw_utilization_by_cell_wkly] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-91).ToShortDateString() + "' AND '" + st.ToShortDateString() + "' AND";
                //aTblName = "[vw_utilization_by_area_wkly] WHERE [TU_Week] BETWEEN " + (semana - 12) + " AND " + semana + " AND";
                aTblName = "[vw_utilization_by_area_wkly] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-91).ToShortDateString() + "' AND '" + st.ToShortDateString() + "' AND";
                colName = "TU_Week";
            }
            else
            {
                sTblName = "[vw_utilization_by_site_mntly_wd] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-180).ToShortDateString() + "' AND '" + st.ToShortDateString() + "'";
                //cTblName = "[vw_utilization_by_cell_mntly_wd] WHERE ";
                cTblName = "[vw_utilization_by_cell_mntly_wd] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-180).ToShortDateString() + "' AND '" + st.ToShortDateString() + "' AND";
                //aTblName = "[vw_utilization_by_area_mntly_wd] WHERE ";
                aTblName = "[vw_utilization_by_area_mntly_wd] WHERE [TU_LstWkDay] BETWEEN '" + st.AddDays(-180).ToShortDateString() + "' AND '" + st.ToShortDateString() + "' AND";
                colName = "TU_Month";
            }

            //Validates filter level by site/area/cell, default filter is by site
            switch (indice)
            {
                case 1:
                    xClass = clase;
                    qry = "SELECT * FROM " + aTblName + " [TU_Area] = '" + xClass +
                          "' ORDER BY [TU_LstWkDay]"; //+ colName + ", [TU_Area]";
                          //"' Order by [TU_Year] DESC, CASE " +
                          //"  WHEN [TU_Month] = 'Jan' THEN 1 " +
                          //"  WHEN [TU_Month] = 'Feb' THEN 2 " +
                          //"  WHEN [TU_Month] = 'Mar' THEN 3 " +
                          //"  WHEN [TU_Month] = 'Apr' THEN 4 " +
                          //"  WHEN [TU_Month] = 'May' THEN 5 " +
                          //"  WHEN [TU_Month] = 'Jun' THEN 6 " +
                          //"  WHEN [TU_Month] = 'Jul' THEN 7 " +
                          //"  WHEN [TU_Month] = 'Aug' THEN 8 " +
                          //"  WHEN [TU_Month] = 'Sep' THEN 9 " +
                          //"  WHEN [TU_Month] = 'Oct' THEN 10 " +
                          //"  WHEN [TU_Month] = 'Nov' THEN 11 " +
                          //"  WHEN [TU_Month] = 'Dec' THEN 12 " +
                          //"  END, " + colName + ", [TU_Area] ";
                    qryBaseline = "SELECT Top 1 [fGoal] FROM [sta_nivel2] WHERE [sMetric] = 'Utilization' and [sClass] LIKE '" + xClass + "'";
                    break;
                case 2:
                    xClass = clase;
                    qry = "SELECT * FROM " + cTblName + " [TU_Celda] = '" + xClass +
                          "' ORDER BY [TU_LstWkDay]"; //+ colName + ", [TU_Celda]";
                          //"' Order by [TU_Year] DESC, CASE " +
                          //"  WHEN [TU_Month] = 'Jan' THEN 1 " +
                          //"  WHEN [TU_Month] = 'Feb' THEN 2 " +
                          //"  WHEN [TU_Month] = 'Mar' THEN 3 " +
                          //"  WHEN [TU_Month] = 'Apr' THEN 4 " +
                          //"  WHEN [TU_Month] = 'May' THEN 5 " +
                          //"  WHEN [TU_Month] = 'Jun' THEN 6 " +
                          //"  WHEN [TU_Month] = 'Jul' THEN 7 " +
                          //"  WHEN [TU_Month] = 'Aug' THEN 8 " +
                          //"  WHEN [TU_Month] = 'Sep' THEN 9 " +
                          //"  WHEN [TU_Month] = 'Oct' THEN 10 " +
                          //"  WHEN [TU_Month] = 'Nov' THEN 11 " +
                          //"  WHEN [TU_Month] = 'Dec' THEN 12 " +
                          //"  END, " + colName + ", [TU_Celda] ";
                    qryBaseline = "SELECT Top 1 [fGoal] FROM [sta_nivel2] WHERE [sMetric] = 'Utilization' and [sClass] LIKE '" + xClass + "'";
                    break;
                default:
                    qry = "SELECT * FROM " + sTblName +
                          "  ORDER BY [TU_LstWkDay]";
                          //" Order by [TU_Year] DESC, CASE " +
                          //"  WHEN [TU_Month] = 'Jan' THEN 1 " +
                          //"  WHEN [TU_Month] = 'Feb' THEN 2 " +
                          //"  WHEN [TU_Month] = 'Mar' THEN 3 " +
                          //"  WHEN [TU_Month] = 'Apr' THEN 4 " +
                          //"  WHEN [TU_Month] = 'May' THEN 5 " +
                          //"  WHEN [TU_Month] = 'Jun' THEN 6 " +
                          //"  WHEN [TU_Month] = 'Jul' THEN 7 " +
                          //"  WHEN [TU_Month] = 'Aug' THEN 8 " +
                          //"  WHEN [TU_Month] = 'Sep' THEN 9 " +
                          //"  WHEN [TU_Month] = 'Oct' THEN 10 " +
                          //"  WHEN [TU_Month] = 'Nov' THEN 11 " +
                          //"  WHEN [TU_Month] = 'Dec' THEN 12 " +
                          //"  END, " + colName;
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
                //prod = Math.Round(prod, 2);
                chartTP01.Series["Series1"].Points.AddXY(dr1[colName].ToString(), tHrs);
                chartTP01.Series["Series2"].Points.AddXY(dr1[colName].ToString(), eHrs);
                chartTP01.Series["Series3"].Points.AddXY(dr1[colName].ToString(), prod);
                chartTP01.Series["Series4"].Points.AddXY(dr1[colName].ToString(), xGoal);
            }
        }
    }
}