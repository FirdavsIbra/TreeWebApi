using Tree.Domain.ModelInterfaces;
using Tree.Domain.ModelInterfaces.Base;

namespace Tree.Service.DTOs
{
    public sealed class TreeDto : ITree
    {
        /// <summary>
        /// Gets or sets id of tree.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets id of tree sort.
        /// </summary>
        public long TreeSortId { get; set; }
        public ITreeSort TreeSort { get; set; }

        /// <summary>
        /// Gets or sets id of plot.
        /// </summary>
        public long PlotId { get; set; }

    }
}
