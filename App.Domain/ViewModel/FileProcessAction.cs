using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ViewModel
{
   public class FileProcessAction
    {
        public string FileNo { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string Attachments { get; set; }
        public string AttachFile { get; set; }
        public string MarkTo { get; set; }
        public DateTime Date { get; set; }
        public bool EmailNoti { get; set; }
        public bool SMSNoti { get; set; }
        public string Action { get; set; }
    }
}
