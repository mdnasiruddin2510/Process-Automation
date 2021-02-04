using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ViewModel
{
    public class ApprovalProcessVM
    {
        public int ProcessNo { get; set; } 
        public string FileNo { get; set; } 
        public string RefNo { get; set; }      
        public string Subject { get; set; }
        public int Description { get; set; }
        public int Attachment { get; set; }
        public int Id { get; set; }
        public string Action { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime Time { get; set; }
        public string Note { get; set; }
        public string ActionBy { get; set; }
        public string MarkTo { get; set; }
        public string Purpose { get; set; }
        public string Attachments { get; set; }
        public bool EmailNotif { get; set; }
        public int ActID { get; set; }
            
       
        public bool Sms { get; set; }
    }
}
