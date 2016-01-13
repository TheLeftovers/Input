using Spire.Pdf;
using Spire.Pdf.Barcode;
using Spire.Pdf.Graphics;
using Spire.Pdf.Grid;
using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
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
                Download();
            }
            else
            {
                AnonymousContent.Visible = true;
                AuthorizedContent.Visible = false;
            }
        }

        public void CreateChart()
        {
           
            //Create proxy
            GetterClient proxy = new GetterClient();

            //Parameters getPositionsList
            string order = "speed";
            string order2 = "hdop";
            int max = 50;


            //If image of chart with same parameters already exists, make asp image visible and this image with specific parameters.
            if (System.IO.File.Exists($"C:\\inetpub\\wwwroot\\CityGIS\\img\\chart{max}_{order}.jpeg") == true
                && System.IO.File.Exists($"C:\\inetpub\\wwwroot\\CityGIS\\img\\chart{max}_{order2}.jpeg") == true)
            {
                Image1.ImageUrl = $"~\\img\\chart{max}_{order}.jpeg";
                Image1.Visible = true;

                Image2.ImageUrl = $"~\\img\\chart{max}_{order2}.jpeg";
                Image2.Visible = true;
            }

            else
            {
                
                //Setup Chart 1.
                Chart Chart1 = new Chart();
                Chart1.ChartAreas.Add(new ChartArea("0"));

                Chart1.Height = 350;
                Chart1.Width = 800;
                Chart1.Compression = 30;
                Chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
                Chart1.RenderType = RenderType.ImageTag;
                Chart1.AntiAliasing = AntiAliasingStyles.All;
                Chart1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF");
                Chart1.IsSoftShadows = true;

                //Series settings
                Chart1.Series.Clear();
                Chart1.Series.Add(new Series("1"));
                Chart1.Series["1"].ChartType = SeriesChartType.Column;
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
                Chart1.ChartAreas["0"].AxisY.Maximum = 166;
                Chart1.ChartAreas["0"].AxisY.Minimum = 156 - 1;
                Chart1.ChartAreas["0"].RecalculateAxesScale();

                //Colors
                Chart1.Series["1"].Color = System.Drawing.Color.DodgerBlue;
                Chart1.ChartAreas["0"].AxisX.TitleForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart1.ChartAreas["0"].AxisY.TitleForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart1.ChartAreas["0"].AxisX.LabelStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart1.ChartAreas["0"].AxisY.LabelStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart1.ChartAreas["0"].AxisY.LineColor = System.Drawing.ColorTranslator.FromHtml("#aaaaaa");
                Chart1.ChartAreas["0"].AxisX.LineColor = System.Drawing.ColorTranslator.FromHtml("#aaaaaa");
                Chart1.ChartAreas["0"].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
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
                Chart2.Width = 800;
                Chart1.Compression = 30;
                Chart2.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
                Chart2.RenderType = RenderType.ImageTag;
                Chart2.AntiAliasing = AntiAliasingStyles.All;
                Chart2.IsSoftShadows = true;

                //Series settings
                Chart2.Series.Clear();
                Chart2.Series.Add(new Series("2"));
                Chart2.Series["2"].ChartType = SeriesChartType.Line;
                Chart2.Series["2"].SmartLabelStyle.Enabled = true;
                Chart2.Series["2"].IsXValueIndexed = false;
                Chart2.Series["2"].LabelForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart2.Series["2"].Sort(PointSortOrder.Descending, "Y");
                Chart2.Series["2"].Sort(PointSortOrder.Ascending, "X");
                Chart2.Series["2"].CustomProperties = "PointWidth=0.6";

                //Open connection
                proxy.Open();
                Chart1.Series["1"].Points.DataBindXY(proxy.GetUnitList(), proxy.GetSpeedList());
                Chart2.Series["2"].Points.DataBindXY(proxy.GetHDOPList(), proxy.GetNumSatellitesList());
                proxy.Close();

                //ChartArea settings
                Chart2.ChartAreas["1"].AxisX.MajorGrid.Enabled = false;
                Chart2.ChartAreas["1"].AxisY.MajorGrid.Enabled = false;
                Chart2.ChartAreas["1"].AxisX.IsStartedFromZero = true;
                Chart2.ChartAreas["1"].AxisY.Title = "Number of Satellites";
                Chart2.ChartAreas["1"].AxisX.Title = "HDOP";
                Chart2.ChartAreas["1"].AxisX.Interval = 10;
               // Chart2.ChartAreas["1"].AxisX.Minimum = Min2;
               // Chart2.ChartAreas["1"].AxisX.Maximum = Max2;
                Chart2.ChartAreas["1"].AxisY.Interval = 1;
                Chart2.ChartAreas["1"].AxisY.Minimum = 0;
                Chart2.ChartAreas["1"].AxisY.Maximum = 14;
                Chart2.ChartAreas["1"].RecalculateAxesScale();
               
                //Add Chart to div in Vehicle.aspx
                AuthorizedContent.Controls.Add(Chart1);
                AuthorizedContent.Controls.Add(new LiteralControl("<br />"));
                AuthorizedContent.Controls.Add(Chart2);
                AuthorizedContent.Controls.Add(new LiteralControl("<br />"));

                //Save created chart in following folder and name.
                Chart1.SaveImage($"C:\\inetpub\\wwwroot\\CityGIS\\img\\chart{max}_{order}.jpeg", ChartImageFormat.Jpeg);
                Chart2.SaveImage($"C:\\inetpub\\wwwroot\\CityGIS\\img\\chart{max}_{order2}.jpeg", ChartImageFormat.Jpeg);


                //Refresh page for new chart to be visible.
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void Download()
        {
            //Create a pdf document.

            PdfDocument doc = new PdfDocument();

            PdfPageSettings setting = new PdfPageSettings();
            setting.Size = PdfPageSize.A4;

            // Create one page

            PdfPageBase page = doc.Pages.Add();

            //Draw the text
            PdfImage img1 = PdfImage.FromFile("C:\\inetpub\\wwwroot\\CityGIS\\img\\chart50_speed.jpeg");
            PdfImage img2 = PdfImage.FromFile("C:\\inetpub\\wwwroot\\CityGIS\\img\\chart50_hdop.jpeg");

            PointF position = new PointF(0, 0);
            PointF positionText = new PointF(0, 280);
            PointF positionText2 = new PointF(0, 650);
            PointF position2 = new PointF(0, 400);
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 10);
            PdfBrush brush = PdfBrushes.Black;


            page.Canvas.DrawImage(img1, position);
            page.Canvas.DrawString("Top 50 hoogste snelheden per wagen.", font, brush , positionText);
            page.Canvas.DrawImage(img2, position2);
            page.Canvas.DrawString("Waarde HDOP per aantal verbonden satellieten.", font, brush, positionText2);


            //Save pdf file.
            try
            {
                doc.SaveToFile("C:\\inetpub\\wwwroot\\CityGIS\\img\\Wagenpark_Rapport.pdf");

                doc.Close();
            }
            catch (Exception e) { MessageBox.Show(Page, "Dit bestand bestaat al!"); }
        }
    }
}