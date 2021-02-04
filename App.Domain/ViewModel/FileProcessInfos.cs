using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ViewModel
{
   public class FileProcessInfos 
    {
       public int Id { get; set; } 
        public int FileNo { get; set; }
        public string FileRef { get; set; }
        public string FileSub { get; set; }
        public string FileText { get; set; } 
        public DateTime CreateDate { get; set; }
        public string CAttachments { get; set; }
        public string MAttachments { get; set; }
        public string Note { get; set; } 
        public string UpdateUser { get; set; }
        public string LoginUser { get; set; }
        
       
    }
}
