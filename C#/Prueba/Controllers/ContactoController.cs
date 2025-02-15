﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.DAL;
using Prueba.Model;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ContactoController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Contacto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContacto()
        {
          if (_context.Contacto == null)
          {
              return NotFound();
          }
            return await _context.Contacto.ToListAsync();
        }

        // GET: api/Contacto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetContacto(string id)
        {
          if (_context.Contacto == null)
          {
              return NotFound();
          }
            var contacto = await _context.Contacto.FindAsync(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return contacto;
        }

        // PUT: api/Contacto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContacto(string id, Contacto contacto)
        {
            if (id != contacto.Id)
            {
                return BadRequest();
            }

            _context.Entry(contacto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoExists(id))
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

        // POST: api/Contacto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContacto(Contacto contacto)
        {
          if (_context.Contacto == null)
          {
              return Problem("Entity set 'ApplicationDBContext.Contacto'  is null.");
          }
            _context.Contacto.Add(contacto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactoExists(contacto.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContacto", new { id = contacto.Id }, contacto);
        }

        // DELETE: api/Contacto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContacto(string id)
        {
            if (_context.Contacto == null)
            {
                return NotFound();
            }
            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactoExists(string id)
        {
            return (_context.Contacto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
