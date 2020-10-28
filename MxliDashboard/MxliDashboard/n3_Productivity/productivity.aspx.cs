using DevExpress.Charts.Native;
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
            if (!Page.IsPostBack)
            {
                loadChartP01(0,"","Week");
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
                loadChartP01(0, "", wk);
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

        //Labor Productivity Charts
        private void loadChartP01(int indice, string clase, string sFilter)
        {
            //Week range, from current week - 13 to current week
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;
            FunctionHelper.FncHelper fh = new FunctionHelper.FncHelper();
            DateTime st = fh.GetSaturday(DateTime.Now);
            string dtFrom = st.AddDays(-91).ToShortDateString();
            string dtTo = st.ToShortDateString();

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
                //sTblName = " FROM [vw_labor_productivity_by_site_wkly] WHERE [NP_Week] BETWEEN " + (semana - 12) + " AND " + semana;
                sTblName = " FROM [vw_labor_productivity_by_site_wkly] WHERE [NP_LstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "'";
                //cTblName = "[vw_labor_productivity_by_cell_wkly] WHERE [NP_Week] BETWEEN " + (semana - 12) + " AND " + semana + " AND";
                cTblName = " FROM [vw_labor_productivity_by_cell_wkly] WHERE [NP_LstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "' AND";
                //aTblName = "[vw_labor_productivity_by_area_wkly] WHERE [NP_Week] BETWEEN " + (semana - 12) + " AND " + semana + " AND";
                aTblName = " FROM [vw_labor_productivity_by_area_wkly] WHERE [NP_LstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "' AND";
                colName = "NP_Week";
            }
            else
            {
                sTblName = ", [NP_LstWkDay] = (SELECT TOP 1 [NP_LstWkDay] FROM tblLaborProductivity WHERE [NP_Month] = [vw_labor_productivity_by_site_mntly].[NP_Month] AND " +
                           "[NP_Year] = [vw_labor_productivity_by_site_mntly].[NP_Year] Order by [NP_LstWkDay] desc) " +
                           "FROM [vw_labor_productivity_by_site_mntly]";
                //cTblName = "[vw_labor_productivity_by_cell_mntly] WHERE ";
                cTblName = ", [NP_LstWkDay] = (SELECT TOP 1 [NP_LstWkDay] FROM tblLaborProductivity WHERE [NP_Month] = [vw_labor_productivity_by_cell_mntly].[NP_Month] AND[NP_Year] = [vw_labor_productivity_by_cell_mntly].[NP_Year] " +
                            " Order by[NP_LstWkDay] desc) FROM [vw_labor_productivity_by_cell_mntly] WHERE ";
                //aTblName = "[vw_labor_productivity_by_area_mntly] WHERE ";
                aTblName = ", [NP_LstWkDay] = (SELECT TOP 1 [NP_LstWkDay] FROM tblLaborProductivity WHERE [NP_Month] = [vw_labor_productivity_by_area_mntly].[NP_Month] AND[NP_Year] = [vw_labor_productivity_by_area_mntly].[NP_Year]" +
                            " Order by[NP_LstWkDay] desc) FROM [vw_labor_productivity_by_area_mntly] WHERE ";
                colName = "NP_Month";
            }

            //Validates filter level by site/area/cell, default filter is by site
            switch (indice)
            {
                case 1:
                    xClass = clase;
                    qry = "SELECT * " + aTblName + " [NP_Area] = '" + xClass +
                          "' ORDER BY [NP_LstWkDay], [NP_Area]";
                    qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE '" + xClass + "'";
                    break;
                case 2:
                    xClass = clase;
                    qry = "SELECT * " + cTblName + " [NP_Celda] = '" + xClass +
                          "' ORDER BY [NP_LstWkDay], [NP_Celda]"; 
                    qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE '" + xClass + "'";
                    break;
                default:
                    qry = "SELECT * " + sTblName +
                          "  ORDER BY [NP_LstWkDay]";
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