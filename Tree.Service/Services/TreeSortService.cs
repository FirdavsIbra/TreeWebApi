using Tree.Domain.ModelInterfaces;
using Tree.Domain.RepositoryInterfaces;
using Tree.Domain.ServiceInterfaces;

namespace Tree.Service.Services
{
    public sealed class TreeSortService : ITreeSortService
    {
        private readonly ITreeSortRepository _treeSortRepository;
        private readonly ITreeTypeRepository _treeTypeRepository;
        public TreeSortService(ITreeSortRepository treeSortRepository, ITreeTypeRepository treeTypeRepository)
        {
            _treeSortRepository = treeSortRepository;
            _treeTypeRepository = treeTypeRepository;
        }

        public async Task AddAsync(ITreeSort sort)
        {
            var type = await _treeTypeRepository.GetByIdAsync(sort.TreeTypeId);
            if (type is null)
                throw new Exception("Type not found!");

            await _treeSortRepository.AddAsync(sort);

        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ITreeSort[]> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ITreeSort> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ITreeSort sort)
        {
            throw new NotImplementedException();
        }
    }
}
