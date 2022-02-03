using MillRekrutacja.Core.Models;
using System.Threading.Tasks;

namespace MillRekrutacja.Core.Services
{
    public interface IFakeService
    {
        Task AddFakeModel(FakeModel model);
        Task<FakeModel> GetFakeModelById(string id);
        Task UpdateFakeModel(FakeModel model);
        Task DeleteFakeModelById(string id);
    }
}
