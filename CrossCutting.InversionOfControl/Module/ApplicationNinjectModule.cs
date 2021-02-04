using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Common;
using Application.Services;
using Ninject.Modules;
using App.Domain.Interface.Service;
using App.Domain.Services;

namespace CrossCutting.InversionOfControl.Module
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Security Tables
            Bind<ISecUserInfoAppService>().To<SecUserInfoAppService>();
            Bind<ISecUserGroupAppService>().To<SecUserGroupAppService>();
            Bind<ISecUserInGroupAppService>().To<SecUserInGroupAppService>();
            Bind<ISecFormListAppService>().To<SecFormListAppService>();
            Bind<ISecProcessListAppService>().To<SecProcessListAppService>();
            Bind<ISecFormProcessAppService>().To<SecFormProcessAppService>();
            Bind<ISecFormRightAppService>().To<SecFormRightAppService>();
            //Security Tables
            Bind<ITransactionLogAppService>().To<TransactionLogAppService>();
             Bind<ICommonAppService>().To<CommonAppService>();
            Bind<IUserProfileAppService>().To<UserProfileAppService>();
            Bind<IRecPasswordAppService>().To<RecPasswordAppService>();
            Bind<IEmailConfigAppService>().To<EmailConfigAppService>();
            Bind<IEmployeeAppService>().To<EmployeeAppService>();
     
            Bind<IEmployeeFuncAppService>().To<EmployeeFuncAppService>();
          
            Bind<IFYDDAppService>().To<FYDDAppService>();
           
         
            Bind<ILanguagesAppService>().To<LanguagesAppService>();
         
            Bind<IFileTransMainAppService>().To<FileTransMainAppService>();
            Bind<IFileTransDetailAppService>().To<FileTransDetailAppService>();
            Bind<IActionListAppService>().To<ActionListAppService>();

            //for File Process
            Bind<IBoundaryAppService>().To<BoundaryAppService>();
            Bind<IReportingAppService>().To<ReportingAppService>();
            Bind<IStaffAppService>().To<StaffAppService>();
            Bind<IStaffDetailsAppService>().To<StaffDetailsAppService>();
            Bind<IFileMainAppService>().To<FileMainAppService>();
            Bind<IFileDetailAppService>().To<FileDetailAppService>();
            Bind<ICompanyInfoAppService>().To<CompanyInfoAppService>();
            Bind<IAFileMainAppService>().To<AFileMainAppService>();
            Bind<IAFileDetailAppService>().To<AFileDetailAppService>();
            Bind<IBranchAppService>().To<BranchAppService>();
            Bind<IUserBranchAppService>().To<UserBranchAppService>();
            Bind<IDynaCapAppService>().To<DynaCapAppService>();
            Bind<IFileProcessInfosAppService>().To<FileProcessInfosAppService>();
            //for Language
            Bind<IDictionaryAppService>().To<DictionaryAppService>();
            Bind<IPhrasesAppServices>().To<PhrasesAppService>();
            Bind<ISysSetAppService>().To<SysSetAppService>();
        }
    }
}
