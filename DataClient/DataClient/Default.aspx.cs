using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClient.myServiceReference;
using System.Collections;
using System.Web.UI.DataVisualization.Charting;

namespace DataClient
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myServiceReference.getPositionClient proxy = new myServiceReference.getPositionClient();

            ArrayList units = new ArrayList(proxy.getUnitID());
            ArrayList speeds = new ArrayList(proxy.getSpeed());

            Chart1.Series.Clear();
            Chart1.Series.Add(new Series("2"));
            Chart1.Series["2"].ChartType = SeriesChartType.Column;
            Chart1.Series["2"].ChartArea = "ChartArea1";
            Chart1.Series["2"].Points.DataBindXY(speeds, units);
            Chart1.ChartAreas[0].AxisY.Title = "Unit ID";
            Chart1.ChartAreas[0].AxisX.Title = "Speed(KM/U)";
            Chart1.ChartAreas[0].AxisX.Interval = 1;






        }

    
    }
}