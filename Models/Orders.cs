using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DROD.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public List<Orders> OrderLines { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(100)]
        [Display(Name = "Address Line")]
        public string AddressLine { get; set; }

        [Required(ErrorMessage = "Please enter your zip code (6 digits)")]
        [Display(Name = "Zip code")]
        [StringLength(6)]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "The zip code must contain 6 digits")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your phone number (10 digits)")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        [StringLength(10)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "The phone number must contain 10 digits")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        public double OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }
    }
}
