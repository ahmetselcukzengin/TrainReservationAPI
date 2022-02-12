using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainReservationAPI.Models.Train;

namespace TrainReservationAPI.Services
{
    public class WagonService
    {
        List<Vagon> Vagons;
        public WagonService()
        {
            this.Vagons = new List<Vagon>
            {
              new Vagon{ Ad="Vagon 1", Kapasite=100, DoluKoltukAdet=50},
              new Vagon{Ad="Vagon 2", Kapasite=90, DoluKoltukAdet=80},
              new Vagon{Ad="Vagon 3", Kapasite=80, DoluKoltukAdet=80},
              new Vagon{ Ad="Vagon 4", Kapasite=100, DoluKoltukAdet=68},
              new Vagon{ Ad="Vagon 5", Kapasite=90, DoluKoltukAdet=80}
            };
        }

        public bool WagonsExists(List<Vagon> vagons)
        {
            bool exist = false;
            foreach (var vagon in vagons)
            {
                exist = Vagons.Any(x => x.Ad == vagon.Ad && x.Kapasite == vagon.Kapasite);
                if (!exist)
                    break;
            }
            return exist;
        }
    }
}
