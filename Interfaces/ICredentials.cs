using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace Interfaces
{
    public interface ICredentials
    {
        public Task<ActionResult<Credentials>> ValidateCredentials(Credentials credentials);
        public Task<ActionResult> InsertCredentials(Credentials credentials);
        public Task<ActionResult<List<Credentials>>> GetCredentials();
        public Task<ActionResult> UpdateCredentials(Credentials credentials,int id);
        public Task<ActionResult> DeleteCredentials(int id);
        public Task<ActionResult<Credentials>> GetCredentialsById(int id);
    }
}
