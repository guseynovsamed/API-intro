using System;
using System.ComponentModel.DataAnnotations;

namespace APICrud.Models
{
    public class City : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public Country? Country { get; set; }
        public int CountryId { get; set; }
    }
}

