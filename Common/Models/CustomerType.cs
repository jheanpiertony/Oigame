using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models
{
    [Table("CustomerType")]
    public class CustomerType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Description"), MaxLength(length: 100)]
        public string Description { get; set; }

        public List<Customer> Customers{ get; set; }
    }
}
