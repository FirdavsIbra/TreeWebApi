using Tree.Domain.ModelInterfaces;

namespace Tree.Service.DTOs
{
    public class PlotDto : IPlot
    {
        /// <summary>
        /// Gets or sets id of plot.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets capacity of plot.
        /// </summary>
        public double Capacity { get; set; }
    }
}
