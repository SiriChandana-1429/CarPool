using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace Interfaces
{
    public interface ICredentials
    {
        public Credentials ValidateCredentials(Credentials credentials);
        public void InsertCredentials(Credentials credentials);
        public List<Credentials> GetCredentials();
        public bool UpdateCredentials(Credentials credentials,int id);
        public bool DeleteCredentials(int id);
        public Credentials GetCredentialsById(int id);
    }
}
