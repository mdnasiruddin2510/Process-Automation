using App.Domain;
using Application.Interfaces;
using ERPConfiguration.Models;
using Newtonsoft.Json.Linq;
using ProcessAutomation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace AcclineERP.Controllers
{
    public class NewStaffController : Controller
    {
        private readonly IBoundaryAppService _boundaryService;
        private readonly IReportingAppService _reportingService;
        private readonly IStaffAppService _newStaffService;
        private readonly IStaffDetailsAppService _staffDetailsAppService;
        public NewStaffController(IStaffDetailsAppService _staffDetailsAppService, IBoundaryAppService _boundaryService, IReportingAppService _reportingService, IStaffAppService _newStaffService)
        {
            this._staffDetailsAppService = _staffDetailsAppService;
            this._boundaryService = _boundaryService;
            this._reportingService = _reportingService;
            this._newStaffService = _newStaffService;
        }
        public ActionResult NewStaff()
        {
            ViewBag.Id = _newStaffService.All().Select(x => x.StaffId).LastOrDefault() + 1;
            ViewBag.BoundaryId = LoadDropDown.LoadBoundary(_boundaryService);
            ViewBag.ReportingId = LoadDropDown.LoadReportingTo(_newStaffService);
            return View();
        }
        public ActionResult SaveNewStaff()
        {
            try
            {
            using (var transaction = new TransactionScope())
            {
            string PhysicalPhPath = "";
            HttpFileCollectionBase PhotoFile = Request.Files;
            //var PhotoFile = Request.Files["PhotoFile"];
            var fMain = Request.Form["loadInfo"];
            var obj1 = JObject.Parse(fMain);
            var StaffId = (int)obj1["loadInfo"]["StaffId"];
            try
            {
                    string fileName = "";
                    string NewPhotoID = "";
                    string ImgPrefix = "";
                    string ext = "";
                    string fileId = Guid.NewGuid().ToString().Replace("-", "");
                    string PhotoPath = "";
                    string DBPhotoPath = "";
                if (PhotoFile != null)
                {
                    for (int i = 0; i < PhotoFile.Count; i++)
                    {
                        HttpPostedFileBase file = PhotoFile[i];
                        fileName = Path.GetFileName(file.FileName);
                        ImgPrefix = "Photo";
                        int fSize = file.ContentLength;
                        //var path = Path.Combine(Server.MapPath("~/Uploads/Photo/"), MemberCode, fileId);

                        ext = System.IO.Path.GetExtension(fileName);
                        if (ext.ToLower().Contains("gif") || ext.ToLower().Contains("jpg") ||
                            ext.ToLower().Contains("jpeg")
                            || ext.ToLower().Contains("png"))
                        {
                            NewPhotoID = ImgPrefix + fileId + ext;
                            PhotoPath = ConfigurationManager.AppSettings["PhotoPath"];
                            PhysicalPhPath = Path.Combine(Server.MapPath(PhotoPath), NewPhotoID);
                            //var path = Path.Combine(Server.MapPath("~/Images/Photo"), fileName);
                            file.SaveAs(PhysicalPhPath);

                            DBPhotoPath = PhotoPath + "\\" + NewPhotoID;
                        }
                        StaffDetails newStaffDetails = new StaffDetails();
                        var fileByte = new byte[file.ContentLength];
                        file.InputStream.Read(fileByte, 0, file.ContentLength);
                        newStaffDetails.File = fileByte;
                        newStaffDetails.FileName = file.FileName;
                        _staffDetailsAppService.Add(newStaffDetails);
                        _staffDetailsAppService.Save();
                    }
                }
            }
                
                 catch (Exception)
                {
                    transaction.Dispose();
                    return Json("0", JsonRequestBehavior.AllowGet);
                }    
                    StaffInfo StaffInfo = new StaffInfo();
                    //StaffInfo = newStaff;
                    StaffInfo.StaffId = (int)obj1["loadInfo"]["StaffId"];
                    StaffInfo.StaffName = EncryptionDecryption.DH_PEncode((string)obj1["loadInfo"]["StaffName"]);
                    StaffInfo.LoginName = EncryptionDecryption.DH_PEncode((string)obj1["loadInfo"]["LoginName"]);
                    StaffInfo.BoundaryId = EncryptionDecryption.DH_PEncodeInt((int)obj1["loadInfo"]["BoundaryId"]);
                    //var boundaryId = EncryptionDecryption.DH_PEncode(Convert.ToString(StaffInfo.BoundaryId));
                    StaffInfo.ReportingId = EncryptionDecryption.DH_PEncodeInt((int)obj1["loadInfo"]["ReportingId"]);
                    StaffInfo.Email = EncryptionDecryption.DH_PEncode((string)obj1["loadInfo"]["Email"]);
                    StaffInfo.Mobile = EncryptionDecryption.DH_PEncode((string)obj1["loadInfo"]["Mobile"]);
                    StaffInfo.Password = EncryptionDecryption.DH_PEncode((string)obj1["loadInfo"]["Password"]);// newStaff.Password;
                    StaffInfo.ConfirmPass = EncryptionDecryption.DH_PEncode((string)obj1["loadInfo"]["ConfirmPass"]);
                    StaffInfo.SignPath = PhysicalPhPath;
                    StaffInfo.SignPin = EncryptionDecryption.DH_PEncode((string)obj1["loadInfo"]["SignPin"]);
                    _newStaffService.Add(StaffInfo);
                    _newStaffService.Save();
                    ////EncryptionDecryption.DH_PEncode(StaffInfo.StaffId, StaffInfo.StaffName, StaffInfo.LoginName,
                    // StaffInfo.BoundaryId, StaffInfo.ReportingId, StaffInfo.Email, StaffInfo.Mobile, StaffInfo.Password,
                    // StaffInfo.ConfirmPass);
                    transaction.Complete();
                   return Json("1", JsonRequestBehavior.AllowGet);
                   //return Json(LoadDropDown.LoadLastStaff(newStaff.StaffId), JsonRequestBehavior.AllowGet);
                   }
                }
                catch (Exception)
                {
                    //transaction.Dispose();
                    return Json("0", JsonRequestBehavior.AllowGet);
                }            
        }
    }
}