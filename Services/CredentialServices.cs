using DatabaseContext;
using Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    
    public class CredentialServices:ControllerBase, ICredentials
    {
        private readonly MyDbContext _context;

        public CredentialServices(MyDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Credentials>> ValidateCredentials(Credentials credentials)
        {
            var check = _context.Credentials.Where(i => i.Email.Equals(credentials.Email) && (i.Password.Equals(credentials.Password)));
            if (!check.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(credentials);
            }
        }
        public async void InsertCredentials(Credentials credentials)
        {
            _context.Credentials.Add(credentials);
            await _context.SaveChangesAsync();
            //return CreatedAtAction(nameof(GetCredentialsById), new { id = credentials.Id }, credentials);
        }
        public async Task<ActionResult<List<Credentials>>> GetCredentials()
        {
            return await _context.Credentials.ToListAsync();
        }
        public async Task<ActionResult> UpdateCredentials(Credentials credentials,int id)
        {
            if (id != credentials.Id)
            {
                return BadRequest();
            }
            _context.Entry(credentials).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CredentialsExists(id))
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
        public async Task<ActionResult> DeleteCredentials(int id)
        {
            if (_context.Credentials == null)
            {
                return NotFound();

            }
            var check = await _context.Credentials.FindAsync(id);
            if (check == null)
            {
                return NotFound();
            }
            _context.Credentials.Remove(check);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        private bool CredentialsExists(int id)
        {
            return (_context.Credentials?.Any(e => e.Id == id)).GetValueOrDefault();
        
        }
        public async Task<ActionResult<Credentials>> GetCredentialsById(int id)
        {
            if (_context.Credentials == null)
            {
                return NotFound();
            }
            var check = await _context.Credentials.FindAsync(id);
            if (check == null)
            {
                return NotFound();
            }
            else
            {
                return check;
            }
        }
    }
}
