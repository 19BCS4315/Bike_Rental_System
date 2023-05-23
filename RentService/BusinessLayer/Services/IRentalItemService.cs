﻿using BusinessLayer.Models;

namespace BikeRentalSystem.RentService.BusinessLayer.Services
{
    public interface IRentalItemService
    {
        RentalItemDto GetRentalItem(int rentalItemId);
        IEnumerable<RentalItemDto> GetAllRentalItems();
        IEnumerable<RentalItemDto> GetRentalItemsByRental(int rentalId);
        IEnumerable<RentalItemDto> GetRentalItemsByBike(int bikeId);
        void AddRentalItem(RentalItemDto rentalItem);
        void UpdateRentalItem(RentalItemDto rentalItem);
        void DeleteRentalItem(int rentalItemId);
        bool RentalItemExists(int rentalItemId);
    }
}
