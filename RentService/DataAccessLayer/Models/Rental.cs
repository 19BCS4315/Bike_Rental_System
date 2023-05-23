using BikeRentalSystem.BikeService.DataAccessLayer.Models;
using BikeRentalSystem.RentService.DataAccessLayer.Models;
using BikeRentalSystem.RentService.DataAccessLayer.Models;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int BikeId { get; set; }
        public int CustomerId { get; set; }
        public string RentalType { get; set; } = string.Empty;
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public int RentalDuration { get; set; }
        public decimal TotalRentalAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public Bike Bike { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public ICollection<RentalItem> RentalItems { get; set; } = null!;

    }
}
