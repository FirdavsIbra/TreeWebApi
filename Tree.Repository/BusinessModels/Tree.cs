using Tree.Domain.ModelInterfaces;
using Tree.Domain.ModelInterfaces.Base;

namespace Tree.Repository.BusinessModels
{
    internal sealed class Tree : ITree
    {
        /// <summary>
        /// Gets or sets id of tree.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets sort of tree.
        /// </summary>
        public long TreeSortId { get; internal set; }
        public ITreeSort TreeSort { get; internal set; }
        /// <summary>
        /// Gets or sets plot of tree.
        /// </summary>
        public long PlotId { get; set; }

    }
}
