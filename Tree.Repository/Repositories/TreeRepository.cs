using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Tree.DBCodeFirst.DbContexts;
using Tree.DBCodeFirst.Entities;
using Tree.Domain.ModelInterfaces.Base;
using Tree.Domain.RepositoryInterfaces;

namespace Tree.Repository.Repositories
{
    public sealed class TreeRepository : ITreeRepository
    {
        private readonly IMapper _mapper;
        public TreeRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Add tree.
        /// </summary>
        public async Task AddAsync(ITree tree)
        {
            await using var dbContext = new AppDbContext();
            await dbContext.Trees.AddAsync(_mapper.Map<TreeDb>(tree));
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Add pupil array.
        /// </summary>
        public async Task AddRangeAsync(IEnumerable<ITree> pupils)
        {
            await using var dbContext = new AppDbContext();

            await dbContext.Trees.AddRangeAsync(pupils.Select(_mapper.Map<TreeDb>));

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete tree.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            await using var dbContext = new AppDbContext();

            var tree = await dbContext.Trees.FirstOrDefaultAsync(x => x.Id == id);

            if (tree is not null)
            {
                dbContext.Trees.Remove(tree);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all trees.
        /// </summary>
        public async Task<ITree[]> GetAllAsync()
        {
            await using var dbContext = new AppDbContext();

            var cfg = ConfigureMapping();

            return await dbContext.Trees.Include(x => x.TreeSort).ProjectToType<BusinessModels.Tree>(cfg)
                                        .AsNoTracking()
                                        .ToArrayAsync();
        }

        /// <summary>
        /// Get tree by id.
        /// </summary>
        public async Task<ITree> GetByIdAsync(long id)
        {
            await using var dbContext = new AppDbContext();

            var cfg = ConfigureMapping();

            return await dbContext.Trees.Include(t => t.TreeSort)
                                            .ProjectToType<BusinessModels.Tree>(cfg)
                                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Update tree.
        /// </summary>
        public async Task UpdateAsync(ITree tree)
        {
            await using var dbContext = new AppDbContext();

            var treeDb = await dbContext.Trees.FirstOrDefaultAsync(x => x.Id == tree.Id);

            if (treeDb is null)
                throw new Exception("Tree not found!");

            dbContext.Trees.Update(_mapper.Map(tree, treeDb));

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get average height of tree.
        /// </summary>
        public async Task<double> GetAverageHeightAsync(long plotId)
        {
            await using var dbContext = new AppDbContext();

            var trees = dbContext.Trees.Where(t => t.PlotId == plotId);

            if (!trees.Any())
                return 0;

            return await trees.AverageAsync(t => t.TreeSort.HeightInMetre);
        }

        /// <summary>
        /// Get maximum year of the harvest.
        /// </summary>
        public async Task<double> GetMaximumYearOfTheHarvestAsync(long plotId)
        {
            await using var dbContext = new AppDbContext();

            var trees = dbContext.Trees.Where(t => t.PlotId == plotId);

            if (!trees.Any())
                return 0;

            return await trees.DefaultIfEmpty().MaxAsync(t => t.TreeSort.BeginingOfTheHarvestInY);
        }

        /// <summary>
        /// Get total occupying area of the tree.
        /// </summary>
        public async Task<double> GetTotalOccupyingAreaAsync(long plotId)
        {
            await using var dbContext = new AppDbContext();

            var trees = dbContext.Trees.Where(t => t.PlotId == plotId);

            if (!trees.Any())
                return 0;

            return await trees.SumAsync(t => t.TreeSort.Square);
        }

        private TypeAdapterConfig ConfigureMapping()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<ITree, TreeDb>()
                .Map(dest => dest.TreeSort.BeginingOfTheHarvestInY, src => src.TreeSort.BeginingOfTheHarvestInY)
                .Map(dest => dest.TreeSort.HeightInMetre, src => src.TreeSort.HeightInMetre)
                .Map(dest => dest.TreeSort.Square, src => src.TreeSort.Square);
            return config;
        }

    }
}
