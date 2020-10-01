using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard
{
    public partial class WebForm1 : System.Web.UI.Page
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

        protected void cmbox_DataBoundMrp(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxMrpInContent.Items.Insert(0, defaultItem);
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

            if (ASPxComboBoxMrpInContent.SelectedIndex > 0)
            {
                ASPxComboBoxMrpInContent.SelectedIndex = 0;
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

            if (ASPxComboBoxMrpInContent.SelectedIndex > 0)
            {
                idx = 3;
                filter = ASPxComboBoxMrpInContent.SelectedItem.ToString();
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
            int yr = DateTime.Now.Year;

            chartTP01.Series["Series1"].Points.Clear();
            chartTP01.Series["Series2"].Points.Clear();
            chartTP01.Series["Series3"].Points.Clear();
            chartTP01.Series["Series4"].Points.Clear();

            string qry = "", qryBaseline = "";
            string colName = "";
            string xClass = "";
            string sTblName = "", cTblName = "", aTblName = "", mTblName = "";
            string qryOrder = "";

            //Selects filter according to user's selection, dafult filter is by week
            if (sFilter == "Week")
            {
                sTblName = "[vw_ottr_by_site_wkly] WHERE [TO_Wk] BETWEEN " + (semana - 12) + " AND " + semana + " AND [TO_Yr] = " + yr;
                cTblName = "[vw_ottr_by_cell_wkly] WHERE [TO_Wk] BETWEEN " + (semana - 12) + " AND " + semana + " AND [TO_Yr] = " + yr + " AND ";
                aTblName = "[vw_ottr_by_area_wkly] WHERE [TO_Wk] BETWEEN " + (semana - 12) + " AND " + semana + " AND [TO_Yr] = " + yr + " AND ";
                mTblName = "[vw_ottr_by_mrp_wkly] WHERE [TO_Wk] BETWEEN " + (semana - 12) + " AND " + semana + " AND [TO_Yr] = " + yr + " AND ";
                qryBaseline = "SELECT * FROM [sta_nivel2] WHERE [sMetric] = 'OTTR' AND [sClass] = 'All' AND [sType] = 'Weekly' AND [sDesc] BETWEEN " + (semana - 12) + " AND " + semana;
                qryOrder = "[TO_Wk]";
                colName = "TO_Wk";
            }
            else
            {
                sTblName = "[vw_ottr_by_site_mntly] WHERE [TO_Yr] = " + yr;
                cTblName = "[vw_ottr_by_cell_mntly] WHERE [TO_Yr] = " + yr + " AND ";
                aTblName = "[vw_ottr_by_area_mntly] WHERE [TO_Yr] = " + yr + " AND ";
                mTblName = "[vw_ottr_by_mrp_mntly] WHERE [TO_Yr] = " + yr + " AND ";
                qryBaseline = "SELECT * FROM [sta_nivel2] WHERE [sMetric] = 'OTTR' AND [sClass] = 'All' AND [sType] = 'Monthly'";
                qryOrder = "[TO_Month]";
                colName = "TO_Month";
            }

            //Validates filter level by site/area/cell, default filter is by site
            switch (indice)
            {
                case 1:
                    xClass = clase;
                    qry = "SELECT * FROM " + aTblName + " [TO_rArea] = '" + xClass + "' Order by [TO_Yr], " + qryOrder + ", [TO_rArea]";
                    break;
                case 2:
                    xClass = clase;
                    qry = "SELECT * FROM " + cTblName + " [TO_Cell] = '" + xClass + "' Order by [TO_Yr], " + qryOrder + ", [TO_Cell]";
                    break;
                case 3:
                    xClass = clase;
                    qry = "SELECT * FROM " + mTblName + " [TO_MRP] = '" + xClass + "' Order by [TO_Yr], " + qryOrder + ", [TO_MRP]";
                    break;
                default:
                    qry = "SELECT * FROM " + sTblName + " Order by [TO_Yr], " + qryOrder;
                    break;
            }

            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dtPareto = dBHelper.QryManager(qry);
            DataTable dtBaseline = dBHelper.QryManager(qryBaseline);

            double xGoal = 0;

            foreach (DataRow dr in dtBaseline.Rows)
            {
                xGoal = Convert.ToDouble(dr["fGoal"].ToString());
                xGoal = xGoal / 100;
                chartTP01.Series["Series4"].Points.AddXY(dr["sType"].ToString(), xGoal);
            }

            foreach (DataRow dr1 in dtPareto.Rows)
            {
                double xHit = Convert.ToDouble(dr1["HIT"].ToString());
                double xTotHrs = Convert.ToDouble(dr1["TotalOrdrs"].ToString());
                double perc = (xHit / xTotHrs);
                //prod = Math.Round(prod, 2);
                chartTP01.Series["Series1"].Points.AddXY(dr1[colName].ToString(), xHit);
                chartTP01.Series["Series2"].Points.AddXY(dr1[colName].ToString(), xTotHrs);
                chartTP01.Series["Series3"].Points.AddXY(dr1[colName].ToString(), perc);
            }
        }
    }
}