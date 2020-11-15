using System;
using System.ComponentModel.DataAnnotations;

namespace AcmeCorporationMVC.Models
{
    public class SubmissionModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must enter a First Name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must enter a Last Name.")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You must enter an Email Address.")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Serial Number")]
        [Required(ErrorMessage = "You must enter a Serial Number.")]
        public Guid SerialNumber { get; set; }

        public bool IsOver18 => true;

        [Display(Name = "Are you over 18?")]
        [Compare(nameof(IsOver18), ErrorMessage = "You must be over 18 to enter the giveaway.")]
        [Required]
        public bool IsOldEnough { get; set; }
    }
}