using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;

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
        public ActionResult LogIn(Models.AccountModel user)
        {
            if (ModelState.IsValid)
            {
                if (IsVaild(user.UserName, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Data is incorrect.");
                }
            }

            return View(user);
        }

        public ActionResult LogOut()
        {
            return View();
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
                    Guid userIdGuid = Guid.NewGuid();
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrpPass = crypto.Compute(user.Password);

                    var sysUser = db.Users.CreateObject();
                    var sysProfile = db.Profiles.CreateObject();


                    sysUser.UserName = user.UserName;
                    //sysUser.Password = encrpPass;
                    //sysUser.PasswordSalt = crypto.Salt;
                    sysUser.Password = user.Password;
                    sysUser.PasswordSalt = "123";


                    sysProfile.FirstName = user.FirstName;
                    sysProfile.LastName = user.LastName;
                    sysProfile.Emails = user.Email;
                    sysProfile.CreateDate = DateTime.Today;
                    sysProfile.Address = user.Address;
                    sysProfile.Phone = user.Phone;

                    //sysProfile.ProfileId.

                    //userIdGuid = new Guid(sysUser.UserId);
                    //sysUser.UserId = userIdGuid;

                    db.Profiles.AddObject(sysProfile);
                    db.Users.AddObject(sysUser);

                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login Data is incorrect.");
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


    }
}
