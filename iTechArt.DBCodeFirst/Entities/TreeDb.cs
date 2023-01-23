using Tree.Domain.Enums;

namespace iTechArt.DBCodeFirst.Entities
{
    public sealed class TreeDb
    {
        /// <summary>
        /// Gets or sets id of tree.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets sort of tree.
        /// </summary>
        public SortsOfTree Sort { get; set; }

        /// <summary>
        /// Gets or sets type of tree.
        /// </summary>
        public TypesOfTree Type { get; set; }

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
        /// Gets or sets count of tree.
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// Gets or sets id of plot.
        /// </summary>
        public long PlotId { get; set; }
        public PlotDb Plot { get; set; }
    }
}
