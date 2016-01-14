<%@ Page Title="Wagenpark" MasterPageFile="~/Site.Master" EnableSessionState="False" EnableViewState="False" Trace="false" ViewStateMode="Disabled" Language="C#" AutoEventWireup="True" CodeBehind="~/Vehicle.aspx.cs" Inherits="WebApplication.Vehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerPlaceHolder" runat="server">
    <!-- amCharts javascript code -->
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/amcharts.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/serial.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/light.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/dark.js"></script>
   

    <script type="text/javascript">
        var unitArray = <%=vehicle_aspx.Serialize(this.UnitArrayList) %>;      //ArrayList with data
        var speedArray = <%=vehicle_aspx.Serialize(this.SpeedArrayList) %>;    //ArrayList with data

        var unit = []
        var speed = [];
            
        for (var i = 0; i < unitArray.length; i++) {
            unit.push(unitArray[i]);
            speed.push(speedArray[i]);
        }

        var chartData = [];

        for( var i = 0; i < unitArray.length; i++ ) {
            chartData.push( {
                "Unit": unit[i],
                "Speed": speed[i],
            } )};

        AmCharts.themes = AmCharts.themes.light;

        AmCharts.makeChart("chartdiv",
            {
               
                "type": "serial",
                "categoryField": "category",
                "startDuration": 1,
                "handDrawScatter": 4,
                "theme": "dark",
                "categoryAxis": {
                    "gridPosition": "start",
                    "labelFrequency": 5,
                    "title": "Unit ID"      //Titel X-axis
                },
                "chartCursor": {
                    "enabled": true         //Cursor
                },
                "chartScrollbar": {
                    "enabled": true         //Scrollbar
                },
                "trendLines": [],
                "graphs": [
                    {
                        "fillAlphas": 1,
                        "id": "AmGraph-1",
                        "title": "graph 1",
                        "type": "column",       //Type chart
                        "valueField": "Speed"
                            
                    }
                ],
                "guides": [],
                "valueAxes": [
                    {
                        "id": "ValueAxis-1",
                        "position": "left",
                        "title": "Snelheid in km/u"     //Titel y-axis
                    }
                ],
                "allLabels": [],
                "balloon": {},
                "titles": [
                    {
                        "id": "Title-1",
                        "size": 15,
                        "position": "bottom",
                        "text": "Top 50 hoogste snelheden per wagen"     //Titel Chart
                    }
                ],						
                "dataProvider": chartData,  //Data
            }
        );

    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <br />

    <div id="AuthorizedContent" runat="server">
        <div id="chartdiv" style="width: 100%; height: 400px; background-color: #FFFFFF;"></div>
    </div>

    <div id="AnonymousContent" runat="server">U bent niet geautoriseerd om de inhoud van deze pagina te zien.</div>
</asp:Content>
