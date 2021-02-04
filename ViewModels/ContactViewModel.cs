using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PosterShop.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        [MinLength(5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Too Long")]
        public string Message { get; set; }
    }
}
