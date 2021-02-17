<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="xSettings.aspx.cs" Inherits="MxliDashboard.xSettings" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <p></p>
            <div class="jumbotron">
                <table style="width: 100%">
                    <tr>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="SETTINGS" Font-Size="XX-Large" ForeColor="#C20406"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label2" runat="server" Text="Select an option" Font-Size="Large"></asp:Label>
                        </th>
                    </tr>
                </table>
            </div>
            <p></p>
            <div class="jumbotron">
                <asp:Label ID="LabelFunctions" runat="server" Text="Goals Parameters:" Font-Size="Large"></asp:Label>
                <hr />
                </p>
                <table style="width: 100%" >
                    <tr>
                        <th style="text-align: center">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="AOP Goals" Font-Size="Large" Height="35px" Theme="Office365" Width="150px" OnClick="ASPxButton1_Click"></dx:ASPxButton>
                        </th>
                        <th style="text-align: center">
                            <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Forecast" Font-Size="Large" Height="35px" Theme="Office365" Width="150px" OnClick="ASPxButton2_Click"></dx:ASPxButton>
                        </th>
                        <th style="text-align: center">
                            <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Highlights" Font-Size="Large" Height="35px" Theme="Office365" Width="150px" OnClick="ASPxButton3_Click"></dx:ASPxButton>
                        </th>
                    </tr>
                </table>
            </div>
            <div class="jumbotron">
                <asp:Label ID="Label3" runat="server" Text="System catalogs:" Font-Size="Large"></asp:Label>
                <hr />
                </p>
                <table style="width: 100%" >
                    <tr>
                        <th style="text-align: center">
                            <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Actions" Font-Size="Large" Height="35px" Theme="Office365" Width="150px" OnClick="ASPxButton4_Click"></dx:ASPxButton>
                        </th>
                        <th style="text-align: center">
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="VSM/AREA/CELL" Font-Size="Large" Height="35px" Theme="Office365" Width="150px" OnClick="ASPxButton5_Click"></dx:ASPxButton>
                        </th>
                        <th style="text-align: center">
                            <dx:ASPxButton ID="ASPxButton6" runat="server" Text="METRICS" Font-Size="Large" Height="35px" Theme="Office365" Width="150px" OnClick="ASPxButton6_Click"></dx:ASPxButton>
                        </th>
                    </tr>
                </table>
            </div>
            <p></p>
            <div class="jumbotron">
                <table style="width: 100%">
                    <tr>
                        <th>
                            <asp:Image ID="Image9" runat="server" ImageUrl="~/img/logo.png" Width="150px" />
                        </th>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
