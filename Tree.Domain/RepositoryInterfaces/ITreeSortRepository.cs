using Tree.Domain.ModelInterfaces;

namespace Tree.Domain.RepositoryInterfaces
{
    public interface ITreeSortRepository
    {
        /// <summary>
        /// Get sort by id.
        /// </summary>
        public Task<ITreeSort> GetByIdAsync(long id);

        /// <summary>
        /// Add sort of tree.
        /// </summary>
        public Task AddAsync(ITreeSort sort);

        /// <summary>
        /// Delete sort by id.
        /// </summary>
        public Task DeleteAsync(long id);

        /// <summary>
        /// Update sort.
        /// </summary>
        public Task UpdateAsync(ITreeSort sort);

        /// <summary>
        /// Get all sorts of tree.
        /// </summary>
        public Task<ITreeSort[]> GetAllAsync();
    }
}
