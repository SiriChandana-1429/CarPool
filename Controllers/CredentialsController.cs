using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CredentialsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Credentials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Credentials>>> GetCredentials()
        {
            return await _context.Credentials.ToListAsync();
        }

        // GET: api/Credentials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Credentials>> GetCredentials(int id)
        {
            var credentials = await _context.Credentials.FindAsync(id);

            if (credentials == null)
            {
                return NotFound();
            }

            return credentials;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<Credentials>> PostCredentials(Credentials credentials)
        {
            _context.Credentials.Add(credentials);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCredentialsId", new { id = credentials.Id }, credentials);
        }



        // POST: api/Credentials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("login")]
        public async Task<ActionResult<Credentials>> ValidateCredentials(Credentials credentials)
        {
            var check=_context.Credentials.Where(i=>i.Email.Equals(credentials.Email) && (i.Password.Equals(credentials.Password)));
            if (!check.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(credentials);
            }
        }

        
    }
}
