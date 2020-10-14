<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="n2_Delivery.aspx.cs" Inherits="MxliDashboard.n2_Delivery" %>

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
             <div class="row" runat="server" id="D01">   <%--OTTR--%>
                <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" HeaderText="OTTR Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True" BackColor="White">
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
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceVsm1"
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
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceCell1"
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
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceMrp1"
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
                            <hr />
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
                                <dx:aspxlabel ID="D01Actual" runat="server" Text="" Font-Size="Medium"></dx:aspxlabel>
                            </td>
                            <td style="text-align:center">
                                <dx:aspxlabel ID="D01AOP" runat="server" Text="" Font-Size="Medium"></dx:aspxlabel>
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
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <asp:SqlDataSource ID="SqlDataSourceVsm1" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'ottr' and sfilter = 'vsm' order by sClass"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceCell1" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'ottr' and sfilter = 'cell' order by sClass"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceMrp1" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'ottr' and sfilter = 'mrp' order by sClass"></asp:SqlDataSource>
            </div>
            <p></p>
            <hr />
            <p></p>
             <div class="row" runat="server" id="D02">   <%--Output--%>
                <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" HeaderText="Output Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True" BackColor="White">
                    <HeaderStyle ForeColor="White" />
                    <HeaderContent BackColor="#666666">
                    </HeaderContent>
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <table style="table-layout: fixed">
                                <tr>                           
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabelF4" runat="server" Text="Select VSM filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF4" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceVsm2"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF4" OnSelectedIndexChanged="ASPxComboBoxF4_SelectedIndexChanged">
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
                                        <dx:ASPxLabel ID="ASPxLabelF5" runat="server" Text="Select Cell filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF5" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceCell2"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF5" OnSelectedIndexChanged="ASPxComboBoxF5_SelectedIndexChanged">
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
                                        <dx:ASPxLabel ID="ASPxLabelF6" runat="server" Text="Select MRP filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF6" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceMrp2"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF6" OnSelectedIndexChanged="ASPxComboBoxF6_SelectedIndexChanged">
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
                            <hr />
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
                                <dx:aspxlabel ID="D02Report" runat="server" Text="OUTPUT" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                            </td>
                            <td style="text-align:center">
                                <dx:aspxlabel ID="D02Actual" runat="server" Text="" Font-Size="Medium"></dx:aspxlabel>
                            </td>
                            <td style="text-align:center">
                                <dx:aspxlabel ID="D02AOP" runat="server" Text="" Font-Size="Medium"></dx:aspxlabel>
                            </td>
                            <td style="text-align:center">
                                <asp:Image ID="imgD02" runat="server" ImageUrl="~/img/bad.png" />
                            </td>
                            <td style="text-align:center">
                                <asp:Chart ID="chartTD02" runat="server" Height="120px" Width="500px">
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
                                <a class="btn btn-danger" href="n3_Delivery/output.aspx">View &raquo;</a>
                            </td>
                        </tr>
                    </table>       
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <asp:SqlDataSource ID="SqlDataSourceVsm2" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'output' and sfilter = 'vsm' order by sClass"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceCell2" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'output' and sfilter = 'cell' order by sClass"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceMrp2" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'output' and sfilter = 'mrp' order by sClass"></asp:SqlDataSource>
            </div>
           <p></p>
            <hr />
            <p></p>
             <div class="row" runat="server" id="D03">   <%--PD--%>
                <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" HeaderText="Past Due Filters" ForeColor="Black" AllowCollapsingByHeaderClick="True" BackColor="White">
                    <HeaderStyle ForeColor="White" />
                    <HeaderContent BackColor="#666666">
                    </HeaderContent>
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent4" runat="server">
                            <table style="table-layout: fixed">
                                <tr>                           
                                    <th>
                                        <dx:ASPxLabel ID="ASPxLabelF7" runat="server" Text="Select VSM filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF7" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceVsm3"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF7" OnSelectedIndexChanged="ASPxComboBoxF7_SelectedIndexChanged">
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
                                        <dx:ASPxLabel ID="ASPxLabelF8" runat="server" Text="Select Cell filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF8" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceCell3"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF8" OnSelectedIndexChanged="ASPxComboBoxF8_SelectedIndexChanged">
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
                                        <dx:ASPxLabel ID="ASPxLabelF9" runat="server" Text="Select MRP filter:">
                                        </dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="ASPxComboBoxF9" runat="server" ValueField="sclass"
                                            TextField="sclass" ValueType="System.String" DataSourceID="SqlDataSourceMrp3"
                                            AutoPostBack="True" OnDataBound="cmbox_DataBoundF9" OnSelectedIndexChanged="ASPxComboBoxF9_SelectedIndexChanged">
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
                            <hr />
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
                                <dx:aspxlabel ID="D03Report" runat="server" Text="PAST DUE" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                            </td>
                            <td style="text-align:center">
                                <dx:aspxlabel ID="D03Actual" runat="server" Text="" Font-Size="Medium"></dx:aspxlabel>
                            </td>
                            <td style="text-align:center">
                                <dx:aspxlabel ID="D03AOP" runat="server" Text="" Font-Size="Medium"></dx:aspxlabel>
                            </td>
                            <td style="text-align:center">
                                <asp:Image ID="imgD03" runat="server" ImageUrl="~/img/bad.png" />
                            </td>
                            <td style="text-align:center">
                                <asp:Chart ID="chartTD03" runat="server" Height="120px" Width="500px">
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
                                <a class="btn btn-danger" href="n3_Delivery/pastdue.aspx">View &raquo;</a>
                            </td>
                        </tr>
                    </table>       
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <asp:SqlDataSource ID="SqlDataSourceVsm3" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'pastdue' and sfilter = 'vsm' order by sClass"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceCell3" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'pastdue' and sfilter = 'cell' order by sClass"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceMrp3" runat="server" ConnectionString="Data Source=MX29W1009;Initial Catalog=DB_1033_Dashboard;Persist Security Info=True;User ID=OPEX_Users;Password=Gqb%Pjo7XZ"
                    SelectCommand="SELECT distinct [sClass] FROM [sta_nivel2] where smetric = 'pastdue' and sfilter = 'mrp' order by sClass"></asp:SqlDataSource>
            </div>

            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
