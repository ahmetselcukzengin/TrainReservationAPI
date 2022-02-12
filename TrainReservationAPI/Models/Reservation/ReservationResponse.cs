using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainReservationAPI.Models.Train;

namespace TrainReservationAPI.Models.Reservation
{
    public class ReservationResponse
    {
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; }
    }
}
