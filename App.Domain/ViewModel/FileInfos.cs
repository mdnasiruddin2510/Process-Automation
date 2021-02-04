using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ViewModel
{
   public class FileInfos
    {
      // public int Id { get; set; } 
        public string FileNo { get; set; }
        public string FileRef { get; set; }
        public string FileSub { get; set; }
        public string CreateDate { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string UpdateUser { get; set; }
        public string UpdateName { get; set; } 
        public string LoginUser { get; set; }
        public int approved { get; set; }
        public int UserId { get; set; }
        public string MainID { get; set; }
    }
}
