using Tree.Domain.Enums;
using Tree.Domain.ModelInterfaces;
using Tree.Domain.ModelInterfaces.Base;
using Tree.Domain.RepositoryInterfaces;
using Tree.Domain.ServiceInterfaces;
using Tree.Service.DTOs;
using Tree.Service.Models;

namespace Tree.Service.Services
{
    public sealed class TreeService : ITreeService
    {
        private readonly IPlotRepository _plotRepository;
        private readonly ITreeRepository _treeRepository;
        public TreeService(ITreeRepository treeRepository, IPlotRepository plotRepository)
        {
            _treeRepository = treeRepository;
            _plotRepository = plotRepository;
        }

        /// <summary>
        /// Add tree.
        /// </summary>
        public async Task AddTreeAsync(SortsOfTree sortsOfTree, long count, long plotId)
        {
            var plot = await _plotRepository.GetByIdAsync(plotId);
            if (plot is null)
                throw new Exception("Plot not found!");

            var sort = await _treeRepository.GetBySortAsync(sortsOfTree);
            if (sort == null) 
            {
                var tree = TreeFactory(sortsOfTree);
                tree.Count = count;
                tree.PlotId = plotId;

                await _treeRepository.AddAsync(tree);
            }
            else
            {
                sort.Count += count;
                await _treeRepository.UpdateAsync(sort.Id, sort);
            }
        }

        /// <summary>
        /// Delete tree.
        /// </summary>
        public async Task DeleteAsync(long count, long plotId, SortsOfTree sort)
        {
            var plot = await _plotRepository.GetByIdAsync(plotId);
            if (plot == null)
                throw new Exception("Plot not found!");

            var tree = await _treeRepository.GetBySortAsync(sort);
            if (tree == null)
                throw new Exception("Sort not found!");

            if ((tree.Count -= count) < 0)
                throw new Exception("Too many count of trees to delete!");

            tree.Count -= count;

            await _treeRepository.UpdateAsync(tree.Id, tree);
        }

        /// <summary>
        /// Get all trees.
        /// </summary>
        public async Task<ITree[]> GetAllAsync()
        {
            return await _treeRepository.GetAllAsync();
        }

        /// <summary>
        /// Get tree info.
        /// </summary>
        public async Task<ITreeCalculation> GetTreeInfoAsync(long plotId)
        {
            var plot = await _plotRepository.GetByIdAsync(plotId);
            if (plot == null)
            {
                throw new Exception("Plot not found");
            }

            return new TreeCalculation
            {
                Year = await _treeRepository.GetMaximumYearOfTheHarvestAsync(plotId),
                MaxHeight = await _treeRepository.GetAverageHeightAsync(plotId),
                TotalArea = await _treeRepository.GetTotalOccupyingAreaAsync(plotId)
            };
        }

        private ITree TreeFactory(SortsOfTree sortOfTree)
        {
            return sortOfTree switch
            {
                SortsOfTree.Golden => new Golden(),
                SortsOfTree.PinkLady => new PinkLady(),
                SortsOfTree.Semerenko => new Semerenko(),
                SortsOfTree.GrannySmith => new GrannySmith(),
                SortsOfTree.Saltanat => new Saltanat(),
                SortsOfTree.Kishmish => new Kishmish(),
                SortsOfTree.Xusein => new Xusein(),
                SortsOfTree.Gvidon => new Gvidon(),
                _ => throw new ArgumentException("Sort not found!"),
            };
        }
    }
}
