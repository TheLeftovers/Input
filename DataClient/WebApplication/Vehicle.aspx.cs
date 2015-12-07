using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using WebApplication.positionGetter;

namespace WebApplication
{
    public partial class Vehicle : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getterServiceSoapClient proxy = new getterServiceSoapClient();

            //New ArrayLists of data used in chart(XY)
            ArrayList unit = new ArrayList();
            ArrayList speed = new ArrayList();

            //Parameters getPositionsList
            int max = 10;
            string OrderBy = "Speed";

            proxy.Open();

            //Place values needed in ArrayList
            for (int i = 0; i < max; i++)
            {
                unit.Add(proxy.GetPositionsList(max, OrderBy)[i].UnitId);
                speed.Add(proxy.GetPositionsList(max, OrderBy)[i].Speed);
            }

            //Get Minimum and Maximum value in ArrayList 'speed'
            speed.Sort();
            int Max = int.MinValue;
            int Min = int.MaxValue;

            foreach (int x in speed)
            {
                if (Max < x)
                { Max = x; }
                if (Min > x)
                { Min = x; }
            }

            //Setup Chart
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
            Chart1.Series["1"].Sort(PointSortOrder.Descending, "Y");
            Chart1.ChartAreas[0].RecalculateAxesScale();

            proxy.Close();
        }
    }
}