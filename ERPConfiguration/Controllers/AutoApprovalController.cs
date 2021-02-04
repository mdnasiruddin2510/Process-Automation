using App.Domain;
using Application.Interfaces;
using ProcessAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProcessAutomation.Controllers
{
    public class AutoApprovalController : Controller
    {

        private IActionListAppService _actionListService;
        private IEmployeeAppService _employeeService;
        private IFileTransMainAppService _FileTransMainService;
        private IFileTransDetailAppService _palogsService;
        public AutoApprovalController(IEmployeeAppService _employeeService, IFileTransMainAppService _pafamainService, IFileTransDetailAppService _palogsService, IActionListAppService _actionListService)
         {
            
             this._employeeService = _employeeService;
             this._FileTransMainService = _pafamainService;
             this._palogsService = _palogsService;
             this._actionListService = _actionListService;
         }
        // GET: AutoApproval
        public ActionResult AutoApproval() 
        {

            ViewBag.ProcessNo = _FileTransMainService.All().Select(x => x.FileTransID).LastOrDefault() + 1;
            ViewBag.ActID = LoadDropDown.LoadAllActions(_actionListService);
            ViewBag.ActionBy = LoadDropDown.LoadPrepApprvBy();
            ViewBag.MarkTo = LoadDropDown.LoadPrepApprvBy();
           // ViewBag.ActionBy = LoadDropDown.LoadPrepApprvBy(_employeeService, "MemberLoan", "Action By");
           // ViewBag.MarkTo = LoadDropDown.LoadPrepApprvBy(_employeeService, "MemberLoan", "Mark To");
            return View();
        }
        public ActionResult Savepa_fpmain(FileTransMain pafpmain)
        {
            try
            {

                //RBACUser rUser = new RBACUser(Session["UserName"].ToString());
                //if (!rUser.HasPermission("Receive_Insert"))
                //{
                //    return Json("X", JsonRequestBehavior.AllowGet);
                //}
                var IfExit = _FileTransMainService.All().Where(x => x.FileTransID == pafpmain.FileTransID).ToList();
                if (IfExit.Count == 0)
                {

                    FileTransMain pa_fpmains = new FileTransMain();
                    pa_fpmains = pafpmain;
                    //pa_fpmains.ProcessNo = _pafamainService.All().Select(x => x.ProcessNo).LastOrDefault() + 1;
                    _FileTransMainService.Add(pa_fpmains);
                    _FileTransMainService.Save();


                }
                var ecode = 1;
                return Json(ecode, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json("0", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult SendEmailToUser() {
            bool result = false;
            result = SendEmail("annaislam1000@gmail.com", "test subject", "<p>Hi Anna,</br> this mail is for check</p>");
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public bool SendEmail(string toEmail,string subject, string emailBody) {

            try 
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com",587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail,toEmail,subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            } 
        }
    }
}