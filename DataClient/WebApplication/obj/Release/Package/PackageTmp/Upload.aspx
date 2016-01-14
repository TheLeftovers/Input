<%@ Page Language="C#" Title="Upload" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="Upload.aspx.cs" Inherits="WebApplication.Upload" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
        <br />

            <input type=file id=File1 name=File1 runat="server" />
            <br />
            <input type="submit" id="Submit1" value="Upload" runat="server" name="Submit1" />
          <br />
</asp:Content>
