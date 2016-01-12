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
                FillTable();
                CreateChart();
            }
            else
            {
                AnonymousContent.Visible = true;
                AuthorizedContent.Visible = false;
            }
        }

        public void FillTable()
        {
            //Create proxy
            GetterClient proxy = new GetterClient();

            //Open connection
            proxy.Open();

            for (int i = 0; i < 9; i++)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = proxy.GetUnitListbyRepair()[i].ToString();
                row.Cells.Add(cell);
                Table1.Rows.Add(row);
            }

            proxy.Close();
        }

        public void CreateChart()
        {
            //Create proxy
            GetterClient proxy = new GetterClient();

            //Parameters getPositionsList
            string order = "gpstemp";


            //If image of chart with same parameters already exists, make asp image visible and this image with specific parameters.
            if (System.IO.File.Exists($"C:\\inetpub\\wwwroot\\CityGIS\\img\\chart{order}.jpeg") == true)
            {
                Image1.ImageUrl = $"~\\img\\chart{order}.jpeg";
                Image1.Visible = true;
            }

            

            else { 
            
                //Setup Chart 1.
                Chart Chart1 = new Chart();
                Chart1.ChartAreas.Add(new ChartArea("0"));

                Chart1.Height = 350;
                Chart1.Width = 700;
                //Chart1.Compression = 50;
                Chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
                Chart1.RenderType = RenderType.ImageTag;
                Chart1.AntiAliasing = AntiAliasingStyles.All;
                Chart1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF");
                Chart1.IsSoftShadows = true;

                //Series settings
                Chart1.Series.Clear();
                Chart1.Series.Add(new Series("1"));
                Chart1.Series["1"].ChartType = SeriesChartType.Line;
                Chart1.Series["1"].SmartLabelStyle.Enabled = true;
                Chart1.Series["1"].IsXValueIndexed = true;
                Chart1.Series["1"].LabelForeColor = System.Drawing.ColorTranslator.FromHtml("#383838");
                Chart1.Series["1"].Sort(PointSortOrder.Descending, "Y");
                Chart1.Series["1"].CustomProperties = "PointWidth=0.6";

                //Open connection
                proxy.Open();
                Chart1.Series["1"].Points.DataBindXY(proxy.GetBeginTimeList(), proxy.GetMaxList());
                proxy.Close();

                //ChartArea settings
                Chart1.ChartAreas["0"].AxisX.MajorGrid.Enabled = false;
                Chart1.ChartAreas["0"].AxisX.IsStartedFromZero = false;
                Chart1.ChartAreas["0"].AxisY.Title = "Temperatuur";
                Chart1.ChartAreas["0"].AxisX.Title = "Tijd";
                Chart1.ChartAreas["0"].AxisY.Interval = 2;
                Chart1.ChartAreas["0"].AxisY.Maximum = 36;
                Chart1.ChartAreas["0"].AxisY.Minimum = 12 - 1;
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

                //Add Chart to div in Vehicle.aspx
                AuthorizedContent.Controls.Add(Chart1);
                AuthorizedContent.Controls.Add(new LiteralControl("<h4>Temperatuur in graden Celsius over tijd.</h4>"));
                AuthorizedContent.Controls.Add(new LiteralControl("<br />"));

                //Save created chart in following folder and name.
                Chart1.SaveImage($"C:\\inetpub\\wwwroot\\CityGIS\\img\\chart{order}.jpeg", ChartImageFormat.Jpeg);
                //Chart1.SaveImage($"C:\\Github\\Input\\DataClient\\WebApplication\\img\\chart{order}.jpeg", ChartImageFormat.Jpeg);

                //Refresh page for new chart to be visible.
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}