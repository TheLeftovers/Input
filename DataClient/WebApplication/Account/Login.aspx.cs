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

namespace WebApplication.Account
{
    public partial class Login : Page
    {
        
        public object Login1 { get; private set; }
        public bool IsValidaded { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {


            var cfg = new Configuration();
            List<Users> ulist = new List<Users>();
            
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Server=localhost;database=project56;user id=postgres;password=root";
                x.Driver<NHibernate.Driver.NpgsqlDriver>();
                x.Dialect<NHibernate.Dialect.PostgreSQLDialect>();
            });
            
            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var sessionFactory = cfg.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {

                var maillist = session.CreateSQLQuery("SELECT email FROM users").List();
                var passwordlist = session.CreateSQLQuery("SELECT password FROM users").List();


                for (int i=0; i < maillist.Count; i++)
                {
                    Users u = new Users(maillist[i].ToString(), passwordlist[i].ToString());
                    ulist.Add(u);
                }
                tx.Commit();

            }
            

            for (int i = 0; i < ulist.Count; i++)
                {
                    if (ulist[i].Email.Equals(Email.Text))
                    {
                        if (ulist[i].Password.Equals(Password.Text))
                        {
                            System.Diagnostics.Debug.WriteLine("Logged in as" + ulist[i].Email);
                            MessageBox.Show(Page, "Logged in");
                            IsValidaded = true;
                            WebApplication.SiteMaster.LoggedIn = true;
                            WebApplication.SiteMaster.UserName = ulist[i].Email;
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
