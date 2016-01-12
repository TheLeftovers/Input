using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace WebApplication
{
    public partial class SiteMaster : MasterPage
    {
        public static bool LoggedIn { get; internal set; }
        public static string UserName { get; internal set; }
        public static string Rank { get; internal set; }


        protected void Page_Init(object sender, EventArgs e)
        {
            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (LoggedIn)
            {
                AnonymousTemplate.Visible = false;
                LoggedInTemplate.Visible = true;
             }
            else
            {
                AnonymousTemplate.Visible = true;
                LoggedInTemplate.Visible = false;

            }

            if (Rank == "2" && LoggedIn)
            {
                UserManagement.Visible = true;
            }
            else
            {
                UserManagement.Visible = false;
            }
        }

       
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            LoggedIn = false;
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

        }
    }

}