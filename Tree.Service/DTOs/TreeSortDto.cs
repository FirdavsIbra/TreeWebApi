using Tree.Domain.ModelInterfaces;

namespace Tree.Service.DTOs
{
    public sealed class TreeSortDto : ITreeSort
    {
        /// <summary>
        /// Gets or sets id of tree sort.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets name of tree sort.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets height of tree sort.
        /// </summary>
        public double HeightInMetre { get; set; }

        /// <summary>
        /// Gets or sets square of tree sort.
        /// </summary>
        public double Square { get; set; }

        /// <summary>
        /// Gets or sets begining of the harvest in year of tree sort.
        /// </summary>
        public double BeginingOfTheHarvestInY { get; set; }

        /// <summary>
        /// Gets or sets id of tree type.
        /// </summary>
        public long TreeTypeId { get; set; }
    }
}
