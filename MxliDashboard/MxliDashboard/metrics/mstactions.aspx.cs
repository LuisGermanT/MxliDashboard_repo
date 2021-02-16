using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard.n3_Safety
{
    public partial class mstactions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxResInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxResInContent_SelectedIndexChanged);
            this.ASPxComboBoxStaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxStaInContent_SelectedIndexChanged);
            if (!Page.IsPostBack)
            {
                chartDefault("SITE", "All");
            }
        }

        protected void cmbox_DataBoundRes(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxResInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxResInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundSta(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxStaInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxStaInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxResInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxStaInContent.SelectedIndex = 0;
            if (ASPxComboBoxResInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("RESPONSIBLE", ASPxComboBoxResInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxStaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxResInContent.SelectedIndex = 0;
            if (ASPxComboBoxStaInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("STATUS", ASPxComboBoxStaInContent.SelectedItem.ToString());
            }
        }

        protected void chartDefault(string xType, string xFilter)
        {
            try
            {

                WebChartControl1.Series["Total"].Points.Clear();
                WebChartControl1.Series["Goal"].Points.Clear();
                int semana = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

                string query = "SELECT TOP 13 * FROM cht_seguridad WHERE smetric = 'mst' and sType = '" + xType + "' and sfilter = '" + xFilter + "' and sday < '" + (semana) + "'  order by id ";
                string qry = "select * from (" + query + ") q1 order by id";
                SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
                DataTable dt1 = dBHelper.QryManager(qry);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    double xTotal = Convert.ToDouble(dr1["fTotal"].ToString());
                    double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                    WebChartControl1.Series["Total"].Points.AddPoint("W-" + dr1["sday"].ToString(), xTotal);
                    WebChartControl1.Series["Goal"].Points.AddPoint("W-" + dr1["sday"].ToString(), xGoal);
                }
            }
            catch (Exception ex)
            {
                int errNum = -99999999;
                string errDesc = "";
                HttpContext.Current.Items.Add("Exception", ex);

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
                Server.Transfer("~\\CustomErrors\\Errors.aspx?handler=mstactions.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
        }
    }
}