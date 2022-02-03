using MillRekrutacja.Core.Models;
using System.Threading.Tasks;

namespace MillRekrutacja.Core.Repositories
{
    public interface IFakeRepository
    {
        Task<FakeModel> GetByUniqueValue(string value);
        Task<FakeModel> GetFakeModelById(string id);
        Task AddFakeModel(FakeModel fake);
        Task UpdateFakeModel(FakeModel fake);
        Task DeleteFakeModelById(string id);
    }
}
