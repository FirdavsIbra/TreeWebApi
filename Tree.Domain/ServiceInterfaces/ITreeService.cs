using Tree.Domain.ModelInterfaces;
using Tree.Domain.ModelInterfaces.Base;

namespace Tree.Domain.ServiceInterfaces
{
    public interface ITreeService
    {
        /// <summary>
        /// Gets all trees.
        /// </summary>
        public Task<ITree[]> GetAllAsync();

        /// <summary>
        /// Add tree.
        /// </summary>
        public Task AddTreeAsync(long sortId, long count, long plotId);

        /// <summary>
        /// Get tree info.
        /// </summary>
        public Task<ITreeCalculation> GetTreeInfoAsync(long plotId);

        /// <summary>
        /// Delete tree.
        /// </summary>
        public Task DeleteAsync(long treeId, long plotId);

        /// <summary>
        /// Get tree by id.
        /// </summary>
        public Task<ITree> GetByIdAsync(long id);
    }
}
