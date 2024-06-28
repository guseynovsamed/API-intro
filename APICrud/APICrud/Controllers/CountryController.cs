using System;
using APICrud.Data;
using APICrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICrud.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CountryController : ControllerBase
	{
		private readonly AppDbContext _context;

		public CountryController(AppDbContext context)
		{
			_context = context;
		}


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var datas = _context.Countries.Include(m => m.Cities).ToListAsync();
			return Ok(datas);
		}


		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Country country)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			await _context.Countries.AddAsync(country);

			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(Create), country);
		}


		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery] int? id)
		{
			if (id is null) return BadRequest();

			var existData = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

			if (existData is null) return NotFound();

			_context.Countries.Remove(existData);

			await _context.SaveChangesAsync();

			return Ok();
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Country country)
		{
			var existData = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

			if (existData is null) return NotFound();

			existData.Name = country.Name;

			await _context.SaveChangesAsync();

			return Ok();
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
            var existData = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

            if (existData is null) return NotFound();

            return Ok(existData);
        }
    }
}

