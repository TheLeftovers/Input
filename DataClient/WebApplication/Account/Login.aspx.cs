﻿using Microsoft.AspNet.Identity.Owin;
using Npgsql;
using System;
using System.Collections;
using System.Web;
using System.Web.UI;

namespace WebApplication.Account
{
    public partial class Login : Page
    {
        
        public object Login1 { get; private set; }
        public bool IsValidaded { get; private set; }
        ArrayList maillist = new ArrayList();
        ArrayList passwordlist = new ArrayList();
        ArrayList ranklist = new ArrayList();


        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
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
                ranklist.Add(dr[2]);
            }

            // Close connection
            conn.Close();
            
            //Check if email exists and if it exists check the belonging password is the same.
            for (int i = 0; i < maillist.Count; i++)
                {
                    if (maillist[i].Equals(Email.Text))
                    {
                        if (passwordlist[i].Equals(Password.Text))
                        {
                            MessageBox.Show(Page, "Ingelogd");
                            IsValidaded = true;
                            WebApplication.SiteMaster.LoggedIn = true;                      //Set login to true
                            WebApplication.SiteMaster.UserName = maillist[i].ToString();    //Email user
                            WebApplication.SiteMaster.Rank = ranklist[i].ToString();        //Rank user
                        }
                        else
                        {
                            MessageBox.Show(Page, "Ongeldig wachtwoord!");
                        }
                    }
                    else
                    {
                        MessageBox.Show(Page, "Dit emailadres is niet geregistreerd!");
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
                                                        Request.QueryString["ReturnUrl"]),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Login mislukt!";
                        ErrorMessage.Visible = true;
                        break;
                }
            }

            }
        
        }
    }
