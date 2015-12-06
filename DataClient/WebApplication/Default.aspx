﻿<%@ Page Title="Home Page" Async="true" EnableSessionState="ReadOnly" EnableViewState="true" Trace="false" ViewStateMode="Enabled" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Chart ID="Chart1" runat="server" Height="350px" Width="350px" TextAntiAliasingQuality="Normal" RenderType="ImageTag" ImageStorageMode="UseHttpHandler" Compression="50" AntiAliasing="Graphics">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>

    

</asp:Content>
