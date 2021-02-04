using App.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using ProcessAutomation.Models;
using System.Web;
using System.Web.Mvc;
using Application.Interfaces;
using ERPConfiguration.Models;

namespace ERPConfiguration.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IStaffAppService _newStaffService;
        public AuthenticationController(IStaffAppService _newStaffService)
        {
            this._newStaffService = _newStaffService;
        }
        // GET: Authentication
        public ActionResult Authentication()
        {
            return View("~/Views/Security/Authentication.cshtml");
           // return View();
        }
        [HttpPost]
        public ActionResult Login(VMLogin user)
        {
            string Pass = EncryptionDecryption.DH_PEncode(user.Password);
            string Uname = EncryptionDecryption.DH_PEncode(user.UserName);
            var userInfo = (from mi in _newStaffService.All().ToList()
                            where mi.LoginName == Uname && mi.Password == Pass
                            select new
                            {
                                UserID = mi.StaffId,
                                UserName = mi.LoginName,
                                Password = mi.Password,
                                Email = mi.Email
                            }).FirstOrDefault();

            if (userInfo!=null)
            {
                Session["UserID"] = userInfo.UserID;
                Session["UserName"] = userInfo.UserName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Login data is incorrect!";
                return RedirectToAction("Authentication", "Authentication");
            }
        }
        public ActionResult LogOff()
        {
            //WebSecurity.Logout();

            Session.Abandon();
            Session.RemoveAll();

            return RedirectToAction("Authentication", "Authentication");
        }
    }
}