using BikeRentalSystem.BikeService.BusinessLayer.Models;
using BikeRentalSystem.BikeService.DataAccessLayer.Models;
using BikeRentalSystem.BikeService.DataAccessLayer.Repositories;

namespace BikeRentalSystem.BikeService.BusinessLayer.Services
{
    public class BikeService : IBikeService
    {
        private readonly IBikeRepository _bikeRepository;
        public BikeService(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }
        public IEnumerable<BikeDto> GetBikes()
        {
            try
            {
                var bikes = _bikeRepository.GetAllBikes();
                return bikes.Select(bike => new BikeDto
                {
                    BikeId = bike.BikeId,
                    BikeType = bike.BikeType,
                    Brand = bike.Brand,
                    Model = bike.Model,
                    PurchaseDate = bike.PurchaseDate,
                    PurchasePrice = bike.PurchasePrice,
                    RentalPricePerDay = bike.RentalPricePerDay,
                    RentalPricePerHour = bike.RentalPricePerHour,
                    RentalPricePerWeek = bike.RentalPricePerWeek,
                    AvailableQuantity = bike.AvailableQuantity
                });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all bikes.", ex);
            }
        }
        public BikeDto GetBikeById(int bikeId)
        {
            var bike = _bikeRepository.GetBike(bikeId);
            if (bike == null)
            {
                throw new Exception("Bike not found");
            }
            return new BikeDto
            {
                BikeId = bike.BikeId,
                BikeType = bike.BikeType,
                Brand = bike.Brand,
                Model = bike.Model,
                PurchaseDate = bike.PurchaseDate,
                PurchasePrice = bike.PurchasePrice,
                RentalPricePerDay = bike.RentalPricePerDay,
                RentalPricePerHour = bike.RentalPricePerHour,
                RentalPricePerWeek = bike.RentalPricePerWeek,
                AvailableQuantity = bike.AvailableQuantity
            };
        }
        public void AddBike(BikeDto bikeDto)
        {
            var bike = new Bike
            {
                BikeId = bikeDto.BikeId,
                BikeType = bikeDto.BikeType,
                Brand = bikeDto.Brand,
                Model = bikeDto.Model,
                PurchaseDate = bikeDto.PurchaseDate,
                PurchasePrice = bikeDto.PurchasePrice,
                RentalPricePerDay = bikeDto.RentalPricePerDay,
                RentalPricePerHour = bikeDto.RentalPricePerHour,
                RentalPricePerWeek = bikeDto.RentalPricePerWeek,
                AvailableQuantity = bikeDto.AvailableQuantity
            };
            _bikeRepository.AddBike(bike);
            _bikeRepository.Save();
        }
        public void UpdateBike(BikeDto bikeDto)
        {
            var bike = _bikeRepository.GetAllBikes();
            _bikeRepository.UpdateBike(bike);
            _bikeRepository.Save();
        }
        public void DeleteBike(int bikeId)
        {
            var bike = _bikeRepository.GetBike(bikeId);
            _bikeRepository.DeleteBike(bike);
            _bikeRepository.Save();
        }
    }
}
