using System;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;

namespace WebApplication
{
    public partial class Vehicle : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebApplication.SiteMaster.LoggedIn)
            {
                AnonymousContent.Visible = false;
                AuthorizedContent.Visible = true;
            } else
            {
                AnonymousContent.Visible = true;
                AuthorizedContent.Visible = false;
            }
           
            //Get ArrayLists from Global.asax used for the Chart.
            var speed = Global.speed;
            var unit = Global.unit;

            //Sort elements in ArrayList
            speed.Sort();
            int Max = int.MinValue;
            int Min = int.MaxValue;

            //Get Minimum and Maximum value of ArrayList to define axes of the Chart.
            foreach (int x in speed)
            {
                if (Max < x)
                { Max = x; }
                if (Min > x)
                { Min = x; }
            }

            //Setup Chart.
            Chart1.Series.Clear();
            Chart1.Series.Add(new System.Web.UI.DataVisualization.Charting.Series("1"));
            Chart1.Series["1"].ChartType = SeriesChartType.Column;
            Chart1.Series["1"].ChartArea = "ChartArea1";
            Chart1.Series["1"].Points.DataBindXY(unit, speed);
            Chart1.Series["1"].SmartLabelStyle.Enabled = true;
            Chart1.Series["1"].IsXValueIndexed = true;

            Chart1.ChartAreas[0].AxisX.Title = "Unit ID";
            Chart1.ChartAreas[0].AxisX.IsStartedFromZero = false;
            Chart1.ChartAreas[0].AxisY.Title = "Speed(KM/H)";
            Chart1.ChartAreas[0].AxisY.Interval = 1;
            Chart1.ChartAreas[0].AxisY.Minimum = Min - 1;
            Chart1.ChartAreas[0].AxisY.Maximum = Max;
            Chart1.ChartAreas[0].RecalculateAxesScale();
            Chart1.Series["1"].Sort(PointSortOrder.Descending, "Y");
            }

     }
}