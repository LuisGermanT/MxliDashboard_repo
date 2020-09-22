<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Safety.aspx.cs" Inherits="MxliDashboard.Safety" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Views & Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True">
            <HeaderStyle ForeColor="White" />
            <HeaderContent BackColor="#666666">
            </HeaderContent>
            <PanelCollection>
                <dx:PanelContent ID="PanelContent1" runat="server">
                    <table style="table-layout: fixed">
                        <tr>
                            <th>
                                <dx:ASPxLabel ID="ASPxLabelCaptionV" runat="server" Text="Select Tier view:">
                                </dx:ASPxLabel>
                                <dx:ASPxComboBox ID="ASPxComboBoxV" runat="server" ValueType="System.String" AutoPostBack="True"
                                    OnSelectedIndexChanged="ASPxComboBoxV_SelectedIndexChanged">
                                    <Items>
                                        <dx:ListEditItem Selected="True" Text="All" Value="0" />
                                        <dx:ListEditItem Text="T1" Value="1" />
                                        <dx:ListEditItem Text="T2" Value="2" />
                                        <dx:ListEditItem Text="T3" Value="3" />
                                        <dx:ListEditItem Text="TFunction" Value="4" />
                                        <dx:ListEditItem Text="WarRoom" Value="5" />
                                    </Items>
                                    <ClientSideEvents Validation="function(s, e) {
                                            if (s.GetSelectedIndex()==0) {
                                            e.isValid = false;
                                            e.errorText = &quot;You should Select One View&quot;;
                                            }}" />
                                    <ValidationSettings ValidateOnLeave="False">
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                            </th>                           
                        </tr>
                    </table>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxRoundPanel>
    <p></p>
    <hr />
    <p></p>
    <div class="row" runat="server" id="S01">   <%--No incidentes--%>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 10%;">
                        Report
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Actual
                    </th>
                    <th style="text-align:center; width: 8%;">
                        AOP
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Status
                    </th>
                    <th style="text-align:center; width: 25%;">
                        Trend
                    </th>
                    <th style="text-align:center; width: 25%;">
                        Pareto
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Actions
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Details
                    </th>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="S01Report" runat="server" Text="No Incidentes" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="S01Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="S01AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgS01" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTS01" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True" Palette="Grayscale">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="Green" MarkerStyle="Circle" Name="Series3">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0">
                                    </AxisY2>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartPS01" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="IndianRed" MarkerStyle="Circle">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0">
                                    </AxisY2>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="#">Edit &raquo;</a>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="n3_safety/incidentes.aspx">View &raquo;</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <dx:ASPxLabel ID="ASPxLabelS01" runat="server" Text="Last update: September 18, 2020" Font-Size="Small"></dx:ASPxLabel>
                    </td>
                    <td style="text-align: center">
                        <asp:Image ID="ImageSeriesI" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row" runat="server" id="S02">   <%--MST Actions--%>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 10%;">
                        Report
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Actual
                    </th>
                    <th style="text-align:center; width: 8%;">
                        AOP
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Status
                    </th>
                    <th style="text-align:center; width: 25%;">
                        Trend
                    </th>
                    <th style="text-align:center; width: 25%;">
                        Pareto
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Actions
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Details
                    </th>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="S02Report" runat="server" Text="MST Actions" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="S02Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="S02AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgS02" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTS02" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True" Palette="Grayscale">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="Green" MarkerStyle="Circle" Name="Series3">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0">
                                    </AxisY2>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartPS02" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="IndianRed" MarkerStyle="Circle">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0">
                                    </AxisY2>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="#">Edit &raquo;</a>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="n3_safety/mstactions.aspx">View &raquo;</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <dx:ASPxLabel ID="ASPxLabelS02" runat="server" Text="Last update: September 18, 2020" Font-Size="Small"></dx:ASPxLabel>
                    </td>
                    <td style="text-align: center">
                        <asp:Image ID="ImageSeriesM" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />   
    <p></p>
    <div class="row" runat="server" id="S03">   <%--Training--%>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 10%;">
                        Report
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Actual
                    </th>
                    <th style="text-align:center; width: 8%;">
                        AOP
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Status
                    </th>
                    <th style="text-align:center; width: 25%;">
                        Trend
                    </th>
                    <th style="text-align:center; width: 25%;">
                        Pareto
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Actions
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Details
                    </th>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="S03Report" runat="server" Text="Training" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="S03Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="S03AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgS03" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTS03" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True" Palette="Grayscale">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="Green" MarkerStyle="Circle" Name="Series3">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0">
                                    </AxisY2>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartPS03" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="IndianRed" MarkerStyle="Circle">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0">
                                    </AxisY2>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="#">Edit &raquo;</a>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="#">View &raquo;</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <dx:ASPxLabel ID="ASPxLabelS03" runat="server" Text="Last update: " Font-Size="Small"></dx:ASPxLabel>
                    </td>
                    <td style="text-align: center">
                        <asp:Image ID="ImageSeriesT" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />   
    <p></p>
</asp:Content>
