using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplication.Models;
using System.Data.SqlClient;
using System.Data;
using NHibernate.Cfg;
using System.Reflection;
using System.Collections.Generic;
using System.Web.Security;
using Npgsql;
using System.Collections;
using System.Diagnostics;

namespace WebApplication.Account
{
    public partial class Login : Page
    {
        
        public object Login1 { get; private set; }
        public bool IsValidaded { get; private set; }
        ArrayList maillist = new ArrayList();
        ArrayList passwordlist = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            
            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM users", conn);

            // Execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            

            //Get rows and place in ArrayList
            while (dr.Read())
            {
                maillist.Add(dr[0]);
                passwordlist.Add(dr[1]);
            }

            // Close connection
            conn.Close();
            

            for (int i = 0; i < maillist.Count; i++)
                {
                    if (maillist[i].Equals(Email.Text))
                    {
                        if (passwordlist[i].Equals(Password.Text))
                        {
                            System.Diagnostics.Debug.WriteLine("Logged in as" + maillist[i].ToString());
                            MessageBox.Show(Page, "Logged in");
                            IsValidaded = true;
                            WebApplication.SiteMaster.LoggedIn = true;
                            WebApplication.SiteMaster.UserName = maillist[i].ToString();
                       
                        }
                        else
                        {
                            MessageBox.Show(Page, "Invalid password");
                        }
                    }
                    else
                    {
                        MessageBox.Show(Page, "This email is not registrated");
                    }
                }
           

            if (IsValidaded)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = SignInStatus.Success;

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);


                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }

            }
        
        }
    }
