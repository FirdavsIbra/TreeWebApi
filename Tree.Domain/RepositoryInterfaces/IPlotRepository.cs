using Tree.Domain.ModelInterfaces;

namespace Tree.Domain.RepositoryInterfaces
{
    public interface IPlotRepository
    {
        /// <summary>
        /// Get plot by id.
        /// </summary>
        public Task<IPlot> GetByIdAsync(long id);

        /// <summary>
        /// Add plot.
        /// </summary>
        public Task AddAsync(IPlot tree);

        /// <summary>
        /// Delete plot by id.
        /// </summary>
        public Task DeleteAsync(long id);

        /// <summary>
        /// Update plot.
        /// </summary>
        public Task UpdateAsync(long id, IPlot tree);

        /// <summary>
        /// Get all plots.
        /// </summary>
        public Task<IPlot[]> GetAllAsync();
    }
}
