using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for XtraReport1
/// </summary>
public class r_agedwip : DevExpress.XtraReports.UI.XtraReport
{
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    private DetailBand Detail;
    private XRChart xrChart1;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRLine xrLine1;
    private XRPictureBox xrPictureBox1;
    private XRLabel xrLabel1;
    private XRLine xrLine2;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrColumn1;
    private XRTableCell xrColumn2;
    private XRTableCell xrColumn3;
    private XRTableCell xrColumn4;
    private XRTableCell xrColumn5;
    private XRTableCell xrColumn6;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private DetailReportBand DetailReport;
    private DetailBand Detail1;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private ReportFooterBand ReportFooter;
    private XRChart xrChart3;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel2;
    private XRChart xrChart2;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public r_agedwip()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
        xrLabel1.Text = DateTime.Today.ToShortDateString();
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(r_agedwip));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView2 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery3 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery4 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView3 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView4 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel3 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView5 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel3 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrChart2 = new DevExpress.XtraReports.UI.XRChart();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrChart3 = new DevExpress.XtraReports.UI.XRChart();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrColumn1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrColumn2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrColumn3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrColumn4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrColumn5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrColumn6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLine1,
            this.xrPictureBox1});
            this.TopMargin.HeightF = 65F;
            this.TopMargin.Name = "TopMargin";
            // 
            // xrLabel4
            // 
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(598.9583F, 25.33332F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(391.0416F, 23F);
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "AGED WIP";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderColor = System.Drawing.Color.Empty;
            this.xrLine1.ForeColor = System.Drawing.Color.Gray;
            this.xrLine1.LineWidth = 5F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 48.33333F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(996.875F, 16.66667F);
            this.xrLine1.StylePriority.UseBorderColor = false;
            this.xrLine1.StylePriority.UseForeColor = false;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox1.ImageSource"));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8.75F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(153.125F, 39.58333F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLine2});
            this.BottomMargin.HeightF = 54F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(598.9583F, 16.66667F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(401.0417F, 23F);
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLine2
            // 
            this.xrLine2.BorderColor = System.Drawing.Color.Empty;
            this.xrLine2.ForeColor = System.Drawing.Color.Gray;
            this.xrLine2.LineWidth = 5F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(996.875F, 16.66667F);
            this.xrLine2.StylePriority.UseBorderColor = false;
            this.xrLine2.StylePriority.UseForeColor = false;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrChart2,
            this.xrLabel6,
            this.xrChart3,
            this.xrLabel3,
            this.xrLabel5,
            this.xrTable2,
            this.xrChart1});
            this.Detail.HeightF = 572.9167F;
            this.Detail.Name = "Detail";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(748.9583F, 0F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "PARETO";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrChart2
            // 
            this.xrChart2.AutoLayout = true;
            this.xrChart2.BackColor = System.Drawing.Color.White;
            this.xrChart2.BorderColor = System.Drawing.Color.Black;
            this.xrChart2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChart2.DataSource = this.sqlDataSource1;
            xyDiagram1.AxisX.Label.Angle = 270;
            xyDiagram1.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            xyDiagram1.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
            xyDiagram1.AxisX.Label.ResolveOverlappingOptions.MinIndent = 0;
            xyDiagram1.AxisX.MinorCount = 1;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            this.xrChart2.Diagram = xyDiagram1;
            this.xrChart2.IndicatorsPaletteName = "Grayscale";
            this.xrChart2.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.xrChart2.Legend.BackColor = System.Drawing.Color.Transparent;
            this.xrChart2.Legend.Border.Color = System.Drawing.SystemColors.ActiveBorder;
            this.xrChart2.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.xrChart2.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.xrChart2.Legend.MarkerSize = new System.Drawing.Size(20, 10);
            this.xrChart2.Legend.Name = "Default Legend";
            this.xrChart2.Legend.Title.Text = "Actual";
            this.xrChart2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.xrChart2.LocationFloat = new DevExpress.Utils.PointFloat(611.4583F, 23.00002F);
            this.xrChart2.Name = "xrChart2";
            this.xrChart2.PaletteBaseColorNumber = 2;
            this.xrChart2.PaletteName = "Grayscale";
            series1.ArgumentDataMember = "Query_2.smaterial";
            sideBySideBarSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            sideBySideBarSeriesLabel1.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.False;
            sideBySideBarSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            sideBySideBarSeriesLabel1.TextColor = System.Drawing.Color.Black;
            sideBySideBarSeriesLabel1.TextOrientation = DevExpress.XtraCharts.TextOrientation.BottomToTop;
            sideBySideBarSeriesLabel1.TextPattern = "{V:c2}M";
            series1.Label = sideBySideBarSeriesLabel1;
            series1.LegendName = "Default Legend";
            series1.Name = "Actual";
            series1.ValueDataMembersSerializable = "Query_2.cValue";
            sideBySideBarSeriesView1.Color = System.Drawing.Color.Firebrick;
            sideBySideBarSeriesView1.Transparency = ((byte)(135));
            series1.View = sideBySideBarSeriesView1;
            series2.ArgumentDataMember = "Query_2.smaterial";
            pointSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel1.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Empty;
            pointSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel1.TextColor = System.Drawing.Color.Black;
            pointSeriesLabel1.TextPattern = "{V:c2}M";
            series2.Label = pointSeriesLabel1;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Goal";
            series2.ShowInLegend = false;
            series2.ValueDataMembersSerializable = "Query_2.Acum";
            splineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            series2.View = splineSeriesView1;
            this.xrChart2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            sideBySideBarSeriesView2.Transparency = ((byte)(135));
            this.xrChart2.SeriesTemplate.View = sideBySideBarSeriesView2;
            this.xrChart2.SizeF = new System.Drawing.SizeF(378.5416F, 501.2916F);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "DB_1033_DashboardConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query_1";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            customSqlQuery2.Name = "Query_2";
            customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
            customSqlQuery3.Name = "Query_3";
            customSqlQuery3.Sql = "select top 5 * from [tbl_actions]\r\nwhere report = \'aged wip\'";
            customSqlQuery4.Name = "Query_4";
            customSqlQuery4.Sql = resources.GetString("customSqlQuery4.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1,
            customSqlQuery2,
            customSqlQuery3,
            customSqlQuery4});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 524.2917F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(153.125F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "ACTIONS RAIL";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrChart3
            // 
            this.xrChart3.AutoLayout = true;
            this.xrChart3.BackColor = System.Drawing.Color.White;
            this.xrChart3.BorderColor = System.Drawing.Color.Black;
            this.xrChart3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChart3.DataSource = this.sqlDataSource1;
            xyDiagram2.AxisX.Label.Angle = 270;
            xyDiagram2.AxisX.Label.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram2.AxisX.Label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram2.AxisX.Label.ResolveOverlappingOptions.MinIndent = 1;
            xyDiagram2.AxisX.MinorCount = 1;
            xyDiagram2.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram2.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram2.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram2.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram2.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            this.xrChart3.Diagram = xyDiagram2;
            this.xrChart3.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.xrChart3.Legend.BackColor = System.Drawing.Color.Transparent;
            this.xrChart3.Legend.Border.Color = System.Drawing.SystemColors.ActiveBorder;
            this.xrChart3.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.xrChart3.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.xrChart3.Legend.MarkerSize = new System.Drawing.Size(20, 10);
            this.xrChart3.Legend.Name = "Default Legend";
            this.xrChart3.Legend.Title.Text = "Actual";
            this.xrChart3.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.xrChart3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 374.6251F);
            this.xrChart3.Name = "xrChart3";
            this.xrChart3.PaletteBaseColorNumber = 2;
            this.xrChart3.PaletteName = "Grayscale";
            series3.ArgumentDataMember = "Query_4.scause";
            sideBySideBarSeriesLabel2.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            sideBySideBarSeriesLabel2.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.False;
            sideBySideBarSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            sideBySideBarSeriesLabel2.TextColor = System.Drawing.Color.Black;
            sideBySideBarSeriesLabel2.TextOrientation = DevExpress.XtraCharts.TextOrientation.BottomToTop;
            sideBySideBarSeriesLabel2.TextPattern = "{V:c2}M";
            series3.Label = sideBySideBarSeriesLabel2;
            series3.LegendName = "Default Legend";
            series3.Name = "Actual";
            series3.ValueDataMembersSerializable = "Query_4.factual";
            sideBySideBarSeriesView3.Color = System.Drawing.Color.SteelBlue;
            sideBySideBarSeriesView3.Transparency = ((byte)(135));
            series3.View = sideBySideBarSeriesView3;
            series4.ArgumentDataMember = "Query_4.scause";
            pointSeriesLabel2.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel2.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel2.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Empty;
            pointSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel2.TextColor = System.Drawing.Color.Black;
            pointSeriesLabel2.TextPattern = "{V:c2}M";
            series4.Label = pointSeriesLabel2;
            series4.Name = "Goal";
            series4.ShowInLegend = false;
            series4.ValueDataMembersSerializable = "Query_4.fsum";
            splineSeriesView2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            series4.View = splineSeriesView2;
            this.xrChart3.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3,
        series4};
            sideBySideBarSeriesView4.Transparency = ((byte)(135));
            this.xrChart3.SeriesTemplate.View = sideBySideBarSeriesView4;
            this.xrChart3.SizeF = new System.Drawing.SizeF(601.0417F, 149.6665F);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(259.9998F, 351.6251F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "FORECAST";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(259.9998F, 0F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "TREND";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable2
            // 
            this.xrTable2.BackColor = System.Drawing.Color.IndianRed;
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.BorderWidth = 1F;
            this.xrTable2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.ForeColor = System.Drawing.Color.White;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 547.2917F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(996.875F, 25F);
            this.xrTable2.StylePriority.UseBackColor = false;
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseBorderWidth = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseForeColor = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrColumn1,
            this.xrColumn2,
            this.xrColumn3,
            this.xrColumn4,
            this.xrColumn5,
            this.xrColumn6});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrColumn1
            // 
            this.xrColumn1.Multiline = true;
            this.xrColumn1.Name = "xrColumn1";
            this.xrColumn1.Text = "RESPONSIBLE";
            this.xrColumn1.Weight = 0.92163030833659876D;
            // 
            // xrColumn2
            // 
            this.xrColumn2.Multiline = true;
            this.xrColumn2.Name = "xrColumn2";
            this.xrColumn2.Text = "ISSUE";
            this.xrColumn2.Weight = 1.4858934475411441D;
            // 
            // xrColumn3
            // 
            this.xrColumn3.Multiline = true;
            this.xrColumn3.Name = "xrColumn3";
            this.xrColumn3.Text = "ACTION";
            this.xrColumn3.Weight = 1.8025078982170846D;
            // 
            // xrColumn4
            // 
            this.xrColumn4.Multiline = true;
            this.xrColumn4.Name = "xrColumn4";
            this.xrColumn4.Text = "STATUS";
            this.xrColumn4.Weight = 0.60501558214145756D;
            // 
            // xrColumn5
            // 
            this.xrColumn5.Multiline = true;
            this.xrColumn5.Name = "xrColumn5";
            this.xrColumn5.Text = "START_DATE";
            this.xrColumn5.Weight = 0.5987462345709248D;
            // 
            // xrColumn6
            // 
            this.xrColumn6.Multiline = true;
            this.xrColumn6.Name = "xrColumn6";
            this.xrColumn6.Text = "DUE_DATE";
            this.xrColumn6.Weight = 0.58620652919279D;
            // 
            // xrChart1
            // 
            this.xrChart1.BorderColor = System.Drawing.Color.Black;
            this.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChart1.DataSource = this.sqlDataSource1;
            xyDiagram3.AxisX.AutoScaleBreaks.MaxCount = 1;
            xyDiagram3.AxisX.InterlacedColor = System.Drawing.Color.DimGray;
            xyDiagram3.AxisX.MinorCount = 1;
            xyDiagram3.AxisX.Tickmarks.MinorVisible = false;
            xyDiagram3.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram3.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram3.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram3.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram3.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram3.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram3.RuntimePaneCollapse = false;
            this.xrChart1.Diagram = xyDiagram3;
            this.xrChart1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.xrChart1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.xrChart1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.xrChart1.Legend.MarkerSize = new System.Drawing.Size(10, 10);
            this.xrChart1.Legend.Name = "Default Legend";
            this.xrChart1.Legend.Title.Text = "ESCAPES";
            this.xrChart1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.00002F);
            this.xrChart1.Name = "xrChart1";
            this.xrChart1.PaletteName = "Grayscale";
            series5.ArgumentDataMember = "Query_1.sdesc";
            sideBySideBarSeriesLabel3.TextPattern = "{V:c2}M";
            series5.Label = sideBySideBarSeriesLabel3;
            series5.Name = "Actual";
            series5.ValueDataMembersSerializable = "Query_1.factual";
            sideBySideBarSeriesView5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            series5.View = sideBySideBarSeriesView5;
            series6.ArgumentDataMember = "Query_1.sdesc";
            pointSeriesLabel3.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel3.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel3.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Empty;
            pointSeriesLabel3.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel3.TextColor = System.Drawing.Color.Black;
            pointSeriesLabel3.TextPattern = "{V:c2}M";
            series6.Label = pointSeriesLabel3;
            series6.Name = "Goal";
            series6.ValueDataMembersSerializable = "Query_1.fgoal";
            lineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series6.View = lineSeriesView1;
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series5,
        series6};
            this.xrChart1.SizeF = new System.Drawing.SizeF(601.0417F, 328.6251F);
            // 
            // xrTable1
            // 
            this.xrTable1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrTable1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(996.875F, 25F);
            this.xrTable1.StylePriority.UseBackColor = false;
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query_3].[responsible]")});
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "xrTableCell1";
            this.xrTableCell1.Weight = 0.92163007873726477D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query_3].[issue]")});
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.Weight = 1.4858935393808777D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query_3].[action]")});
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "xrTableCell3";
            this.xrTableCell3.Weight = 1.8025080359766852D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query_3].[open_close]")});
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "xrTableCell4";
            this.xrTableCell4.Weight = 0.60501558214145756D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query_3].[creation_date]")});
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.TextFormatString = "{0:MM/dd/yyyy}";
            this.xrTableCell5.Weight = 0.5987462345709248D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query_3].[due_date]")});
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "xrTableCell6";
            this.xrTableCell6.TextFormatString = "{0:MM/dd/yyyy}";
            this.xrTableCell6.Weight = 0.58620652919279D;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.ReportFooter});
            this.DetailReport.DataMember = "Query_3";
            this.DetailReport.DataSource = this.sqlDataSource1;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail1.HeightF = 25F;
            this.Detail1.Name = "Detail1";
            // 
            // ReportFooter
            // 
            this.ReportFooter.HeightF = 2.708689F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // r_agedwip
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.DetailReport});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(48, 50, 65, 54);
            this.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.RequestParameters = false;
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
