using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainReservationAPI.Models.Train
{
    public class Vagon
    {
        public string Ad { get; set; } //Name
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }
    }
}
