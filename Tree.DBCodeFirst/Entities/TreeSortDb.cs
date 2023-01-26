namespace Tree.DBCodeFirst.Entities
{
    public class TreeSortDb
    {
        /// <summary>
        /// Gets or sets id of sort.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets name of sort.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets height of tree in metre.
        /// </summary>
        public double HeightInMetre { get; set; }

        /// <summary>
        /// Gets or sets ocupying area of the tree.
        /// </summary>
        public double Square { get; set; }

        /// <summary>
        /// Gets or sets begining year of the harvest.
        /// </summary>
        public double BeginingOfTheHarvestInY { get; set; }

        /// <summary>
        /// Gets or sets id of tree type.
        /// </summary>
        public long TreeTypeId { get; set; }
        public TreeTypeDb TreeType { get; set; }
    }
}
