using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirplaneRegister.WebAPI.Models;


namespace AirplaneRegister.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AirplaneRegisterController : ControllerBase
    {
        private readonly AirplaneRegisterContext _context;

        public AirplaneRegisterController(AirplaneRegisterContext context)
        {
            _context = context;
        }

        // GET: api/AirplaneRegister
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.AirplaneRegister>>> GetAirplaneRegisters()
        {
            return await _context.AirplaneRegisters.ToListAsync();
        }

        // GET: api/AirplaneRegister/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.AirplaneRegister>> GetAirplaneRegister(int id)
        {
            var airplaneRegister = await _context.AirplaneRegisters.FindAsync(id);

            if (airplaneRegister == null)
            {
                return NotFound();
            }

            return airplaneRegister;
        }

        // PUT: api/AirplaneRegister/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplaneRegister(int id, Models.AirplaneRegister airplaneRegister)
        {
            if (id != airplaneRegister.Id)
            {
                return BadRequest();
            }

            airplaneRegister.Created = DateTime.Now;
            _context.Entry(airplaneRegister).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneRegisterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AirplaneRegister
        [HttpPost]
        public async Task<ActionResult<Models.AirplaneRegister>> PostAirplaneRegister(Models.AirplaneRegister airplaneRegister)
        {
            airplaneRegister.Created = DateTime.Now;
            _context.AirplaneRegisters.Add(airplaneRegister);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirplaneRegister", new { id = airplaneRegister.Id }, airplaneRegister);
        }

        // DELETE: api/AirplaneRegister/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.AirplaneRegister>> DeleteAirplaneRegister(int id)
        {
            var airplaneRegister = await _context.AirplaneRegisters.FindAsync(id);
            if (airplaneRegister == null)
            {
                return NotFound();
            }

            _context.AirplaneRegisters.Remove(airplaneRegister);
            await _context.SaveChangesAsync();

            return airplaneRegister;
        }

        private bool AirplaneRegisterExists(int id)
        {
            return _context.AirplaneRegisters.Any(e => e.Id == id);
        }
    }
}
