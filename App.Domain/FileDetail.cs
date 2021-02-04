using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
   public class FileDetail
    {
        public int FileDetailID { get; set; }
       
        public string AttachFileName { get; set; }
        public string FileType { get; set; }
        public Int64 Size { get; set; }
        public string FileSourcePath { get; set; }
        public int MainID { get; set; } 
    }
}
