﻿<%@ Page Title="CityGIS Hard- en Software" Async="true" MasterPageFile="~/Site.Master" EnableSessionState="False" EnableViewState="False" Trace="false" ViewStateMode="Disabled" Language="C#"  AutoEventWireup="True" CodeBehind="~/Citygis.aspx.cs" Inherits="WebApplication.Citygis" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <br />

    <div id="AuthorizedContent" runat="server">
        
        <h4>Te Reparen Wagens</h4>
        
        <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Font-Size="13px">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Unit ID</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

        <br /><br />

        <asp:Image ID="Image1" runat="server" Visible="False" />
        
    </div>
    <div id="AnonymousContent" runat="server">
        You are not authorized to view this page. Please login.</div>
</asp:Content>