using Tree.Domain.ModelInterfaces;
using Tree.Domain.RepositoryInterfaces;
using Tree.Domain.ServiceInterfaces;

namespace Tree.Service.Services
{
    public sealed class PlotService : IPlotService
    {
        private readonly IPlotRepository _plotRepository;
        private readonly ITreeRepository _treeRepository;
        public PlotService(IPlotRepository plotRepository, ITreeRepository treeRepository)
        {
            _plotRepository = plotRepository;
            _treeRepository = treeRepository;
        }

        public async Task AddAsync(IPlot plot)
        {
            await _plotRepository.AddAsync(plot);
        }

        public async Task<IPlot[]> GetAllAsync()
        {
            return await _plotRepository.GetAllAsync();
        }
    }
}
