using Tree.Domain.ModelInterfaces;

namespace Tree.Service.DTOs
{
    public sealed class TreeCalculation : ITreeCalculation
    {
        /// <summary>
        /// Get year when tree give fruits.
        /// </summary>
        public double Year { get; set; }

        /// <summary>
        /// Get total area that takes tree.
        /// </summary>
        public double TotalArea { get; set; }

        /// <summary>
        /// Get maximum height of the tree.
        /// </summary>
        public double MaxHeight { get; set; }
    }
}
