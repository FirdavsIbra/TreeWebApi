using Tree.Domain.ModelInterfaces;

namespace Tree.Domain.ServiceInterfaces
{
    public interface ITreeTypeService
    {
        /// <summary>
        /// Gets all types.
        /// </summary>
        public Task<ITreeType[]> GetAllAsync();

        /// <summary>
        /// Add type.
        /// </summary>
        public Task AddAsync(string name);

        /// <summary>
        /// Delete type.
        /// </summary>
        public Task DeleteAsync(long id);

        /// <summary>
        /// Update type.
        /// </summary>
        public Task UpdateAsync(ITreeType type);

        /// <summary>
        /// Get type by id.
        /// </summary>
        public Task<ITreeType> GetByIdAsync(long id);
    }
}
