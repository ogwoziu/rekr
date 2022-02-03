using MillRekrutacja.Core.Exceptions;
using MillRekrutacja.Core.Models;
using MillRekrutacja.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace MillRekrutacja.Core.Services
{
    public class FakeService : IFakeService
    {
        private readonly IFakeRepository _fakeRepository;
        public FakeService(IFakeRepository fakeRepository)
        {
            _fakeRepository = fakeRepository;
        }

        public async Task AddFakeModel(FakeModel model)
        {
            ValideFakeModel(model);

            FakeModel result = await _fakeRepository.GetByUniqueValue(model.UniqueValue);
            if (result != null)
            {
                throw new FakeModelExistsException($"{nameof(FakeModel)} with {nameof(FakeModel.UniqueValue)} equal '{model.Value}' already exists");
            }
            await _fakeRepository.AddFakeModel(model);
        }

        public async Task<FakeModel> GetFakeModelById(string id)
        {
            if (String.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            FakeModel result = await _fakeRepository.GetFakeModelById(id);
            if (result == null)
            {
                throw new FakeModelNotFoundException($"{nameof(FakeModel)} with id equal {id} not found");
            }

            return result;
        }

        public Task UpdateFakeModel(FakeModel model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteFakeModelById(string id)
        {
            throw new NotImplementedException();
        }

        private void ValideFakeModel(FakeModel model)
        {
            if (model == null) throw new ArgumentNullException();
            if (model.UniqueValue == null) throw new ArgumentNullException(nameof(model.UniqueValue));
        }


    }
}
