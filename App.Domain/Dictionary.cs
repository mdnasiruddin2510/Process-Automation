using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class Dictionary
    {
        [Key]
        public int DictId { get;set; }
        public int LangId { get; set; }
        public int PhraseId { get; set; }
        public string Phrase { get; set; }
    }
}
