namespace Tree.Domain.ModelInterfaces
{
    public interface IPlot
    {
        /// <summary>
        /// Gets id of plot.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets capacity of plot.
        /// </summary>
        public double Capacity { get; }
    }
}
