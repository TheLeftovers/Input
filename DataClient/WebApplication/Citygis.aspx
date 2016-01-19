<%@ Page Title="CityGIS Hard- en Software" Async="true" MasterPageFile="~/Site.Master" EnableSessionState="False" EnableViewState="False" Trace="false" ViewStateMode="Disabled" Language="C#" AutoEventWireup="True" CodeBehind="~/Citygis.aspx.cs" Inherits="WebApplication.Citygis" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="headerPlaceHolder" ID="Head" runat="server">
    <!-- amCharts javascript sources -->
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/amcharts.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/pie.js"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/serial.js"></script>
    <script src="https://www.amcharts.com/lib/3/plugins/export/export.js" type="text/javascript"></script>
    <link href="https://www.amcharts.com/lib/3/plugins/export/export.css" rel="stylesheet" type="text/css">
    <script type="text/javascript">

        /// BEGIN OF CHART1 //////
        var connTrueArray = <%=citygis_aspx.Serialize(this.ConnBoolTrueArrayList) %>;      //ArrayList with data
        var connFalseArray = <%=citygis_aspx.Serialize(this.ConnBoolFalseArrayList) %>;    //ArrayList with data

        var connTrue = [];
        var connFalse = [];

        for (var i = 0; i < connTrueArray.length; i++) {
            connFalse.push(connFalseArray[i]);
            connTrue.push(connTrueArray[i]);
        }

        AmCharts.makeChart("chartdiv",      //DIV
            {
                "type": "pie",              //TYPE
                "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>",
                "innerRadius": 0,
                "labelRadius": 25,
                "baseColor": "#0192D3",     //COLOR
                "pullOutEffect": "elastic",
                "titleField": "category",       //Title 
                "valueField": "values",
                "allLabels": [],
                "balloon": {},
                "legend": {
                    "enabled": true,
                    "align": "center",
                    "markerType": "circle"
                },
                "titles": [{
                    "id": "Title-1",
                    "size": 15,
                    "position": "bottom",
                    "text": "Connecties Status"     //Titel Chart
                }],
                "dataProvider": [
						{
						    "category": "Connectie gemaakt",
						    "values": connTrue
						},
						{
						    "category": "Connectie verbroken",
						    "values": connFalse
						}
                ],
                "export": {
                    "enabled": true,
                }
        
            });
        ///END Of Chart1    ////
    </script>
    <script type="text/javascript">
        /// BEGIN OF getData()  ///
        function getDataForChart2(){
            var dateArray = <%=citygis_aspx.Serialize(this.DateArrayList) %>;      //ArrayList with data
            var tempArray = <%=citygis_aspx.Serialize(this.TempArrayList) %>;    //ArrayList with data

            var date = [];
            var temp = [];
            var chartData = [];

            for (var i = 0; i < dateArray.length; i++) {
                date.push(dateArray[i]);
                temp.push(tempArray[i]);
            }

            for( var i = 0; i < dateArray.length; i++ ) {
                chartData.push( {
                    "column-1": temp[i],
                    "date": date[i]
                } )};

            return chartData;
        }
        /// END OF getData()    ///


        ///BEGIN OF CHART 2 ////
        AmCharts.makeChart("chartdiv2",     ////DIV
				{
				    "type": "serial",
				    "categoryField": "date",
				    "dataDateFormat": "YYYY-MM-DD HH:NN:SS",
				    "categoryAxis": {
				        "title": "Tijd",
				        "parseDates": true,
				        "minPeriod": "ss",
				        "dateFormats": [ {
				            "period": "fff",
				            "format": "JJ:NN:SS"
				        }, {
				            "period": "ss",
				            "format": "JJ:NN:SS"
				        }, {
				            "period": "mm",
				            "format": "JJ:NN"
				        }, {
				            "period": "hh",
				            "format": "JJ:NN"
				        }, {
				            "period": "DD",
				            "format": "MMM DD JJ:NN"
				        }, {
				            "period": "WW",
				            "format": "MMM DD"
				        }, {
				            "period": "MM",
				            "format": "MMM"
				        }, {
				            "period": "YYYY",
				            "format": "YYYY"
				        } ],
				    },
				    "chartCursor": {
				        "enabled": true,
				        "categoryBalloonDateFormat": "JJ:NN:SS"
				    },
				    "chartScrollbar": {
				        "enabled": true
				    },
				    "trendLines": [],
				    "graphs": [
						{
						    "bullet": "round",
						    "id": "AmGraph-1",
						    "title": "graph 1",
						    "valueField": "column-1"
						}
				    ],
				    "guides": [],
				    "valueAxes": [
						{
						    "id": "ValueAxis-1",
						    "title": "Temperatuur (Celsius)"
						}
				    ],
				    "allLabels": [],
				    "balloon": {},
				    "titles": [
						{
						    "id": "Title-1",
						    "size": 15,
						    "text": "Temperatuur GPS module over tijd"
						}
				    ],
				    "dataProvider": getDataForChart2(),
				    "export": {
				        "enabled": true
				    }
				}
			);
        /// END OF CHART 2 ///
    </script>
    <script type="text/javascript">
        /// BEGIN OF getData()  ///
        function getDataForChart3(){
            var dateArray = <%=citygis_aspx.Serialize(this.CPUDateArrayList) %>;      //ArrayList with data
            var tempArray = <%=citygis_aspx.Serialize(this.CPUTempArrayList) %>;    //ArrayList with data

            var date = [];
            var temp = [];
            var chartData = [];

            for (var i = 0; i < dateArray.length; i++) {
                date.push(dateArray[i]);
                temp.push(tempArray[i]);
            }

            for( var i = 0; i < dateArray.length; i++ ) {
                chartData.push( {
                    "column-1": temp[i],
                    "date": date[i]
                } )};

            return chartData;
        }
        /// END OF getData()    ///


        ///BEGIN OF CHART 3 ////
        AmCharts.makeChart("chartdiv3",     ////DIV
				{
				    "type": "serial",
				    "categoryField": "date",
				    "dataDateFormat": "YYYY-MM-DD HH:NN:SS",
				    "categoryAxis": {
				        "title": "Tijd",
				        "parseDates": true,
				        "minPeriod": "ss",
				        "dateFormats": [ {
				            "period": "fff",
				            "format": "JJ:NN:SS"
				        }, {
				            "period": "ss",
				            "format": "JJ:NN:SS"
				        }, {
				            "period": "mm",
				            "format": "JJ:NN"
				        }, {
				            "period": "hh",
				            "format": "JJ:NN"
				        }, {
				            "period": "DD",
				            "format": "MMM DD JJ:NN"
				        }, {
				            "period": "WW",
				            "format": "MMM DD"
				        }, {
				            "period": "MM",
				            "format": "MMM"
				        }, {
				            "period": "YYYY",
				            "format": "YYYY"
				        } ],
				    },
				    "chartCursor": {
				        "enabled": true,
				        "categoryBalloonDateFormat": "JJ:NN:SS"
				    },
				    "chartScrollbar": {
				        "enabled": true
				    },
				    "trendLines": [],
				    "graphs": [
						{
						    "bullet": "round",
						    "id": "AmGraph-1",
						    "title": "graph 1",
						    "valueField": "column-1"
						}
				    ],
				    "guides": [],
				    "valueAxes": [
						{
						    "id": "ValueAxis-1",
						    "title": "Temperatuur (Celsius)"
						}
				    ],
				    "allLabels": [],
				    "balloon": {},
				    "titles": [
						{
						    "id": "Title-1",
						    "size": 15,
						    "text": "Temperatuur CPU over tijd"
						}
				    ],
				    "dataProvider": getDataForChart3(),
				    "export": {
				        "enabled": true
				    }
				}
			);
        /// END OF CHART 2 ///

       
    </script>
</asp:Content>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <br />

    <div id="AuthorizedContent" runat="server">
        <h4>Te Reparen Wagens</h4>

        <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Font-Size="13px">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Unit ID</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

        <br />
        <br />
       
        <div id="chartdiv" style="width: 100%; height: 400px; background-color: #FFFFFF;"></div>
        <br />
        <div id="chartdiv2" style="width: 100%; height: 400px; background-color: #FFFFFF;"></div>
         <br />
        <div id="chartdiv3" style="width: 100%; height: 400px; background-color: #FFFFFF;"></div>



    </div>
    <div id="AnonymousContent" runat="server">U bent niet geautoriseerd om de inhoud van deze pagina te zien.</div>

</asp:Content>
