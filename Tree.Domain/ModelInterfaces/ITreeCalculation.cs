namespace Tree.Domain.ModelInterfaces
{
    public interface ITreeCalculation
    {
        /// <summary>
        /// Get year when tree give fruits.
        /// </summary>
        public double Year { get; }

        /// <summary>
        /// Get total area that takes tree.
        /// </summary>
        public double TotalArea { get; }

        /// <summary>
        /// Get maximum height of the tree.
        /// </summary>
        public double MaxHeight { get; }
    }
}
