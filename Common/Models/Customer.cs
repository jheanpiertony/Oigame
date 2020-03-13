using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    [Table("Customer")]
    public class Customer
    {
        public Customer()
        {
            Active = true;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Firstname"), MaxLength(length:100)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Lastname"), MaxLength(length: 100)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Passport"), MaxLength(length: 100)]
        public string Passport { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}
