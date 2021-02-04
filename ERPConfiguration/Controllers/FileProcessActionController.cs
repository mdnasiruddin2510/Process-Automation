using App.Domain;
using App.Domain.ViewModel;
using Application.Interfaces;
using Data.Context;
using ERPConfiguration.Models;
using Newtonsoft.Json.Linq;
using ProcessAutomation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace ERPConfiguration.Controllers
{
    public class FileProcessActionController : Controller
    {
        private readonly IStaffAppService _newStaffService;
        private readonly IFileMainAppService _fileMainService;
        private readonly IFileDetailAppService _fileDetailService; 
        private readonly IFileTransMainAppService _fileTransMainService;
        private readonly IFileTransDetailAppService _fileTransDetailService;
        private readonly IActionListAppService _actionListService;
        public FileProcessActionController(IStaffAppService _newStaffService, IFileMainAppService _fileMainService, IFileTransMainAppService _fileTransMainService, IFileTransDetailAppService _fileTransDetailService, IFileDetailAppService _fileDetailService,IActionListAppService _actionListService)
        {
            
            this._newStaffService = _newStaffService;
            this._fileMainService = _fileMainService;
            this._fileDetailService = _fileDetailService;
            this._fileTransMainService = _fileTransMainService;
            this._fileTransDetailService = _fileTransDetailService;
            this._actionListService = _actionListService;
        }
        // GET: FileProcessAction
        public ActionResult FileProcessAction()
        {
            ViewBag.MarkTo = LoadDropDown.LoadReportingTo(_newStaffService);
           // ViewBag.MarkTo = _newStaffService.All().Where(x => x.StaffId == Convert.ToInt32(Session["UserID"])).Select(x => x.ReportingId).FirstOrDefault();
            ViewBag.Action = LoadDropDown.LoadEmpDlList();
            //FileMain data = TempData["mydata"] as FileMain;
            //return View(data);
            return View();            
        }  
        public ActionResult GetNewFileIdforMoveToProcess(string FileNo) 
        {
            //RBACUser rUser = new RBACUser(Session["UserName"].ToString());
            //if (!rUser.HasPermission("Group_Edit"))
            //{
            //    return Json("D", JsonRequestBehavior.AllowGet);
            //}

            try
            {
                FileMain FileMainAdd = new FileMain();
                var data = _fileMainService.All().ToList().FirstOrDefault(x => x.FileNo == FileNo);
                var MainID = _fileMainService.All().ToList().Where(x => x.FileNo == FileNo).Select(x => x.MainID).FirstOrDefault();
                string sql = string.Format(" Select fd.AttachFileName as FileName from FileDetail as fd where MainID= '" + MainID + "' " +
                " union select AttachFileName from FileTransDetail where FileTransID in " +
                "(select FileTransID from FileTransMain where MainID = '" + MainID + "')");
                List<ProcessActionVM> VchrList;
                using (ERPConfigurationContext dbContext = new ERPConfigurationContext())
                {
                    VchrList = dbContext.Database.SqlQuery<ProcessActionVM>(sql).ToList();
                }
               // ViewBag.Items = VchrList;              
                if (data != null)
                {
                    FileMainAdd = data;
                }

                return Json(new { FileMainAdd, VchrList}, JsonRequestBehavior.AllowGet);
             
            }
            catch (Exception)
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }
        }
       
        public ActionResult SaveFileProcessAction()
        {
            //foreach (HttpPostedFileBase f in Request.Files)
            //{ 
            //}
            HttpFileCollectionBase PhotoFile = Request.Files;
            var fMain = Request.Form["fMain"];         
            var obj1 = JObject.Parse(fMain);
            var fileBelongstoUser = _fileMainService.All().Where(x => x.FileNo == (string)obj1["fMain"]["FileID"]).Select(x => x.UserID).FirstOrDefault();                  
            try
            {
                using (var transaction = new TransactionScope())
                {
                                 
                    var fileNoCheck = _fileMainService.All().Where(x => x.FileNo == (string)obj1["fMain"]["FileID"]).FirstOrDefault();
                    //FileMain FileMainInfo = new FileMain();
                    if (fileNoCheck != null)
                    {
                        var VersionNo =EncryptionDecryption.DH_PEncode( _actionListService.All().Where(x => x.ActID == (int)obj1["fMain"]["Action"]).Select(x => x.ActDesc).LastOrDefault());
                        var UpdUserID = (int)obj1["fMain"]["MarkTo"];
                        if (UpdUserID == 0)
                        {
                            fileNoCheck.UpdUserID = EncryptionDecryption.DH_PEncodeInt(fileBelongstoUser); //Convert.ToInt32(Session["UserID"]);
                        }
                        else
                        {
                            fileNoCheck.UpdUserID = EncryptionDecryption.DH_PEncodeInt((int)obj1["fMain"]["MarkTo"]);    
                        }
                        fileNoCheck.VersionNo =EncryptionDecryption.DH_PEncode( VersionNo);
                        _fileMainService.Update(fileNoCheck);
                        _fileMainService.Save();
                    }
                    var user = Convert.ToInt32(Session["UserID"]);
                    FileTransMain FileTransMainInfo = new FileTransMain();
                    FileTransMainInfo.MainID =EncryptionDecryption.DH_PEncodeInt( _fileMainService.All().Where(x => x.FileNo == (string)obj1["fMain"]["FileID"]).Select(x => x.MainID).FirstOrDefault());                      
                    FileTransMainInfo.ActionNum =EncryptionDecryption.DH_PEncode( _actionListService.All().Where(x => x.ActID == (int)obj1["fMain"]["Action"]).Select(x => x.ActDesc).LastOrDefault());
                    //FileTransMainInfo.EntryDate = (DateTime)obj1["fMain"]["Date"];
                    FileTransMainInfo.MarkToID =EncryptionDecryption.DH_PEncodeInt( (int)obj1["fMain"]["MarkTo"]);
                    //FileTransMainInfo.MarkToID = _newStaffService.All().Where(x => x.StaffId ==user).Select(x => x.ReportingId).FirstOrDefault();
                    if (FileTransMainInfo.MarkToID == 0)
                    {

                        FileTransMainInfo.MarkToID = fileBelongstoUser;
                    }
                    FileTransMainInfo.EntryDate = DateTime.Now;
                    FileTransMainInfo.ActionID =EncryptionDecryption.DH_PEncodeInt( (int)obj1["fMain"]["Action"]);
                    FileTransMainInfo.AttachNum =EncryptionDecryption.DH_PEncode( Convert.ToString(PhotoFile.Count));
                   
                    
                    // var action = _fileTransMainService.All().Where(x => x.MainID ==(int)obj1["fMain"]["FileID"]).Select(x => x.ActionNum).LastOrDefault();
                    var FileTransNum = Convert.ToInt16(_fileTransMainService.All().Where(x => x.MainID == FileTransMainInfo.MainID).Select(x=>x.FileTransNum).LastOrDefault());

                    FileTransMainInfo.FileTransNum = EncryptionDecryption.DH_PEncode((FileTransNum + 1).ToString());
                   
                  

                   // FileTransMainInfo.FileTransID = 1;
                    FileTransMainInfo.ActionByID =EncryptionDecryption.DH_PEncodeInt( Convert.ToInt32(Session["UserID"].ToString()));
                    FileTransMainInfo.SignDate =DateTime.Now;
                    FileTransMainInfo.TransDate = DateTime.Now;
                    FileTransMainInfo.Note =EncryptionDecryption.DH_PEncode( (string)obj1["fMain"]["Note"]);
                    _fileTransMainService.Add(FileTransMainInfo);
                    _fileTransMainService.Save();
                    transaction.Complete();
                   
                }
            }
               
            catch (Exception ex)
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }
            var MainIdCheck = _fileMainService.All().Where(x => x.FileNo == (string)obj1["fMain"]["FileID"]).Select(x => x.MainID).LastOrDefault(); 
                string fileName = "";
                string NewPhotoID = "";
                //string ImgPrefix = "";
                string ext = "";
                string PhotoPath = "";
                string PhysicalPhPath = "";
                string DBPhotoPath = "";
                try
                {
                    if (PhotoFile != null)
                    {
                        for (int i = 0; i < PhotoFile.Count; i++)
                        {
                            string fileId = Guid.NewGuid().ToString().Replace("-", "");
                            HttpPostedFileBase file = PhotoFile[i];
                            fileName = Path.GetFileName(file.FileName);
                            //ImgPrefix = file.ContentType; //"Photo";//file.ContentType;// 
                            int fSize = file.ContentLength;
                            //var path = Path.Combine(Server.MapPath("~/Uploads/Photo/"), MemberCode, fileId);

                            ext = System.IO.Path.GetExtension(fileName);
                            if (ext.ToLower().Contains("txt") || ext.ToLower().Contains("gif") || ext.ToLower().Contains("jpg") || ext.ToLower().Contains("jpeg")
                                || ext.ToLower().Contains("png") || ext.ToLower().Contains(".xls") || ext.ToLower().Contains(".docx")
                                || ext.ToLower().Contains(".xlsx") || ext.ToLower().Contains(".pdf"))
                            {
                                NewPhotoID = fileId + ext;
                                PhotoPath = ConfigurationManager.AppSettings["PhotoPath"];
                                PhysicalPhPath = Path.Combine(Server.MapPath(PhotoPath), NewPhotoID);
                                //var path = Path.Combine(Server.MapPath("~/Images/Photo"), fileName);
                                file.SaveAs(PhysicalPhPath);
                                DBPhotoPath = PhotoPath + "\\" + NewPhotoID;
                            }
                            var FileTransMain = new FileTransDetail
                            {
                                AttachFileName = fileName,
                                FileType = ext,
                                Size = fSize,
                                FileSourcePath = PhysicalPhPath,
                                FileTransID = _fileTransMainService.All().Where(x => x.MainID == MainIdCheck).Select(x => x.FileTransID).LastOrDefault(),
                            };
                            _fileTransDetailService.Add(FileTransMain);
                            _fileTransDetailService.Save();
                        }
                    }
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json("0", JsonRequestBehavior.AllowGet);
                }              
        }
       // public JsonResult SendEmailToUser(int pMarkTo,int FileNo) 
       // {
       //    // var data = _fileTransMainService.All().Select(x => x.MarkToID == pMarkTo).FirstOrDefault();
       //     var receivermail = _newStaffService.All().Where(x => x.StaffId == pMarkTo).Select(x => x.Email);
       //     var senderId = _fileMainService.All().Where(x => x.FileNo == FileNo).Select(x => x.UserID).FirstOrDefault();
       //     var sendermail = _newStaffService.All().Where(x => x.StaffId == senderId).Select(x => x.Email);
       //     bool result = false;
       //    // result = SendEmail("data", "test subject", "<p>Hi Anna,</br> this mail is for check</p>");
       //     return Json(result, JsonRequestBehavior.AllowGet);
       // }
       //// public bool SendEmail(string toEmail, string subject, string emailBody)
        public bool SendEmail(int pMarkTo, string pFileNo)
        {
            try
            {
                var toEmail = _newStaffService.All().Where(x => x.StaffId == pMarkTo).Select(x => x.Email).FirstOrDefault();
                var senderPassword ="hello";
                var senderId = _fileMainService.All().Where(x => x.FileNo == pFileNo).Select(x => x.UserID).FirstOrDefault();
                var senderEmail = _newStaffService.All().Where(x => x.StaffId == senderId).Select(x => x.Email).FirstOrDefault();
                string subject = "test subject";
                string emailBody = "<p>Hi Anna,</br> this mail is for check</p>";

                // string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                //string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();
                using (SmtpClient client = new SmtpClient())
                {
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Timeout = 100000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                    client.Send(mailMessage);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public JsonResult GetSignPin(int ActId)
        {
            var LoginUser = (Session["UserID"].ToString());
            var LoginSign = _newStaffService.All().Where(x => x.StaffId.ToString() == LoginUser).Select(x => x.SignPin).First();
            return null;
        }
       
    }
}