<%@ Page Title="Heatmap" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maps.aspx.cs" Inherits="WebApplication.Maps" %>

<asp:Content ContentPlaceHolderID="headerPlaceHolder" ID="Head" runat="server">

    <script>
        var map, heatmap;

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: 51.9166667, lng: 4.5 },
                zoom: 8
            });

            heatmap = new google.maps.visualization.HeatmapLayer({
                data: getPoints(),
                map: map
            });

            function getPoints() {
                var latLonArray = <%=maps_aspx.Serialize(this.LatLonArrayList) %>;
            var latArray = [];
            var lonArray = [];
            var googleLatLon = [];

            for (var i = 0; i < latLonArray.length; i++) {
                if (i % 2 == !0){   
                    lonArray.push(latLonArray[i]);
                }
                else{
                    latArray.push(latLonArray[i]);
                }
            }

            for (var i = 0; i < latArray.length && i < lonArray.length; i++) {
                var point = new google.maps.LatLng(parseFloat(latArray[i]), parseFloat(lonArray[i]));
                googleLatLon.push(point);
            }

            return googleLatLon;
        }
    }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDazsHBOfJMAznmcc98G9F5f4rkpvrEmMI&signed_in=true&libraries=visualization&callback=initMap" async="async" defer="defer"></script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <br />

    <div id="AuthorizedContent" runat="server">
        <center>
        <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Unit ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Datum</asp:TableHeaderCell>
                <asp:TableHeaderCell>Begintijd</asp:TableHeaderCell>
                <asp:TableHeaderCell>Eindtijd</asp:TableHeaderCell>
                <asp:TableHeaderCell></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell><asp:DropDownList ID="DropDownUnit" runat="server"></asp:DropDownList></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownDate" runat="server"></asp:DropDownList></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownBegin" runat="server"></asp:DropDownList></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="DropDownEnd" runat="server"></asp:DropDownList></asp:TableCell>
                <asp:TableCell><asp:Button ID="createMap" runat="server" Text="Create Heatmap" OnClick="createMap_Click"></asp:Button></asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <div id="map" style="width:550px;height:550px;"></div>

        </center>
    </div>
    <div id="AnonymousContent" runat="server">U bent niet geautoriseerd om de inhoud van deze pagina te zien.</div>

</asp:Content>
