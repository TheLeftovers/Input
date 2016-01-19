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
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDazsHBOfJMAznmcc98G9F5f4rkpvrEmMI&signed_in=true&libraries=visualization&callback=initMap" async defer></script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <br />

    <div id="AuthorizedContent" runat="server">
        <center>
        <div id="map" style="width:550px;height:550px;"></div>
        </center>
    </div>
        <div id="AnonymousContent" runat="server">U bent niet geautoriseerd om de inhoud van deze pagina te zien.</div>

</asp:Content>
