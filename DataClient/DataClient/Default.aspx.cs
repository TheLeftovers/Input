using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI.DataVisualization.Charting;
using Webservice;

namespace DataWebsite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Positions> Posit = Webservice.getPosition.GoGet();
            ArrayList units = new ArrayList();
            ArrayList speeds = new ArrayList();

            for (int i=0; i< Posit.Count; i++) {
                units.Add(Posit[i].UnitId);
                speeds.Add(Posit[i].Speed);
            }


            TextBox1.Text = speeds.ToString();
            /*
            Chart1.Series.Clear();
            Chart1.Series.Add(new Series("1"));
            Chart1.Series["1"].ChartType = SeriesChartType.Column;
            Chart1.Series["1"].ChartArea = "ChartArea1";
            Chart1.Series["1"].Points.DataBindXY(units, speeds);
            Chart1.Series["1"].SmartLabelStyle.Enabled = true;
            Chart1.Series["1"].IsXValueIndexed = true;

            Chart1.ChartAreas[0].AxisX.Title = "Unit ID";
            Chart1.ChartAreas[0].AxisX.IsStartedFromZero = false;
            Chart1.ChartAreas[0].AxisY.Title = "Speed(KM/H)";
            Chart1.ChartAreas[0].AxisY.Interval = 1;
            Chart1.ChartAreas[0].AxisY.Minimum = (position.getSpeed().Min() -1);
            Chart1.ChartAreas[0].AxisY.Maximum = position.getSpeed().Max();
            Chart1.ChartAreas[0].RecalculateAxesScale();
            */
            
        }


    }
}