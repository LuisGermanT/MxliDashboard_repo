<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YTD.aspx.cs" Inherits="MxliDashboard.YTD" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
            </div>
            <p></p>
            <div>
                <table style="width: 100%">
                    <tr>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="YTD Actual vs Plan" Font-Size="XX-Large" ForeColor="#C20406"></asp:Label>
                        </th>
                    </tr>
                </table>
            </div>
            <p></p>
            <div>
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" Width="1180px" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared" >
                    <SettingsPager Visible="False" PageSize="50"></SettingsPager>
                    <SettingsBehavior AllowCellMerge="true" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="METRIC" FieldName="metric" VisibleIndex="0" Width="160px" FixedStyle="Left">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="TYPE"  FieldName="metric2" VisibleIndex="1" Width="90px" FixedStyle="Left">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="JAN" FieldName="mjan" VisibleIndex="2" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="FEB" FieldName="mfeb" VisibleIndex="3" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="MAR" FieldName="mmar" VisibleIndex="4" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="APR" FieldName="mapr" VisibleIndex="5" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="MAY" FieldName="mmay" VisibleIndex="6" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="JUN" FieldName="mjun" VisibleIndex="7" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="JUL" FieldName="mjul" VisibleIndex="8" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="AUG" FieldName="maug" VisibleIndex="9" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="SEP" FieldName="msep" VisibleIndex="10" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="OCT" FieldName="moct" VisibleIndex="11" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="NOV" FieldName="mnov" VisibleIndex="12" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="DEC" FieldName="mdec" VisibleIndex="13" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="YTD" FieldName="ytd" VisibleIndex="14" Width="65px">
                            <Settings AllowCellMerge="False" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataHyperLinkColumn Caption="DETAILS" FieldName="url" VisibleIndex="15" Width="75px">
                            <PropertiesHyperLinkEdit NavigateUrlFormatString = "{0}" Text="View" Style-HorizontalAlign="Center" ></PropertiesHyperLinkEdit>
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataHyperLinkColumn>                       
                    </Columns>
                    <Settings HorizontalScrollBarMode="Visible" VerticalScrollBarMode="Hidden"  VerticalScrollableHeight="760"/>
                    <Styles>
                        <Header BackColor="#666666" Border-BorderColor="White" Border-BorderStyle="Solid" Border-BorderWidth="3px" Font-Size="Medium" ForeColor="White" HorizontalAlign="Center"></Header>
                        <Row Font-Size="Medium"></Row>
                        <AlternatingRow BackColor="#F3F3F3"></AlternatingRow>
                        <FixedColumn BackColor="LightYellow" />
                    </Styles>                    
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_1033_DashboardConnectionString %>" SelectCommand="
                    SELECT [metric], [metric2], [mjan], [mfeb], [mmar], [mapr], [mmay], [mjun], [mjul], [maug], [msep], [moct], [mnov], [mdec], [ytd], [url], [style] FROM [DB_1033_Dashboard].[dbo].[tbl_ytd]
                "></asp:SqlDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
