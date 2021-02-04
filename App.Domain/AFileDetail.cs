using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
   public class AFileDetail  
    {
       [Key]
        public int FileDetailID { get; set; }
        public int FileNo { get; set; }
        public string AttachFileName { get; set; }
        public string FileType { get; set; }
        public Int64 Size { get; set; }
        public string FileSourcePath { get; set; }
    }
}
