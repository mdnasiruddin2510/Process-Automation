using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Interface.Service;
using App.Domain.Interface.Service.Common;
using App.Domain.Services;
using App.Domain.Services.Common;
using Ninject.Modules;
using Application.Interfaces;
using Application.Services;

namespace CrossCutting.InversionOfControl.Module
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IService<>)).To(typeof(Service<>));
            //Security Tables
            Bind<ISecUserInfoService>().To<SecUserInfoService>();
            Bind<ISecUserGroupService>().To<SecUserGroupService>();
            Bind<ISecUserInGroupService>().To<SecUserInGroupService>();
            Bind<ISecFormListService>().To<SecFormListService>();
            Bind<ISecProcessListService>().To<SecProcessListService>();
            Bind<ISecFormProcessService>().To<SecFormProcessService>();
            Bind<ISecFormRightService>().To<SecFormRightService>();
            //Security Tables
            Bind<ITransactionLogService>().To<TransactionLogService>();
            Bind<ICommonSearchService>().To<CommonSearchService>();
            Bind<IUserProfileService>().To<UserProfileService>();
            Bind<IRecPasswordService>().To<RecPasswordService>();
            Bind<IEmailConfigService>().To<EmailConfigService>();
            Bind<IEmployeeService>().To<EmployeeService>();        
            Bind<IEmployeeFuncService>().To<EmployeeFuncService>();    
            Bind<IFYDDService>().To<FYDDService>();
          
                 
           
            Bind<ILanguagesService>().To<LanguagesService>();
          
            Bind<IFileTransMainService>().To<FileTransMainService>();
            Bind<IFileTransDetailService>().To<FileTransDetailService>();
            Bind<IActionListService>().To<ActionListService>();
            //for file process
            Bind<IBoundaryService>().To<BoundaryService>();
            Bind<IReportingService>().To<ReportingService>();
            Bind<IStaffService>().To<StaffService>();
            Bind<IStaffDetailsService>().To<StaffDetailsService>();
            Bind<IFileMainService>().To<FileMainService>();
            Bind<IFileDetailService>().To<FileDetailService>();
            Bind<IAFileMainService>().To<AFileMainService>();
            Bind<IAFileDetailService>().To<AFileDetailService>();
            Bind<ICompanyInfoService>().To<CompanyInfoService>();
            Bind<IDynaCapService>().To<DynaCapService>();
            Bind<IBranchService>().To<BranchService>();
            Bind<IUserBranchService>().To<UserBranchService>();
            Bind<IFileProcessInfosService>().To<FileProcessInfosService>();
            //for Language
            Bind<IDictionaryService>().To<DictionaryService>();
            Bind<IPhrasesServices>().To<PhrasesServices>();
            Bind<ISysSetService>().To<SysSetService>();
        }
    }
}
