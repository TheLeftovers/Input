using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UploadFile(object sender, EventArgs e)
    {
        string FileName = FileUpload1.PostedFile.FileName;
        string extension = Path.GetExtension(FileName);

            if (extension.Equals(".csv", StringComparison.CurrentCultureIgnoreCase))
            {
            string path = Server.MapPath("~/");
                FileUpload1.SaveAs(path + FileName);
                MessageBox.Show(Page,"File uploaded succesfully.");
            }
            else
            {
            MessageBox.Show(Page,"Selected file must be .csv");
            }
    }
    
}