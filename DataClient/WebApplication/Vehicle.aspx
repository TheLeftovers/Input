<%@ Page Title="Wagenpark" MasterPageFile="~/Site.Master" EnableSessionState="False" EnableViewState="False" Trace="false" ViewStateMode="Disabled" Language="C#" AutoEventWireup="True" CodeBehind="~/Vehicle.aspx.cs" Inherits="WebApplication.Vehicle" %>

<asp:Content ID="Head" ContentPlaceHolderID="headerPlaceHolder" runat="server">
    <!-- amCharts javascript code -->
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/amcharts.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/pie.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/serial.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/light.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/dark.js"></script>
    <script src="https://www.amcharts.com/lib/3/plugins/export/export.js" type="text/javascript"></script>
    <link href="https://www.amcharts.com/lib/3/plugins/export/export.css" rel="stylesheet" type="text/css">

    <script type="text/javascript">

        ////    BEGIN OF getDataForChart1   ////
        function getDataForChart1(){
            var unitArray = <%=vehicle_aspx.Serialize(this.UnitArrayList) %>;      //ArrayList with data
            var speedArray = <%=vehicle_aspx.Serialize(this.SpeedArrayList) %>;    //ArrayList with data

            var unit = [];
            var speed = [];
            var chartData = [];

            for (var i = 0; i < unitArray.length; i++) {
                unit.push(unitArray[i]);
                speed.push(speedArray[i]);
            }

            for( var i = 0; i < unitArray.length; i++ ) {
                chartData.push( {
                    "Unit": unit[i],
                    "Speed": speed[i],
                } )};

            return chartData;
        }

        /// END OF getDataForChart1 ////

        /// BEGIN OF CHART1 //////
        AmCharts.makeChart("chartdiv1",     //DIV
            {
                "type": "serial",
                "categoryField": "Unit",    //X-axis waardes
                "startDuration": 1,
                "handDrawScatter": 4,
                "theme": "light",           ///Thema --> light, dark, chalk
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
                "dataProvider": getDataForChart1(), //Data
                "export": {
                    "enabled": true
                }
                
            }
        );
        ////    END OF CHART 1  ////

        ////    BEGIN OF getDataForChart2   ////
        function getDataForChart2(){
            var hdopArray = <%=vehicle_aspx.Serialize(this.HDOPArrayList) %>;      //ArrayList with data
            var satelliteArray = <%=vehicle_aspx.Serialize(this.SatelliteArrayList) %>;    //ArrayList with data

            var hdop = [];
            var satellite = [];

            var chartData = [];

            for (var i = 0; i < hdopArray.length; i++) {
                hdop.push(hdopArray[i]);
                satellite.push(satelliteArray[i]);
            }

            for( var i = 0; i < hdopArray.length; i++ ) {
                chartData.push( {
                    "HDOP": hdop[i],
                    "Number of Satellites": satellite[i],
                } )};

            return chartData;
        }

        /// END OF getDataForChart2 ////

        /// BEGIN OF CHART2 //////
        AmCharts.makeChart("chartdiv2",     //DIV
            {
               
                "type": "serial",
                "categoryField": "Number of Satellites",    //X-axis waardes
                "startDuration": 1,
                "handDrawScatter": 4,
                "theme": "light",           ///Thema --> light, dark, chalk
                "categoryAxis": {
                    "gridPosition": "start",
                    "labelFrequency": 2,
                    "title": "Aantal verbonden satellieten"      //Titel X-axis
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
                        "type": "line",       //Type chart
                        "valueField": "HDOP"
                            
                    }
                ],
                "guides": [],
                "valueAxes": [
                    {
                        "id": "ValueAxis-1",
                        "position": "left",
                        "title": "Waarde HDOP"     //Titel y-axis
                    }
                ],
                "allLabels": [],
                "balloon": {},
                "titles": [
                    {
                        "id": "Title-1",
                        "size": 15,
                        "position": "bottom",
                        "text": "HDOP waarde t.o.v. aantal verbonden satellieten"     //Titel Chart
                    }
                ],						
                "dataProvider": getDataForChart2(),  //Data
                "export": {
                    "enabled": true
                }
            }
        );
     
        ////    END OF CHART 2  ////
        </script>

    <script type="text/javascript">
        var satelliteArray = <%=vehicle_aspx.Serialize(this.SatelliteArrayList) %>; 
        var chart;
        var legend;
        var satellite = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
        for( var i = 0; i < satelliteArray.length; i++ ) {
            satellite[satelliteArray[i]] = satellite[satelliteArray[i]] + 1;
        };
            
        var chartData = [
            {
                "country": "3 satelieten",
                "litres": satellite[3]
            },
            {
                "country": "4 of 5 satelieten",
                "litres": satellite[4]+satellite[5]
            },
            {
                "country": "6 of 7 satelieten",
                "litres": satellite[6]+satellite[7]
            },
            {
                "country": "8 of 9 satelieten",
                "litres": satellite[8]+satellite[9]
            },
            {
                "country": "10 of meer satelieten",
                "litres": satellite[10]+satellite[11] + satellite[12]+ satellite[13]+ satellite[14]+ satellite[15]+ satellite[16]+ satellite[17]
            }
        ];

        AmCharts.ready(function () {
            // PIE CHART
            chart = new AmCharts.AmPieChart();
            chart.dataProvider = chartData;
            chart.titleField = "country";
            chart.valueField = "litres";
            chart.gradientRatio = [0, 0, 0 ,-0.2, -0.4];
            chart.gradientType = "radial";

            // LEGEND
            legend = new AmCharts.AmLegend();
            legend.align = "center";
            legend.markerType = "circle";
            chart.balloonText = "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>";
            chart.addLegend(legend);

            // WRITE
            chart.write("chartdiv3");
        });
           

        // changes label position (labelRadius)
        function setLabelPosition() {
            if (document.getElementById("rb1").checked) {
                chart.labelRadius = 30;
                chart.labelText = "[[title]]: [[value]]";
            } else {
                chart.labelRadius = -30;
                chart.labelText = "[[percents]]%";
            }
            chart.validateNow();
        }


        // makes chart 2D/3D
        function set3D() {
            if (document.getElementById("rb3").checked) {
                chart.depth3D = 10;
                chart.angle = 10;
            } else {
                chart.depth3D = 0;
                chart.angle = 0;
            }
            chart.validateNow();
        }

        // changes switch of the legend (x or v)
        function setSwitch() {
            if (document.getElementById("rb5").checked) {
                legend.switchType = "x";
            } else {
                legend.switchType = "v";
            }
            legend.validateNow();
        };

    </script>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <br />

    <div id="AuthorizedContent" runat="server">
        <div id="chartdiv1" style="width: 100%; height: 400px; background-color: #FFFFFF;"></div>
        <div id="chartdiv2" style="width: 100%; height: 400px; background-color: #FFFFFF;"></div>
        <div id="chartdiv3" style="width: 100%; height: 400px;"></div>
        <table align="center" cellspacing="20">
            <tr>
                <td>
                    <input type="radio" checked="true" name="group" id="rb1" onclick="setLabelPosition()">labels outside
                    <input type="radio" name="group" id="rb2" onclick="setLabelPosition()">labels inside</td>
                <td>
                    <input type="radio" name="group2" id="rb3" onclick="set3D()">3D
                    <input type="radio" checked="true" name="group2" id="rb4" onclick="set3D()">2D</td>
                <td>Legend switch type:
                    <input type="radio" checked="true" name="group3" id="rb5"
                        onclick="setSwitch()">x
                    <input type="radio" name="group3" id="rb6" onclick="setSwitch()">v</td>
            </tr>
        </table>


    </div>

    <div id="AnonymousContent" runat="server">U bent niet geautoriseerd om de inhoud van deze pagina te zien.</div>
</asp:Content>
