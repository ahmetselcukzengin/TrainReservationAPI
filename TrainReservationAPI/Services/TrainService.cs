using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainReservationAPI.Models.Train;

namespace TrainReservationAPI.Services
{
    public class TrainService
    {
        List<Tren> Trains;
        public TrainService()
        {
            this.Trains = new List<Tren>
            {
                new Tren{
                    Ad="Başkent Ekspres",
                    Vagonlar=new List<Vagon>
                    {
                      new Vagon{ Ad="Vagon 1", Kapasite=100, DoluKoltukAdet=50},
                      new Vagon{ Ad="Vagon 2", Kapasite=90, DoluKoltukAdet=80},
                      new Vagon{ Ad="Vagon 3", Kapasite=80, DoluKoltukAdet=80}
                    }
                },
                new Tren{
                    Ad="Doğu Ekspres",
                    Vagonlar=new List<Vagon>
                    {
                      new Vagon{ Ad="Vagon 1", Kapasite=100, DoluKoltukAdet=50},
                      new Vagon{ Ad="Vagon 2", Kapasite=90, DoluKoltukAdet=80},
                      new Vagon{ Ad="Vagon 3", Kapasite=80, DoluKoltukAdet=80},
                      new Vagon{ Ad="Vagon 4", Kapasite=100, DoluKoltukAdet=68},
                      new Vagon{ Ad="Vagon 5", Kapasite=90, DoluKoltukAdet=80}
                    }
                }
            };
        }

        public Tren Get(Tren train)
        {
            return this.Trains.Find(x => x.Ad == train.Ad);
        }
    }
}
