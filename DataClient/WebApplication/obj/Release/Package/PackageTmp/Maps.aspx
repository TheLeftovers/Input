<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maps.aspx.cs" Inherits="WebApplication.Maps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script>
        var map, heatmap;

      function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: 51.2, lng: 4.4 },
            zoom: 12
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
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="map" style="width:900px;height:700px;"></div>
    </div>
    </form>
</body>
</html>
