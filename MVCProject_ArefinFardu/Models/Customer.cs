//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCProject_ArefinFardu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "You can't leave it blank...")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Enter minimum 2 or maximum 30 character")]
        [Display(Name = "Customer's Name", Description = "Name of the Customer's")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You can't leave it blank...")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "You can't leave it blank...")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You can't leave it blank...")]
        [Display(Name = "Email Adderss")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You can't leave it blank...")]
        [Display(Name = "Cell Phone No.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "You can only add upto 11 character")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White spaces not Allowed")]
        public string PhoneNO { get; set; }
    }
}