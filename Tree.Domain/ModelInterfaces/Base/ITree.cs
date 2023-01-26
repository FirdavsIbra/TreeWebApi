namespace Tree.Domain.ModelInterfaces.Base
{
    public interface ITree
    {
        /// <summary>
        /// Gets id of tree.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets id of sort tree.
        /// </summary>
        public long TreeSortId { get; }

        /// <summary>
        /// Gets id of tree type.
        /// </summary>
        public long TreeTypeId { get; }

        /// <summary>
        /// Gets or sets id of plot.
        /// </summary>
        public long PlotId { get; set; }
    }
}
