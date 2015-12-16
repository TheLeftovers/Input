using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplication.Models;
using NHibernate.Cfg;
using System.Collections.Generic;
using System.Reflection;

namespace WebApplication.Account
{
    public partial class Register : Page
    {
        public bool EmailUnique = true;


        protected void CreateUser_Click(object sender, EventArgs e)
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


                for (int i = 0; i < maillist.Count; i++)
                {
                    Users u = new Users(maillist[i].ToString(), passwordlist[i].ToString());
                    ulist.Add(u);
                }
                for (int i = 0; i < ulist.Count; i++)
                {
                    if (ulist[i].Email.Equals(Email.Text))
                    {
                        EmailUnique = false;
                        MessageBox.Show(Page, "This email is already registrated");
                        break;
                    }
                }

                if (EmailUnique)
                {
                    /*System.Diagnostics.Debug.WriteLine("INSERT INTO users(email, password) SELECT email, password, ('" + Email.Text + "'), ('" + Password.Text + "')");
                    session.CreateSQLQuery("INSERT INTO users ('" + Email.Text + "', '" + Password.Text + "');");*/

                    Users user = new Users();

                    user.Email = Email.Text;
                    user.Password = Password.Text;
                    session.Save(user);
                    tx.Commit();
                    MessageBox.Show(Page, "Account succesfully created");

                }




            }

            /* var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
            */
        }
    }
}