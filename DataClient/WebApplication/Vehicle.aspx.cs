﻿using System;
using System.Collections;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using WebApplication.GetterService;

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
            ArrayList unit = new ArrayList();
            ArrayList speed = new ArrayList();
            ArrayList hdop = new ArrayList();
            ArrayList sats = new ArrayList();

            //Create proxy
            GetterClient proxy = new GetterClient();

            //Parameters getPositionsList
            string order = "speed";
            string order2 = "hdop";
            int max = 50;


            //If image of chart with same parameters already exists, make asp image visible and this image with specific parameters.
            if (System.IO.File.Exists($"C:\\GitHub\\Input\\DataClient\\WebApplication\\TempImages\\chart{max}_{order}.jpeg") == true)
            {
                Image1.ImageUrl = $"~\\TempImages\\chart{max}_{order}.jpeg";
                Image1.Visible = true;

                Image2.ImageUrl = $"~\\TempImages\\chart{max}_{order2}.jpeg";
                Image2.Visible = true;
            }

            else
            {
                //Open connection
                proxy.Open();

                //Place values needed in ArrayList
                for (int i = 0; i < max; i++)
                {
                    unit.Add(proxy.GetUnitList()[i]);
                    speed.Add(proxy.GetSpeedList()[i]);
                    hdop.Add(proxy.GetHDOPList()[i]);
                    sats.Add(proxy.GetNumSatellitesList()[i]);
                }

                //Close connection
                proxy.Close();


                //Sort elements in ArrayList
                int Max = int.MinValue;
                int Min = int.MaxValue;
                int Max2 = int.MinValue;
                int Min2 = int.MaxValue;

                //Get Minimum and Maximum value of ArrayList to define axes of the Chart.
                foreach (int x in speed)
                {
                    if (Max < x)
                    { Max = x; }
                    if (Min > x)
                    { Min = x; }
                }

                //Get Minimum and Maximum value of ArrayList to define axes of the Chart.
                foreach (int x in hdop)
                {
                    if (Max2 < x)
                    { Max2 = x; }
                    if (Min2 > x)
                    { Min2 = x; }
                }

                //Setup Chart 1.
                Chart Chart1 = new Chart();
                Chart1.ChartAreas.Add(new ChartArea("0"));

                Chart1.Height = 350;
                Chart1.Width = 400;
                //Chart1.Compression = 50;
                Chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
                Chart1.RenderType = RenderType.ImageTag;
                Chart1.AntiAliasing = AntiAliasingStyles.All;
                Chart1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF");
                Chart1.IsSoftShadows = true;

                //Series settings
                Chart1.Series.Clear();
                Chart1.Series.Add(new Series("1"));
                Chart1.Series["1"].ChartType = SeriesChartType.Column;
                Chart1.Series["1"].Points.DataBindXY(unit, speed);
                Chart1.Series["1"].SmartLabelStyle.Enabled = true;
                Chart1.Series["1"].IsXValueIndexed = true;
                Chart1.Series["1"].LabelForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart1.Series["1"].Sort(PointSortOrder.Descending, "Y");
                Chart1.Series["1"].CustomProperties = "PointWidth=0.6";

                //ChartArea settings
                Chart1.ChartAreas["0"].AxisX.MajorGrid.Enabled = false;
                Chart1.ChartAreas["0"].AxisX.IsStartedFromZero = false;
                Chart1.ChartAreas["0"].AxisX.Title = "Unit ID";
                Chart1.ChartAreas["0"].AxisY.Title = "Snelheid(KM/U)";
                Chart1.ChartAreas["0"].AxisY.Interval = 5;
                Chart1.ChartAreas["0"].AxisX.Interval = 5;
                Chart1.ChartAreas["0"].AxisY.Minimum = Min - 1;
                Chart1.ChartAreas["0"].AxisY.Maximum = Max;
                Chart1.ChartAreas["0"].RecalculateAxesScale();

                //Colors
                Chart1.Series["1"].Color = System.Drawing.Color.DodgerBlue;
                Chart1.ChartAreas["0"].AxisX.TitleForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart1.ChartAreas["0"].AxisY.TitleForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart1.ChartAreas["0"].AxisX.LabelStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart1.ChartAreas["0"].AxisY.LabelStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart1.ChartAreas["0"].AxisY.LineColor = System.Drawing.ColorTranslator.FromHtml("#aaaaaa");
                Chart1.ChartAreas["0"].AxisX.LineColor = System.Drawing.ColorTranslator.FromHtml("#aaaaaa");
                Chart1.ChartAreas["0"].BackColor = System.Drawing.ColorTranslator.FromHtml("#888888");
                Chart1.ChartAreas["0"].AxisY.MajorGrid.LineColor = System.Drawing.ColorTranslator.FromHtml("#aaaaaa");
                Chart1.ChartAreas["0"].AxisX.MajorGrid.LineColor = System.Drawing.ColorTranslator.FromHtml("#aaaaaa");
                Chart1.ChartAreas["0"].ShadowColor = System.Drawing.Color.Gray;


                //3D Setting for Chart
                Chart1.ChartAreas["0"].Area3DStyle.Enable3D = false;
                Chart1.ChartAreas["0"].Area3DStyle.IsClustered = false;
                Chart1.ChartAreas["0"].Area3DStyle.IsRightAngleAxes = false;
                Chart1.ChartAreas["0"].Area3DStyle.Inclination = 10;
                Chart1.ChartAreas["0"].Area3DStyle.LightStyle = LightStyle.Realistic;
                Chart1.ChartAreas["0"].Area3DStyle.Perspective = 15;
                Chart1.ChartAreas["0"].Area3DStyle.WallWidth = 10;

                //Setup Chart 2.
                Chart Chart2 = new Chart();
                Chart2.ChartAreas.Add(new ChartArea("1"));

                Chart2.Height = 350;
                Chart2.Width = 400;
                //Chart1.Compression = 50;
                Chart2.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
                Chart2.RenderType = RenderType.ImageTag;
                Chart2.AntiAliasing = AntiAliasingStyles.All;
                Chart2.IsSoftShadows = true;

                //Series settings
                Chart2.Series.Clear();
                Chart2.Series.Add(new Series("2"));
                Chart2.Series["2"].ChartType = SeriesChartType.Line;
                Chart2.Series["2"].Points.DataBindXY(hdop, sats);
                Chart2.Series["2"].SmartLabelStyle.Enabled = true;
                Chart2.Series["2"].IsXValueIndexed = false;
                Chart2.Series["2"].LabelForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart2.Series["2"].Sort(PointSortOrder.Descending, "Y");
                Chart2.Series["2"].Sort(PointSortOrder.Ascending, "X");
                Chart2.Series["2"].CustomProperties = "PointWidth=0.6";

                //ChartArea settings
                Chart2.ChartAreas["1"].AxisX.MajorGrid.Enabled = false;
                Chart2.ChartAreas["1"].AxisY.MajorGrid.Enabled = false;
                Chart2.ChartAreas["1"].AxisX.IsStartedFromZero = true;
                Chart2.ChartAreas["1"].AxisY.Title = "Number of Satellites";
                Chart2.ChartAreas["1"].AxisX.Title = "HDOP";
                Chart2.ChartAreas["1"].AxisX.Interval = 10;
                Chart2.ChartAreas["1"].AxisX.Minimum = Min2;
                Chart2.ChartAreas["1"].AxisX.Maximum = Max2;
                Chart2.ChartAreas["1"].AxisY.Interval = 1;
                Chart2.ChartAreas["1"].AxisY.Minimum = 0;
                Chart2.ChartAreas["1"].AxisY.Maximum = 14;
                Chart2.ChartAreas["1"].RecalculateAxesScale();


                //Add Chart to div in Vehicle.aspx
                AuthorizedContent.Controls.Add(Chart1);
                AuthorizedContent.Controls.Add(new LiteralControl("<br />"));
                AuthorizedContent.Controls.Add(Chart2);

                //Save created chart in following folder and name.
                Chart1.SaveImage($"C:\\GitHub\\Input\\DataClient\\WebApplication\\TempImages\\chart{max}_{order}.jpeg", ChartImageFormat.Jpeg);
                Chart2.SaveImage($"C:\\GitHub\\Input\\DataClient\\WebApplication\\TempImages\\chart{max}_{order2}.jpeg", ChartImageFormat.Jpeg);


                //Refresh page for new chart to be visible.
                Response.Redirect(Request.RawUrl);
            

            }
        }
    }
}