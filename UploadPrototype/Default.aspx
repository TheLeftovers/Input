<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <p>
                Select .csv file to upload:
                <asp:FileUpload runat="server" ID="FileUpload1" />
            </p>
            <asp:Button ID="btnSubmit" OnClick="UploadFile" runat="server" Text="Upload" />
        </div>
</asp:Content>
