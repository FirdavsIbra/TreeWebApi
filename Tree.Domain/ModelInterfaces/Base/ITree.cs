using Tree.Domain.Enums;

namespace Tree.Domain.ModelInterfaces.Base
{
    public interface ITree
    {
        /// <summary>
        /// Gets id of tree.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets sort of tree.
        /// </summary>
        public SortsOfTree Sort { get; }

        /// <summary>
        /// Gets type of tree.
        /// </summary>
        public TypesOfTree Type { get; }

        /// <summary>
        /// Gets height of tree in metre.
        /// </summary>
        public double HeightInMetre { get; }

        /// <summary>
        /// Gets ocupying area of the tree.
        /// </summary>
        public double Square { get; }

        /// <summary>
        /// Gets begining year of the harvest.
        /// </summary>
        public double BeginingOfTheHarvestInY { get; }

        /// <summary>
        /// Gets count of tree. 
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// Gets count of plot.
        /// </summary>
        public long PlotId { get; set; }
    }
}
