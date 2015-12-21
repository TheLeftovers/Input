using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using WebApplication.GetterService;

namespace WebApplication
{
    public partial class Vehicle : Page
    {
        Stopwatch stopwatch = new Stopwatch();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebApplication.SiteMaster.LoggedIn)
            {
                AnonymousContent.Visible = false;
                AuthorizedContent.Visible = true;
            }
            else
            {
                AnonymousContent.Visible = true;
                AuthorizedContent.Visible = false;
            }

            //New ArrayLists of data used in chart(XY) in Vehicle.aspx.cs
            ArrayList unit = new ArrayList();
            ArrayList speed = new ArrayList();

            //Create proxy
            GetterClient proxy = new GetterClient();

            //Parameters getPositionsList
            int max = 20;
            string OrderBy = "Speed";

            if (System.IO.File.Exists($"D:/Johan/Documenten/Visual Studio 2015/Projects/DataClient/WebApplication/TempImages/chart{max}_{OrderBy}.jpeg") == true)
            {
                Image1.ImageUrl = $"~/TempImages/chart{max}_{OrderBy}.jpeg";
                Image1.Visible = true;
            }

            else
            {

                //Open connection
                proxy.Open();
                stopwatch.Start();


                //Place values needed in ArrayList
                for (int i = 0; i < max; i++)
                {
                    unit.Add(proxy.GetPositionsList(max, OrderBy)[i].UnitId);
                    speed.Add(proxy.GetPositionsList(max, OrderBy)[i].Speed);
                }

                //Close connection
                proxy.Close();
                stopwatch.Stop();
                Debug.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.Seconds);

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
                Chart Chart1 = new Chart();
                Chart1.Height = 300;
                Chart1.Width = 300;
                Chart1.Compression = 60;
                Chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.Normal;
                Chart1.RenderType = RenderType.ImageTag;
                Chart1.AntiAliasing = AntiAliasingStyles.Graphics;

                Chart1.Series.Clear();
                Chart1.Series.Add(new System.Web.UI.DataVisualization.Charting.Series("1"));
                Chart1.Series["1"].ChartType = SeriesChartType.Column;
                Chart1.Series["1"].Points.DataBindXY(unit, speed);
                Chart1.Series["1"].SmartLabelStyle.Enabled = true;
                Chart1.Series["1"].IsXValueIndexed = true;

                Chart1.ChartAreas.Add(new ChartArea());
                Chart1.ChartAreas[0].AxisX.Title = "Unit ID";
                Chart1.ChartAreas[0].AxisX.IsStartedFromZero = false;
                Chart1.ChartAreas[0].AxisY.Title = "Speed(KM/H)";
                Chart1.ChartAreas[0].AxisY.Interval = 1;
                Chart1.ChartAreas[0].AxisY.Minimum = Min - 1;
                Chart1.ChartAreas[0].AxisY.Maximum = Max;
                Chart1.ChartAreas[0].RecalculateAxesScale();
                Chart1.Series["1"].Sort(PointSortOrder.Descending, "Y");
                AuthorizedContent.Controls.Add(Chart1);

                Chart1.SaveImage($"D:/Johan/Documenten/Visual Studio 2015/Projects/DataClient/WebApplication/TempImages/chart{max}_{OrderBy}.jpeg", ChartImageFormat.Jpeg);

                Response.Redirect(Request.RawUrl);

            }
        }

    }

}