using EFCore.Dominio;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();
        Task<Users[]> GetAllUsers();
        Task<Users> GetUserById(int id);
        Task<Users[]> GetUserByName(string name);

    }
}
