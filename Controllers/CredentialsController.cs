using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
       
        public ICredentials credentialServices;

        public CredentialsController(ICredentials credentialServices)
        {
            
            this.credentialServices = credentialServices;

        }

        // GET: api/Credentials
        [HttpGet]
        public async Task<ActionResult<List<Credentials>>> GetCredentials()
        {
            return await credentialServices.GetCredentials();
        }

        // GET: api/Credentials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Credentials>> GetCredentials(int id)
        {
            return await credentialServices.GetCredentialsById(id);
        }

        [HttpPost("signup")]
        
        public void PostCredentials(Credentials credentials)
        {
            credentialServices.InsertCredentials(credentials);
        }



        // POST: api/Credentials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("login")]
        public async Task<ActionResult<Credentials>> ValidateCredentials(Credentials credentials)
        {
            return await credentialServices.ValidateCredentials(credentials);
        }

        
    }
}
