<%@ Page Title="CityGis DashBoard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataClient._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   

    <asp:Chart ID="Chart1" runat="server" Palette="EarthTones" OnLoad="Page_Load" Height="500px" Width="500px">
        <Series>
            <asp:Series Name="Series1" IsXValueIndexed="True"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX IntervalAutoMode="VariableCount">
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

    <br />
    
    
</asp:Content>
