<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="Upload.aspx.cs" Inherits="WebApplication.Upload" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <input type=file id=File1 name=File1 runat="server" />
            <br />
            <input type="submit" id="Submit1" value="Upload" runat="server" name="Submit1" />
          <br />
</asp:Content>
