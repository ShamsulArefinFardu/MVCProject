using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace MVCProject_ArefinFardu.Models.ViewModel
{
    public class SupplierVM
    {
        public int SupplierId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is Required")]
        [MinLength(2, ErrorMessage = "Must be 2 characher Long")]
        [StringLength(30, ErrorMessage = "Maximum 30 character Long")]
        public string Name { get; set; }
        public string Address { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Enter Valid Email Address")]
        public string Email { get; set; }
        public Nullable<int> PhoneNo { get; set; }
    }
}