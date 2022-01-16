using System.Threading.Tasks;

namespace TestTaskApi.Business.Services.Interfaces
{
    public interface IPersonManager
    {
        Task<string> GetAllAsync(string filter);
        Task<long> UpsertAsync(string input);
    }
}
