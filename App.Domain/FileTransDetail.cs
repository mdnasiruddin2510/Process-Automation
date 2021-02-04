using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class FileTransDetail 
    {
        [Key]
        public int FileTransDetailID { get; set; }        
        public int FileTransID { get; set; }
        
         public string AttachFileName { get; set; }
         public string FileType { get; set; }
         public int Size { get; set; }
         public string FileSourcePath { get; set; }                     
    }
}


