using AutoMapper;
using ProjetoModeloDDDv.Domain.Entities;
using ProjetoModeloDDDv.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public override string ProfileName
        {

            get { return "ViewModelToDomainMappings"; }

        }

        protected override void Configure()
        {

            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();

        }

    }
}