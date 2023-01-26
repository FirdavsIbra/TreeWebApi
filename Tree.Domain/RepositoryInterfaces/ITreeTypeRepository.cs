using Tree.Domain.ModelInterfaces;

namespace Tree.Domain.RepositoryInterfaces
{
    public interface ITreeTypeRepository
    {
        /// <summary>
        /// Get type by id.
        /// </summary>
        public Task<ITreeType> GetByIdAsync(long id);

        /// <summary>
        /// Add type of tree.
        /// </summary>
        public Task AddAsync(ITreeType type);

        /// <summary>
        /// Delete type by id.
        /// </summary>
        public Task DeleteAsync(long id);

        /// <summary>
        /// Update type.
        /// </summary>
        public Task UpdateAsync(ITreeType type);

        /// <summary>
        /// Get all types of tree.
        /// </summary>
        public Task<ITreeType[]> GetAllAsync();
    }
}
