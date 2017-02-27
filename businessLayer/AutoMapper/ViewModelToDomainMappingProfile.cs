using AutoMapper;
using Repositories.Models;
using ViewModels.Models;

namespace BusinessLayer.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
       
            public override string ProfileName
            {
                get { return "ViewModelToDomainMappingProfile"; }
            }

            protected override void Configure()
            {
                CreateMap<AlbumViewModel, Album>();
                CreateMap<PhotoViewModel, Photo>();
            }
        }
}