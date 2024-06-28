using System;
using System.ComponentModel.DataAnnotations;

namespace APIintro.Models
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}

