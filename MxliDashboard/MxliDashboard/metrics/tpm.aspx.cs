using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard.n3_Safety
{   
    public partial class tpm : System.Web.UI.Page
    {
        public int bandChange = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxAreaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxAreaInContent_SelectedIndexChanged);
            this.ASPxComboBoxCellInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxCellInContent_SelectedIndexChanged);
            this.ASPxComboBoxProInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxProInContent_SelectedIndexChanged);
            this.ASPxComboBoxShiInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxShiInContent_SelectedIndexChanged);
            this.ASPxComboBoxStaInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxStaInContent_SelectedIndexChanged);
            if (!Page.IsPostBack)
            {
                chartDefault("SITE", "All");
            }
        }

        protected void cmbox_DataBoundArea(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxAreaInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxAreaInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundCell(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxCellInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxCellInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundPro(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxProInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxProInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundShi(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxShiInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxShiInContent.SelectedIndex = 0;
        }

        protected void cmbox_DataBoundSta(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxStaInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxStaInContent.SelectedIndex = 0;
        }

        protected void ASPxComboBoxAreaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                bandChange = 1;
                ASPxComboBoxCellInContent.SelectedIndex = 0;
                ASPxComboBoxProInContent.SelectedIndex = 0;
                ASPxComboBoxShiInContent.SelectedIndex = 0;
                ASPxComboBoxStaInContent.SelectedIndex = 0;
                bandChange = 0;
                if (ASPxComboBoxAreaInContent.SelectedIndex == 0)
                {
                    chartDefault("SITE", "All");
                }
                else
                {
                    chartDefault("VSM", ASPxComboBoxAreaInContent.SelectedItem.ToString());
                }
            }
        }

        protected void ASPxComboBoxCellInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                bandChange = 1;
                ASPxComboBoxAreaInContent.SelectedIndex = 0;
                ASPxComboBoxProInContent.SelectedIndex = 0;
                ASPxComboBoxShiInContent.SelectedIndex = 0;
                ASPxComboBoxStaInContent.SelectedIndex = 0;
                bandChange = 0;
                if (ASPxComboBoxCellInContent.SelectedIndex == 0)
                {
                    chartDefault("SITE", "All");
                }
                else
                {
                    chartDefault("CELL", ASPxComboBoxCellInContent.SelectedItem.ToString());
                }
            }
        }

        protected void ASPxComboBoxProInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                bandChange = 1;
                ASPxComboBoxAreaInContent.SelectedIndex = 0;
                ASPxComboBoxCellInContent.SelectedIndex = 0;
                ASPxComboBoxShiInContent.SelectedIndex = 0;
                ASPxComboBoxStaInContent.SelectedIndex = 0;
                bandChange = 0;
                if (ASPxComboBoxProInContent.SelectedIndex == 0)
                {
                    chartDefault("SITE", "All");
                }
                else
                {
                    chartDefault("PROCESS", ASPxComboBoxProInContent.SelectedItem.ToString());
                }
            }
        }

        protected void ASPxComboBoxShiInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                bandChange = 1;
                ASPxComboBoxAreaInContent.SelectedIndex = 0;
                ASPxComboBoxCellInContent.SelectedIndex = 0;
                ASPxComboBoxProInContent.SelectedIndex = 0;
                ASPxComboBoxStaInContent.SelectedIndex = 0;
                bandChange = 0;
                if (ASPxComboBoxShiInContent.SelectedIndex == 0)
                {
                    chartDefault("SITE", "All");
                }
                else
                {
                    chartDefault("SHIFT", ASPxComboBoxShiInContent.SelectedItem.ToString());
                }
            }
        }

        protected void ASPxComboBoxStaInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandChange == 1) { }
            else
            {
                bandChange = 1;
                ASPxComboBoxAreaInContent.SelectedIndex = 0;
                ASPxComboBoxCellInContent.SelectedIndex = 0;
                ASPxComboBoxProInContent.SelectedIndex = 0;
                ASPxComboBoxShiInContent.SelectedIndex = 0;
                bandChange = 0;
                if (ASPxComboBoxStaInContent.SelectedIndex == 0)
                {
                    chartDefault("SITE", "All");
                }
                else
                {
                    chartDefault("STATUS", ASPxComboBoxStaInContent.SelectedItem.ToString());
                }
            }
        }

        protected void chartDefault(string xType, string xFilter)
        {
            try
            {
                WebChartControl1.Series["Total"].Points.Clear();
                WebChartControl1.Series["Goal"].Points.Clear();

                string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
                SqlConnection conn1 = new SqlConnection(myCnStr1);
                SqlCommand cmd1 = new SqlCommand("SELECT sday, fTotal, fGoal, fAcc FROM cht_seguridad WHERE smetric = 'tpms' and sType = '" + xType + "' and sfilter = '" + xFilter + "' order by id", conn1);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
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
                Response.Redirect("~\\CustomErrors\\Errors.aspx?handler=tpm.aspx&msg=" + errNum + "&errDesc=" + errDesc);
            }
        }



    }
}