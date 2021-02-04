using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class ActionList
    {
        [Key]
        public int ActID { get; set; }
        public string ActDesc { get; set; }
    }
}
