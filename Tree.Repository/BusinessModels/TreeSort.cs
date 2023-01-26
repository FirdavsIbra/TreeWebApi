using Tree.Domain.ModelInterfaces;

namespace Tree.Repository.BusinessModels
{
    internal class TreeSort : ITreeSort
    {
        /// <summary>
        /// Gets or internal sets id of sort.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or internal sets name of sort.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets or internal sets height of tree in metre.
        /// </summary>
        public double HeightInMetre { get; internal set; }

        /// <summary>
        /// Gets or internal sets ocupying area of the tree.
        /// </summary>
        public double Square { get; internal set; }

        /// <summary>
        /// Gets or internal sets begining year of the harvest.
        /// </summary>
        public double BeginingOfTheHarvestInY { get; internal set; }

        /// <summary>
        /// Gets or internal sets id of tree type.
        /// </summary>
        public long TreeTypeId { get; internal set; }
    }
}
