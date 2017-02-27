using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Repositories;
using Repositories.Models;
using Repositories.Repositories;
using ViewModels.Models;

namespace businessLayer
{
    public class PhotoAutomapper
    {
         PhotoRepository<Photo> _photoRepository = new PhotoRepository<Photo>(new BildGalleryContext());

        public  async Task<PhotoViewModel> FromBltoUiGetById(Guid id)
        {
            var getRepo = await _photoRepository.GetByIdAsync(id);
            var detailsId = Mapper.Map<Photo, PhotoViewModel>(getRepo);
            return detailsId;
        }

        public IQueryable<PhotoViewModel> SearchFor(Expression<Func<PhotoViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<PhotoViewModel> FromBltoUiGetAll()
        {
            var getData = _photoRepository.GetAll().ToList();
            var randomPhoto = Mapper.Map<List<Photo>, List<PhotoViewModel>>(getData);
            return randomPhoto;
        }
        //public List<PhotoViewModel> FromBlToUiGetApartList()
        //{

        //    var getData = _genericRepository.GetAll()
        //       //.Include(a => new Adress() {Id = a.Adress.Id, Street = a.Adress.Street})
        //       //.Include(a => new HousingType() {Id = a.Housing.Id, Type = a.Housing.Type})
        //       //.Include(a => new District() {Id = a.District.Id, Name = a.District.Name})
        //       //.Include(x => x.Features.Select(s => new Features() { Id = s.Id, name = s.name }))
        //       .Select(p => new AppartmentViewModel()
        //       {
        //           Id = p.Id,
        //           Area = p.Area,
        //           Rent = p.Rent,
        //           NrOfRooms = p.NrOfRooms,
        //           BuildinFloors = p.BuildinFloors,
        //           Floor = p.Floor,
        //           BuildYear = p.BuildYear,
        //           MoveInDate = p.MoveInDate,
        //           LastAdmissionDate = p.LastAdmissionDate,
        //           PublicationDate = p.PublicationDate,
        //           Avalible = p.Avalible,
        //           //Adress = new AdressViewModel() { Id = p.Adress.Id, Street = p.Adress.Street },
        //           //Housing = new HousingTypeViewModel() { Id = p.Housing.Id, Type = p.Housing.Type },
        //           //District = new DistrictViewModel() { Id = p.District.Id, Name = p.District.Name, Description = p.District.Description }

        //       })
        //        .ToList();
        //    return getData;
        //}
        public  async Task FromBltoUiEditAsync(PhotoViewModel Photo)
        {
            var editMap = Mapper.Map<PhotoViewModel, Photo>(Photo);
            await _photoRepository.EditAsync(editMap);
        }

        public  async Task FromBltoUiInser(PhotoViewModel Photo)
        {
            var addMap = Mapper.Map<PhotoViewModel, Photo>(Photo);
            await _photoRepository.InsertAsync(addMap);
        }

        public  async Task FromBltoUiDeleteAsync(Guid id)
        {
            var getFromR = await _photoRepository.GetByIdAsync(id);
            await _photoRepository.DeleteAsync(getFromR);
        }
    }
}
