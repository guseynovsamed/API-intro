using System;
using System.ComponentModel.DataAnnotations;

namespace APICrud.Models
{
    public class Country : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}

