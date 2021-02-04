using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    [Table("SysSet")]
    public class SysSet
    {
        [Key]
        public int Id { set; get; }  
        public bool Lang { set; get; } 
       
    } 
}
