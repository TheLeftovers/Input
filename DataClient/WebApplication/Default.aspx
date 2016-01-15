<%@ Page Title="Home" EnableSessionState="ReadOnly" EnableViewState="false" Trace="false" ViewStateMode="Disabled" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h4 class="welcome">
            <img src="img/cg.jpg" />
            <br />
            <br />
            <b>Welkom op het CityGIS Dashboard. </b>
            <br />
            <br />
            Hier kunt u verschillende analyses vinden over de voertuigen
            <br />
            van de hulpdiensten in regio Rijnmond en de hard- en software van CityGIS,
            <br />
            Om deze analyses te kunnen zien moet u inloggen.
            <br />
            <br />
            <a href="Account/Login.aspx"><b>Inloggen</b></a>
        </h4>
    </div>



</asp:Content>
