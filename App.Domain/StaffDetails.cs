using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
  public class StaffDetails
  {
      [Key]
        public int StaffDetId { get; set; }
        public int StaffId { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
