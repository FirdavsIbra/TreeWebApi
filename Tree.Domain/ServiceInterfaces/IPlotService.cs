using Tree.Domain.ModelInterfaces;

namespace Tree.Domain.ServiceInterfaces
{
    public interface IPlotService
    {
        /// <summary>
        /// Gets all plots.
        /// </summary>
        public Task<IPlot[]> GetAllAsync();

        /// <summary>
        /// Add plot.
        /// </summary>
        public Task AddAsync(IPlot plot);

        /// <summary>
        /// Delete plot.
        /// </summary>
        public Task DeleteAsync(long id);

        /// <summary>
        /// Update plot.
        /// </summary>
        public Task UpdateAsync(IPlot plot);
    }
}
