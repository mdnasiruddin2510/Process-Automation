using App.Domain;
using App.Domain.ViewModel;
using Application.Interfaces;
using Data.Context;
using ProcessAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace ProcessAutomation.Controllers
{
    public class HomeController : Controller
    {
        private IActionListAppService _actionListService;
        private readonly IFileTransMainAppService _fileTransMainService;
        private readonly IFileMainAppService _fileMainService;
        private readonly IFileDetailAppService _fileDetailService;
        private readonly IAFileMainAppService _afileMainService;
        private readonly IAFileDetailAppService _afileDetailService;
        private readonly IStaffAppService _newStaffService;
        private readonly IBoundaryAppService _boundaryService;
        private readonly IFileProcessInfosAppService _fileProcessInfoService; 
        public HomeController(IFileMainAppService _fileMainService, IFileDetailAppService _fileDetailService,
            IStaffAppService _newStaffService, IActionListAppService _actionListService, IBoundaryAppService _boundaryService, IFileTransMainAppService _fileTransMainService,
            IFileProcessInfosAppService _fileProcessInfoService, IAFileDetailAppService _afileDetailService, IAFileMainAppService _afileMainService) 
        {
            this._fileMainService = _fileMainService;
            this._fileDetailService = _fileDetailService;
            this._afileMainService = _afileMainService;
            this._afileDetailService = _afileDetailService;
            this._newStaffService = _newStaffService;
            this._actionListService = _actionListService;
            this._boundaryService = _boundaryService;
            this._fileTransMainService = _fileTransMainService;
            this._fileProcessInfoService = _fileProcessInfoService;
        }
        public ActionResult Index()
        {
           ViewBag.MarkTo = LoadDropDown.LoadReportingTo(_newStaffService);
            var ReportingName = _newStaffService.All().Where(x => x.StaffId == Convert.ToInt32(Session["UserID"])).Select(x => x.ReportingId).FirstOrDefault();
            //ViewBag.MarkTo = _newStaffService.All().Where(x => x.StaffId == ReportingName).Select(x => x.StaffName).FirstOrDefault();
           
            ViewBag.Action = LoadDropDown.LoadActionList(_actionListService);  
            ViewBag.Id = _newStaffService.All().Select(x => x.StaffId).LastOrDefault() + 1;
            ViewBag.BoundaryId = LoadDropDown.LoadBoundary(_boundaryService);
            ViewBag.ReportingId = LoadDropDown.LoadReportingTo(_newStaffService);
            //ViewBag.Items = GetAllItem();           
            return View();
        }
        public ActionResult GetAllItem()       
        {            
            //FileMainInfo.UserID = Convert.ToInt32(Session["UserID"].ToString());
            var uservalid = Convert.ToInt32(Session["UserID"].ToString());

            var FileInfo = _fileMainService.All().ToList().Where(x => x.UserID == uservalid || (x.UpdUserID == uservalid));

            var FileInfoAll = _fileMainService.All(); 
            //var FileTransNo = _fileMainService.All().Where(x => x.UserID == uservalid).Select(x => x.FileNo).FirstOrDefault();
            //var FileTransInfo = _fileTransMainService.All().Where(x => x.FileID == FileTransNo).Select(x=>x.MarkToID);
            if (uservalid != null) 
            {
                List<FileInfos> fInfos = new List<FileInfos>();
                //if (FileInfo!=null)
                //{
                     foreach (var item in FileInfo)
                {
                    FileInfos fInfo = new FileInfos();
                    fInfo.FileNo = item.FileNo;
                    fInfo.FileRef = item.FileRef;
                    fInfo.FileSub = item.FileSub;                    
                    var openuser = _fileMainService.All().Where(x => x.FileNo == item.FileNo).Select(x => x.UserID).FirstOrDefault();
                    var openuserstaff = _newStaffService.All().Where(x => x.StaffId == openuser).Select(x => x.StaffName).FirstOrDefault();
                    fInfo.UserName = openuserstaff;   

                    var openuserstaffid = _newStaffService.All().Where(x => x.StaffId == openuser).Select(x => x.StaffId).FirstOrDefault();
                    fInfo.UserId = openuserstaffid;   
                    
                    var updateUserId = _fileMainService.All().Where(x => x.FileNo == item.FileNo).Select(x => x.UpdUserID).FirstOrDefault();
                   // fInfo.UpdateName = _newStaffService.All().Where(x => x.StaffId == updateUserId).Select(x => x.StaffName).FirstOrDefault();
                   // var approvedCheck = _fileMainService.All().Where(x => x.FileNo == item.FileNo).Select(x => x.VersionNo).LastOrDefault();
                    //var Check = item.VersionNo;
                    var MainId = _fileMainService.All().Where(x => x.FileNo == item.FileNo).Select(x => x.MainID).FirstOrDefault();
                    var Checkid = _fileTransMainService.All().Where(x => x.MainID == MainId).Select(x => x.ActionID).LastOrDefault();
                    var Check = _actionListService.All().Where(x => x.ActID == Checkid).Select(x => x.ActDesc).FirstOrDefault();
                    fInfo.approved = _actionListService.All().Where(x => x.ActDesc ==Check).Select(x => x.ActID).LastOrDefault();
                    fInfo.Status = Convert.ToString(Check);
                    if (Check=="New") {
                        fInfo.Status = "New";
                    }                   
                    //DateTime CurrDate = DateTime.UtcNow;
                    //fInfo.days = (int)(CurrDate.Subtract((DateTime)fInfo.CreateDate)).Days;
                    fInfo.CreateDate = item.CreateDate.ToString("yyyy-MM-dd");
                    fInfo.UpdateUser = updateUserId.ToString();
                    fInfo.LoginUser =(Session["UserID"].ToString());
                    if (fInfo.UserId == Convert.ToInt64(fInfo.LoginUser) && fInfo.approved==2)
                    {
                        fInfo.Status = "Processing.....";
                    }
                    fInfos.Add(fInfo);
                  
                   
                }
                 
                     if ( uservalid==1002)
                     {
                          List<FileInfos> fInfosTr = new List<FileInfos>();               
                          foreach (var item in FileInfoAll)
                          {
                              FileInfos fInfoAll = new FileInfos();
                              fInfoAll.FileNo = item.FileNo;
                              fInfoAll.FileRef = item.FileRef;
                              fInfoAll.FileSub = item.FileSub;
                              var openuser = _fileMainService.All().Where(x => x.FileNo == item.FileNo).Select(x => x.UserID).FirstOrDefault();
                              var openuserstaff = _newStaffService.All().Where(x => x.StaffId == openuser).Select(x => x.StaffName).FirstOrDefault();
                              fInfoAll.UserName = openuserstaff;
                              fInfoAll.CreateDate = item.CreateDate.ToString("yyyy-MM-dd");
                              fInfoAll.Status = item.VersionNo;
                              var updateUserId = _fileMainService.All().Where(x => x.FileNo == item.FileNo).Select(x => x.UpdUserID).FirstOrDefault();
                              fInfoAll.UpdateName = _newStaffService.All().Where(x => x.StaffId == updateUserId).Select(x => x.StaffName).FirstOrDefault();
                              fInfosTr.Add(fInfoAll);

                              return Json(new { data = fInfoAll }, JsonRequestBehavior.AllowGet);
                          }

                        
                         
                     }
                     return Json(new { data = fInfos }, JsonRequestBehavior.AllowGet);
                    
            }
            else
            {
                return null;
            }
        }
        //public ActionResult FileProcessActionPdf(string sNo)
        //{
        //    var markToId = _fileMainService.All().Where(x => x.FileNo == sNo).Select(x => x.UpdUserID).LastOrDefault();
        //    var MainId = _fileMainService.All().Where(x => x.FileNo == sNo).Select(x => x.MainID).LastOrDefault();
        //    string sql = string.Format("Select td.FileNo, td.FileRef as Reference, td.FileSub as Subject, td.FileText as Description,tm.AttachFileName as FileName,nc.FileTransNum as Note from FileMain as td " +
        //                          " left join FileDetail as tm on td.MainID = tm.MainID " +
        //                          "left join FileTransMain as nc on nc.MainID = td.MainID " +
        //                           "where td.FileNo = '" + sNo + "' and td.UpdUserID='" + markToId + "'");
        //    List<ProcessActionPdfVM> VchrList;
        //    using (ERPConfigurationContext dbContext = new ERPConfigurationContext())
        //    {
        //        VchrList = dbContext.Database.SqlQuery<ProcessActionPdfVM>(sql).ToList();
        //    }

        //    return View("~/Views/Home/FileProcessActionPdf.cshtml", VchrList);

        //}
        public ActionResult FileProcessActionPdf(string sNo)
        {
            var MainId = _fileMainService.All().Where(x => x.FileNo == sNo).Select(x => x.MainID).LastOrDefault();
            string sql = string.Format("rptFileTrans '" + MainId + "'");
            IEnumerable<ProcessActionPreviewVM> VchrList;
             using (ERPConfigurationContext dbContext = new ERPConfigurationContext())
             {
                 VchrList = dbContext.Database.SqlQuery<ProcessActionPreviewVM>(sql).ToList();
             }
             return View("~/Views/Home/FileProcessActionPdf.cshtml", VchrList);
        }
        public ActionResult ClosetoArchive(string FileNo)
        {
            //RBACUser rUser = new RBACUser(Session["UserName"].ToString());
            //if (!rUser.HasPermission("NewFile_Delete"))
            //{
            //    return Json("D", JsonRequestBehavior.AllowGet);
            //}   
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var FileMainNo = _fileMainService.All().Where(x => x.FileNo == FileNo).FirstOrDefault();
                    if (FileMainNo != null)
                    {
                        //For filemain and afilemain by Anna               
                        var aFileMain = new AFileMain();
                        aFileMain.FileNo = FileMainNo.FileNo;
                        aFileMain.FileRef = FileMainNo.FileRef;
                        aFileMain.FileSub = FileMainNo.FileSub;
                        aFileMain.FileText = FileMainNo.FileText;
                        aFileMain.LastUpdDate = FileMainNo.LastUpdDate;
                        aFileMain.UpdUserID = Convert.ToInt32(FileMainNo.UpdUserID);
                        aFileMain.UserID = FileMainNo.UserID;
                        aFileMain.VersionNo = FileMainNo.VersionNo;
                        aFileMain.CreateDate = FileMainNo.CreateDate;
                        aFileMain.AttachNum = FileMainNo.AttachNum;
                        _afileMainService.Add(aFileMain);
                        _afileMainService.Save();


                        _fileMainService.Delete(FileMainNo);
                        _fileMainService.Save();
                    }
                    //var FileDetailNo = _fileDetailService.All().Where(x => x.MainID == FileNo).FirstOrDefault();
                    //if (FileDetailNo != null)
                    //{
                    //    var aFileDetail = new AFileDetail();
                    //    aFileDetail.AttachFileName = FileDetailNo.AttachFileName;
                    //    aFileDetail.FileNo = FileDetailNo.MainID;
                    //    aFileDetail.FileSourcePath = FileDetailNo.FileSourcePath;
                    //    aFileDetail.FileType = FileDetailNo.FileType;
                    //    aFileDetail.Size = FileDetailNo.Size;
                       
                    //    _afileDetailService.Add(aFileDetail);
                    //    _afileDetailService.Save();

                    //    _fileDetailService.Delete(FileDetailNo);
                    //    _fileDetailService.Save();
                    //    transaction.Complete();
                    //}
                    //else
                    //{
                    //    return Json("2", JsonRequestBehavior.AllowGet);
                    //}
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json("0", JsonRequestBehavior.AllowGet);
                }

            }
        }      
    }
}
