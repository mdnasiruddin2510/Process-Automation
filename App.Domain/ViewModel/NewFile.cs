using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ViewModel
{
   public class NewFile
    {
        public string FileNo { get; set; }
        public string RefNo { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string AttachFile { get; set; }
    }
}
