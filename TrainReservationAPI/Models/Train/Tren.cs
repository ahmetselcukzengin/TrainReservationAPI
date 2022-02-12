using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainReservationAPI.Models.Train
{
    public class Tren
    {
        public string Ad { get; set; } //Name
        public List<Vagon> Vagonlar { get; set; } //Wagons
    }
}
