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
                loadChartP01(0,"");
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

        protected void ASPxComboBoxVsmInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ASPxComboBoxCellInContent.SelectedIndex > 0)
            {
                ASPxComboBoxCellInContent.SelectedIndex = 0;
            }

            int indx = ASPxComboBoxVsmInContent.SelectedIndex;
            if (indx != 0)
            {
                string vsm = ASPxComboBoxVsmInContent.SelectedItem.ToString();
                loadChartP01(1, vsm);
            }
            else
            {
                loadChartP01(1, "");
            }
        }

        protected void ASPxComboBoxCellInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ASPxComboBoxVsmInContent.SelectedIndex > 0)
            {
                ASPxComboBoxVsmInContent.SelectedIndex = 0;
            }

            int idx = ASPxComboBoxCellInContent.SelectedIndex;
            if (idx != 0)
            {
                string cell = ASPxComboBoxCellInContent.SelectedItem.ToString();
                loadChartP01(2, cell);
            }
            else
            {
                loadChartP01(0, "");
            }           
        }

        //Net Productivity Charts
        private void loadChartP01(int indice, string clase)
        {
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;   //semana actual aun no cierra

            chartTP01.Series["Series1"].Points.Clear();
            chartTP01.Series["Series2"].Points.Clear();
            chartTP01.Series["Series3"].Points.Clear();
            chartTP01.Series["Series4"].Points.Clear();

            string qry = "", qryBaseline = "";
            string colName = "";
            string xTipo = "weekly";
            string xClass = "";
            
            switch (indice)
            {
                case 1:
                    xClass = clase;
                    qry = "SELECT * FROM [vw_net_productivity_by_area] WHERE [NP_Area] = '" + xClass +
                          "' ORDER BY CASE WHEN [NP_Month] = 'Jan' THEN 1 " +
                          "  WHEN [NP_Month] = 'Feb' THEN 2 " +
                          "  WHEN [NP_Month] = 'Mar' THEN 3 " +
                          "  WHEN [NP_Month] = 'Apr' THEN 4 " +
                          "  WHEN [NP_Month] = 'May' THEN 5 " +
                          "  WHEN [NP_Month] = 'Jun' THEN 6 " +
                          "  WHEN [NP_Month] = 'Jul' THEN 7 " +
                          "  WHEN [NP_Month] = 'Aug' THEN 8 " +
                          "  WHEN [NP_Month] = 'Sep' THEN 9 " +
                          "  WHEN [NP_Month] = 'Oct' THEN 10 " +
                          "  WHEN [NP_Month] = 'Nov' THEN 11 " +
                          "  WHEN [NP_Month] = 'Dec' THEN 12 " +
                          "END, NP_Week, NP_Year, NP_Area";
                    qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE '" + xClass + "'";
                    colName = "NP_Week";
                    break;
                case 2:
                    xClass = clase;
                    qry = "SELECT * FROM [vw_net_productivity_by_cell] WHERE [NP_Celda] = '" + xClass +
                          "' ORDER BY CASE WHEN NP_Month = 'Jan' THEN 1 " +
                          "  WHEN NP_Month = 'Feb' THEN 2 " +
                          "  WHEN NP_Month = 'Mar' THEN 3 " +
                          "  WHEN NP_Month = 'Apr' THEN 4 " +
                          "  WHEN NP_Month = 'May' THEN 5 " +
                          "  WHEN NP_Month = 'Jun' THEN 6 " +
                          "  WHEN NP_Month = 'Jul' THEN 7 " +
                          "  WHEN NP_Month = 'Aug' THEN 8 " +
                          "  WHEN NP_Month = 'Sep' THEN 9 " +
                          "  WHEN NP_Month = 'Oct' THEN 10 " +
                          "  WHEN NP_Month = 'Nov' THEN 11 " +
                          "  WHEN NP_Month = 'Dec' THEN 12 " +
                          "END, NP_Week, NP_Year, NP_Celda";
                    qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE '" + xClass + "'";
                    colName = "NP_Week";
                    break;
                default:
                    qry = "SELECT * FROM [vw_net_productivity_by_site]" +
                          "  ORDER BY CASE WHEN NP_Month = 'Jan' THEN 1 " +
                          "  WHEN NP_Month = 'Feb' THEN 2 " +
                          "  WHEN NP_Month = 'Mar' THEN 3 " +
                          "  WHEN NP_Month = 'Apr' THEN 4 " +
                          "  WHEN NP_Month = 'May' THEN 5 " +
                          "  WHEN NP_Month = 'Jun' THEN 6 " +
                          "  WHEN NP_Month = 'Jul' THEN 7 " +
                          "  WHEN NP_Month = 'Aug' THEN 8 " +
                          "  WHEN NP_Month = 'Sep' THEN 9 " +
                          "  WHEN NP_Month = 'Oct' THEN 10 " +
                          "  WHEN NP_Month = 'Nov' THEN 11 " +
                          "  WHEN NP_Month = 'Dec' THEN 12 " +
                          "END, NP_Year";
                    qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE 'Site'";
                    colName = "NP_Month";
                    break;
            }

            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dtPareto = dBHelper.ProdN3(qry);
            DataTable dtBaseline = dBHelper.GetBaseLine(qryBaseline);

            double xGoal;
            Double.TryParse(dtBaseline.Rows[0]["TBP_Base"].ToString(), out xGoal);
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