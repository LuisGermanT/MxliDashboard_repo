﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="n2_Inventory.aspx.cs" Inherits="MxliDashboard.Inventory" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <p></p>
            <div class="row">
                <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Views" ForeColor="Black" AllowCollapsingByHeaderClick="True">
                    <HeaderStyle ForeColor="White" />
                    <HeaderContent BackColor="#666666">
                    </HeaderContent>
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <table style="table-layout: fixed">
                                <tr>
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Select Tier view:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxVF" runat="server" ValueType="System.String" AutoPostBack="True"
                                            OnSelectedIndexChanged="ASPxComboBoxVF_SelectedIndexChanged">
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
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabelCaptionV" runat="server" Text="Select metric filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxV" runat="server" ValueType="System.String" AutoPostBack="True"
                                            OnSelectedIndexChanged="ASPxComboBoxV_SelectedIndexChanged">
                                            <Items>
                                                <dx:ListEditItem Selected="True" Text="Default" Value="0" />
                                                <dx:ListEditItem Text="Weekly" Value="1" />
                                                <dx:ListEditItem Text="Monthly" Value="2" />
                                                <dx:ListEditItem Text="Quarterly" Value="3" />
                                                <dx:ListEditItem Text="Yearly" Value="4" />
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
            </div>
            <p></p>
            <hr />
            <p></p>
            <div class="row" id="I01" runat="server">
                <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" HeaderText="Inventory Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True" BackColor="White">
                    <HeaderStyle ForeColor="White" />
                    <HeaderContent BackColor="#666666">
                    </HeaderContent>
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                            <table style="table-layout: fixed">
                                <tr>
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabelCaptionF1" runat="server" Text="Select VSM filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF1" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceVsm"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF1" OnSelectedIndexChanged="ASPxComboBoxF1_SelectedIndexChanged">
                                            <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One VSM&quot;;
                                                    }}" />
                                            <ValidationSettings ValidateOnLeave="False">
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </th>
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabelCaptionF2" runat="server" Text="Select Cell filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF2" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceCell"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF2" OnSelectedIndexChanged="ASPxComboBoxF2_SelectedIndexChanged">
                                            <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One Cell&quot;;
                                                    }}" />
                                            <ValidationSettings ValidateOnLeave="False">
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </th>
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabelCaptionF3" runat="server" Text="Select MRP filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF3" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceMrp"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF3" OnSelectedIndexChanged="ASPxComboBoxF3_SelectedIndexChanged">
                                            <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One MRP&quot;;
                                                    }}" />
                                            <ValidationSettings ValidateOnLeave="False">
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </th>
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabelCaptionF4" runat="server" Text="Select PFEP filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF4" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourcePfep"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF4" OnSelectedIndexChanged="ASPxComboBoxF4_SelectedIndexChanged">
                                            <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One PFEP&quot;;
                                                    }}" />
                                            <ValidationSettings ValidateOnLeave="False">
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </th>
                                </tr>
                            </table>
                            <hr />
                            <table style="width: 100%">
                                <tr>
                                    <th style="text-align: center; width: 10%;">Report
                                    </th>
                                    <th style="text-align: center; width: 10%;">Actual
                                    </th>
                                    <th style="text-align: center; width: 10%;">AOP
                                    </th>
                                    <th style="text-align: center; width: 10%;">Status
                                    </th>
                                    <th style="text-align: center; width: 50%;">Trend
                                    </th>
                                    <th style="text-align: center; width: 10%;">Details
                                    </th>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <dx:ASPxLabel ID="I01Report" runat="server" Text="INVENTORY" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <dx:ASPxLabel ID="I01Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <dx:ASPxLabel ID="I01AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Image ID="imgI01" runat="server" ImageUrl="~/img/bad.png" />
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Chart ID="chartTI01" runat="server" Height="120px" Width="500px">
                                            <Series>
                                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SlateGray" IsValueShownAsLabel="True" Palette="Grayscale">
                                                </asp:Series>
                                                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle">
                                                </asp:Series>
                                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="0, 192, 0" MarkerStyle="Circle" Name="Series3">
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
                                    <td style="text-align: center">
                                        <a class="btn btn-danger" href="n3_inventory/inventory.aspx">View &raquo;</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <dx:ASPxLabel ID="ASPxLabelI" runat="server" Text="Last update:" Font-Size="Small"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Image ID="ImageSeriesI" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                                    </td>
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <asp:SqlDataSource ID="SqlDataSourceVsm" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'inventario' and sfilter = 'vsm' order by sClass"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceCell" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'inventario' and sfilter = 'cell' order by sClass"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceMrp" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'inventario' and sfilter = 'mrp' order by sClass"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourcePfep" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'inventario' and sfilter = 'pfep' order by sClass"></asp:SqlDataSource>
            </div>
            <p></p>
            <hr />
            <p></p>

            <div class="row" id="I02" runat="server">
                <%--WIP ENTITLEMENT--%>
                <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" HeaderText="Entitlement Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True" BackColor="White">
                    <HeaderStyle ForeColor="White" />
                    <HeaderContent BackColor="#666666">
                    </HeaderContent>
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <table style="table-layout: fixed">
                                <tr>
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabelF5" runat="server" Text="Select VSM filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF5" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceVsm2"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF5" OnSelectedIndexChanged="ASPxComboBoxF5_SelectedIndexChanged">
                                            <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One VSM&quot;;
                                                    }}" />
                                            <ValidationSettings ValidateOnLeave="False">
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </th>
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabelF6" runat="server" Text="Select Cell filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF6" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceCell2"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF6" OnSelectedIndexChanged="ASPxComboBoxF6_SelectedIndexChanged">
                                            <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One Cell&quot;;
                                                    }}" />
                                            <ValidationSettings ValidateOnLeave="False">
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </th>
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabelF7" runat="server" Text="Select MRP filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF7" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceMrp2"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF7" OnSelectedIndexChanged="ASPxComboBoxF7_SelectedIndexChanged">
                                            <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One MRP&quot;;
                                                    }}" />
                                            <ValidationSettings ValidateOnLeave="False">
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </th>
                                </tr>
                            </table>
                            <hr />
                            <table style="width: 100%">
                                <tr>
                                    <th style="text-align: center; width: 10%;">Report
                                    </th>
                                    <th style="text-align: center; width: 10%;">Actual
                                    </th>
                                    <th style="text-align: center; width: 10%;">AOP
                                    </th>
                                    <th style="text-align: center; width: 10%;">Status
                                    </th>
                                    <th style="text-align: center; width: 50%;">Trend
                                    </th>
                                    <th style="text-align: center; width: 10%;">Details
                                    </th>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <dx:ASPxLabel ID="I02Report" runat="server" Text="WIP ENTITLEMENT" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <dx:ASPxLabel ID="I02Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <dx:ASPxLabel ID="I02AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Image ID="imgI02" runat="server" ImageUrl="~/img/bad.png" />
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Chart ID="chartTI02" runat="server" Height="120px" Width="500px">
                                            <Series>
                                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SlateGray" IsValueShownAsLabel="True" Palette="Grayscale">
                                                </asp:Series>
                                                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle">
                                                </asp:Series>
                                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="0, 192, 0" MarkerStyle="Circle" Name="Series3">
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
                                    <td style="text-align: center">
                                        <a class="btn btn-danger" href="n3_inventory/entitlement.aspx">View &raquo;</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <dx:ASPxLabel ID="ASPxLabelE" runat="server" Text="Last update:" Font-Size="Small"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Image ID="ImageSeriesE" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                                    </td>
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <asp:SqlDataSource ID="SqlDataSourceVsm2" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'entitlement' and sfilter = 'vsm' order by sClass"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceCell2" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'entitlement' and sfilter = 'cell' order by sClass"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceMrp2" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'entitlement' and sfilter = 'mrp' order by sClass"></asp:SqlDataSource>
            </div>
            <p></p>
            <hr />
            <p></p>
            <div class="row" id="I03" runat="server">
                <%--VMI--%>
                <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" HeaderText="VMI Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True" BackColor="White">
                    <HeaderStyle ForeColor="White" />
                    <HeaderContent BackColor="#666666">
                    </HeaderContent>
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent4" runat="server">
                            <table style="table-layout: fixed">
                                <tr>
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabelF8" runat="server" Text="Select Supplier filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF8" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceSup"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF8" OnSelectedIndexChanged="ASPxComboBoxF8_SelectedIndexChanged">
                                            <ClientSideEvents Validation="function(s, e) {
                                                    if (s.GetSelectedIndex()==0) {
                                                    e.isValid = false;
                                                    e.errorText = &quot;You should Select One Supplier&quot;;
                                                    }}" />
                                            <ValidationSettings ValidateOnLeave="False">
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </th>
                                </tr>
                            </table>
                            <hr />
                            <table style="width: 100%">
                                <tr>
                                    <th style="text-align: center; width: 10%;">Report
                                    </th>
                                    <th style="text-align: center; width: 10%;">Actual
                                    </th>
                                    <th style="text-align: center; width: 10%;">AOP
                                    </th>
                                    <th style="text-align: center; width: 10%;">Status
                                    </th>
                                    <th style="text-align: center; width: 50%;">Trend
                                    </th>
                                    <th style="text-align: center; width: 10%;">Details
                                    </th>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <dx:ASPxLabel ID="I03Report" runat="server" Text="VMI" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <dx:ASPxLabel ID="I03Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <dx:ASPxLabel ID="I03AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Image ID="imgI03" runat="server" ImageUrl="~/img/bad.png" />
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Chart ID="chartTI03" runat="server" Height="120px" Width="500px">
                                            <Series>
                                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SlateGray" IsValueShownAsLabel="True" Palette="Grayscale">
                                                </asp:Series>
                                                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle">
                                                </asp:Series>
                                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="0, 192, 0" MarkerStyle="Circle" Name="Series3">
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
                                    <td style="text-align: center">
                                        <a class="btn btn-danger" href="n3_inventory/vmi.aspx">View &raquo;</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <dx:ASPxLabel ID="ASPxLabelV" runat="server" Text="Last update:" Font-Size="Small"></dx:ASPxLabel>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Image ID="ImageSeriesV" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                                    </td>
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <asp:SqlDataSource ID="SqlDataSourceSup" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'vmi' and sfilter = 'supplier' order by sClass"></asp:SqlDataSource>
            </div>
            p></p>
            <hr />
            <p></p>
            <asp:UpdatePanel runat="server" ID="UpdPnl4" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row" id="I04" runat="server">
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" Width="100%" HeaderText="COPQ Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True" BackColor="White">
                            <HeaderStyle ForeColor="White" />
                            <HeaderContent BackColor="#666666">
                            </HeaderContent>
                            <PanelCollection>
                                <dx:PanelContent ID="PanelContent6" runat="server">
                                     <table style="table-layout: fixed">
                                            <th>
                                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Select VSM filter:">
                                                </dx:ASPxLabel>
                                                <dx:ASPxComboBox ID="ASPxComboBoxF9" runat="server" ValueField="sclass"
                                                    TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceCOPQ1"
                                                    AutoPostBack="True" OnDataBound="cmbox_DataBoundF9" OnSelectedIndexChanged="ASPxComboBoxF9_SelectedIndexChanged">
                                                    <ClientSideEvents Validation="function(s, e) {
                                                            if (s.GetSelectedIndex()==0) {
                                                            e.isValid = false;
                                                            e.errorText = &quot;You should Select One VSM&quot;;
                                                            }}" />
                                                    <ValidationSettings ValidateOnLeave="False">
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </th>
                                            <th>
                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Select Cell filter:">
                                                </dx:ASPxLabel>
                                                <dx:ASPxComboBox ID="ASPxComboBoxF10" runat="server" ValueField="sclass"
                                                    TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceCOPQ2"
                                                    AutoPostBack="True" OnDataBound="cmbox_DataBoundF10" OnSelectedIndexChanged="ASPxComboBoxF10_SelectedIndexChanged">
                                                    <ClientSideEvents Validation="function(s, e) {
                                                            if (s.GetSelectedIndex()==0) {
                                                            e.isValid = false;
                                                            e.errorText = &quot;You should Select One Cell&quot;;
                                                            }}" />
                                                    <ValidationSettings ValidateOnLeave="False">
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </th>
                                    </table>
                                    <hr />
                                    <table style="width:100%">
                                       <tr>
                                            <th style="text-align: center; width: 10%;">Report
                                            </th>
                                            <th style="text-align: center; width: 10%;">Actual
                                            </th>
                                            <th style="text-align: center; width: 10%;">AOP
                                            </th>
                                            <th style="text-align: center; width: 10%;">Status
                                            </th>
                                            <th style="text-align: center; width: 50%;">Trend
                                            </th>
                                            <th style="text-align: center; width: 10%;">Details
                                            </th>
                                        </tr>
                                        <tr>
                                        <td style="text-align:center">
                                            <dx:aspxlabel ID="I04Report" runat="server" Text="COPQ" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                                        </td>
                                        <td style="text-align:center">
                                            <dx:aspxlabel ID="I04Actual" runat="server" Text="ASPxLabel"  Font-Size="Medium"></dx:aspxlabel>
                                        </td>
                                        <td style="text-align:center">
                                            <dx:aspxlabel ID="I04AOP" runat="server"  Text="ASPxLabel"  Font-Size="Medium"></dx:aspxlabel>
                                        </td>
                                        <td style="text-align:center">
                                            <asp:Image ID="imgI04" runat="server" ImageUrl="~/img/bad.png" />
                                        </td>
                                        <td style="text-align:center">
                                            <asp:Chart ID="chartTI04" runat="server" Height="120px" Width="500px">
                                                <Series>
                                                    <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SlateGray" IsValueShownAsLabel="True" Palette="Grayscale" CustomProperties="LabelStyle=Top">
                                                        <SmartLabelStyle CalloutLineAnchorCapStyle="None" CalloutLineColor="Transparent" Enabled="False" MovingDirection="Top, TopRight, BottomLeft, BottomRight" />
                                                    </asp:Series>
                                                    <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle" MarkerBorderColor="DodgerBlue" MarkerBorderWidth="3" MarkerColor="White" MarkerSize="8">
                                                    </asp:Series>
                                                    <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series3" Color="0, 192, 0" MarkerStyle="Circle"  MarkerBorderColor="0, 192, 0" MarkerBorderWidth="3" MarkerColor="White" MarkerSize="8">
                                                    </asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1">
                                                        <AxisY Enabled="False" LineWidth="0">
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
                                                </ChartAreas>
                                            </asp:Chart>
                                        </td>
                                        <td style="text-align:center">
                                            <a class="btn btn-danger" href="n3_Delivery/OTTR.aspx">View &raquo;</a>
                                        </td>
                                    </tr>
                                    </table> 
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                         <asp:SqlDataSource ID="SqlDataSourceCOPQ1" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                            SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'COPQ' and sfilter = 'vsm' order by sClass"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSourceCOPQ2" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                            SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'COPQ' and sfilter = 'cell' order by sClass"></asp:SqlDataSource>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
