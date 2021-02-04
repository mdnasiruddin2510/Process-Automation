using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context.Config;
using App.Domain;
using App.Domain.ViewModel;


namespace Data.Context
{
    public class ERPConfigurationContext : BaseDbContext
    {        
        #region  Constructor
       

        static ERPConfigurationContext()
        {
            //System.Data.Entity.Database.SetInitializer(new ContextInitializer());
        }

        public ERPConfigurationContext()
            : base("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.Configuration.LazyLoadingEnabled = false;
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Configurations.Add(new GenreMap());
            //modelBuilder.Configurations.Add(new ArtistMap());
            //modelBuilder.Configurations.Add(new AlbumMap());
            //modelBuilder.Configurations.Add(new CartMap());
            //modelBuilder.Configurations.Add(new OrderMap());
            //modelBuilder.Configurations.Add(new OrderDetailMap());

        }
        #endregion
        #region DbSet

        //Security Tables
        public DbSet<SecUserInfo> SecUserInfo { get; set; }
        public DbSet<SecUserGroup> SecUserGroup { get; set; }
        public DbSet<SecUserInGroup> SecUserInGroup { get; set; }
        public DbSet<SecFormList> SecFormList { get; set; }
        public DbSet<SecProcessList> SecProcessList { get; set; }
        public DbSet<SecFormProcess> SecFormProcess { get; set; }
        public DbSet<SecFormRight> SecFormRight { get; set; }
        //Security Tables

        public virtual DbSet<TransactionLog> TransactionLog { set; get; }
        public virtual DbSet<Employee> Employee { set; get; }
        public virtual DbSet<RecPassword> RecPasswords { set; get; }
        public virtual DbSet<EmailConfig> EmailConfig { set; get; }
        public DbSet<FYDD> FYDD { set; get; }
      
        

      
       

        public DbSet<EmployeeFunc> EmployeeFunc { set; get; }
        public DbSet<Branch> Branch { get; set; }    
        public DbSet<GetwayProvider> GetwayProvider { get; set; }
        public DbSet<DynaCap> DynaCap { get; set; }   
        public DbSet<Languages> Languages { get; set; }
        public DbSet<SysSet> SysSet { get; set; }  
        public DbSet<CompanyInfo> CompanyInfo { get; set; } 
        public DbSet<FileTransDetail> FileTransDetail { get; set; }
        public DbSet<FileTransMain> FileTransMain { get; set; }
        public DbSet<ActionList> ActionList { get; set; }
        public DbSet<Department> Department { get; set; }  
        //for file process
        public DbSet<Boundary> Boundary { get; set; }
        public DbSet<ReportingTo> ReportingTo { get; set; }
        public DbSet<StaffInfo> StaffInfo { get; set; }
        public DbSet<StaffDetails> StaffDetails { get; set; }
        public DbSet<FileMain> FileMain { get; set; }
        public DbSet<FileDetail> FileDetail { get; set; }
        public DbSet<UserBranch> UserBranch { get; set; }
        public DbSet<AFileMain> AFileMain { get; set; } 
        public DbSet<AFileDetail> AFileDetail { get; set; } 
        //for Languagr
      
        public DbSet<Dictionary> Dictionary { get; set; }
        public DbSet<Phrases> Phrases { get; set; }
        public DbSet<PhrasePage> PhrasePage { get; set; }
        public DbSet<PageList> PageList { get; set; } 
        #endregion
    }
}
