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
    public sealed class TreeTypeRepository : ITreeTypeRepository
    {
        private readonly IMapper _mapper;
        public TreeTypeRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Add sort of tree.
        /// </summary>
        public async Task AddAsync(ITreeType type)
        {
            await using var dbContext = new AppDbContext();
            await dbContext.TreeTypes.AddAsync(_mapper.Map<TreeTypeDb>(type));
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete type of tree.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            await using var dbContext = new AppDbContext();
            var type = await dbContext.TreeTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (type is not null)
            {
                dbContext.TreeTypes.Remove(type);
                await dbContext.SaveChangesAsync();
            }

        }

        /// <summary>
        /// Get all types of tree.
        /// </summary>
        public async Task<ITreeType[]> GetAllAsync()
        {
            await using var dbContext = new AppDbContext();

            return await dbContext.TreeTypes.ProjectTo<TreeType>(_mapper.ConfigurationProvider).ToArrayAsync();
        }

        /// <summary>
        /// Get type by id.
        /// </summary>
        public async Task<ITreeType> GetByIdAsync(long id)
        {
            await using var dbContext = new AppDbContext();

            var tree = await dbContext.TreeTypes.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<TreeType>(tree);
        }

        /// <summary>
        /// Update type of tree.
        /// </summary>
        public async Task UpdateAsync(ITreeType type)
        {
            await using var dbContext = new AppDbContext();

            var typeDb = await dbContext.TreeTypes.FirstOrDefaultAsync(x => x.Id == type.Id);

            if (typeDb is null)
                throw new Exception("Tree type not found!");

            dbContext.TreeTypes.Update(_mapper.Map(type, typeDb));

            await dbContext.SaveChangesAsync();
        }
    }
}
