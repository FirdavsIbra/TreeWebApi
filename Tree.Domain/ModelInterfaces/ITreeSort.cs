namespace Tree.Domain.ModelInterfaces
{
    public interface ITreeSort
    {
        /// <summary>
        /// Gets id of sort.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets name of sort.
        /// </summary>
        public string Name { get; }

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
        /// Gets id of tree type.
        /// </summary>
        public long TreeTypeId { get; }
    }
}
