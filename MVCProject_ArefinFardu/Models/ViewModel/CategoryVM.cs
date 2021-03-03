using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace MVCProject_ArefinFardu.Models.ViewModel
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}