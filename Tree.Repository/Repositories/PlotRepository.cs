using AutoMapper;
using Tree.DBCodeFirst.DbContexts;
using Tree.DBCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Tree.Domain.ModelInterfaces;
using Tree.Domain.ModelInterfaces.Base;
using Tree.Domain.RepositoryInterfaces;
using Tree.Repository.BusinessModels;

namespace Tree.Repository.Repositories
{
    public sealed class PlotRepository : IPlotRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public PlotRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Add plot.
        /// </summary>
        public async Task AddAsync(IPlot plot)
        {
            await _dbContext.Plots.AddAsync(_mapper.Map<PlotDb>(plot));
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete plot.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var plot = await _dbContext.Plots.FirstOrDefaultAsync(x => x.Id == id);

            if (plot is not null)
            {
                _dbContext.Plots.Remove(plot);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all plots.
        /// </summary>
        public async Task<IPlot[]> GetAllAsync()
        {
            return await _dbContext.Plots.Select(g => _mapper.Map<Plot>(g)).ToArrayAsync();
        }

        /// <summary>
        /// Get plot by id.
        /// </summary>
        public async Task<IPlot> GetByIdAsync(long id)
        {
            var plot = await _dbContext.Plots.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<Plot>(plot);
        }

        /// <summary>
        /// Update plot.
        /// </summary>
        public async Task UpdateAsync(IPlot plot)
        {
            _dbContext.Plots.Update(_mapper.Map<PlotDb>(plot));

            await _dbContext.SaveChangesAsync();
        }

    }
}
