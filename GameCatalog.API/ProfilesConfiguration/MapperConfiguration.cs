using AutoMapper;
using GameCatalog.API.Domain.Entities;
using GameCatalog.API.Models.Developers.InputModels;
using GameCatalog.API.Models.Developers.ViewModels;
using GameCatalog.API.Models.Games.InputModels;
using GameCatalog.API.Models.Games.ViewModels;

namespace GameCatalog.API.ProfilesConfiguration
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<AddGameInputModel, Game>();
            CreateMap<UpdateGameInputModel, Game>();
            CreateMap<AddDeveloperInputModel, Developer>();
            CreateMap<UpdateGameInputModel, Developer>();

            CreateMap<Game, GameViewModel>();
            CreateMap<Game, GameWithDeveloperViewModel>();
            CreateMap<Developer, DeveloperViewModel>();
            CreateMap<Developer, DeveloperWithGamesViewModel>();
        }   
    }
}