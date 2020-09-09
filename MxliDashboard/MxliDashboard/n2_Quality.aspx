<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="n2_Quality.aspx.cs" Inherits="MxliDashboard.Quality" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Select View" ForeColor="Black">
        <HeaderStyle ForeColor="White" />
        <HeaderContent BackColor="#666666">
        </HeaderContent>
        <PanelCollection>
            <dx:PanelContent ID="PanelContent1" runat="server">
                <dx:ASPxLabel ID="ASPxLabelCaptionV" runat="server" Text="">
                </dx:ASPxLabel>
                <dx:ASPxComboBox ID="ASPxComboBoxV" runat="server" AutoPostBack="True">
                    <Items>
                        <dx:ListEditItem Selected="True" Text="All" Value="0" />
                        <dx:ListEditItem Text="T1" Value="1" />
                        <dx:ListEditItem Text="T2" Value="2" />
                        <dx:ListEditItem Text="T3" Value="3" />
                        <dx:ListEditItem Text="TFunction" Value="4" />
                        <dx:ListEditItem Text="WarRoom" Value="5" />
                    </Items>
                </dx:ASPxComboBox>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
    <p></p>
    <hr />
    <p></p>
    <div class="row" runat="server" id="Q01">   <%--PPMs--%>
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
                        (PPMs Qty)</th>
                    <th style="text-align:center; width: 25%;">
                        Pareto
                        (PPMs Qty)</th>
                    <th style="text-align:center; width: 8%;">
                        Actions
                    </th>
                    <th style="text-align:center; width: 8%;">
                        Details
                    </th>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="Q01Report" runat="server" Text="PPM ESCAPES" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="Q01Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="Q01AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgQ01" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTQ01" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" Color="IndianRed" MarkerStyle="Circle">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Enabled="False" Title="PPMs" Interval="1" IsLabelAutoFit="False" LineWidth="0">
                                        <MajorGrid Enabled="False" />
                                         <LabelStyle Angle="-90" />
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
                        <asp:Chart ID="chartPQ01" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series2" Color="IndianRed" MarkerStyle="Circle">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Enabled="False" LineWidth="0" Title="PPMs">
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
                        <a class="btn btn-default" href="Actions.aspx?pA=QUALITY&pV=SITE&pM=N/A&pR=ESCAPES_PPM">Edit &raquo;</a>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="n3_quality/escapesppm.aspx">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row" runat="server" id="Q02">   <%--ESCAPES--%>
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
                        <dx:aspxlabel ID="Q02Report" runat="server" Text="ESCAPES" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="Q02Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="Q02AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgQ02" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTQ02" runat="server" Height="120px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Column" Name="Series1" Color="SteelBlue" IsValueShownAsLabel="True">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Spline" Name="Series2" Color="IndianRed" MarkerStyle="Circle">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="Black" MarkerStyle="Square" Name="Series3">
                                    <EmptyPointStyle BorderWidth="0" Color="Transparent" IsVisibleInLegend="False" />
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" Color="Gray" Name="Series4">
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
                        <asp:Chart ID="chartPQ02" runat="server" Height="120px">
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
                        <a class="btn btn-default" href="Actions.aspx?pA=QUALITY&pV=SITE&pM=N/A&pR=ESCAPES">Edit &raquo;</a>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="n3_quality/escapes.aspx">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
    <div class="row" runat="server" id="Q03">   <%--DEFECTS--%>
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
                        <dx:aspxlabel ID="Q03Report" runat="server" Text="DEFECTS" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="Q03Actual" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <dx:aspxlabel ID="Q03AOP" runat="server" Text="ASPxLabel" Font-Size="Medium"></dx:aspxlabel>
                    </td>
                    <td style="text-align:center">
                        <asp:Image ID="imgQ03" runat="server" ImageUrl="~/img/bad.png" />
                    </td>
                    <td style="text-align:center">
                        <asp:Chart ID="chartTQ03" runat="server" Height="120px">
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
                        <asp:Chart ID="chartPQ03" runat="server" Height="120px">
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
                        <a class="btn btn-default" href="Actions.aspx?pA=QUALITY&pV=SITE&pM=N/A&pR=DEFECTS">Edit &raquo;</a>
                    </td>
                    <td style="text-align:center">
                        <a class="btn btn-default" href="n3_quality/defects.aspx">View &raquo;</a>
                    </td>
                </tr>
            </table>          
    </div>
    <p></p>
    <hr />
    <p></p>
</asp:Content>
