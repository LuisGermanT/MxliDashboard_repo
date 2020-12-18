using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
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
            //Week range, from current week - 13 to current week
            int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            semana = semana - 1;
            FunctionHelper.FncHelper fh = new FunctionHelper.FncHelper();
            DateTime st = fh.GetSaturday(DateTime.Now);
            string dtFrom = st.AddDays(-91).ToShortDateString();
            string dtTo = st.ToShortDateString();

            chartTP01.Series["Series1"].Points.Clear();
            chartTP01.Series["Series2"].Points.Clear();

            string query = "", qry = "", qryBaseline = "";
            string colName = "";
            string xClass = "";
            string sTblName = "", cTblName = "", aTblName = "", vTblName = "";

            //Selects filter according to user's selection, dafult filter is by week
            if (sFilter == "Week")
            {
                //sTblName = " FROM [vw_scrap_weekly_by_site] WHERE [sLstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "'";
                sTblName = " FROM [vw_scrap_weekly_by_site]";
                //aTblName = " FROM [vw_scrap_weekly_by_area] WHERE [sLstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "' AND";
                aTblName = " FROM [vw_scrap_weekly_by_area] WHERE ";
                //cTblName = " FROM [vw_scrap_weekly_by_cell] WHERE [sLstWkDay] BETWEEN '" + dtFrom + "' AND '" + dtTo + "' AND";
                cTblName = " FROM [vw_scrap_weekly_by_cell] WHERE ";
                vTblName = " FROM [vw_scrap_weekly_by_vsm] WHERE ";
                colName = "TCS_Week";
            }
            else
            {
                sTblName = " FROM [vw_scrap_monthly_by_site]";
                aTblName = " FROM [vw_scrap_monthly_by_area] WHERE ";
                cTblName = " FROM [vw_scrap_monthly_by_cell] WHERE ";
                vTblName = " FROM [vw_scrap_monthly_by_vsm] WHERE ";
                colName = "sMontName";
            }

            //Validates filter level by site/area/cell, default filter is by site
            switch (indice)
            {
                case 1:
                    xClass = clase;
                    query = "SELECT TOP 12 * " + vTblName + " [TCS_Group] = '" + xClass +
                          "' ORDER BY [sLstWkDay] desc, [TCS_Group]";
                    qry = "select * from (" + query + ") q1 order by [sLstWkDay] asc";
                    qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE '" + xClass + "'";
                    break;
                case 2:
                    xClass = clase;
                    query = "SELECT TOP 12 * " + aTblName + " [TCS_Area] = '" + xClass +
                          "' ORDER BY [sLstWkDay] desc, [TCS_Area]";
                    qry = "select * from (" + query + ") q1 order by [sLstWkDay] asc";
                    qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE '" + xClass + "'";
                    break;
                case 3:
                    xClass = clase;
                    query = "SELECT TOP 12 * " + cTblName + " [TCS_Cell] = '" + xClass +
                          "' ORDER BY [sLstWkDay] desc, [TCS_Cell]";
                    qry = "select * from (" + query + ") q1 order by [sLstWkDay] asc";
                    qryBaseline = "SELECT * FROM [tblBaseProductivity] WHERE [TBP_Name] LIKE '" + xClass + "'";
                    break;
                default:
                    query = "SELECT TOP 12 * " + sTblName +
                          "  ORDER BY [sLstWkDay] desc";
                    qry = "select * from (" + query + ") q1 order by [sLstWkDay] asc";
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

            var maxVal = 0;
            if (dtPareto.Rows.Count > 0)
            {
                maxVal = Convert.ToInt32(dtPareto.Compute("Max([TCS_Amount])", string.Empty));
            }
            
            double maxScale = 1000000;

            if (maxVal > 999999) 
            {
                chartTP01.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "#,##0,,M";

                // set maximum scale to the nearest interval by 5 million
                maxScale = Math.Ceiling(Convert.ToDouble(maxVal) / 5000000d) * 5000000;
            }
            else if(maxVal <= 999999)
            {
                chartTP01.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "#,##0,k";

                switch (maxVal)
                {
                    case int val when (val <= 100):
                        maxScale = 100;
                        break;
                    case int val when (val > 99 && val <= 999):
                        maxScale = 1000;
                        break;
                    case int val when (val > 999 && val <= 10000):
                        maxScale = 10000;
                        break;
                    case int val when (val > 9999 && val <= 50000):
                        maxScale = maxVal + 10000;
                        break;
                    case int val when (val > 49999 && val <= 100000):
                        maxScale = maxVal + 25000;
                        break;
                    case int val when (val > 99999 && val <= 500000):
                        maxScale = maxVal + 50000;
                        break;
                    default:
                        // set maximum scale to the nearest interval by 500,000
                        maxScale = Math.Ceiling(Convert.ToDouble(maxVal) / 500000d) * 500000;
                        break;
                }
                    
            }

            chartTP01.ChartAreas["ChartArea1"].AxisY.Maximum = maxScale;

            foreach (DataRow dr1 in dtPareto.Rows)
            {
                double tScrap = Convert.ToDouble(dr1["TCS_Amount"].ToString());
                chartTP01.Series["Series1"].Points.AddXY(dr1[colName].ToString(), tScrap);
            }

        }
    }
}