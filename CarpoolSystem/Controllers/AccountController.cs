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

            
            if (ModelState.IsValid)
            {
                if (IsVaild(user.UserName, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("MainPage", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Data is incorrect.");
                }
            }
            return View(user);
        }

        //This method is for logging in a user when they register to the site
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
            String currentUser = User.Identity.Name;

            if (currentUser.Length == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            using (var db = new MainDbEntities())
            {
                var user = db.Users.FirstOrDefault(c => c.UserName == currentUser);
                var results = db.Profiles.FirstOrDefault(c => c.ProfileId == user.ProfileId);
                return View(results);
            }
        }

        public ActionResult EditProfile(int id)
        {

            String currentUser = User.Identity.Name;
            if (currentUser.Length == 0)
            {
                return RedirectToAction("Login", "Account");
            }

            using (var db = new MainDbEntities())
            {
                var results = db.Profiles.FirstOrDefault(c => c.ProfileId == id);
                return View(results);
            }
        }

        [HttpPost]
        public ActionResult EditProfile(Models.EditProfileModel userProfile)
        {
            String currentUser = User.Identity.Name;
            if (currentUser.Length == 0)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                using (var db = new MainDbEntities())
                {
                    try
                    {
                        var user = db.Users.FirstOrDefault(c => c.UserName == currentUser);
                        var results = db.Profiles.FirstOrDefault(c => c.ProfileId == user.ProfileId);

                        results.Emails = userProfile.Emails;
                        results.FirstName = userProfile.FirstName;
                        results.LastName = userProfile.LastName;
                        results.Phone = userProfile.Phone;
                        db.SaveChanges();
                        return RedirectToAction("Profile", "Account");
                    }
                    catch
                    {
                        ModelState.AddModelError("", "An error occured while saving profile changes");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Please varify the updated information is correct");
            }
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
            if (isLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }
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
                    {   
                        if (IsVaild(currentUser,pw.OldPassword))
                        {
                             User sysUser = db.Users.FirstOrDefault(m => m.UserName == currentUser);
                             var encrpPass = crypto.Compute(pw.NewPassword);
                             sysUser.Password = encrpPass;
                             sysUser.PasswordSalt = crypto.Salt;
                             db.SaveChanges();

                        }
                    }            
                    return RedirectToAction("PasswordChangeOk", "Account");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult PasswordChangeOk()
        {
            return View();
        }

        //this method is for when a user forgets their 
        //password and needs it emailed to them
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
                    return RedirectToAction("PasswordChangeOk", "Account");
                }
            }

            return View();
        }

        // returns true if user is logged in, false otherwise
        public bool isLoggedIn()
        {
            bool isLoggedIn = false;
            string currentlyLoggedInUser = User.Identity.Name;
            if (currentlyLoggedInUser.Length == 0)
            {
                isLoggedIn = true;
            }
            return isLoggedIn;
        }
    }
}
