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
    public partial class n1_Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxComboBoxF.SelectedIndexChanged += new System.EventHandler(ASPxComboBoxF_SelectedIndexChanged);
            llenarDatos_I(0);
            llenarDatos_S(0);
            llenarDatos_Q(0);
            llenarDatos_P(0);
        }

        protected void ASPxComboBoxF_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = ASPxComboBoxF.SelectedIndex;
            llenarDatos_I(indice);
            llenarDatos_S(indice);
            llenarDatos_Q(indice);
            llenarDatos_P(indice);
        }

        public void llenarDatos_I(int indice)
        {
            //must use 'B' img because metric have to be low
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";

            string qry = "select * from [sta_nivel1] where smetric = 'inventory' order by id";
            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry);

            //string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn1 = new SqlConnection(myCnStr1);
            //SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel1] where smetric = 'inventory' order by id", conn1);
            //SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            //DataTable dt1 = new DataTable();
            //da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
            }

            if (actual > aop) { imagen = "badB"; }
            imgInventory.ImageUrl = "~/img/" + imagen + ".png";

            inventoryActual.Text = actual + "";
            inventoryAOP.Text = aop + "";

            loadChartI(indice);
        }

        public void llenarDatos_S(int indice)
        {
            double actual = 0;
            double aop = 1.75;
            string imagen = "good";

            string qry = "select * from [sta_nivel1] where smetric = 'safety' order by id";
            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry);

            //string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn1 = new SqlConnection(myCnStr1);
            //SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel1] where smetric = 'safety' order by id", conn1);
            //SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            //DataTable dt1 = new DataTable();
            //da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
            }

            if (actual < aop) { imagen = "bad"; }
            imgSafety.ImageUrl = "~/img/" + imagen + ".png";

            safetyActual.Text = actual + "";
            safetyAOP.Text = aop + "";

            loadChartS(indice);
        }

        public void llenarDatos_Q(int indice)
        {
            //must use 'B' img because metric have to be low
            double actual = 0;
            double aop = 0;
            string imagen = "goodB";

            string qry = "select * from [sta_nivel1] where smetric = 'quality' order by id";
            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry);

            //string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn1 = new SqlConnection(myCnStr1);
            //SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel1] where smetric = 'quality' order by id", conn1);
            //SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            //DataTable dt1 = new DataTable();
            //da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
            }

            if (actual > aop) { imagen = "badB"; }
            imgQuality.ImageUrl = "~/img/" + imagen + ".png";

            qualityActual.Text = actual + "";
            qualityAOP.Text = aop + "";

            loadChartQ(indice);
        }

        public void llenarDatos_D(int indice)
        {
            double actual = 87.1;
            double aop = 81.2;
            string imagen = "good";

            string qry = "select * from [sta_nivel1] where smetric = 'productivity' and stype = 'current' order by id";
            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry);

            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
            }


            if (actual < aop) { imagen = "bad"; }
            imgDelivery.ImageUrl = "~/img/" + imagen + ".png";

            deliveryActual.Text = actual + " %";
            deliveryAOP.Text = aop + " %";

            loadChartD(indice);
        }

        public void llenarDatos_P(int indice)
        {
            double actual = 0;
            double aop = 93.90;
            string imagen = "good";

            string qry = "select * from [sta_nivel1] where smetric = 'productivity' and stype = 'current' order by id";
            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt1 = dBHelper.QryManager(qry);

            //string myCnStr1 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn1 = new SqlConnection(myCnStr1);
            //SqlCommand cmd1 = new SqlCommand("select * from [sta_nivel1] where smetric = 'productivity' and stype = 'current' order by id", conn1);
            //SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            //DataTable dt1 = new DataTable();
            //da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                actual = Convert.ToDouble(dr1["factual"].ToString());
                aop = Convert.ToDouble(dr1["fgoal"].ToString());
            }

            if (actual < aop) { imagen = "bad"; }
            imgProductivity.ImageUrl = "~/img/" + imagen + ".png";

            productivityActual.Text = actual + "%";
            productivityAOP.Text = aop + " %";

            loadChartP(indice);
        }

        private void loadChartI(int indice)
        {
            chartI.Series["Series1"].Points.Clear();
            chartI.Series["Series2"].Points.Clear();
            string tipo = "monthly";

            if (indice == 4)
            {
                tipo = "quarterly";
            }
            if (indice == 5)
            {
                tipo = "yearly";
            }

            string query1 = "select top 6 * from [sta_nivel1] where smetric = 'inventory' and stype = '" + tipo + "' order by id desc";
            string qry = "select * from (" + query1 + ") q1 order by id";
            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt2 = dBHelper.QryManager(qry);

            //string myCnStr2 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn2 = new SqlConnection(myCnStr2);
            //string query1 = "select top 6 * from [sta_nivel1] where smetric = 'inventory' and stype = '" + tipo + "' order by id desc";
            //SqlCommand cmd2 = new SqlCommand("select * from ("+query1+") q1 order by id", conn2);
            //SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                chartI.Series["Series1"].Points.AddXY(dr2["sdesc"].ToString(), dr2["factual"].ToString());
                chartI.Series["Series2"].Points.AddXY(dr2["sdesc"].ToString(), dr2["fgoal"].ToString());
            }

            chartIp.Series["Series1"].Points.Clear();
            chartIp.Series["Series2"].Points.Clear();
            chartIp.Series["Series3"].Points.Clear();

            qry = "select * from [sta_nivel1p] where smetric = 'inventory' and stype = '" + tipo + "' order by id";
            DataTable dt3 = dBHelper.QryManager(qry);

            //string myCnStr3 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn3 = new SqlConnection(myCnStr3);
            //SqlCommand cmd3 = new SqlCommand("select * from [sta_nivel1p] where smetric = 'inventory' and stype = '" + tipo + "' order by id", conn3);
            //SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            //DataTable dt3 = new DataTable();
            //da3.Fill(dt3);
            double xTemp = .90;
            foreach (DataRow dr3 in dt3.Rows)
            {
                double xGoal = Convert.ToDouble(dr3["fgoal"].ToString());
                chartIp.Series["Series1"].Points.AddXY(dr3["sdesc"].ToString(), dr3["factual"].ToString());
                chartIp.Series["Series2"].Points.AddXY(dr3["sdesc"].ToString(), dr3["fgoal"].ToString());
                chartIp.Series["Series3"].Points.AddXY(dr3["sdesc"].ToString(), (xGoal* xTemp).ToString());
                xTemp = xTemp - .05;
            }
        }

        private void loadChartS(int indice)
        {
            chartS.Series["Series1"].Points.Clear();
            chartS.Series["Series2"].Points.Clear();
            string tipo = "monthly";

            if (indice == 4)
            {
                tipo = "quarterly";
            }
            if (indice == 5)
            {
                tipo = "yearly";
            }

            string query1 = "select top 6 * from [sta_nivel1] where smetric = 'safety' and stype = '" + tipo + "' order by id desc";
            string qry = "select * from (" + query1 + ") q1 order by id";
            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt2 = dBHelper.QryManager(qry);

            //string myCnStr2 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn2 = new SqlConnection(myCnStr2);
            //string query1 = "select top 6 * from [sta_nivel1] where smetric = 'safety' and stype = '" + tipo + "' order by id desc";
            //SqlCommand cmd2 = new SqlCommand("select * from (" + query1 + ") q1 order by id", conn2);
            //SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                chartS.Series["Series1"].Points.AddXY(dr2["sdesc"].ToString(), dr2["factual"].ToString());
                chartS.Series["Series2"].Points.AddXY(dr2["sdesc"].ToString(), dr2["fgoal"].ToString());
            }

            chartSp.Series["Series1"].Points.Clear();
            chartSp.Series["Series2"].Points.Clear();
            chartSp.Series["Series3"].Points.Clear();

            qry = "select * from [sta_nivel1p] where smetric = 'safety' and stype = '" + tipo + "' order by id";
            DataTable dt3 = dBHelper.QryManager(qry);

            //string myCnStr3 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn3 = new SqlConnection(myCnStr3);
            //SqlCommand cmd3 = new SqlCommand("select * from [sta_nivel1p] where smetric = 'safety' and stype = '" + tipo + "' order by id", conn3);
            //SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            //DataTable dt3 = new DataTable();
            //da3.Fill(dt3);
            foreach (DataRow dr3 in dt3.Rows)
            {
                chartSp.Series["Series1"].Points.AddXY(dr3["sdesc"].ToString(), dr3["factual"].ToString());
                chartSp.Series["Series2"].Points.AddXY(dr3["sdesc"].ToString(), dr3["fgoal"].ToString());
                chartSp.Series["Series3"].Points.AddXY(dr3["sdesc"].ToString(), "0");
            }
        }

        private void loadChartQ(int indice)
        {
            chartQ.Series["Series1"].Points.Clear();
            chartQ.Series["Series2"].Points.Clear();
            string tipo = "monthly";

            if (indice == 4)
            {
                tipo = "quarterly";
            }
            if (indice == 5)
            {
                tipo = "yearly";
            }

            string query1 = "select top 6 * from [sta_nivel1] where smetric = 'quality' and stype = '" + tipo + "' order by id desc";
            string qry = "select * from (" + query1 + ") q1 order by id";
            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt2 = dBHelper.QryManager(qry);

            //string myCnStr2 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn2 = new SqlConnection(myCnStr2);
            //string query1 = "select top 6 * from [sta_nivel1] where smetric = 'quality' and stype = '" + tipo + "' order by id desc";
            //SqlCommand cmd2 = new SqlCommand("select * from (" + query1 + ") q1 order by id", conn2);
            //SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);

            foreach (DataRow dr2 in dt2.Rows)
            {
                chartQ.Series["Series1"].Points.AddXY(dr2["sdesc"].ToString(), dr2["factual"].ToString());
                chartQ.Series["Series2"].Points.AddXY(dr2["sdesc"].ToString(), dr2["fgoal"].ToString());
            }

            chartQp.Series["Series1"].Points.Clear();
            chartQp.Series["Series2"].Points.Clear();
            chartQp.Series["Series3"].Points.Clear();

            qry = "select * from [sta_nivel1p] where smetric = 'quality' and stype = '" + tipo + "' order by id";
            DataTable dt3 = dBHelper.QryManager(qry);

            //string myCnStr3 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn3 = new SqlConnection(myCnStr3);
            //SqlCommand cmd3 = new SqlCommand("select * from [sta_nivel1p] where smetric = 'quality' and stype = '" + tipo + "' order by id", conn3);
            //SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            //DataTable dt3 = new DataTable();
            //da3.Fill(dt3);

            foreach (DataRow dr3 in dt3.Rows)
            {
                chartQp.Series["Series1"].Points.AddXY(dr3["sdesc"].ToString(), dr3["factual"].ToString());
                chartQp.Series["Series2"].Points.AddXY(dr3["sdesc"].ToString(), dr3["fgoal"].ToString());
                chartQp.Series["Series3"].Points.AddXY(dr3["sdesc"].ToString(), "0");
            }
        }

        private void loadChartD(int indice)
        {
            chartD.Series["Series1"].Points.Clear();
            chartD.Series["Series2"].Points.Clear();
            string tipo = "monthly";


            if (indice == 4)
            {
                tipo = "quarterly";
            }
            if (indice == 5)
            {
                tipo = "yearly";
            }

            string qry = "select * from [sta_nivel1] where smetric = 'delivery' and stype = '" + tipo + "' order by id";
            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt2 = dBHelper.QryManager(qry);

            //string myCnStr2 = Properties.Settings.Default.db_1033_dashboard;
            //SqlConnection conn2 = new SqlConnection(myCnStr2);
            //SqlCommand cmd2 = new SqlCommand("select * from [sta_nivel1] where smetric = 'delivery' and stype = '" + tipo + "' order by id", conn2);
            //SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);

            foreach (DataRow dr2 in dt2.Rows)
            {
                chartD.Series["Series1"].Points.AddXY(dr2["sdesc"].ToString(), dr2["factual"].ToString());
                chartD.Series["Series2"].Points.AddXY(dr2["sdesc"].ToString(), dr2["fgoal"].ToString());
            }
        }

        private void loadChartP(int indice)
        {
            chartP.Series["Series1"].Points.Clear();
            chartP.Series["Series2"].Points.Clear();
            string tipo = "monthly";

            if (indice == 4)
            {
                tipo = "quarterly";
            }
            if (indice == 5)
            {
                tipo = "yearly";
            }

            string qry = "select * from [sta_nivel1] where smetric = 'productivity' and stype = '" + tipo + "' order by id";

            //Connection object, retrieves sql data
            SQLHelper.DBHelper dBHelper = new SQLHelper.DBHelper();
            DataTable dt2 = dBHelper.QryManager(qry);

            foreach (DataRow dr2 in dt2.Rows)
            {
                chartP.Series["Series1"].Points.AddXY(dr2["sdesc"].ToString(), dr2["factual"].ToString());
                chartP.Series["Series2"].Points.AddXY(dr2["sdesc"].ToString(), dr2["fgoal"].ToString());
            }
        }


    }
}