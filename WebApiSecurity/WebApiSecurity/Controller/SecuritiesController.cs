using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSecurity.Data;
using WebApiSecurity.Models;

namespace WebApiSecurity.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecuritiesController : ControllerBase
    {
        private readonly Context _context;

        public SecuritiesController(Context context)
        {
            _context = context;
        }

        // GET: api/Securities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Security>>> GetSecurityItems()
        {
            return await _context.SecurityItems.ToListAsync();
        }

        [AllowAnonymous]
        // GET: api/Securities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Security>> GetSecurity(int id)
        {
            var security = await _context.SecurityItems.FindAsync(id);

            if (security == null)
            {
                return NotFound();
            }

            return security;
        }

        // PUT: api/Securities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecurity(int id, Security security)
        {
            if (id != security.SecId)
            {
                return BadRequest();
            }

            _context.Entry(security).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecurityExists(id))
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

        // POST: api/Securities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Security>> PostSecurity(Security security)
        {
            _context.SecurityItems.Add(security);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecurity", new { id = security.SecId }, security);
        }

        [Authorize]
        // DELETE: api/Securities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Security>> DeleteSecurity(int id)
        {
            var security = await _context.SecurityItems.FindAsync(id);
            if (security == null)
            {
                return NotFound();
            }

            _context.SecurityItems.Remove(security);
            await _context.SaveChangesAsync();

            return security;
        }

        private bool SecurityExists(int id)
        {
            return _context.SecurityItems.Any(e => e.SecId == id);
        }
    }
}
