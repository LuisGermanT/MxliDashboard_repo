using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard
{
    public partial class set_forecast : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxF1.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF1_SelectedIndexChanged);
        }

        protected void cmbox_DataBoundF1(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("Select one", "%%");
            ASPxComboBoxF1.Items.Insert(0, defaultItem);
            ASPxComboBoxF1.SelectedIndex = 0;
        }

        protected void ASPxComboBoxF1_SelectedIndexChanged(object sender, EventArgs e)
        {
            METRIC_GOALS.Visible= true;
        }

        protected void ASPxGridView1_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "x")
            {
                ASPxComboBox cmb = e.Editor as ASPxComboBox;
                cmb.Items.Add("SITE");
                cmb.Items.Add("VSM");
                cmb.Items.Add("CELL");
                cmb.Items.Add("MRP");
            }
            if (e.Column.FieldName == "y")
            {
                ASPxComboBox cmb = e.Editor as ASPxComboBox;
                cmb.Items.Add("AVERAGE");
                cmb.Items.Add("LATEST");
                cmb.Items.Add("SUM");
            }
            if (e.Column.FieldName == "z")
            {
                ASPxComboBox cmb = e.Editor as ASPxComboBox;
                cmb.Items.Add("PERCENT");
                cmb.Items.Add("QUANTITY");
                cmb.Items.Add("VALUE");
            }
            if (e.Column.FieldName == "xyz")
            {
                ASPxComboBox cmb = e.Editor as ASPxComboBox;
                cmb.Items.Add("2020");
                cmb.Items.Add("2021");
                cmb.Items.Add("2022");
                cmb.Items.Add("2023");
                cmb.Items.Add("2024");
                cmb.Items.Add("2025");
            }
        }


    }
}