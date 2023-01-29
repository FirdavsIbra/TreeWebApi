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

        /// <summary>
        /// Add type of tree.
        /// </summary>
        public async Task AddAsync(string name)
        {
            ITreeType treeType = new TreeTypeDto()
            {
                Name = name,
            };

            await _treeTypeRepository.AddAsync(treeType);
        }

        /// <summary>
        /// Delete type of tree by id.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            await _treeTypeRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Get all types of tree.
        /// </summary>
        public async Task<ITreeType[]> GetAllAsync()
        {
            return await _treeTypeRepository.GetAllAsync();
        }

        /// <summary>
        /// Get type of tree by id.
        /// </summary>
        public async Task<ITreeType> GetByIdAsync(long id)
        {
            return await _treeTypeRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Update type of tree.
        /// </summary>
        public async Task UpdateAsync(ITreeType type)
        {
            await _treeTypeRepository.UpdateAsync(type);
        }
    }
}
