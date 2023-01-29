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
        
        /// <summary>
        /// Add sort of tree.
        /// </summary>
        public async Task AddAsync(ITreeSort sort)
        {
            var type = await _treeTypeRepository.GetByIdAsync(sort.TreeTypeId);
            if (type is null)
                throw new Exception("Type not found!");

            await _treeSortRepository.AddAsync(sort);

        }

        /// <summary>
        /// Delete sort of tree by id.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            await _treeSortRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Get all sorts of tree.
        /// </summary>
        public async Task<ITreeSort[]> GetAllAsync()
        {
            return await _treeSortRepository.GetAllAsync();
        }

        /// <summary>
        /// Get sort of tree by id.
        /// </summary>
        public async Task<ITreeSort> GetByIdAsync(long id)
        {
            var treeSort = await _treeSortRepository.GetByIdAsync(id);
            if (treeSort is null)
                throw new Exception("Sort of tree not found!");

            return treeSort;
        }

        /// <summary>
        /// Update sort of tree.
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        public async Task UpdateAsync(ITreeSort sort)
        {
            await _treeSortRepository.UpdateAsync(sort);
        }
    }
}
