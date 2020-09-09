<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="n2_Inventory.aspx.cs" Inherits="MxliDashboard.Inventory" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">   <%--Inventory--%>
        <p></p>
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Filters" ForeColor="Black">
            <HeaderStyle ForeColor="White" />
            <HeaderContent BackColor="#666666">
            </HeaderContent>
            <PanelCollection>
                <dx:PanelContent ID="PanelContent1" runat="server">
                    <table style="table-layout: fixed">
                        <tr>
                            <th>
                                <dx:ASPxLabel ID="ASPxLabelCaption2" runat="server" Text="Select VSM:">
                                </dx:ASPxLabel>
                                <dx:ASPxComboBox ID="ASPxComboBoxVsmInContent" runat="server" ValueField="sclass"
                                    TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceVsm"
                                    AutoPostBack="True" OnDataBound="cmbox_DataBoundVsm" OnSelectedIndexChanged="ASPxComboBoxVsmInContent_SelectedIndexChanged">
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
                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Select Cell:">
                                </dx:ASPxLabel>
                                <dx:ASPxComboBox ID="ASPxComboBoxCellInContent" runat="server" ValueField="sclass"
                                    TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceCell"
                                    AutoPostBack="True" OnDataBound="cmbox_DataBoundCell" OnSelectedIndexChanged="ASPxComboBoxCellInContent_SelectedIndexChanged">
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
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxRoundPanel>
        <asp:SqlDataSource ID="SqlDataSourceVsm" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
            SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where sfilter = 'vsm' order by sClass" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceCell" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
            SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where sfilter = 'cell' order by sClass"></asp:SqlDataSource>
        <p></p>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 12%;">
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
                    <th style="text-align:center; width: 48%;">
                        Trend
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
                        <dx:aspxlabel ID="I01Report" runat="server" Text="INVENTORY" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="I01Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="I01AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgI01" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTI01" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" Color="IndianRed" MarkerStyle="Circle">
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
                        <a class="btn btn-default" href="n3_inventory/inventory.aspx">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row">   <%--WIP ENTITLEMENT--%>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 12%;">
                        Report
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Actual
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Ideal
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Status
                    </th>
                    <th style="text-align:center; width: 48%;">
                        Trend
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
                        <dx:aspxlabel ID="I02Report" runat="server" Text="WIP ENTITLEMENT" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="I02Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="I02AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgI02" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTI02" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" Color="IndianRed" MarkerStyle="Circle">
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
                        <a class="btn btn-default" href="n3_inventory/entitlement.aspx">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row">   <%--VMI--%>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 12%;">
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
                    <th style="text-align:center; width: 48%;">
                        Trend
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
                        <dx:aspxlabel ID="I03Report" runat="server" Text="VMI" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="I03Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="I03AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgI03" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTI03" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" Color="IndianRed" MarkerStyle="Circle">
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
                        <a class="btn btn-default" href="n3_inventory/vmi.aspx">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
</asp:Content>
