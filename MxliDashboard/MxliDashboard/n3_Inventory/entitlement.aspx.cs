using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard.n3_Inventory
{
    public partial class entitlement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void cmbox_DataBoundSta(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxStaInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxStaInContent.SelectedIndex = 0;
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


    }
}