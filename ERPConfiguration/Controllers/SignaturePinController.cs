using App.Domain.ViewModel;
using Application.Interfaces;
using ERPConfiguration.Models;
using ProcessAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace ERPConfiguration.Controllers
{
    public class SignaturePinController : Controller
    {
        private readonly IStaffAppService _newStaffService;
        public SignaturePinController(IStaffAppService _newStaffService)
        {
            this._newStaffService = _newStaffService;
        }
        // GET: SignaturePin
        public ActionResult Signature()
        {
            return View();
        }
        public ActionResult UpdateSignature(SignaturePin signature)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var userId = Convert.ToInt32(Session["UserID"].ToString());
                    var userInfo = _newStaffService.All().Where(x => x.StaffId == userId).FirstOrDefault();
                    userInfo.Password = EncryptionDecryption.DH_PEncode(signature.Pin); //(signature.Pin);
                    userInfo.ConfirmPass = EncryptionDecryption.DH_PEncode(signature.ConfirmPin);
                    _newStaffService.Update(userInfo);
                    _newStaffService.Save();
                    transaction.Complete();
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                    transaction.Dispose();
                    return Json("0", JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}