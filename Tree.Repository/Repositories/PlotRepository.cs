using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tree.DBCodeFirst.DbContexts;
using Tree.DBCodeFirst.Entities;
using Tree.Domain.ModelInterfaces;
using Tree.Domain.RepositoryInterfaces;
using Tree.Repository.BusinessModels;

namespace Tree.Repository.Repositories
{
    public sealed class PlotRepository : IPlotRepository
    {
        private readonly IMapper _mapper;
        public PlotRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Add plot.
        /// </summary>
        public async Task AddAsync(IPlot plot)
        {
            await using var dbContext = new AppDbContext();
            await dbContext.Plots.AddAsync(_mapper.Map<PlotDb>(plot));
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete plot.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            await using var dbContext = new AppDbContext();

            var plot = await dbContext.Plots.FirstOrDefaultAsync(x => x.Id == id);

            if (plot is not null)
            {
                dbContext.Plots.Remove(plot);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all plots.
        /// </summary>
        public async Task<IPlot[]> GetAllAsync()
        {
            await using var dbContext = new AppDbContext();

            return await dbContext.Plots.Select(g => _mapper.Map<Plot>(g)).ToArrayAsync();
        }

        /// <summary>
        /// Get plot by id.
        /// </summary>
        public async Task<IPlot> GetByIdAsync(long id)
        {
            await using var dbContext = new AppDbContext();

            var plot = await dbContext.Plots.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<Plot>(plot);
        }

        /// <summary>
        /// Update plot.
        /// </summary>
        public async Task UpdateAsync(IPlot plot)
        {
            await using var dbContext = new AppDbContext();

            var plotDb = await dbContext.Plots.FirstOrDefaultAsync(x => x.Id == plot.Id);
            if (plotDb is null)
                throw new Exception("Plot not found!");

            dbContext.Plots.Update(_mapper.Map(plot, plotDb));

            await dbContext.SaveChangesAsync();
        }
    }
}
