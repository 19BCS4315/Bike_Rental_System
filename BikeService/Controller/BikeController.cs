using BikeRentalSystem.BikeService.BusinessLayer.Models;
using BikeRentalSystem.BikeService.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalSystem.BikeService.Controller
{
    [ApiController]
    [Route("/api/bikes")]
    public class BikeController : ControllerBase
    {
        private readonly IBikeService _bikeService;

        public BikeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        [HttpGet]
        public IActionResult GetAllBikes()
        {
            var bikes = _bikeService.GetBikes();
            return Ok(bikes);
        }

        [HttpGet("{bikeId}")]
        public IActionResult GetBike(int bikeId)
        {
            var bike = _bikeService.GetBikeById(bikeId);

            if (bike == null)
            {
                return NotFound();
            }

            return Ok(bike);
        }

        [HttpPost]
        public IActionResult AddBike(BikeDto bike)
        {
            _bikeService.AddBike(bike);
            return CreatedAtAction(nameof(GetBike), new { bikeId = bike.BikeId }, bike);
        }

        [HttpPut("{bikeId}")]
        public IActionResult UpdateBike(int bikeId, BikeDto bike)
        {
            if (bikeId != bike.BikeId)
            {
                return BadRequest();
            }

            _bikeService.UpdateBike(bike);

            return NoContent();
        }

        [HttpDelete("{bikeId}")]
        public IActionResult DeleteBike(int bikeId)
        {
            var bike = _bikeService.GetBikeById(bikeId);

            if (bike == null)
            {
                return NotFound();
            }

            _bikeService.DeleteBike(bikeId);

            return NoContent();
        }
    }
}
