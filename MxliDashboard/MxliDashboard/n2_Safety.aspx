<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Safety.aspx.cs" Inherits="MxliDashboard.Safety" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <hr />
    <p></p>
    <div class="row">   <%--No incidentes--%>
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
                        <dx:aspxlabel ID="S03Report" runat="server" Text="No Incidentes" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
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
    <div class="row">   <%--MST Actions--%>
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
                        <dx:aspxlabel ID="S01Report" runat="server" Text="MST Actions" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
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
    <div class="row">   <%--Training--%>
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
                        <dx:aspxlabel ID="S02Report" runat="server" Text="Training" Font-Size="Medium" Font-Bold="True" ForeColor="#333333"></dx:aspxlabel>
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
</asp:Content>
