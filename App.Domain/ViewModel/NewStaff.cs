using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ViewModel
{
  public class NewStaff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public int BoundaryId { get; set; }
        public int ReportingId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
      [Required(ErrorMessage="Password is Required")]
      [StringLength(255, ErrorMessage = "Please include at least 1 uppercase character, 1 lowercase character, and 1 number.", MinimumLength = 8)]
        public string Password { get; set; }
      [Required(ErrorMessage = "Confirmation Password is required.")]
      [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
      [StringLength(255, ErrorMessage = "Please include at least 1 uppercase character, 1 lowercase character, and 1 number.", MinimumLength = 8)]
        public string ConfirmPass { get; set; }
      public string SignPin { get; set; }
      public string SignPath { get; set; }     
    }
}
