using BikeRentalSystem.BikeService.DataAccessLayer.Data;
using BikeRentalSystem.BikeService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace BikeRentalSystem.BikeService.DataAccessLayer.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly BikeDbContext _context;
        public BikeRepository(BikeDbContext context)
        {
            _context = context;
        }
        public Bike GetBike(int bikeId)
        {
            var getBike = _context.Bikes.FirstOrDefault(b=>b.BikeId == bikeId);

            if(getBike == null)
            {
                throw new ArgumentException("No Bike found with this Id");
            }
            return getBike;
        }
        public IEnumerable<Bike> GetAllBikes()
        {
            return _context.Bikes.ToList();

        }
        public IEnumerable<Bike> GetAvailableBikes()
        {
            return _context.Bikes.Where(b => b.AvailableQuantity > 0);
        }
        public void AddBike(Bike bike)
        {
            _context.Bikes.Add(bike);
        }
        public void UpdateBike(Bike bike)
        {
            _context.Entry(bike).State = EntityState.Modified;
        }
        public void DeleteBike(Bike bike)
        {
            _context.Bikes.Remove(bike);
        }
        public bool BikeExists(int bikeId)
        {
            return _context.Bikes.Any(b => b.BikeId == bikeId);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void UpdateBike(IEnumerable<Bike> bike)
        {
            foreach (var b in bike)
            {
                var existingBike = _context.Bikes.FirstOrDefault(ba => ba.BikeId == b.BikeId &&
                                                                     ba.BikeType == b.BikeType &&
                                                                     ba.Brand == b.Brand &&
                                                                     ba.Model == b.Model &&
                                                                     ba.PurchaseDate == b.PurchaseDate &&
                                                                     ba.PurchasePrice == b.PurchasePrice &&
                                                                     ba.RentalPricePerHour == b.RentalPricePerHour &&
                                                                     ba.RentalPricePerDay == b.RentalPricePerDay &&
                                                                     ba.RentalPricePerWeek == b.RentalPricePerWeek &&
                                                                     ba.AvailableQuantity == b.AvailableQuantity);
                if (existingBike != null)
                {
                    existingBike.BikeId = b.BikeId;
                    existingBike.BikeType = b.BikeType;
                    existingBike.Brand = b.Brand;
                    existingBike.Model = b.Model;
                    existingBike.PurchaseDate = b.PurchaseDate;
                    existingBike.PurchasePrice = b.PurchasePrice;
                    existingBike.RentalPricePerHour = b.RentalPricePerHour;
                    existingBike.RentalPricePerDay = b.RentalPricePerDay;
                    existingBike.RentalPricePerWeek = b.RentalPricePerWeek;
                    existingBike.AvailableQuantity = b.AvailableQuantity;
                }

            }
        }
    }
}
