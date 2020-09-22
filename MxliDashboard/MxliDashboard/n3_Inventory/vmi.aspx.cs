using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxliDashboard.n3_Inventory
{
    public partial class vmi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmbox_DataBoundSup(object sender, EventArgs e)
        {
            ListEditItem defaultItem = new ListEditItem("All", "%%");
            ASPxComboBoxSupInContent.Items.Insert(0, defaultItem);
            ASPxComboBoxSupInContent.SelectedIndex = 0;
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