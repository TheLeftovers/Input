<%@ Page Title="Wagenpark" Async="true" MasterPageFile="~/Site.Master" EnableSessionState="False" EnableViewState="False" Trace="false" ViewStateMode="Disabled" Language="C#"  AutoEventWireup="True" CodeBehind="~/Vehicle.aspx.cs" Inherits="WebApplication.Vehicle" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="AuthorizedContent" runat="server">
        Top 10 hoogste snelheden per UnitID.
        <br />
        <asp:Chart ID="Chart1" runat="server" Height="350px" Width="350px" TextAntiAliasingQuality="Normal" RenderType="ImageTag" ImageStorageMode="UseImageLocation" Compression="50" AntiAliasing="Graphics" ViewStateContent="Default" ImageLocation="~/TempImages/ChartPicture_#SEQ(300,5)">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    <div id="AnonymousContent" runat="server">You are not autorized to view this page. Please login.</div>
    

</asp:Content>
