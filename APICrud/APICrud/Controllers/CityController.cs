using System;
using System.Diagnostics.Metrics;
using APICrud.Data;
using APICrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
	{
		private readonly AppDbContext _context;

		public CityController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var datas = await _context.Cities.Include(m => m.Country).ToListAsync();

			return Ok(datas);
        }


		[HttpPost]
		public async Task<IActionResult> Create([FromBody] City city )
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			await _context.Cities.AddAsync(city);

			await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), city);
        }


		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery] int? id)
		{
			if (id is null) return BadRequest();

            var existData = await _context.Cities.FirstOrDefaultAsync(m => m.Id == id);

            if (existData is null) return NotFound();

            _context.Cities.Remove(existData);

            await _context.SaveChangesAsync();

            return Ok();
        }

		[HttpPut("{id}")]
		public async Task<IActionResult> Edit([FromRoute]int id , City city)
		{
            var existData = await _context.Cities.FirstOrDefaultAsync(m => m.Id == id);

            if (existData is null) return NotFound();

            existData.Name = city.Name;

            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var existData = await _context.Cities.FirstOrDefaultAsync(m => m.Id == id);

            if (existData is null) return NotFound();

            return Ok(existData);
        }
    }
}

