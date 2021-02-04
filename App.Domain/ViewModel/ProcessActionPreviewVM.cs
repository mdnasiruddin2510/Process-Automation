using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ViewModel
{
   public class ProcessActionPreviewVM
    {
        public string RCaption { get; set; }
        public string RData { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public byte FilePart { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } 
    }
}
