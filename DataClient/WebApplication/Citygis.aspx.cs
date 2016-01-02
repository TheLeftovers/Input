using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using WebApplication.GetterService;

namespace WebApplication
{
    public partial class Citygis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebApplication.SiteMaster.LoggedIn)
            {
                AnonymousContent.Visible = false;
                AuthorizedContent.Visible = true;
                CreateChart();
            }
            else
            {
                AnonymousContent.Visible = true;
                AuthorizedContent.Visible = false;
            }
        }

        public void CreateChart()
        {
            //New ArrayLists of data used in chart(XY) in Vehicle.aspx.cs
            ArrayList maxtemp = new ArrayList();
            ArrayList mintemp = new ArrayList();
            ArrayList maxtime = new ArrayList();
            ArrayList mintime = new ArrayList();


            //Create proxy
            GetterClient proxy = new GetterClient();

            //Parameters getPositionsList
            string order = "time";
            int max = 100;


            //If image of chart with same parameters already exists, make asp image visible and this image with specific parameters.
            if (System.IO.File.Exists($"C:/inetpub/wwwroot/CityGIS/TempImages/chart{max}_{order}.jpeg") == true)
            {
                Image1.ImageUrl = $"C:/inetpub/wwwroot/CityGIS/TempImages/chart{max}_{order}.jpeg";
                Image1.Visible = true;
            }

            else
            {
                //Open connection
                proxy.Open();

                //Place values needed in ArrayList
                for (int i = 0; i < max; i++)
                {
                    maxtime.Add(proxy.GetMaxTimeList()[i]);
                    //mintime.Add(proxy.GetMinTimeList()[i]);
                    maxtemp.Add(proxy.GetMaxTempList()[i]);
                    //mintemp.Add(proxy.GetMinTempList()[i]);
                }

                //Close connection
                proxy.Close();

                
                //Sort elements in ArrayList
                maxtemp.Sort();
                mintemp.Sort();
                /*
                int Max = int.MinValue;
                int Min = int.MaxValue;

                //Get Minimum and Maximum value of ArrayList to define axes of the Chart.
                foreach (int x in temp)
                {
                    if (Max < x)
                    { Max = x; }
                    if (Min > x)
                    { Min = x; }
                }*/
                

                //Setup Chart.
                Chart Chart1 = new Chart();
                Chart1.Height = 400;
                Chart1.Width = 1000;
                Chart1.Compression = 60;
                Chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
                Chart1.RenderType = RenderType.ImageTag;
                Chart1.AntiAliasing = AntiAliasingStyles.All;
                

                Chart1.Series.Clear();
                Chart1.Series.Add(new Series("1"));
                Chart1.Series["1"].ChartType = SeriesChartType.Line;
                Chart1.Series["1"].Points.DataBindXY(maxtime, maxtemp);
                Chart1.Series["1"].SmartLabelStyle.Enabled = true;
                

                //Chart1.Series["1"].IsXValueIndexed = true;

                Chart1.ChartAreas.Add(new ChartArea());
                Chart1.ChartAreas[0].AxisY.Title = "Temperature(Degree Celsius)";
                Chart1.ChartAreas[0].AxisX.Title = "Time";
                Chart1.ChartAreas[0].AxisY.Interval = 1;
                Chart1.ChartAreas[0].AxisY.Minimum = 5;
                Chart1.ChartAreas[0].AxisY.Maximum = 40;
                Chart1.ChartAreas[0].AxisX.Interval = 1;
                Chart1.ChartAreas[0].RecalculateAxesScale();
                Chart1.Series["1"].Sort(PointSortOrder.Descending, "Y");


                //3D Setting for Chart
                Chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
                Chart1.ChartAreas[0].Area3DStyle.IsClustered = false;
                Chart1.ChartAreas[0].Area3DStyle.IsRightAngleAxes = false;
                Chart1.ChartAreas[0].Area3DStyle.Inclination = 10;
                Chart1.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;
                Chart1.ChartAreas[0].Area3DStyle.Perspective = 15;
                Chart1.ChartAreas[0].Area3DStyle.WallWidth = 10;


                //Add Chart to div in Vehicle.aspx
                AuthorizedContent.Controls.Add(Chart1);

                //Save created chart in following folder and name.
                Chart1.SaveImage($"C:/inetpub/wwwroot/CityGIS/TempImages/chart{max}_{order}.jpeg", ChartImageFormat.Jpeg);

                //Refresh page for new chart to be visible.
                Response.Redirect(Request.RawUrl);


            }
        }
    }
}