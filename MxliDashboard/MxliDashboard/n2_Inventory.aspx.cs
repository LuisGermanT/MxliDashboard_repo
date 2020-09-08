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
    public partial class Inventory : System.Web.UI.Page
    {
        public int bandChange = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarDatos_I01(0);
            loadChartI01(0, "All");
            llenarDatos_I02(0);
            loadChartI02(0, "All");
            llenarDatos_I03(0);
            loadChartI03(0);
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
            if (bandChange == 1) { }
            else
            {
                int xTodos = ASPxComboBoxVsmInContent.SelectedIndex;
                string vsm = ASPxComboBoxVsmInContent.SelectedItem.ToString();
                if (xTodos == 0)
                {
                    llenarDatos_I01(0);
                    loadChartI01(0, "");
                    llenarDatos_I02(0);
                    loadChartI02(0, "");
                }
                else
                {
                    llenarDatos_I01(0);
                    loadChartI01(1, vsm);
                    llenarDatos_I02(0);
                    loadChartI02(1, vsm);
                }
            }

            if (ASPxComboBoxCellInContent.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxCellInContent.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        protected void ASPxComboBoxCellInContent_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (bandChange == 1) { }
            else
            {
                int xTodos = ASPxComboBoxCellInContent.SelectedIndex;
                string cell = ASPxComboBoxCellInContent.SelectedItem.ToString();
                if (xTodos == 0)
                {
                    llenarDatos_I01(0);
                    loadChartI01(0, "");
                    llenarDatos_I02(0);
                    loadChartI02(0, "");
                }
                else
                {
                    llenarDatos_I01(0);
                    loadChartI01(2, cell);
                    llenarDatos_I02(0);
                    loadChartI02(0, "");
                }
            }

            if (ASPxComboBoxVsmInContent.SelectedIndex > 0)
            {
                bandChange = 1;
                ASPxComboBoxVsmInContent.SelectedIndex = 0;
                bandChange = 0;
            }
        }

        public void llenarDatos_I01(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'inventario' and sfilter = 'SITE' and sdesc = '31' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
            }

            if (actual > aop) { imagen = "badB"; }
            imgI01.ImageUrl = "~/img/" + imagen + ".png";

            I01Actual.Text = (actual / 1000).ToString("C2") + "K";
            I01AOP.Text = (aop / 1000).ToString("C2") + "K";


        }
        public void llenarDatos_I02(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'entitlement' and sfilter = 'SITE' and sdesc = '31' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
            }

            if (actual > aop) { imagen = "badB"; }
            imgI02.ImageUrl = "~/img/" + imagen + ".png";

            I02Actual.Text = (actual / 1000).ToString("C2") + "K";
            I02AOP.Text = (aop / 1000).ToString("C2") + "K";
        }

        public void llenarDatos_I03(int indice)
        {
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'vmi' and sfilter = 'SITE' and sdesc = '31' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
            }

            if (actual > aop) { imagen = "badB"; }
            imgI03.ImageUrl = "~/img/" + imagen + ".png";

            I03Actual.Text = (actual / 1000).ToString("C2") + "K";
            I03AOP.Text = (aop / 1000).ToString("C2") + "K";
        }

        private void loadChartI01(int tipo, string clase)
        {
            chartTI01.Series["Series1"].Points.Clear();
            chartTI01.Series["Series2"].Points.Clear();
            string xTipo = "weekly";
            //tipo=0
            String xFilter = "SITE";
            string xClass = "All";

            if (tipo == 1)
            {
                xClass = clase;
                xFilter = "VSM";
            }
            if (tipo == 2)
            {
                xClass = clase;
                xFilter = "CELL";
            }

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'inventario' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTI01.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTI01.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
            }
        }

        private void loadChartI02(int tipo, string clase)
        {
            chartTI02.Series["Series1"].Points.Clear();
            chartTI02.Series["Series2"].Points.Clear();
            string xTipo = "weekly";
            //tipo=0
            String xFilter = "SITE";
            string xClass = "All";
            if (tipo == 1)
            {
                xClass = clase;
                xFilter = "VSM";
            }
            if (tipo == 2)
            {
                xClass = clase;
                xFilter = "CELL";
            }

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'entitlement' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTI02.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTI02.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
            }
        }

        private void loadChartI03(int indice)
        {
            chartTI03.Series["Series1"].Points.Clear();
            chartTI03.Series["Series2"].Points.Clear();
            String xFilter = "SITE";
            string xTipo = "weekly";
            string xClass = "All";

            string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            SqlConnection conn1 = new SqlConnection(myCnStr1);
            SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel2] where smetric = 'vmi' and sclass = '" + xClass + "' and stype = '" + xTipo + "' and sfilter = '" + xFilter + "' order by id", conn1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                double xActual = Convert.ToDouble(dr1["factual"].ToString());
                double xGoal = Convert.ToDouble(dr1["fgoal"].ToString());
                chartTI03.Series["Series1"].Points.AddXY(dr1["sdesc"].ToString(), xActual);
                chartTI03.Series["Series2"].Points.AddXY(dr1["sdesc"].ToString(), xGoal);
            }
        }

    }
}