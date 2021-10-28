using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly DB_ilookContext _context;

        public EFCoreRepository(DB_ilookContext context)
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

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<Users[]> GetAllUsers()
        {
            IQueryable<Users> query = _context.Users
                .Include(u => u.Ends);

            query = query.AsNoTracking().OrderBy(u => u.IdUsers);

            return await query.ToArrayAsync();
        }

        public async Task<Users> GetUserById(int id)
        {
            IQueryable<Users> query = _context.Users
                .Include(u => u.Ends);

            query = query.AsNoTracking().OrderBy(u => u.IdUsers);

            return await query.FirstOrDefaultAsync(u => u.IdUsers == id);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Users[]> GetUserByName(string name)
        {
            IQueryable<Users> query = _context.Users
                .Include(u => u.Ends);

            query = query.AsNoTracking()
                         .Where(u => u.NameUsers.Contains(name))
                         .OrderBy(u => u.IdUsers);

            return await query.ToArrayAsync();
        }
    }
}



