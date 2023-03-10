using AutoMapper;
using Tree.DBCodeFirst.Entities;
using Tree.Domain.ModelInterfaces;
using Tree.Domain.ModelInterfaces.Base;
using Tree.Repository.BusinessModels;

namespace Tree.Repository.Mappers
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configuration of tree mapping.
            CreateMap<ITree, TreeDb>();
            CreateMap<TreeDb, BusinessModels.Tree>();

            // Configuration of plot mapping.
            CreateMap<IPlot, PlotDb>();
            CreateMap<PlotDb, Plot>();

            // Configuration of tree type mapping.
            CreateMap<ITreeType, TreeTypeDb>();
            CreateMap<TreeTypeDb, TreeType>();

            // Configruation of tree sort mapping.
            CreateMap<ITreeSort, TreeSortDb>();
            CreateMap<TreeSortDb, TreeSort>();
        }
    }
}
