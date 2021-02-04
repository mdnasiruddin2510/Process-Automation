using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Net.Mail;
using App.Domain.ViewModel;
using App.Domain;
using System.Transactions;
using Application.Interfaces;
using System.Configuration;
using Newtonsoft.Json.Linq;
using ProcessAutomation.Models;

namespace ProcessAutomation.Controllers 
{
    public class NewFileController : Controller
    {
        
        private readonly IFileMainAppService _fileMainService;
        private readonly IFileDetailAppService _fileDetailService;
        private IActionListAppService _actionListService;
        private readonly ISysSetAppService _sysSet;

        public NewFileController ( IFileMainAppService _fileMainService, ISysSetAppService _sysSet,
                                    IFileDetailAppService _fileDetailService, IActionListAppService _actionListService)
        {
           
            this._fileMainService = _fileMainService;
            this._fileDetailService = _fileDetailService;
           this._actionListService = _actionListService;
           this._sysSet = _sysSet;

        }
        // GET: NewFile

        public ActionResult NewFile()
        {
            ViewBag.ActID = LoadDropDown.LoadAllActions(_actionListService);
            ViewBag.Lang = _sysSet.All().Select(x => x.Lang).First();
            return View();
        }

        public ActionResult SaveNewFile()
        {
            HttpFileCollectionBase PhotoFile = Request.Files;
            var fMain = Request.Form["fMain"];
            var obj1 = JObject.Parse(fMain);
            var FileNo = (string)obj1["fMain"]["FileID"];
            try
            {              
                var fileNoCheck = _fileMainService.All().Where(x => x.FileNo.ToString() == FileNo).Select(x => x.FileNo).FirstOrDefault();

                if (fileNoCheck == null) 
                { 
                FileMain FileMainInfo = new FileMain();
                FileMainInfo.FileNo = (string)obj1["fMain"]["FileID"];
                FileMainInfo.FileSub = (string)obj1["fMain"]["FileSub"];
                FileMainInfo.FileRef = (string)obj1["fMain"]["FileRef"];
                FileMainInfo.FileText = (string)obj1["fMain"]["FileText"];
                FileMainInfo.AttachNum = Convert.ToByte(PhotoFile.Count);
                //FileMainInfo.FileID = 1;
                FileMainInfo.UserID = Convert.ToInt32(Session["UserID"].ToString());
                //FileMainInfo.VersionNo = _actionListService.All().Select(x=>x.ActDesc).FirstOrDefault();
                FileMainInfo.VersionNo="New";
                FileMainInfo.UpdUserID = Convert.ToInt32(Session["UserID"].ToString());
                FileMainInfo.CreateDate = DateTime.Now;
                FileMainInfo.LastUpdDate = DateTime.Now;
                _fileMainService.Add(FileMainInfo);
                _fileMainService.Save();              
                }
            }
            catch (Exception ex)
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }
                //else
                //{
                //     return Json("2", JsonRequestBehavior.AllowGet);
                //}
                string fileName = "";
                string NewPhotoID = "";
                string ImgPrefix = "";
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
                            ext = System.IO.Path.GetExtension(fileName);
                            ImgPrefix = FileNo; //"Photo";//file.ContentType;// 
                            int fSize = file.ContentLength;
                            //var path = Path.Combine(Server.MapPath("~/Uploads/Photo/"), MemberCode, fileId);


                            if (ext.ToLower().Contains("txt") || ext.ToLower().Contains("gif") || ext.ToLower().Contains("jpg") || ext.ToLower().Contains("jpeg")
                                || ext.ToLower().Contains("png") || ext.ToLower().Contains(".xls") || ext.ToLower().Contains(".docx")
                                || ext.ToLower().Contains(".xlsx") || ext.ToLower().Contains(".pdf"))
                            {
                                NewPhotoID = ImgPrefix + fileId + ext;
                                PhotoPath = ConfigurationManager.AppSettings["PhotoPath"];
                                PhysicalPhPath = Path.Combine(Server.MapPath(PhotoPath), NewPhotoID);
                                //var path = Path.Combine(Server.MapPath("~/Images/Photo"), fileName);
                                file.SaveAs(PhysicalPhPath);

                                DBPhotoPath = PhotoPath + "\\" + NewPhotoID;
                            }
                            var NewFile = new FileDetail
                            {
                                AttachFileName = fileName,
                                FileType = ext,
                                Size = fSize,
                                FileSourcePath = PhysicalPhPath,
                                //MainID = (int)obj1["fMain"]["MainID"],                              
                                MainID = _fileMainService.All().Where(x => x.FileNo == (string)obj1["fMain"]["FileID"]).Select(x => x.MainID).FirstOrDefault(),
                            };
                            _fileDetailService.Add(NewFile);
                            _fileDetailService.Save();
                        }

                    }
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json("0", JsonRequestBehavior.AllowGet);
                }                        
        }

        public ActionResult GetNewFileIdforEdit(string FileNo)
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
                    if (data != null)
                    {
                        FileMainAdd = data;
                    }                                  
                    return Json(FileMainAdd, JsonRequestBehavior.AllowGet);                 
            }
            catch (Exception)
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult UpdateFileMain()
        {
            HttpFileCollectionBase PhotoFile = Request.Files;
            var fMain = Request.Form["fMain"];
            var obj1 = JObject.Parse(fMain);
            var FileNo = (string)obj1["fMain"]["FileID"];
            var MainID = _fileMainService.All().Where(x => x.FileNo == FileNo).Select(x => x.MainID).FirstOrDefault();
            FileMain _FileMainInfo = new FileMain();
            _FileMainInfo = _fileMainService.All().ToList().FirstOrDefault(x => x.MainID == MainID);

            try
            {
                if (_FileMainInfo != null)
                {
                    string fileName = "";
                    string NewPhotoID = "";
                    string ImgPrefix = "";
                    string ext = "";
                    string PhotoPath = "";
                    string PhysicalPhPath = "";
                    string DBPhotoPath = "";
                    string[] fileList = null;
                    string filesToDelete = "";
                    if (PhotoFile != null)
                    {
                        if (PhotoFile.Count!=0)
                        {
                            var ExistFD = _fileDetailService.All().ToList().Where(x => x.MainID == MainID);
                            if (ExistFD != null)
                            {
                                foreach (var item in ExistFD)
                                {
                                    _fileDetailService.Delete(item);
                                }
                            }
                        }
                       
                        for (int i = 0; i < PhotoFile.Count; i++)
                        {
                            string fileId = Guid.NewGuid().ToString().Replace("-", "");
                            HttpPostedFileBase file = PhotoFile[i];
                            fileName = Path.GetFileName(file.FileName);
                            ext = System.IO.Path.GetExtension(fileName);
                            ImgPrefix = FileNo.ToString(); //"Photo";//file.ContentType;// 
                            int fSize = file.ContentLength;

                            if (ext.ToLower().Contains("txt") || ext.ToLower().Contains("gif") || ext.ToLower().Contains("jpg") || ext.ToLower().Contains("jpeg")
                                || ext.ToLower().Contains("png") || ext.ToLower().Contains(".xls") || ext.ToLower().Contains(".docx")
                                || ext.ToLower().Contains(".xlsx") || ext.ToLower().Contains(".pdf"))
                            {
                                NewPhotoID = ImgPrefix + fileId + ext;
                                PhotoPath = ConfigurationManager.AppSettings["PhotoPath"];
                                PhysicalPhPath = Path.Combine(Server.MapPath(PhotoPath), NewPhotoID);

                                filesToDelete = ImgPrefix + "*";   // Only delete files containing "membercode+photo" in their filenames
                                fileList = System.IO.Directory.GetFiles(Server.MapPath(PhotoPath), filesToDelete);
                                foreach (string files in fileList)
                                {
                                    System.IO.File.Delete(files);
                                }
                                file.SaveAs(PhysicalPhPath);

                                DBPhotoPath = PhotoPath + "\\" + NewPhotoID;
                            }

                            var NewFile = new FileDetail
                            {
                                AttachFileName = fileName,
                                FileType = ext,
                                Size = fSize,
                                FileSourcePath = PhysicalPhPath,
                                MainID = MainID,
                            };
                            _fileDetailService.Add(NewFile);
                            _fileDetailService.Save();
                        }

                    }

                    //FileMain FileMainInfo = new FileMain();
                    var FileMainUp = _fileMainService.All().Where(x => x.MainID == MainID).FirstOrDefault();
                    FileMainUp.FileNo = (string)obj1["fMain"]["FileID"];
                    FileMainUp.FileSub = (string)obj1["fMain"]["FileSub"];
                    FileMainUp.FileRef = (string)obj1["fMain"]["FileRef"];
                    FileMainUp.FileText = (string)obj1["fMain"]["FileText"];
                    FileMainUp.AttachNum = Convert.ToByte(PhotoFile.Count);
                   
                    //FileMainInfo.FileID = 1;
                    FileMainUp.UserID = Convert.ToInt32(Session["UserID"].ToString());
                    FileMainUp.VersionNo = _actionListService.All().Select(x => x.ActDesc).FirstOrDefault();
                    FileMainUp.UpdUserID = Convert.ToInt32(Session["UserID"].ToString());
                    FileMainUp.CreateDate = DateTime.Now;
                    FileMainUp.LastUpdDate = DateTime.Now;
                    _fileMainService.Update(FileMainUp);
                    _fileMainService.Save();
                }
                return Json("1", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult DeleteNewFile(string Id)
        {

            //RBACUser rUser = new RBACUser(Session["UserName"].ToString());
            //if (!rUser.HasPermission("NewFile_Delete"))
            //{
            //    return Json("D", JsonRequestBehavior.AllowGet);
            //}          
            try
            {
                using (var transaction = new TransactionScope())
                {
                    var IsExits = _fileMainService.All().Where(x => x.FileNo == Id).Select(x => x.MainID).FirstOrDefault();
                    var IsFileDetail = _fileDetailService.All().Where(x => x.MainID == IsExits).ToList();
                    // var ExistFD = _fileDetailService.All().ToList().Where(x => x.MainID == MainID);
                    if (IsFileDetail != null)
                    {
                        foreach (var item in IsFileDetail)
                        {
                            _fileDetailService.Delete(item);
                        }
                        _fileMainService.Save();
                      
                    }
                    var IsUserBr = _fileMainService.All().Where(x => x.FileNo == Id).FirstOrDefault();
                   
                    if (IsUserBr != null)
                    {
                        //For user branch table by Farhad
                        _fileMainService.Delete(IsUserBr);
                        _fileMainService.Save();
                        transaction.Complete();
                    }                
                    else
                    {
                        return Json("2", JsonRequestBehavior.AllowGet);
                    }
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }
            }
    }
} 
