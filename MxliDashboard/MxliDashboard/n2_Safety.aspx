<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Safety.aspx.cs" Inherits="MxliDashboard.Safety" %>

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
    <hr />
    <p></p>
    <div class="row" runat="server" id="S01">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" HeaderText="Incidents filters" ForeColor="Black" AllowCollapsingByHeaderClick="True" BackColor="White">
            <HeaderStyle ForeColor="White" />
            <HeaderContent BackColor="#666666">
            </HeaderContent>
            <PanelCollection>
                <dx:PanelContent ID="PanelContent1" runat="server">
                    <table style="table-layout: fixed">
                        <tr>
                            <th>
                                <dx:ASPxLabel ID="ASPxLabelCaptionF1" runat="server" Text="Select Area filter:">
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
                        </tr>
                    </table>
                    <hr />
                    <table style="width: 100%">
                        <tr>
                            <th style="text-align: center; width: 8%;">Report
                            </th>
                            <th style="text-align: center; width: 8%;">Actual
                            </th>
                            <th style="text-align: center; width: 8%;">AOP
                            </th>
                            <th style="text-align: center; width: 8%;">Status
                            </th>
                            <th style="text-align: center; width: 30%;">Trend
                            </th>
                            <th style="text-align: center; width: 30%;">Pareto
                            </th>
                            <th style="text-align: center; width: 8%;">Details
                            </th>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <dx:ASPxLabel ID="S01Report" runat="server" Text="Incidentes" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:ASPxLabel>
                            </td>
                            <td style="text-align: center">
                                <dx:ASPxLabel ID="S01Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:ASPxLabel>
                            </td>
                            <td style="text-align: center">
                                <dx:ASPxLabel ID="S01AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:ASPxLabel>
                            </td>
                            <td style="text-align: center">
                                <asp:Image ID="imgS01" runat="server" ImageUrl="~/img/bad.png" />
                            </td>
                            <td style="text-align: center">
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
                            <td style="text-align: center">
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
                            <td style="text-align: center">
                                <a class="btn btn-danger" href="n3_safety/incidentes.aspx">View &raquo;</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <dx:ASPxLabel ID="ASPxLabelS01" runat="server" Text="Last update:" Font-Size="Small"></dx:ASPxLabel>
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
            SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric in ('incidentes') and sfilter = 'vsm' order by sClass"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceCell" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
            SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric in ('incidentes') and sfilter = 'cell' order by sClass"></asp:SqlDataSource>
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row" runat="server" id="S02">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" HeaderText="MST Actions filters" ForeColor="Black" AllowCollapsingByHeaderClick="True" BackColor="White">
            <HeaderStyle ForeColor="White" />
            <HeaderContent BackColor="#666666">
            </HeaderContent>
            <PanelCollection>
                <dx:PanelContent ID="PanelContent3" runat="server">
                    <table style="table-layout: fixed">
                        <tr>
                            <th>
                                <dx:ASPxLabel ID="ASPxLabelCaptionF3" runat="server" Text="Select responsible filter:">
                                </dx:ASPxLabel>
                                <dx:ASPxComboBox ID="ASPxComboBoxF3" runat="server" ValueField="sclass"
                                    TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceRes"
                                    AutoPostBack="True" OnDataBound="cmbox_DataBoundF3" OnSelectedIndexChanged="ASPxComboBoxF3_SelectedIndexChanged">
                                    <ClientSideEvents Validation="function(s, e) {
                                            if (s.GetSelectedIndex()==0) {
                                            e.isValid = false;
                                            e.errorText = &quot;You should Select One Responsible&quot;;
                                            }}" />
                                    <ValidationSettings ValidateOnLeave="False">
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                            </th>
                            <th>
                                <dx:ASPxLabel ID="ASPxLabelCaptionF4" runat="server" Text="Select Status filter:">
                                </dx:ASPxLabel>
                                <dx:ASPxComboBox ID="ASPxComboBoxF4" runat="server" ValueField="sclass"
                                    TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceSta"
                                    AutoPostBack="True" OnDataBound="cmbox_DataBoundF4" OnSelectedIndexChanged="ASPxComboBoxF4_SelectedIndexChanged">
                                    <ClientSideEvents Validation="function(s, e) {
                                            if (s.GetSelectedIndex()==0) {
                                            e.isValid = false;
                                            e.errorText = &quot;You should Select One Status&quot;;
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
                            <th style="text-align: center; width: 8%;">Report
                            </th>
                            <th style="text-align: center; width: 8%;">Actual
                            </th>
                            <th style="text-align: center; width: 8%;">AOP
                            </th>
                            <th style="text-align: center; width: 8%;">Status
                            </th>
                            <th style="text-align: center; width: 30%;">Trend
                            </th>
                            <th style="text-align: center; width: 30%;">Pareto
                            </th>
                            <th style="text-align: center; width: 8%;">Details
                            </th>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <dx:ASPxLabel ID="S02Report" runat="server" Text="MST Actions" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:ASPxLabel>
                            </td>
                            <td style="text-align: center">
                                <dx:ASPxLabel ID="S02Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:ASPxLabel>
                            </td>
                            <td style="text-align: center">
                                <dx:ASPxLabel ID="S02AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:ASPxLabel>
                            </td>
                            <td style="text-align: center">
                                <asp:Image ID="imgS02" runat="server" ImageUrl="~/img/bad.png" />
                            </td>
                            <td style="text-align: center">
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
                            <td style="text-align: center">
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
                            <td style="text-align: center">
                                <a class="btn btn-danger" href="n3_safety/mstactions.aspx">View &raquo;</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <dx:ASPxLabel ID="ASPxLabelS02" runat="server" Text="Last update:" Font-Size="Small"></dx:ASPxLabel>
                            </td>
                            <td style="text-align: center">
                                <asp:Image ID="ImageSeriesM" runat="server" ImageUrl="~/img/chartSeries.png" Height="16px" />
                            </td>
                        </tr>
                    </table>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxRoundPanel>
        <asp:SqlDataSource ID="SqlDataSourceRes" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
            SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric in ('mst') and sfilter = 'responsible' order by sClass"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceSta" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
            SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric in ('mst') and sfilter = 'status' order by sClass"></asp:SqlDataSource>
    </div>
    <p></p>
    <hr />   
    <p></p>
    
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
