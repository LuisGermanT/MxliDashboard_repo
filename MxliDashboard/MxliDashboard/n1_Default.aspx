<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="n1_Default.aspx.cs" Inherits="MxliDashboard.n1_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Select View" ForeColor="Black" AllowCollapsingByHeaderClick="True">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent1" runat="server">
                <dx:ASPxLabel ID="ASPxLabelCaptionF" runat="server" Text="">
                </dx:ASPxLabel>
                <dx:ASPxComboBox ID="ASPxComboBoxF" runat="server" AutoPostBack="True">
                    <Items>
                        <dx:ListEditItem Selected="True" Text="Default" Value="0" />
                        <dx:ListEditItem Text="byDay" Value="1" />
                        <dx:ListEditItem Text="byWeek" Value="2" />
                        <dx:ListEditItem Text="byMonth" Value="3" />
                        <dx:ListEditItem Text="byQuarter" Value="4" />
                        <dx:ListEditItem Text="byYear" Value="5" />
                    </Items>
                </dx:ASPxComboBox>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
    <hr />
     <div class="jumbotron">
        <table style="width: 100%">
            <tr>
                <th style="text-align: center; width: 8%;">Safety
                </th>
                <th style="text-align: center; width: 8%;">Actual
                </th>
                <th style="text-align: center; width: 8%;">AOP
                </th>
                <th style="text-align: center; width: 8%;">Status
                </th>
                <th style="text-align: center; width: 30%">Trend (HSE Balanced Factor)
                </th>
                <th style="text-align: center; width: 30%">Forecast (HSE Balanced Factor)
                </th>
                <th style="text-align: center; width: 8%;">Details
                </th>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Image ID="ImageLogoS" runat="server" ImageUrl="~/img/safety.jpg" />
                </td>
                <td style="text-align: center">
                    <dx:ASPxLabel ID="safetyActual" runat="server" Text="ASPxLabel" Font-Size="Larger"></dx:ASPxLabel>
                </td>
                <td style="text-align: center">
                    <dx:ASPxLabel ID="safetyAOP" runat="server" Text="ASPxLabel" Font-Size="Larger"></dx:ASPxLabel>
                </td>
                <td style="text-align: center">
                    <asp:Image ID="imgSafety" runat="server" ImageUrl="~/img/bad.png" />
                </td>
                <td style="text-align: center">
                    <asp:Chart ID="chartS" runat="server" Height="120px">
                        <series>
                                <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Name="Series1">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="IndianRed" MarkerStyle="Circle" LabelBorderWidth="0" LabelForeColor="Maroon">
                                </asp:Series>
                            </series>
                        <chartareas>
                                <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0" Enabled="True">
                                        <MajorGrid Enabled="False" />
                                    </AxisY2>
                                </asp:ChartArea>
                            </chartareas>
                    </asp:Chart>
                </td>
                <td style="text-align: center">
                    <asp:Chart ID="chartSp" runat="server" Height="120px">
                        <series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="Silver" IsValueShownAsLabel="True" Palette="Grayscale">
                                    <SmartLabelStyle AllowOutsidePlotArea="Yes" />
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle" BorderDashStyle="Dot">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="0, 192, 0" MarkerStyle="Circle" Name="Series3">
                                </asp:Series>
                            </series>
                        <chartareas>
                                <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0" Enabled="True" TextOrientation="Rotated90">
                                        <MajorGrid Enabled="False" />
                                    </AxisY2>
                                </asp:ChartArea>
                            </chartareas>
                    </asp:Chart>
                </td>
                <td style="text-align: center">
                    <a class="btn btn-danger" href="n2_Safety">View &raquo;</a>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <dx:ASPxLabel ID="ASPxLabelS" runat="server" Text="Last update:" Font-Size="Small"></dx:ASPxLabel>
                </td>
                <td style="text-align: center" >
                    <asp:Image ID="ImageSeriesS" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                </td>
            </tr>
        </table>
    </div>
    <hr />
        <div class="jumbotron">
        <table style="width: 100%">
            <tr>
                <th style="text-align: center; width: 8%;">Quality
                </th>
                <th style="text-align: center; width: 8%;">Actual
                </th>
                <th style="text-align: center; width: 8%;">AOP
                </th>
                <th style="text-align: center; width: 8%;">Status
                </th>
                <th style="text-align: center; width: 30%">Trend (Escapes/PPMs)
                </th>
                <th style="text-align: center; width: 30%">Forecast (Escapes/PPMs)
                </th>
                <th style="text-align: center; width: 8%;">Details
                </th>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Image ID="ImageLogoQ" runat="server" ImageUrl="~/img/quality.jpg" />
                </td>
                <td style="text-align: center">
                    <dx:ASPxLabel ID="qualityActual" runat="server" Text="" Font-Size="Larger"></dx:ASPxLabel>
                </td>
                <td style="text-align: center">
                    <dx:ASPxLabel ID="qualityAOP" runat="server" Text="" Font-Size="Larger"></dx:ASPxLabel>
                </td>
                <td style="text-align: center">
                    <asp:Image ID="imgQuality" runat="server" ImageUrl="~/img/bad.png" />
                </td>
                <td style="text-align: center">
                    <asp:Chart ID="chartQ" runat="server" Height="120px">
                        <series>
                                <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Name="Series1">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="IndianRed" MarkerStyle="Circle" LabelBorderWidth="0" LabelForeColor="Maroon">
                                </asp:Series>
                            </series>
                        <chartareas>
                                <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0" Enabled="True">
                                        <MajorGrid Enabled="False" />
                                    </AxisY2>
                                </asp:ChartArea>
                            </chartareas>
                    </asp:Chart>
                </td>
                <td style="text-align: center">
                    <asp:Chart ID="chartQp" runat="server" Height="120px">
                        <series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="Silver" IsValueShownAsLabel="True" Palette="Grayscale">
                                    <SmartLabelStyle AllowOutsidePlotArea="Yes" />
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle" BorderDashStyle="Dot">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="0, 192, 0" MarkerStyle="Circle" Name="Series3">
                                </asp:Series>
                            </series>
                        <chartareas>
                                <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0" Enabled="True" TextOrientation="Rotated90">
                                        <MajorGrid Enabled="False" />
                                    </AxisY2>
                                </asp:ChartArea>
                            </chartareas>
                    </asp:Chart>
                </td>
                <td style="text-align: center">
                    <a class="btn btn-danger" href="n2_Quality">View &raquo;</a>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <dx:ASPxLabel ID="ASPxLabelQ" runat="server" Text="Last update:" Font-Size="Small"></dx:ASPxLabel>
                </td>
                <td style="text-align: center" >
                    <asp:Image ID="ImageSeriesQ" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <div class="jumbotron">
        <table style="width: 100%">
            <tr>
                <th style="text-align: center; width: 8%;">Delivery
                </th>
                <th style="text-align: center; width: 8%;">Actual
                </th>
                <th style="text-align: center; width: 8%;">AOP
                </th>
                <th style="text-align: center; width: 8%;">Status
                </th>
                <th style="text-align: center; width: 30%">Trend (OTTR_%)
                </th>
                <th style="text-align: center; width: 30%">Forecast (OTTR_%)
                </th>
                <th style="text-align: center; width: 8%;">Detail
                </th>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Image ID="ImageLogoD" runat="server" ImageUrl="~/img/delivery.jpg" />
                </td>
                <td style="text-align: center">
                    <dx:ASPxLabel ID="deliveryActual" runat="server" Text="" Font-Size="Larger"></dx:ASPxLabel>
                </td>
                <td style="text-align: center">
                    <dx:ASPxLabel ID="deliveryAOP" runat="server" Text="" Font-Size="Larger"></dx:ASPxLabel>
                </td>
                <td style="text-align: center">
                    <asp:Image ID="imgDelivery" runat="server" ImageUrl="~/img/bad.png" />
                </td>
                <td style="text-align: center">
                    <asp:Chart ID="chartD" runat="server" Height="120px">
                        <series>
                                <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Name="Series1">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="IndianRed" MarkerStyle="Circle" LabelBorderWidth="0" LabelForeColor="Maroon">
                                </asp:Series>
                            </series>
                        <chartareas>
                                <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0" Enabled="True">
                                        <MajorGrid Enabled="False" />
                                    </AxisY2>
                                </asp:ChartArea>
                            </chartareas>
                    </asp:Chart>
                </td>
                <td style="text-align: center">
                    <asp:Chart ID="chartDp" runat="server" Height="120px">
                        <series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="Silver" IsValueShownAsLabel="True" Palette="Grayscale">
                                    <SmartLabelStyle AllowOutsidePlotArea="Yes" />
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle" BorderDashStyle="Dot">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="0, 192, 0" MarkerStyle="Circle" Name="Series3">
                                </asp:Series>
                            </series>
                        <chartareas>
                                <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0" Enabled="True" TextOrientation="Rotated90">
                                        <MajorGrid Enabled="False" />
                                    </AxisY2>
                                </asp:ChartArea>
                            </chartareas>
                    </asp:Chart>
                </td>
                <td style="text-align: center">
                    <a class="btn btn-danger" href="/n2_Delivery">View &raquo;</a>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <dx:ASPxLabel ID="ASPxLabelD" runat="server" Text="" Font-Size="Small"></dx:ASPxLabel>
                </td>
                <td style="text-align: center" >
                    <asp:Image ID="ImageSeriesD" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <div class="jumbotron">
        <table style="width: 100%">
            <tr>
                <th style="text-align: center; width: 8%;">Inventory
                </th>
                <th style="text-align: center; width: 8%;">Actual
                </th>
                <th style="text-align: center; width: 8%;">AOP
                </th>
                <th style="text-align: center; width: 8%;">Status
                </th>
                <th style="text-align: center; width: 30%">Trend (DOS)
                </th>
                <th style="text-align: center; width: 30%">Forecast (DOS)
                </th>
                <th style="text-align: center; width: 8%;">Details
                </th>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Image ID="ImageLogoI" runat="server" ImageUrl="~/img/inventory.png" />
                </td>
                <td style="text-align: center">
                    <dx:ASPxLabel ID="inventoryActual" runat="server" Text="ASPxLabel" Font-Size="Larger"></dx:ASPxLabel>
                </td>
                <td style="text-align: center">
                    <dx:ASPxLabel ID="inventoryAOP" runat="server" Text="ASPxLabel" Font-Size="Larger"></dx:ASPxLabel>
                </td>
                <td style="text-align: center">
                    <asp:Image ID="imgInventory" runat="server" ImageUrl="~/img/bad.png" />
                </td>
                <td style="text-align: center">
                    <asp:Chart ID="chartI" runat="server" Height="120px">
                        <series>
                                <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Name="Series1">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="IndianRed" MarkerStyle="Circle" LabelBorderWidth="0" LabelForeColor="Maroon">
                                </asp:Series>
                            </series>
                        <chartareas>
                                <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0" Enabled="True">
                                        <MajorGrid Enabled="False" />
                                    </AxisY2>
                                </asp:ChartArea>
                            </chartareas>
                    </asp:Chart>
                </td>
                <td style="text-align: center">
                    <asp:Chart ID="chartIp" runat="server" Height="120px">
                        <series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="Silver" IsValueShownAsLabel="True" Palette="Grayscale">
                                    <SmartLabelStyle AllowOutsidePlotArea="Yes" />
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle" BorderDashStyle="Dot">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="0, 192, 0" MarkerStyle="Circle" Name="Series3">
                                </asp:Series>
                            </series>
                        <chartareas>
                                <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0" Enabled="True" TextOrientation="Rotated90">
                                        <MajorGrid Enabled="False" />
                                    </AxisY2>
                                </asp:ChartArea>
                            </chartareas>
                    </asp:Chart>
                </td>
                <td style="text-align: center">
                    <a class="btn btn-danger" href="n2_Inventory">View &raquo;</a>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <dx:ASPxLabel ID="ASPxLabelI" runat="server" Text="Last update:" Font-Size="Small"></dx:ASPxLabel>
                </td>
                <td style="text-align: center" >
                    <asp:Image ID="ImageSeriesI" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                </td>
            </tr>
        </table>
    </div>  
    <hr />   
    <div class="jumbotron">
        <table style="width: 100%">
            <tr>
                <th style="text-align: center; width: 8%;">Productivity
                </th>
                <th style="text-align: center; width: 8%;">Actual
                </th>
                <th style="text-align: center; width: 8%;">AOP
                </th>
                <th style="text-align: center; width: 8%;">Status
                </th>
                <th style="text-align: center; width: 30%">Trend (Productivity_%)
                </th>
                <th style="text-align: center; width: 30%">Forecast (Productivity_%)
                </th>
                <th style="text-align: center; width: 8%;">Details
                </th>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Image ID="ImageLogoP" runat="server" ImageUrl="~/img/productivity.jpg" />
                </td>
                <td style="text-align: center">
                    <dx:ASPxLabel ID="productivityActual" runat="server" Text="ASPxLabel" Font-Size="Larger"></dx:ASPxLabel>
                </td>
                <td style="text-align: center">
                    <dx:ASPxLabel ID="productivityAOP" runat="server" Text="ASPxLabel" Font-Size="Larger"></dx:ASPxLabel>
                </td>
                <td style="text-align: center">
                    <asp:Image ID="imgProductivity" runat="server" ImageUrl="~/img/bad.png" />
                </td>
                <td style="text-align: center">
                    <asp:Chart ID="chartP" runat="server" Height="120px">
                        <series>
                                <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Name="Series1">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="IndianRed" MarkerStyle="Circle" LabelBorderWidth="0" LabelForeColor="Maroon">
                                </asp:Series>
                            </series>
                        <chartareas>
                                <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0" Enabled="True">
                                        <MajorGrid Enabled="False" />
                                    </AxisY2>
                                </asp:ChartArea>
                            </chartareas>
                    </asp:Chart>
                </td>
                <td style="text-align: center">
                    <asp:Chart ID="chartPp" runat="server" Height="120px">
                        <series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="Silver" IsValueShownAsLabel="True" Palette="Grayscale">
                                    <SmartLabelStyle AllowOutsidePlotArea="Yes" />
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle" BorderDashStyle="Dot">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="0, 192, 0" MarkerStyle="Circle" Name="Series3">
                                </asp:Series>
                            </series>
                        <chartareas>
                                <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0" Enabled="True" TextOrientation="Rotated90">
                                        <MajorGrid Enabled="False" />
                                    </AxisY2>
                                </asp:ChartArea>
                            </chartareas>
                    </asp:Chart>
                </td>
                <td style="text-align: center">
                    <a class="btn btn-danger" href="n2_Productivity">View &raquo;</a>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <dx:ASPxLabel ID="ASPxLabelP" runat="server" Text="Last update:" Font-Size="Small"></dx:ASPxLabel>
                </td>
                <td style="text-align: center" >
                    <asp:Image ID="ImageSeriesP" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
