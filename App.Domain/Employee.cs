using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Domain
{
    public class Employee
    {
        [Key]
        public int Id { set; get; }
        [DisplayName("Employee Name")]
        public string UserName { set; get; }
        public string Email { set; get; }
        public bool IsActive { set;get;}
        [NotMapped]
        //[StringLength(100, ErrorMessage = "Password must be at least 6 characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        public string Password { set; get; }

        [NotMapped]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { set;get;}


        [DisplayName("Garden")]
        public string BranchCode { set; get; }
        //[ForeignKey("BranchCode")]
        //public virtual Branch Branch { set; get; }


        //public virtual List<UserBranch> Branchs { set; get; } 
        public string FullName { set; get; }
        public string Designation{get; set;}
        public int UserRank { get; set; }
    }
}

