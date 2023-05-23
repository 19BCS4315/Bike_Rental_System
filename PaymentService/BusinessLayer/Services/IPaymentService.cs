using BikeRentalSystem.RentService.BusinessLayer.Models;

namespace BikeRentalSystem.RentService.BusinessLayer.Services
{
    public interface IPaymentService
    {
        PaymentDto GetPayment(int paymentId);
        IEnumerable<PaymentDto> GetAllPayments();
        IEnumerable<PaymentDto> GetPaymentsByRental(int rentalId);
        PaymentDto AddPayment(PaymentDto paymentDto);
        void UpdatePayment(PaymentDto paymentDto);
        void DeletePayment(int paymentId);
        bool PaymentExists(int paymentId);
    }
}
