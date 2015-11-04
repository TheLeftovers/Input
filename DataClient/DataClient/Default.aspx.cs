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
            myServiceReference.getPersonClient proxy = new myServiceReference.getPersonClient();

            //ArrayList ids = new ArrayList(proxy.GetID());
            ArrayList hours = new ArrayList(proxy.GetHours());
            ArrayList fnames = new ArrayList(proxy.GetFirstName());

            Chart1.Series.Add(new Series("Person"));
            Chart1.Series["Person"].ChartType = SeriesChartType.Column;
            Chart1.Series["Person"].ChartArea = "ChartArea1";
            Chart1.Series["Person"].Points.DataBindXY(fnames, hours);
            Chart1.ChartAreas[0].AxisX.Title = "Names";
            Chart1.ChartAreas[0].AxisY.Title = "Hours";







        }
    }
}