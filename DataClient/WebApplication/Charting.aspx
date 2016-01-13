<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Charting.aspx.cs" Inherits="WebApplication.Charting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="The description of my page" />
    <!-- amCharts javascript sources -->
		<script type="text/javascript" src="http://www.amcharts.com/lib/3/amcharts.js"></script>
		<script type="text/javascript" src="http://www.amcharts.com/lib/3/serial.js"></script>

		<!-- amCharts javascript code -->
		<script type="text/javascript">
            var unitArray = <%=charting_aspx.Serialize(this.UnitArrayList) %>;
		    var speedArray = <%=charting_aspx.Serialize(this.SpeedArrayList) %>;


			AmCharts.makeChart("chartdiv",
				{
					"type": "serial",
					"categoryField": "Unit ID",
					"startDuration": 1,
					"handDrawScatter": 4,
					"categoryAxis": {
						"gridPosition": "start"
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
							"type": "column",
							"valueField": "Speed"
						}
					],
					"guides": [],
					"valueAxes": [
						{
							"id": "ValueAxis-1",
							"title": "Axis title"
						}
					],
					"allLabels": [],
					"balloon": {},
					"titles": [
						{
							"id": "Title-1",
							"size": 15,
							"text": "Chart Title"
						}
					],						
					"dataProvider": [
						{
						    "Unit ID": unitArray[0],
						    "Speed": speedArray[0]
						},
						{
						    "Unit ID": unitArray[1],
						    "Speed": speedArray[1]
						},
						{
						    "Unit ID": unitArray[2],
						    "Speed": speedArray[2]
						},
						{
						    "Unit ID": unitArray[3],
						    "Speed": speedArray[3]
						},
						{
						    "Unit ID": unitArray[4],
						    "Speed": speedArray[4]
						},
						{
						    "Unit ID": unitArray[5],
						    "Speed": speedArray[5]
						},
						{
						    "Unit ID": unitArray[6],
						    "Speed": speedArray[6]
						},
						{
						    "Unit ID": unitArray[7],
						    "Speed": speedArray[7]
						},
						{
						    "Unit ID": unitArray[8],
						    "Speed": speedArray[8]
						},
						{
						    "Unit ID": unitArray[9],
						    "Speed": speedArray[9]
						},
						{
						    "Unit ID": unitArray[10],
						    "Speed": speedArray[10]
						},
						{
						    "Unit ID": unitArray[11],
						    "Speed": speedArray[11]
						},
						{
						    "Unit ID": unitArray[12],
						    "Speed": speedArray[12]
						},
						{
						    "Unit ID": unitArray[13],
						    "Speed": speedArray[13]
						},
						{
						    "Unit ID": unitArray[14],
						    "Speed": speedArray[14]
						}
			        ]
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
