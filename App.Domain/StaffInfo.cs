using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
   public class StaffInfo 
    {
       [Key]
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string LoginName { get; set; }
        public int BoundaryId { get; set; }
        public int ReportingId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string ConfirmPass { get; set; }
        public string SignPin { get; set; }
        public string SignPath { get; set; }       
    }
}
