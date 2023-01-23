using Tree.Domain.Enums;
using Tree.Domain.ModelInterfaces.Base;

namespace Tree.Domain.RepositoryInterfaces
{
    public interface ITreeRepository
    {
        /// <summary>
        /// Get tree by id.
        /// </summary>
        public Task<ITree> GetByIdAsync(long id);

        /// <summary>
        /// Add tree.
        /// </summary>
        public Task AddAsync(ITree tree);

        /// <summary>
        /// Delete tree by id.
        /// </summary>
        public Task DeleteAsync(long id);

        /// <summary>
        /// Update tree.
        /// </summary>
        public Task UpdateAsync(long id, ITree tree);

        /// <summary>
        /// Get all trees.
        /// </summary>
        public Task<ITree[]> GetAllAsync();

        /// <summary>
        /// Get tree by sort.
        /// </summary>
        public Task<ITree> GetBySortAsync(SortsOfTree sort);

        /// <summary>
        /// Get average height of tree.
        /// </summary>
        public Task<double> GetAverageHeightAsync(long plotId);

        /// <summary>
        /// Get maximum year of the harvest.
        /// </summary>
        public Task<double> GetMaximumYearOfTheHarvestAsync(long plotId);

        /// <summary>
        /// Get total occupying area of the tree.
        /// </summary>
        public Task<double> GetTotalOccupyingAreaAsync(long plotId);
    }
}
