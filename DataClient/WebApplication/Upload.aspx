<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="WebApplication.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
      <body ms_positioning="GridLayout">
        <form id="Form1" method="post" enctype="multipart/form-data" runat="server">
            <input type=file id=File1 name=File1 runat="server" />
            <br />
            <input type="submit" id="Submit1" value="Upload" runat="server" name="Submit1" />
        </form>
  </body>
</html>
