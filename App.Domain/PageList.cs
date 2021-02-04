using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class PageList
    {
        [Key]
        public int PageId { get; set; }
        public string PageName { get; set; }
    }
}
