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
            CreateMap<ITree, TreeDb>();
            CreateMap<TreeDb, BusinessModels.Tree>();

            CreateMap<IPlot, PlotDb>();
            CreateMap<PlotDb, Plot>();
        }
    }
}
