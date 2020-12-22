<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MxliDashboard.Default" %>

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
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/ban1.jpg" Width="200px" />
                        </th>
                        <th>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/img/ban2.jpg" Width="200px" />
                        </th>
                        <th>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/img/ban3.jpg" Width="200px" />
                        </th>
                        <th>
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/img/ban4.jpg" Width="200px" />
                        </th>
                        <th>
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/img/ban5.jpg" Width="200px" />
                        </th>
                    </tr>
                </table>
                <p></p>
                <table style="width: 100%">
                    <tr>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="DECEMBER" Font-Size="XX-Large" ForeColor="#C20406"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label2" runat="server" Text="ISC AEROSPACIAL" Font-Size="Large"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label3" runat="server" Text="MEXICALI" Font-Size="Large"></asp:Label>
                        </th>
                    </tr>
                </table>
            </div>
            <p></p>
            <div class="jumbotron">
                <table style="width: 100%" >
                    <tr>
                        <th style="text-align: center">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="DASHBOARD" Font-Size="Large" Height="35px" Theme="Office365" Width="150px" OnClick="ASPxButton1_Click"></dx:ASPxButton>
                        </th>
                        <th style="text-align: center">
                            <dx:ASPxButton ID="ASPxButton2" runat="server" Text="YTD" Font-Size="Large" Height="35px" Theme="Office365" Width="150px" OnClick="ASPxButton2_Click"></dx:ASPxButton>
                        </th>
                        <th style="text-align: center">
                            <dx:ASPxButton ID="ASPxButton3" runat="server" Text="METRICS" Font-Size="Large" Height="35px" Theme="Office365" Width="150px" OnClick="ASPxButton3_Click"></dx:ASPxButton>
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
