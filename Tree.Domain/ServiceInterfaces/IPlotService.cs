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
        public Task AddAsync(double capacity);

        /// <summary>
        /// Delete plot.
        /// </summary>
        public Task DeleteAsync(long id);

        /// <summary>
        /// Update plot.
        /// </summary>
        public Task UpdateAsync(IPlot plot);

        /// <summary>
        /// Get plot by id.
        /// </summary>
        public Task<IPlot> GetByIdAsync(long id);
    }
}
