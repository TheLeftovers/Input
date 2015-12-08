<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="WebApplication.UploadFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>This is a test for the uploading of files.</title>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
         <h3> File Upload:</h3>
         <br />
         <asp:FileUpload ID="FileUpload1" runat="server" />
         <br /><br />
         <asp:Button ID="btnsave" runat="server" onclick="btnsave_Click"  Text="Save" style="width:85px" />
         <br /><br />
         <asp:Label ID="lblmessage" runat="server" />
      </div>
    </form>
</body>
</html>
