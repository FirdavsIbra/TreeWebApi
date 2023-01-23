using Tree.Domain.ModelInterfaces;

namespace Tree.Repository.BusinessModels
{
    internal class Plot : IPlot
    {
        /// <summary>
        /// Gets or sets id of plot.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets capacity of plot.
        /// </summary>
        public double Capacity { get; internal set; }
    }
}
