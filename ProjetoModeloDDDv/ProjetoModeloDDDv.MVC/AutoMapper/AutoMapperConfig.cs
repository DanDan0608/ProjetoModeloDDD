
using AutoMapper;
using ProjetoModeloDDD.MVC.AutoMapper;

namespace ProjetoModeloDDD.MVC.AutoMapperConfig
{
    public class AutoMapperConfig
    {
        // config = new MapperConfiguration(cfg =>
        // {
        //  cfg.CreateMap<UsuarioViewModel, Models.Usuario>();
        // });


        public static void RegisterMappings()
        {

            Mapper.Initialize(x =>
            {

                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();

            });
        }
    }
}