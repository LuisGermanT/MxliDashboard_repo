<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="n2_Delivery.aspx.cs" Inherits="MxliDashboard.n2_Delivery" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <p></p>
            <hr />
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
                                <dx:ASPxComboBox ID="ASPxComboBoxVsmInContent" runat="server" ValueField="TO_rArea"
                                    TextField="TO_rArea" ValueType="System.String" DataSourceID="SqlDataSourceVsm"
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
                                <dx:ASPxComboBox ID="ASPxComboBoxCellInContent" runat="server" ValueField="TO_Cell"
                                    TextField="TO_Cell" ValueType="System.String" DataSourceID="SqlDataSourceCell"
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
                             <th>
                                <dx:ASPxLabel ID="ASPxLabelCaption4" runat="server" Text="Select Mrp:">
                                </dx:ASPxLabel>
                                <dx:ASPxComboBox ID="ASPxComboBoxMrpInContent" runat="server" ValueField="TO_MRP"
                                    TextField="TO_MRP" ValueType="System.String" DataSourceID="SqlDataSourceMrp"
                                    AutoPostBack="True" OnDataBound="cmbox_DataBoundMrp" OnSelectedIndexChanged="ASPxComboBoxMrpInContent_SelectedIndexChanged">
                                    <ClientSideEvents Validation="function(s, e) {
                                            if (s.GetSelectedIndex()==0) {
                                            e.isValid = false;
                                            e.errorText = &quot;You should Select One Mrp&quot;;
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

           <asp:SqlDataSource ID="SqlDataSourceCell" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [TO_Cell] FROM [tblOTTR] WHERE [TO_rArea] <> 'Buy Parts' AND [TO_rArea] <> 'R&O' order by [TO_Cell]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceVsm" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [TO_rArea] FROM [tblOTTR] WHERE [TO_rArea] <> 'Buy Parts' AND [TO_rArea] <> 'R&O' order by [TO_rArea]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceMrp" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT distinct [TO_MRP] FROM [tblOTTR] WHERE [TO_rArea] <> 'Buy Parts' AND [TO_rArea] <> 'R&O' order by [TO_MRP]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceFilters" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                SelectCommand="SELECT TOP 2 * FROM [tblFilters]"></asp:SqlDataSource>

            <p></p>
            <div class="row">   <%--OTTR--%>
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
                        Actions
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
                        <asp:Chart ID="chartTD01" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" Name="Series2" Color="SteelBlue" Enabled="False">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series3" Color="IndianRed" MarkerStyle="Circle" BorderWidth="2" MarkerBorderColor="IndianRed" MarkerBorderWidth="2" MarkerColor="White" YAxisType="Secondary">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Enabled="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Format="{0:#,#}" />
                                    </AxisY>
                                    <AxisX Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                    <AxisX2 LineWidth="0">
                                    </AxisX2>
                                    <AxisY2 LineWidth="0">
                                        <LabelStyle Format="{0:0.00%}" />
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
                        <a class="btn btn-default" href="#">Edit &raquo;</a>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="n3_Delivery/OTTR.aspx">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
            <p></p>
            <hr />
            <p></p>
            <div class="row">   <%--PAST DUE--%>
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
                                Actions
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
                                <a class="btn btn-default" href="/Safety">Edit &raquo;</a>
                            </td>
                            <td style="text-align:center">
                                <a class="btn btn-default" href="/Safety">View &raquo;</a>
                            </td>
                        </tr>
                    </table>          
            </div>
            <p></p>
            <hr />
            <p></p>
            <div class="row">   <%--WIP TRACKER--%>
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
                                Actions
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
                                <a class="btn btn-default" href="/Safety">Edit &raquo;</a>
                            </td>
                            <td style="text-align:center">
                                <a class="btn btn-default" href="/Safety">View &raquo;</a>
                            </td>
                        </tr>
                    </table>          
            </div>
            <p></p>
            <hr />
            <p></p>
            <div class="row">   <%--MANUFACTURING CYCLE TIME--%>
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
                        Actions
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
                        <a class="btn btn-default" href="/Safety">Edit &raquo;</a>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="/Safety">View &raquo;</a>
                    </td>
                </tr>
            </table>          
            </div>
            <p></p>
            <hr />
            <p></p>
            <div class="row">   <%--OEE--%>
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
                            Actions
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
                            <a class="btn btn-default" href="/Safety">Edit &raquo;</a>
                        </td>
                        <td style="text-align:center">
                            <a class="btn btn-default" href="/Safety">View &raquo;</a>
                        </td>
                    </tr>
                </table>          
            </div>
            <p></p>
            <hr />
            <p></p>
            <div class="row">   <%--OTP--%>
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
                            Actions
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
                        <a class="btn btn-default" href="/Safety">Edit &raquo;</a>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="/Safety">View &raquo;</a>
                    </td>
                    </tr>
                </table>          
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        
</asp:Content>
