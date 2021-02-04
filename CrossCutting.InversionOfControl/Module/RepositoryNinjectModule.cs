using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Interface.Repository;
using App.Domain.Interface.Repository.Common;
using Data.Repository.EntityFramework;
using Data.Repository.EntityFramework.Common;
using Ninject.Modules;
using Application.Interfaces;
using Application.Services;
using App.Domain;
//using App.Domain.ViewModel;

namespace CrossCutting.InversionOfControl.Module
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            //Security Tables
            Bind<ISecUserInfoRepository>().To<SecUserInfoRepository>();
            Bind<ISecUserGroupRepository>().To<SecUserGroupRepository>();
            Bind<ISecUserInGroupRepository>().To<SecUserInGroupRepository>();
            Bind<ISecFormListRepository>().To<SecFormListRepository>();
            Bind<ISecProcessListRepository>().To<SecProcessListRepository>();
            Bind<ISecFormProcessRepository>().To<SecFormProcessRepository>();
            Bind<ISecFormRightRepository>().To<SecFormRightRepository>();
            //Security Tables

            Bind<ITransactionLogRepository>().To<TransactionLogRepository>();
            Bind<ICommonSearchRepo>().To<CommonSearchRepo>();
            Bind<IUserProfileRepository>().To<UserProfileRepository>();
            Bind<IRecPasswordRepository>().To<RecPasswordRepository>();
            Bind<IEmailConfigRepository>().To<EmailConfigRepository>();
            Bind<IEmployeeRepository>().To<EmployeeRepository>();                     
            Bind<IEmployeeFuncRepository>().To<EmployeeFuncRepository>();           
            Bind<IFYDDRepository>().To<FYDDRepository>();                     
          
            Bind<ILanguagesRepository>().To<LanguagesRepository>();        
            Bind<IFileTransMainRepository>().To<FileTransMainRepository>();
            Bind<IFileTransDetailRepository>().To<FileTransDetailRepository>();
            Bind<IActionListRepository>().To<ActionListRepository>();
            // for file process
            Bind<IBoundaryRepository>().To<BoundaryRepository>();
            Bind<IReportingRepository>().To<ReportingRepository>();
            Bind<IStaffRepository>().To<StaffRepository>();
            Bind<IStaffDetailsRepository>().To<StaffDetailsRepository>();
            Bind<IFileMainRepository>().To<FileMainRepository>();
            Bind<IFileDetailRepository>().To<FileDetailRepository>();
            Bind<IAFileMainRepository>().To<AFileMainRepository>();
            Bind<IAFileDetailRepository>().To<AFileDetailRepository>();
            Bind<IUserBranchRepository>().To<UserBranchRepository>();
            Bind<IBranchRepository>().To<BranchRepository>();
            Bind<IDynaCapRepository>().To<DynaCapRepository>();
            Bind<IFileProcessInfosRepository>().To<FileProcessInfosRepository>();
            //for Language

            Bind<IDictionaryRepository>().To<DictionaryRepository>();
            Bind<IPhrasesRepository>().To<PhrasesRepository>();
            Bind<ISysSetRepository>().To<SysSetRepository>();
        } 
    }
}
