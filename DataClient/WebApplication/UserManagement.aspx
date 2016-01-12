<%@ Page Title="Beheer" Async="true" MasterPageFile="~/Site.Master" EnableSessionState="False" EnableViewState="False" Trace="false" ViewStateMode="Disabled" Language="C#"  AutoEventWireup="True" CodeBehind="~/UserManagement.aspx.cs" Inherits="WebApplication.UserManagement" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <br />

    Emails
    <asp:DropDownList ID="maildrop" runat="server" Width="200px">
    </asp:DropDownList>
    <br /><br />
    Ranks
    <asp:DropDownList ID="rankdrop" runat="server" Width="200px">
        <asp:ListItem>0</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
    </asp:DropDownList>
    <br /><br />
    <asp:Button ID="Button1" runat="server" Text="Update" OnClick="UpdateUser" />
    <br /><br />
    <h4>Ranks</h4>
    <ul>
        <li>0: Commerciele partijen</li>
        <li>1: CityGIS personeel</li>
        <li>2: Administrator</li>
    </ul>



</asp:Content>
