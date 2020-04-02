using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CSVReaderAPI.Models.Data
{
    public class CSVReaderRepository : ICSVReaderRepository
    {
        private readonly DataContext _context;
        public CSVReaderRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> DeleteAll()
        {
            var contacts = await GetContacts();
            if (contacts.Count > 0)
            {
                _context.RemoveRange(contacts);
                return true;
            }
            return false;
        }

        public async Task<List<Contact>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}