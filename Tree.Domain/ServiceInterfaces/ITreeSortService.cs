using Tree.Domain.ModelInterfaces;

namespace Tree.Domain.ServiceInterfaces
{
    public interface ITreeSortService
    {
        /// <summary>
        /// Gets all sorts.
        /// </summary>
        public Task<ITreeSort[]> GetAllAsync();

        /// <summary>
        /// Add sort.
        /// </summary>
        public Task AddAsync(ITreeSort sort);

        /// <summary>
        /// Delete sort.
        /// </summary>
        public Task DeleteAsync(long id);

        /// <summary>
        /// Update sort.
        /// </summary>
        public Task UpdateAsync(ITreeSort sort);

        /// <summary>
        /// Get sort by id.
        /// </summary>
        public Task<ITreeSort> GetByIdAsync(long id);
    }
}
