using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard.n3_Inventory
{
    public partial class inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxVsmInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxVsmInContent_SelectedIndexChanged);
            this.ASPxComboBoxCellInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxCellInContent_SelectedIndexChanged);
            this.ASPxComboBoxMrpInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxMrpInContent_SelectedIndexChanged);
            this.ASPxComboBoxPfepInContent.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxPfepInContent_SelectedIndexChanged);
            loadUpdate();
            if (!Page.IsPostBack)
            {
                chartDefault("SITE", "All");
            }
        }

        protected void cmbox_DataBoundMrp(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxMrpInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
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

        protected void cmbox_DataBoundPfep(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxPfepInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxPfepInContent.SelectedIndex = 0;
        }

        protected void grid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Total")
            {
                decimal price = (decimal)e.GetListSourceFieldValue("totQty");
                decimal quantity = (decimal)e.GetListSourceFieldValue("Price");
                e.Value = price * quantity;
            }
        }

        protected void ASPxComboBoxVsmInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
            ASPxComboBoxCellInContent.SelectedIndex = 0;
            ASPxComboBoxPfepInContent.SelectedIndex = 0;
            if (ASPxComboBoxVsmInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("VSM", ASPxComboBoxVsmInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxCellInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxVsmInContent.SelectedIndex = 0;
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
            ASPxComboBoxPfepInContent.SelectedIndex = 0;
            if (ASPxComboBoxCellInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("CELL", ASPxComboBoxCellInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxMrpInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxVsmInContent.SelectedIndex = 0;
            ASPxComboBoxCellInContent.SelectedIndex = 0;
            ASPxComboBoxPfepInContent.SelectedIndex = 0;
            if (ASPxComboBoxMrpInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("MRP", ASPxComboBoxMrpInContent.SelectedItem.ToString());
            }
        }

        protected void ASPxComboBoxPfepInContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBoxVsmInContent.SelectedIndex = 0;
            ASPxComboBoxMrpInContent.SelectedIndex = 0;
            ASPxComboBoxCellInContent.SelectedIndex = 0;           
            if (ASPxComboBoxPfepInContent.SelectedIndex == 0)
            {
                chartDefault("SITE", "All");
            }
            else
            {
                chartDefault("PFEP", ASPxComboBoxPfepInContent.SelectedItem.ToString());
            }
        }

        protected void chartDefault(string xType, string xFilter)
        {
            WebChartControl1.Series["Total"].Points.Clear();
            WebChartControl1.Series["Goal"].Points.Clear();
            WebChartControl1.Series["Adj"].Points.Clear();

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("SELECT sday, fTotal, fGoal, fAcc FROM cht_inventario WHERE smetric = 'inventario' and sType = '" + xType + "' and sfilter = '" + xFilter + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xTotal = Convert.ToDouble(dr1["fTotal"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                double xAcc = Convert.ToDouble(dr1["fAcc"].ToString());
                WebChartControl1.Series["Total"].Points.AddPoint(dr1["sday"].ToString(), xTotal);
                WebChartControl1.Series["Goal"].Points.AddPoint(dr1["sday"].ToString(), xGoal);
                WebChartControl1.Series["Adj"].Points.AddPoint(dr1["sday"].ToString(), xAcc);
            }
        }

        protected void loadUpdate()
        {
            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [tbl_metricsUpdates] WHERE [reportName] = 'inventario'", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                Label1.Text =  dr1["lastUpdateText"].ToString();
            }
        }


    }
}