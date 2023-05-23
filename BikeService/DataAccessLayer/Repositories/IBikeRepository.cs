using BikeRentalSystem.BikeService.DataAccessLayer.Models;

namespace BikeRentalSystem.BikeService.DataAccessLayer.Repositories
{
    public interface IBikeRepository
    {
        Bike GetBike(int bikeId);
        IEnumerable<Bike> GetAllBikes();
        IEnumerable<Bike> GetAvailableBikes();

        void AddBike(Bike bike);
        void UpdateBike(Bike bike);
        void DeleteBike(Bike bike);
        bool BikeExists(int bikeId);
        void Save();
        void UpdateBike(IEnumerable<Bike> bike);
    }
}
