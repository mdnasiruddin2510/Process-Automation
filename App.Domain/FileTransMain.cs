using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
   public  class FileTransMain  
    {
        [Key]
        public int FileTransID { get; set; }
      // public int FileID { get; set; } //fk
       public string FileTransNum { get; set; }     
       public int ActionID { get; set; }//fk
       public string ActionNum { get; set; }
       public string AttachNum { get; set; }
       public int ActionByID { get; set; }
       public Nullable <int> MarkToID { get; set; }
       public DateTime SignDate { get; set; }
       public DateTime TransDate { get; set; }
       public string EmailTo { get; set; }
       public string EmailSub { get; set; }

       public string Note { get; set; } 
       public string EmailBody { get; set; }
       public string SMSTo { get; set; } 
        public string SMSText { get; set; } 
        public DateTime EntryDate { get; set; }
        public int MainID { get; set; }

    } 
}




