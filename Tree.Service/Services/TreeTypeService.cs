using Tree.Domain.ModelInterfaces;
using Tree.Domain.RepositoryInterfaces;
using Tree.Domain.ServiceInterfaces;
using Tree.Service.DTOs;

namespace Tree.Service.Services
{
    public sealed class TreeTypeService : ITreeTypeService
    {
        private readonly ITreeTypeRepository _treeTypeRepository;
        public TreeTypeService(ITreeTypeRepository treeTypeRepository)
        {
            _treeTypeRepository = treeTypeRepository;
        }
        public async Task AddAsync(string name)
        {
            ITreeType treeType = new TreeTypeDto()
            {
                Name = name,
            };
            
            await _treeTypeRepository.AddAsync(treeType);
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ITreeType[]> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ITreeType> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ITreeType type)
        {
            throw new NotImplementedException();
        }
    }
}
