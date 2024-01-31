using MongoDB.Driver;
using WebPokedex.Models;

namespace WebPokedex.Services
{
    public interface ILoginServices
    {
        Task<IEnumerable<LoginRequest>> GetAllAsync();
        Task<LoginRequest> GetByIdAsync(string id);
        Task CreateAsync(LoginRequest trainer);
        Task UpdateAsync(LoginRequest trainer);
        Task DeleteAsync(string id);

    }
}