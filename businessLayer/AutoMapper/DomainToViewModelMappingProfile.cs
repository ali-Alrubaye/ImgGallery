using AutoMapper;
using Repositories.Models;
using ViewModels.Models;

namespace BusinessLayer.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            CreateMap<Album, AlbumViewModel>();
            CreateMap<Photo, PhotoViewModel>()
                .ForMember(dto => dto.AlbumPhV, opt => opt.MapFrom(scr =>scr.Album));
        }
    }
}