﻿<%@ Page Title="Wagenpark" Async="true" MasterPageFile="~/Site.Master" EnableSessionState="False" EnableViewState="False" Trace="false" ViewStateMode="Disabled" Language="C#"  AutoEventWireup="True" CodeBehind="~/Vehicle.aspx.cs" Inherits="WebApplication.Vehicle" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="AuthorizedContent" runat="server">

    </div>
    <div id="AnonymousContent" runat="server">You are not authorized to view this page. Please login.</div>

</asp:Content>
