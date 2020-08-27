using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListTest;
using ListTest.Models;

namespace ListTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly TestContext _context;

        public UserRolesController(TestContext context)
        {
            _context = context;
        }

        // GET: api/UserRoles
        [HttpGet]
        public IQueryable GetUserRoles()
        {
            IQueryable a = _context.UserRoles
                .Include(r => r.User)
                .Include(r => r.Role)
                .Select(x => new
                {
                    Name = x.User.Name,
                    Role = x.Role.Role
                 })
                ;
            return a;
            
        }

        // GET: api/UserRoles/5
        [HttpGet("{id}")]
        public ActionResult GetUserRoles(int id)
        {
            IQueryable a = _context.UserRoles
                .Include(r => r.User)
                .Include(r => r.Role)
                .Where(c => c.IdUser == id)
                .Select(x => new
                {
                    Name = x.User.Name,
                    Role = x.Role.Role
                })
                ;

            if (a == null)
            {
                return Ok(new List<string>());
            }

            return Ok(a);
        }

        // PUT: api/UserRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRoles(int id, UserRoles userRoles)
        {
            if (id != userRoles.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(userRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRolesExists(id))
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

        // POST: api/UserRoles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserRoles>> PostUserRoles(UserRoles userRoles)
        {
            _context.UserRoles.Add(userRoles);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserRolesExists(userRoles.IdUser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserRoles", new { id = userRoles.IdUser }, userRoles);
        }

        // DELETE: api/UserRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRoles>> DeleteUserRoles(int id)
        {
            var userRoles = await _context.UserRoles.FindAsync(id);
            if (userRoles == null)
            {
                return NotFound();
            }

            _context.UserRoles.Remove(userRoles);
            await _context.SaveChangesAsync();

            return userRoles;
        }

        private bool UserRolesExists(int id)
        {
            return _context.UserRoles.Any(e => e.IdUser == id);
        }
    }
}
