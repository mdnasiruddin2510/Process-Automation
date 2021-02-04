using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class PhrasePage
    {
        [Key]
        public int PhraseId { get; set; }
        public int PageId { get; set; }
    }
}
