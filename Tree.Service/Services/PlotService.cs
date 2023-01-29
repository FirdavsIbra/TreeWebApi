using Tree.Domain.ModelInterfaces;
using Tree.Domain.RepositoryInterfaces;
using Tree.Domain.ServiceInterfaces;
using Tree.Service.DTOs;

namespace Tree.Service.Services
{
    public sealed class PlotService : IPlotService
    {
        private readonly IPlotRepository _plotRepository;
        public PlotService(IPlotRepository plotRepository)
        {
            _plotRepository = plotRepository;
        }

        /// <summary>
        /// Add plot.
        /// </summary>
        public async Task AddAsync(double capacity)
        {
            var plot = new PlotDto()
            {
                Capacity = capacity
            };
            await _plotRepository.AddAsync(plot);
        }

        /// <summary>
        /// Delete plot.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var plot = await _plotRepository.GetByIdAsync(id);
            if (plot == null)
                throw new Exception("Plot not found!");

            await _plotRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Get all plots.
        /// </summary>
        public async Task<IPlot[]> GetAllAsync()
        {
            return await _plotRepository.GetAllAsync();
        }

        /// <summary>
        /// Update plot.
        /// </summary>
        public async Task UpdateAsync(IPlot plotDto)
        {
            var plot = await _plotRepository.GetByIdAsync(plotDto.Id);
            if (plot == null)
                throw new Exception("Plot not found!");

            await _plotRepository.UpdateAsync(plotDto);
        }

        /// <summary>
        /// Get plot by id.
        /// </summary>
        public async Task<IPlot> GetByIdAsync(long id)
        {
            var plot = await _plotRepository.GetByIdAsync(id);
            if (plot is null)
                throw new Exception("Plot not found!");

            return plot;
        }
    }
}
