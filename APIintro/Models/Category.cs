using System;
using System.ComponentModel.DataAnnotations;

namespace APIintro.Models
{
	public class Category : BaseEntity
	{
		[Required(ErrorMessage="Bos buraxma")]
		public string Name { get; set; }
	}
}

