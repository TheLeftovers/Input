<%@ Page Title="Wagenpark" MasterPageFile="~/Site.Master" EnableSessionState="False" EnableViewState="False" Trace="false" ViewStateMode="Disabled" Language="C#" AutoEventWireup="True" CodeBehind="~/Vehicle.aspx.cs" Inherits="WebApplication.Vehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerPlaceHolder" runat="server">
    <!-- amCharts javascript code -->
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/amcharts.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/serial.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/light.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/dark.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/plugins/export/export.js"></script>


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
                    "enabled": true,
                    "libs": {
                        "path": "http://www.amcharts.com/lib/3/plugins/export/libs/"
                    },
                    "menu": []
                }
            }
        );
        ////    END OF CHART 1  ////

    </script>

    <script type="text/javascript">

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
                    "enabled": true,
                    "libs": {
                        "path": "http://www.amcharts.com/lib/3/plugins/export/libs/"
                    },
                    "menu": []
                }
            }
        );

        function exportCharts() {
            // iterate through all of the charts and prepare their images for export
            var images = [];
            var pending = AmCharts.charts.length;
            for ( var i = 0; i < AmCharts.charts.length; i++ ) {
                var chart = AmCharts.charts[ i ];
                chart.export.capture( {}, function() {
                    this.toJPG( {}, function( data ) {
                        images.push( {
                            "image": data,
                            "fit": [ 523.28, 769.89 ]
                        } );
                        pending--;
                        if ( pending === 0 ) {
                            // all done - construct PDF
                            chart.export.toPDF( {
                                content: images
                            }, function( data ) {
                                this.download( data, "application/pdf", "amCharts.pdf" );
                            } );
                        }
                    } );
                } );
            }
        }
        ////    END OF CHART 2  ////

    </script>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <br />

    <div id="AuthorizedContent" runat="server">
        <input type="button" value="Exporteer naar PDF" onclick="exportCharts();" />
        <div id="chartdiv1" style="width: 100%; height: 400px; background-color: #FFFFFF;"></div>
        <div id="chartdiv2" style="width: 100%; height: 400px; background-color: #FFFFFF;"></div>

    </div>

    <div id="AnonymousContent" runat="server">U bent niet geautoriseerd om de inhoud van deze pagina te zien.</div>
</asp:Content>
