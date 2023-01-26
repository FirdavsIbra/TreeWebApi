using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly ITreeSortRepository _treeSortRepository;
        public TreeRepository(IMapper mapper, ITreeSortRepository treeSortRepository)
        {
            _mapper = mapper;
            _treeSortRepository = treeSortRepository;
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

            return await dbContext.Trees.ProjectTo<BusinessModels.Tree>(_mapper.ConfigurationProvider)
                                        .AsNoTracking()
                                        .ToArrayAsync();
        }

        /// <summary>
        /// Get tree by id.
        /// </summary>
        public async Task<ITree> GetByIdAsync(long id)
        {
            await using var dbContext = new AppDbContext();

            var tree = await dbContext.Trees.FirstOrDefaultAsync(x => x.Id == id);
      
            return _mapper.Map<BusinessModels.Tree>(tree);
        }

        /// <summary>
        /// Update tree.
        /// </summary>
        public async Task UpdateAsync(ITree tree)
        {
            await using var dbContext = new AppDbContext();

            var treeDb = await dbContext.Trees.FirstOrDefaultAsync(x => x.Id == tree.Id);

            if(treeDb is null)
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
            return 0;

            //return await trees.AverageAsync(t => t.HeightInMetre);
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
            return 0;
            //return await trees.MaxAsync(t => t.BeginingOfTheHarvestInY);
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
            return 0;
            //return await trees.SumAsync(t => t.Square);
        }
    }
}
