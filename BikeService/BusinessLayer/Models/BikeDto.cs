namespace BikeRentalSystem.BikeService.BusinessLayer.Models
{
    public class BikeDto
    {
        public int BikeId { get; set; }
        public string BikeType { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RentalPricePerHour { get; set; }
        public decimal RentalPricePerDay { get; set; }
        public decimal RentalPricePerWeek { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
