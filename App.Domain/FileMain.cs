using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
   public class FileMain
    {
        [Key]
       public int MainID { get; set; } 
        public string FileNo { get; set; }
        public string FileRef { get; set; }
        public string FileSub { get; set; }
        public string FileText { get; set; }
        public byte AttachNum { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserID { get; set; }
        public DateTime LastUpdDate { get; set; }
        public Nullable <int> UpdUserID { get; set; }
        public string VersionNo { get; set; }
    }
}
