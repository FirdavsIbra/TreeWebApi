using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Tree.DBCodeFirst.DbContexts;
using Tree.DBCodeFirst.Entities;
using Tree.Domain.ModelInterfaces;
using Tree.Domain.RepositoryInterfaces;
using Tree.Repository.BusinessModels;

namespace Tree.Repository.Repositories
{
    public sealed class TreeSortRepository : ITreeSortRepository
    {
        private readonly IMapper _mapper;
        public TreeSortRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Add sort of tree.
        /// </summary>
        public async Task AddAsync(ITreeSort sort)
        {
            await using var dbContext = new AppDbContext();
            await dbContext.TreeSorts.AddAsync(_mapper.Map<TreeSortDb>(sort));
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete sort of tree.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            await using var dbContext = new AppDbContext();
            var sort = await dbContext.TreeSorts.FirstOrDefaultAsync(x => x.Id == id);

            if (sort is not null)
            {
                dbContext.TreeSorts.Remove(sort);
                await dbContext.SaveChangesAsync();
            }

        }

        /// <summary>
        /// Get all sorts of tree.
        /// </summary>
        public async Task<ITreeSort[]> GetAllAsync()
        {
            await using var dbContext = new AppDbContext();

            return await dbContext.TreeSorts.ProjectTo<TreeSort>(_mapper.ConfigurationProvider).ToArrayAsync();
        }

        /// <summary>
        /// Get sort by id.
        /// </summary>
        public async Task<ITreeSort> GetByIdAsync(long id)
        {
            await using var dbContext = new AppDbContext();

            var tree = await dbContext.TreeSorts.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<TreeSort>(tree);
        }

        /// <summary>
        /// Update sort of tree.
        /// </summary>
        public async Task UpdateAsync(ITreeSort sort)
        {
            await using var dbContext = new AppDbContext();

            var sortDb = await dbContext.TreeSorts.FirstOrDefaultAsync(x => x.Id == sort.Id);

            if (sortDb is null)
                throw new Exception("Tree sort not found!");

            dbContext.TreeSorts.Update(_mapper.Map(sort, sortDb));

            await dbContext.SaveChangesAsync();
        }
    }
}
