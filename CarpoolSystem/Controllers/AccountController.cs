using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using CarpoolSystem.Utilities;

namespace CarpoolSystem.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.LogInModel user)
        {
            
            var errors = ModelState
        .Where(x => x.Value.Errors.Count > 0)
        .Select(x => new { x.Key, x.Value.Errors })
        .ToArray();


            if (ModelState.IsValid)
            {
                if (IsVaild(user.UserName, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Search", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Data is incorrect.");
                }
            }

            return View(user);
        }

        //This method is for loging in a user when they register to the site
        public void Login(string UserName, string Password)
        {
            if (IsVaild(UserName, Password))
            {
                FormsAuthentication.SetAuthCookie(UserName, false);
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

    

        [HttpPost]
        public ActionResult Registration(Models.AccountModel user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MainDbEntities())
                {
                    var userNameCheck = db.Users.Where(b => b.UserName == user.UserName);
                    Emailer email = new Emailer();

                    if(userNameCheck.Count()==0)
                    {
                        var crypto = new SimpleCrypto.PBKDF2();

                        var encrpPass = crypto.Compute(user.Password);

                        var sysUser = db.Users.CreateObject();
                        var sysProfile = db.Profiles.CreateObject();

                        sysUser.UserName = user.UserName;
                        sysUser.Password = encrpPass;
                        sysUser.PasswordSalt = crypto.Salt;
						
                        sysProfile.FirstName = user.FirstName;
                        sysProfile.LastName = user.LastName;
                        sysProfile.Emails = user.Email;
                        sysProfile.CreateDate = DateTime.Today;
                        sysProfile.Address = user.Address;
                        sysProfile.Phone = user.Phone;

                        db.Profiles.AddObject(sysProfile);
                        db.Users.AddObject(sysUser);

                        db.SaveChanges();
                        //Log user into the site
                        email.RegistrationEmail(user.UserName, user.Email);
                        Login(user.UserName, user.Password);
                        return RedirectToAction("SuccessfulReg", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username already exist.");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Register Data is incorrect.");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }

        private bool IsVaild(string UserName, string password)
        {
            //encryption
            var crypto = new SimpleCrypto.PBKDF2();

            bool isValid = false;

            using (var db = new MainDbEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == UserName);

                if (user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(Models.ChangePasswordModel pw)
        {  
            String currentUser = User.Identity.Name;
            if (ModelState.IsValid)
            {
                using (var db = new MainDbEntities())
                {          
                    var crypto = new SimpleCrypto.PBKDF2();
                    if (pw.ConfirmPassword.Equals(pw.NewPassword))
                    {   if (IsVaild(currentUser,pw.OldPassword)){
                             User sysUser = db.Users.FirstOrDefault(m => m.UserName == currentUser);
                             var encrpPass = crypto.Compute(pw.NewPassword);
                             sysUser.Password = encrpPass;
                             sysUser.PasswordSalt = crypto.Salt;
                             db.SaveChanges();
                        }
                    }            
                    return RedirectToAction("Login", "Account");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult PasswordRetrieval()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordRetrieval(Models.PasswordRetrievalModel pr)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MainDbEntities())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    if (pr.ConfirmEmail.Equals(pr.Email))
                    {
                        int start = 100000; int end = 900000; int rand;
                        User sysUser = db.Users.FirstOrDefault(m => m.UserName == pr.UserName);
                        Random rnd = new Random();
                        rand = rnd.Next(start, end);
                        sysUser.Password = crypto.Compute(rand.ToString());
                        sysUser.PasswordSalt = crypto.Salt;
                        db.SaveChanges();

                        Emailer email = new Emailer();
                        email.ChangePasswordEmail(pr.UserName, pr.Email, rand.ToString());
                    }
                    return RedirectToAction("Login", "Account");
                }
            }

            return View();
        }
    }
}
