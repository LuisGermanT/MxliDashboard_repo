<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="n2_Delivery.aspx.cs" Inherits="MxliDashboard.n2_Delivery" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <div class="row">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Views" ForeColor="Black" AllowCollapsingByHeaderClick="True">
            <HeaderStyle ForeColor="White" />
            <HeaderContent BackColor="#666666">
            </HeaderContent>
            <PanelCollection>
                <dx:PanelContent ID="PanelContent2" runat="server">
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
    <p></p>
    <div class="row">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" HeaderText="Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True">
            <HeaderStyle ForeColor="White" />
            <HeaderContent BackColor="#666666">
            </HeaderContent>
            <PanelCollection>
                <dx:PanelContent ID="PanelContent1" runat="server">
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
    <div class="row" runat="server" id="D01">   <%--OTTR--%>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 150px;">
                        Report
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Actual
                    </th>
                    <th style="text-align:center; width: 100px;">
                        AOP
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Status
                    </th>
                    <th style="text-align:center" width="30%">
                        Trend
                    </th>
                    <th style="text-align:center" width="30%">
                        Pareto
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Details
                    </th>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D01Report" runat="server" Text="OTTR" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D01Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D01AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgD01" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTD01" runat="server" Height="120px" Width="500px">
                        <Series>
                            <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SlateGray" IsValueShownAsLabel="True" Palette="Grayscale" CustomProperties="LabelStyle=Top">
                                <SmartLabelStyle CalloutLineAnchorCapStyle="None" CalloutLineColor="Transparent" Enabled="False" MovingDirection="Top, TopRight, BottomLeft, BottomRight" />
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" Color="DodgerBlue" MarkerStyle="Circle" MarkerBorderColor="DodgerBlue" MarkerBorderWidth="3" MarkerColor="White" MarkerSize="8">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="0, 192, 0" MarkerStyle="Circle" Name="Series3" MarkerBorderColor="0, 192, 0" MarkerBorderWidth="3" MarkerColor="White" MarkerSize="8">
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
                        <asp:Chart ID="chartPD01" runat="server" Height="120px">
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
                        <a class="btn btn-danger" href="n3_Delivery/OTTR.aspx">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row" runat="server" id="D02">   <%--PAST DUE--%>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 150px;">
                        Report
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Actual
                    </th>
                    <th style="text-align:center; width: 100px;">
                        AOP
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Status
                    </th>
                    <th style="text-align:center" width="30%">
                        Trend
                    </th>
                    <th style="text-align:center" width="30%">
                        Pareto
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Details
                    </th>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D02Report" runat="server" Text="PAST DUE" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D02Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D02AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgD02" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTD02" runat="server" Height="120px">
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
                        <asp:Chart ID="chartPD02" runat="server" Height="120px">
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
                        <a class="btn btn-danger" href="n3_Delivery">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row" runat="server" id="D03">   <%--WIP TRACKER--%>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 150px;">
                        Report
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Actual
                    </th>
                    <th style="text-align:center; width: 100px;">
                        AOP
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Status
                    </th>
                    <th style="text-align:center" width="30%">
                        Trend
                    </th>
                    <th style="text-align:center" width="30%">
                        Pareto
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Details
                    </th>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D03Report" runat="server" Text="WIP TRACKER" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D03Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D03AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgD03" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTD03" runat="server" Height="120px">
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
                        <asp:Chart ID="chartPD03" runat="server" Height="120px">
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
                        <a class="btn btn-danger" href="n3_Delivery">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row" runat="server" id="D04">   <%--MANUFACTURING CYCLE TIME--%>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 150px;">
                        Report
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Actual
                    </th>
                    <th style="text-align:center; width: 100px;">
                        AOP
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Status
                    </th>
                    <th style="text-align:center" width="30%">
                        Trend
                    </th>
                    <th style="text-align:center" width="30%">
                        Pareto
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Details
                    </th>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D04Report" runat="server" Text="MCT (Cycle Time)" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D04Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D04AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgD04" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTD04" runat="server" Height="120px">
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
                        <asp:Chart ID="chartPD04" runat="server" Height="120px">
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
                        <a class="btn btn-danger" href="n3_Delivery">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row" runat="server" id="D05">   <%--OEE--%>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 150px;">
                        Report
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Actual
                    </th>
                    <th style="text-align:center; width: 100px;">
                        AOP
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Status
                    </th>
                    <th style="text-align:center" width="30%">
                        Trend
                    </th>
                    <th style="text-align:center" width="30%">
                        Pareto
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Details
                    </th>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D05Report" runat="server" Text="OEE (Downtime)" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D05Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D05AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgD05" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTD05" runat="server" Height="120px">
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
                        <asp:Chart ID="chartPD05" runat="server" Height="120px">
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
                        <a class="btn btn-danger" href="n3_Delivery">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row" runat="server" id="D06">   <%--OTP--%>
            <table style="width:100%">
                <tr>
                    <th style="text-align:center; width: 150px;">
                        Report
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Actual
                    </th>
                    <th style="text-align:center; width: 100px;">
                        AOP
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Status
                    </th>
                    <th style="text-align:center" width="30%">
                        Trend
                    </th>
                    <th style="text-align:center" width="30%">
                        Pareto
                    </th>
                    <th style="text-align:center; width: 100px;">
                        Details
                    </th>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D06Report" runat="server" Text="OTP (OnTime to Promise)" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D06Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="D06AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgD06" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTD06" runat="server" Height="120px">
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
                        <asp:Chart ID="chartPD06" runat="server" Height="120px">
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
                        <a class="btn btn-danger" href="n3_Delivery">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
</asp:Content>
