using App.Domain;
using App.Domain.ViewModel;
using Application.Interfaces;
using Data.Context;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using App.Domain.Interface.Service;
namespace ProcessAutomation.Models
{
    public static class LoadDropDown
    {
        static ERPConfigurationContext db = new ERPConfigurationContext();
          
        public static SelectList LoadAllSecUserGroups(ISecUserGroupAppService _secUserGroupService)
        {
            var items = _secUserGroupService.All().ToList()
                .Select(x => new { x.GroupID, x.GroupName }).ToList();
            items.Insert(0, new { GroupID = 0, GroupName = "---- Select ----" });
            return new SelectList(items, "GroupID", "GroupName");
        }
 
       
        public static SelectList LoadBoundary(IBoundaryAppService _boundaryService)
        {
            var items = _boundaryService.All().ToList()
                .Select(x => new { x.Id, x.BoundaryName }).ToList();
            //items.Insert(0, new { Id = "", BoundaryName = "---- Select ----" });
            return new SelectList(items.OrderBy(x => x.BoundaryName), "Id", "BoundaryName");
        }
        public static SelectList LoadReportingTo(IStaffAppService _newStaffService)
        {
            var items = _newStaffService.All().ToList()
                .Select(x => new { x.StaffId, x.StaffName }).ToList();
            //items.Insert(0, new { Id = "", BoundaryName = "---- Select ----" });
            return new SelectList(items.OrderBy(x => x.StaffName), "StaffId", "StaffName");
        }
        public static SelectList LoadActionList(IActionListAppService _actionListService) 
        {
            var items = _actionListService.All().ToList()
                .Select(x => new { x.ActID, x.ActDesc }).ToList();
            //items.Insert(0, new { Id = "", BoundaryName = "---- Select ----" });
            return new SelectList(items.OrderBy(x => x.ActDesc), "ActID", "ActDesc");
        }
      

       
      
    

     

     


        public static SelectList LoaduserBranchType()
        {
            var item = (from uc in db.SecUserInfo
                        select new { UserID = uc.UserID, UserName = uc.UserName }).ToList();
            return new SelectList(item.OrderBy(x => x.UserID).ToList(), "UserID", "UserName");
        }
        public static SelectList LoadLanguage()
        {
            var item = (from uc in db.Languages
                        select new { LangId = uc.LangId, LangName = uc.LangName }).ToList();
            return new SelectList(item.OrderBy(x => x.LangId).ToList(), "LangId", "LangName");
        }
        
     

     
    

       
        
    
       
        public static SelectList LoadAllFinYears(IFYDDAppService _fYDDService)
        {
            var items = _fYDDService.All().ToList()
                .Select(x => new { x.Id, x.FinYear }).OrderByDescending(x => x.Id).ToList();
            //items.Insert(0, new { ID = 0, FinYear = "---- Select ----" });
            return new SelectList(items, "FinYear", "FinYear");
        }


        public static SelectList LoadAllActions(IActionListAppService _actionListService)
        {
            var items = _actionListService.All().ToList()
                .Select(x => new { x.ActID, x.ActDesc }).ToList();
            items.Insert(0, new { ActID = 0, ActDesc = "---- Select ----" });
            return new SelectList(items, "ActID", "ActDesc");
        }

        public static SelectList LoadPrepApprvBy() 
        {  
            var item = (from uc in db.Employee
                        select new { Id = uc.Id, UserName = uc.UserName }).ToList();
            return new SelectList(item.OrderBy(x => x.Id).ToList(), "Id", "UserName");
        }
        //public static SelectList LoadPrepApprvBy(IEmployeeAppService _employeeService, string form, string functionName)
        //{
        //    string logName = HttpContext.Current.Session["UserName"].ToString();
        //    string sql = string.Format("EXEC LoadPrepApprvBy '" + logName + "', '" + form + "', '" + functionName + "'");
        //    var items = _employeeService.SqlQueary(sql)
        //        .Select(x => new { x.Id, x.UserName }).ToList();
        //    return new SelectList(items.OrderBy(x => x.UserName), "Id", "UserName");
        //}
        public static SelectList LoadEmpDlList()
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("", "---- Select ----");
            return new SelectList(items, "Key", "Value");
        }

        //public static Branch GetBranch()
        //{
        //    return db.Branch.FirstOrDefault();
        //}
        internal static dynamic LoadAllLocation()
        {
            throw new NotImplementedException();
        }

        public static SelectList LoadandSaveBoundary(string nJobNo) 
        {
            Boundary job = new Boundary();
            job.BoundaryName = nJobNo;
            //job.IsActive = true;
            db.Boundary.Add(job);
            db.SaveChanges();

            var item = (from uc in db.Boundary
                        //where uc. == true
                        select new { Id = uc.Id, BoundaryName = uc.BoundaryName }).ToList();
            return new SelectList(item.OrderByDescending(x => x.Id).ToList(), "BoundaryName", "BoundaryName");

        }
        public static SelectList LoadLastStaff(int staffId)
        {
            var item = (from uc in db.StaffInfo
                        //where uc. == true
                        select new { StaffId = uc.StaffId, StaffName = uc.StaffName }).ToList();
            return new SelectList(item.OrderByDescending(x => x.StaffId).ToList(), "StaffName", "StaffName");

        }
    }
}