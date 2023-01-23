using Tree.Domain.Enums;
using Tree.Domain.ModelInterfaces.Base;

namespace Tree.Service.Models
{
    public sealed class Semerenko : ITree
    {
        /// <summary>
        /// Gets id of tree.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets sort of tree.
        /// </summary>
        public SortsOfTree Sort => SortsOfTree.Semerenko;

        /// <summary>
        /// Gets type of tree.
        /// </summary>
        public TypesOfTree Type => TypesOfTree.Apple;

        /// <summary>
        /// Gets height of tree in metre.
        /// </summary>
        public double HeightInMetre => 3.5D;

        /// <summary>
        /// Gets ocupying area of the tree;
        /// </summary>
        public double Square => 5.21D;

        /// <summary>
        /// Gets begining year of the harvest.
        /// </summary>
        public double BeginingOfTheHarvestInY => 5;

        /// <summary>
        /// Gets or sets count of tree.
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// Gets or sets id of plot.
        /// </summary>
        public long PlotId { get; set; }
    }
}
