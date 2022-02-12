using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainReservationAPI.Models.Reservation;
using TrainReservationAPI.Services;

namespace TrainReservationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainReservationController : ControllerBase
    {
        ReservationService ReservationService;
        public TrainReservationController()
        {
            this.ReservationService = new ReservationService();
        }
        [HttpPost]
        public ReservationResponse TrainReservation([FromBody]ReservationRequest request)
        {
            return this.ReservationService.TrainReservation(request);
        }
    }
}
