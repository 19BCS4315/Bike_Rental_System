using BikeRentalSystem.BikeService.BusinessLayer.Models;

namespace BikeRentalSystem.BikeService.BusinessLayer.Services
{
    public interface IBikeService
    {
        IEnumerable<BikeDto> GetBikes();
        BikeDto GetBikeById(int bikeId);
        void AddBike(BikeDto bikeDto);
        void UpdateBike(BikeDto bikeDto);
        void DeleteBike(int bikeId);
    }
}
