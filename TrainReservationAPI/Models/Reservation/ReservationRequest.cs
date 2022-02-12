using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainReservationAPI.Models.Train;

namespace TrainReservationAPI.Models.Reservation
{
    public class ReservationRequest
    {
        public Tren Tren { get; set; } //Name
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
