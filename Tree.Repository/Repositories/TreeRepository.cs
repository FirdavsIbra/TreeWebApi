using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tree.DBCodeFirst.DbContexts;
using Tree.DBCodeFirst.Entities;
using Tree.Domain.Enums;
using Tree.Domain.ModelInterfaces.Base;
using Tree.Domain.RepositoryInterfaces;

namespace Tree.Repository.Repositories
{
    public sealed class TreeRepository : ITreeRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public TreeRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Add tree.
        /// </summary>
        public async Task AddAsync(ITree tree)
        {
            await _dbContext.Trees.AddAsync(_mapper.Map<TreeDb>(tree));
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete tree.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var tree = await _dbContext.Trees.FirstOrDefaultAsync(x => x.Id == id);

            if (tree is not null)
            {
                _dbContext.Trees.Remove(tree);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all trees.
        /// </summary>
        public async Task<ITree[]> GetAllAsync()
        {
            return await _dbContext.Trees.Select(g => _mapper.Map<BusinessModels.Tree>(g)).ToArrayAsync();
        }

        /// <summary>
        /// Get tree by id.
        /// </summary>
        public async Task<ITree> GetByIdAsync(long id)
        {
            var tree = await _dbContext.Trees.FirstOrDefaultAsync(x => x.Id == id);
      
            return _mapper.Map<BusinessModels.Tree>(tree);
        }

        /// <summary>
        /// Update tree.
        /// </summary>
        public async Task UpdateAsync(long id, ITree tree)
        {
            var treeDb = await _dbContext.Trees.FirstOrDefaultAsync(x => x.Id == id);

            if(treeDb is null)
                throw new Exception("Tree not found!");
            
            _dbContext.Trees.Update(_mapper.Map(tree, treeDb));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get tree by sort.
        /// </summary>
        public async Task<ITree> GetBySortAsync(SortsOfTree sort)
        {
            var sortOfTree = await _dbContext.Trees.FirstOrDefaultAsync(x => x.Sort == sort);

            return _mapper.Map<BusinessModels.Tree>(sortOfTree);
        }
    }
}
