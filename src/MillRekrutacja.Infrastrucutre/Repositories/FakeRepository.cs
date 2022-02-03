using MillRekrutacja.Core.Models;
using MillRekrutacja.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillRekrutacja.Infrastrucutre.Repositories
{
    public class FakeRepository : IFakeRepository
    {
        private static readonly List<FakeModel> database = new List<FakeModel>();

        public async Task AddFakeModel(FakeModel fake)
        {
            database.Add(fake);            
        }

        public async Task DeleteFakeModelById(string id)
        {
            int index = database.FindIndex(f => f.Id == id);

            if (index < 0)
            {
                throw new KeyNotFoundException();
            }
            database.RemoveAt(index);
        }

        public async Task<FakeModel> GetByUniqueValue(string value)
        {
            return database.FirstOrDefault(m => m.UniqueValue == value);
        }

        public async Task<FakeModel> GetFakeModelById(string id)
        {
            return database.FirstOrDefault(m => m.Id == id);
        }

        public async Task UpdateFakeModel(FakeModel fake)
        {
            int index = database.FindIndex(f => f.Id == fake.Id);
            
            if (index < 0)
            {
                throw new KeyNotFoundException();
            }
            database[index] = fake;
        }
    }
}
