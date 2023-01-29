using Tree.Domain.ModelInterfaces;
using Tree.Domain.ModelInterfaces.Base;
using Tree.Domain.RepositoryInterfaces;
using Tree.Domain.ServiceInterfaces;
using Tree.Service.DTOs;

namespace Tree.Service.Services
{
    public sealed class TreeService : ITreeService
    {
        private readonly IPlotRepository _plotRepository;
        private readonly ITreeRepository _treeRepository;
        private readonly ITreeSortRepository _treeSortRepository;
        public TreeService(ITreeRepository treeRepository, IPlotRepository plotRepository, ITreeSortRepository treeSortRepository)
        {
            _treeRepository = treeRepository;
            _plotRepository = plotRepository;
            _treeSortRepository = treeSortRepository;
        }

        /// <summary>
        /// Add tree.
        /// </summary>
        public async Task AddTreeAsync(long sortId, long count, long plotId)
        {
            var plot = await _plotRepository.GetByIdAsync(plotId);
            if (plot is null)
                throw new Exception("Plot not found!");

            var treeSort = await _treeSortRepository.GetByIdAsync(sortId);
            if (treeSort is null)
                throw new Exception("Sort not found");

            IList<ITree> trees = new List<ITree>();

            for (int index = 0; index < count; index++)
            {
                var tree = new TreeDto()
                {
                    TreeSortId = sortId,
                    PlotId = plotId,
                };

                trees.Add(tree);
            }

            await _treeRepository.AddRangeAsync(trees);
        }

        /// <summary>
        /// Delete tree.
        /// </summary>
        public async Task DeleteAsync(long treeId, long plotId)
        {
            var plot = await _plotRepository.GetByIdAsync(plotId);
            if (plot == null)
                throw new Exception("Plot not found!");

            await _treeRepository.DeleteAsync(treeId);
        }

        /// <summary>
        /// Get all trees.
        /// </summary>
        public async Task<ITree[]> GetAllAsync()
        {
            return await _treeRepository.GetAllAsync();
        }

        /// <summary>
        /// Get tree by id.
        /// </summary>
        public async Task<ITree> GetByIdAsync(long id)
        {
            var tree = await _treeRepository.GetByIdAsync(id);
            if (tree is null)
                throw new Exception("Tree not found!");

            return tree;
        }

        /// <summary>
        /// Get tree info.
        /// </summary>
        public async Task<ITreeCalculation> GetTreeInfoAsync(long plotId)
        {
            var plot = await _plotRepository.GetByIdAsync(plotId);
            if (plot == null)
                throw new Exception("Plot not found");

            var maxYearOfHarvestTask = _treeRepository.GetMaximumYearOfTheHarvestAsync(plotId);
            var maxHeightTask = _treeRepository.GetAverageHeightAsync(plotId);
            var totalAreaTask = _treeRepository.GetTotalOccupyingAreaAsync(plotId);

            await Task.WhenAll(maxHeightTask, totalAreaTask, maxYearOfHarvestTask);

            return new TreeCalculation()
            {
                Year = maxYearOfHarvestTask.Result,
                MaxHeight = maxHeightTask.Result,
                TotalArea = totalAreaTask.Result,
            };
        }
    }
}
