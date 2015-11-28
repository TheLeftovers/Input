﻿using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using WebApplication.positionGetter;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getterServiceSoapClient proxy = new getterServiceSoapClient();

            ArrayList unit = new ArrayList();
            ArrayList speed = new ArrayList();

            proxy.Open();

            for (int i = 0; i < 10; i++)
            {
                unit.Add(proxy.GetPositionsList(10, "Speed")[i].UnitId);
                speed.Add(proxy.GetPositionsList(10, "Speed")[i].Speed);
            }
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
            //Chart1.ChartAreas[0].AxisY.Interval = 1;
            //Chart1.ChartAreas[0].AxisY.Minimum = 159;
            //Chart1.ChartAreas[0].AxisY.Maximum = 166;
            Chart1.Series["1"].Sort(PointSortOrder.Ascending, "X");
            Chart1.ChartAreas[0].RecalculateAxesScale();

            proxy.Close();

        }
    }
}