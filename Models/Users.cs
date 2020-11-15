using System;

namespace DROD.Models
{
    public enum UserType
    {
        Customer,
        Admin

    }

    public class Users
    {

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public int Id { get; set; }

        public String Email { get; set; }

        public String Genre { get; set; }

        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public UserType Type { get; set; }
    }
}
