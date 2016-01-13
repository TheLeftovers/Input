<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Charting.aspx.cs" Inherits="WebApplication.Charting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Chart" />
    <!-- amCharts javascript sources -->
		<script type="text/javascript" src="http://www.amcharts.com/lib/3/amcharts.js"></script>
		<script type="text/javascript" src="http://www.amcharts.com/lib/3/serial.js"></script>
        <script src="http://www.amcharts.com/lib/3/themes/light.js"></script>
        <script src="http://www.amcharts.com/lib/3/themes/dark.js"></script>
        <script src="http://www.amcharts.com/lib/3/themes/chalk.js"></script>



		<!-- amCharts javascript code -->
		<script type="text/javascript">
            var unitArray = <%=charting_aspx.Serialize(this.UnitArrayList) %>;      //ArrayList with data
		    var speedArray = <%=charting_aspx.Serialize(this.SpeedArrayList) %>;    //ArrayList with data

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

		        AmCharts.makeChart("chartdiv",
                    {
                        "type": "serial",
                        "categoryField": "Unit",
                        "startDuration": 1,
                        "handDrawScatter": 4,
                        "themes": "dark",
                        "categoryAxis": {
                            "gridPosition": "start",
                            "labelFrequency": 5,
                            "title": "Unit ID"
                        },
                        "chartCursor": {
                            "enabled": true
                        },
                        "chartScrollbar": {
                            "enabled": true
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
                                "title": "Unit ID",
                                "text": "Top x hoogste snelheden per wagen"     //Titel Chart
                            }
                        ],						
                        "dataProvider": chartData,
                    }
                );

		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<div id="chartdiv" style="width: 100%; height: 400px; background-color: #FFFFFF;" ></div>
    </div>
    </form>
</body>
</html>
