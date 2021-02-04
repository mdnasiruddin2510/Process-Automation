using App.Domain;
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
    public class BoundaryController : Controller
    {
        private readonly IBoundaryAppService _boundaryService;
        public BoundaryController(IBoundaryAppService _boundaryService)
        {
            this._boundaryService = _boundaryService;
        }
        public ActionResult Boundary()
        {
            ViewBag.Items = GetBoundaryInfo();
            return View();
        }
        public ActionResult SaveBoundary(Boundary boundaryInfo)
        {           
                try
                {
                    Boundary boundary = new Boundary();
                    boundary = boundaryInfo;
                    _boundaryService.Add(boundary);
                    _boundaryService.Save();
                  
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    

                    return Json("0", JsonRequestBehavior.AllowGet);
                }            
        }
        public ActionResult UpdateBoundary(Boundary boundaryInfo)
        {          
                try
                {
                         var boundary = _boundaryService.All().ToList().Where(x => x.Id == boundaryInfo.Id).FirstOrDefault();
                         if (boundary!=null)
                         {
                             boundary.BoundaryName = EncryptionDecryption.DH_PEncode(boundaryInfo.BoundaryName);
                         _boundaryService.Update(boundary);
                        _boundaryService.Save();                     
                         }
                        return Json("1", JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {                   
                    return Json("0", JsonRequestBehavior.AllowGet);
                }            
        }
        public List<Boundary> GetBoundaryInfo()
        {
            var BoundaryInfo = _boundaryService.All();

            List<Boundary> sInfos = new List<Boundary>();
            foreach (var item in BoundaryInfo)
            {
                Boundary sInfo = new Boundary();
                sInfo.BoundaryName = item.BoundaryName;
                sInfos.Add(sInfo);
            }
            return sInfos;
        }
        public ActionResult GetBoundaryByName(string boundary)
        {
            var boundaryInfo = _boundaryService.All().Where(x => x.BoundaryName == boundary).FirstOrDefault();
            return Json(boundaryInfo, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult LoadandSaveBoundary(string nJobNo) 
        //{
        //    return Json(LoadDropDown.LoadandSaveBoundary(nJobNo), JsonRequestBehavior.AllowGet);
        //}
    }
}