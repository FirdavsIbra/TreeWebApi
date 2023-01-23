using Tree.Domain.Enums;
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
        public Task AddTreeAsync(SortsOfTree sortsOfTree, long count, long plotId);
    }
}
