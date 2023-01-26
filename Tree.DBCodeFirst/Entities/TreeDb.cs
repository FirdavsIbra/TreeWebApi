namespace Tree.DBCodeFirst.Entities
{
    public sealed class TreeDb
    {
        /// <summary>
        /// Gets or sets id of tree.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets id of tree sort.
        /// </summary>
        public long TreeSortId { get; set; }
        public TreeSortDb TreeSort { get; set; }

        /// <summary>
        /// Gets or sets id of plot.
        /// </summary>
        public long PlotId { get; set; }
        public PlotDb Plot { get; set; }
    }
}
