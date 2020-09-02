using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListTest;

namespace ListTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TestContext _context;

        public UsersController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IQueryable GetUsers()
        {
            IQueryable a = _context.Users
       /*       .Include(r => r.UserRoles)
              .Select(x => new
           {
               // Id = x.Id,
               Name = x.Name,
               Role = x.UserRoles.Select(s => s.Role.Role)
              })*/;
            return a;

            
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult GetUsers(int id)
        {
            var a = _context.Users
              .Include(r => r.UserRoles)
              .Where(c => c.Id == id)
              .Select(x => new
              {
                  // Id = x.Id,
                  Name = x.Name,
                  Role = x.UserRoles.Select(s => s.Role.Role)
              });
         
            if (a != null)
                return Ok(a);
            else
                return Ok(new List<string>());
         
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
