using DatabaseContext;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    
    public class CredentialServices: ICredentials
    {
        private readonly MyDbContext _context;

        public CredentialServices(MyDbContext context)
        {
            _context = context;
        }
        public Credentials ValidateCredentials(Credentials credentials)
        {
            var check = _context.Credentials.Where(i => i.Email.Equals(credentials.Email) && (i.Password.Equals(credentials.Password)));
            if (!check.Any())
            {
                return null ;
            }
            else
            {
                return credentials;
            }
        }
        public void InsertCredentials(Credentials credentials)
        {
            _context.Credentials.Add(credentials);
            _context.SaveChanges();
            //return CreatedAtAction(nameof(GetCredentialsById), new { id = credentials.Id }, credentials);
        }
        public List<Credentials> GetCredentials()
        {
            return _context.Credentials.ToList();
        }
        public bool UpdateCredentials(Credentials credentials,int id)
        {
            if (id != credentials.Id)
            {
                return false;
            }
            _context.Entry(credentials).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CredentialsExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;

        }
        public bool DeleteCredentials(int id)
        {
            if (_context.Credentials == null)
            {
                return false;

            }
            var check = _context.Credentials.Find(id);
            if (check == null)
            {
                return false;
            }
            _context.Credentials.Remove(check);
            _context.SaveChangesAsync();
            return true;

        }
        private bool CredentialsExists(int id)
        {
            return (_context.Credentials?.Any(e => e.Id == id)).GetValueOrDefault();
        
        }
        public Credentials GetCredentialsById(int id)
        {
            if (_context.Credentials == null)
            {
                return null;
            }
            var check = _context.Credentials.Find(id);
            if (check == null)
            {
                return null;
            }
            else
            {
                return check;
            }
        }
    }
}
