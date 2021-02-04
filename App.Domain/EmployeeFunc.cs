using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class EmployeeFunc
    {
        [Key]
        public int EmpFuncID { set; get; }

        public string BrCode { set; get; }
        //[ForeignKey("BranchCode")]
        //public virtual Branch Branchs { set; get; }     
        public string FormName { set; get; }      
        public string FuncName { set; get; }
        //[Display(Name = "Emplopyee")]
        //public string EmpId { set; get; }
        ////[ForeignKey("EmpId")]
        //public virtual Employee Employees { set; get; }
        public int UserID { set; get; }
        public int FuncSl { set; get; }


       

    }
}
