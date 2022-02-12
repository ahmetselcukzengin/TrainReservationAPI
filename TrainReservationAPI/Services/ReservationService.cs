using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainReservationAPI.Models.Reservation;
using TrainReservationAPI.Models.Train;

namespace TrainReservationAPI.Services
{
    public class ReservationService
    {
        TrainService trainService;
        WagonService wagonService;
        public ReservationService()
        {
            this.trainService = new TrainService();
            this.wagonService = new WagonService();
        }
        public ReservationResponse TrainReservation(ReservationRequest reservationRequest)
        {
            bool result = true;

            #region Business Rules
            CheckTrainExists(reservationRequest, ref result);
            if (!result)
            {
                return new ReservationResponse { RezervasyonYapilabilir = false, YerlesimAyrinti = new List<YerlesimAyrinti>() };
            }
            CheckWagonsExists(reservationRequest, ref result);
            if (!result)
            {
                return new ReservationResponse { RezervasyonYapilabilir = false, YerlesimAyrinti = new List<YerlesimAyrinti>() };
            }
            CheckWagonsCapacities(reservationRequest, ref result);
            if (!result)
            {
                return new ReservationResponse { RezervasyonYapilabilir = false, YerlesimAyrinti = new List<YerlesimAyrinti>() };
            }
            #endregion

            if (reservationRequest.KisilerFarkliVagonlaraYerlestirilebilir)
            {
                List<YerlesimAyrinti> yerlesimAyrintiList = new List<YerlesimAyrinti>();
                var tempKisiSayısı = reservationRequest.RezervasyonYapilacakKisiSayisi;

                foreach (var vagon in reservationRequest.Tren.Vagonlar)
                {
                    YerlesimAyrinti yerlesimAyrinti = new YerlesimAyrinti { VagonAdi = vagon.Ad, KisiSayisi = 0 };
                    for (int i = 0; i < tempKisiSayısı; i++)
                    {
                        decimal occupancy = (vagon.DoluKoltukAdet / (decimal)vagon.Kapasite) * 100;
                        if (occupancy >= 70)
                            break;
                        vagon.DoluKoltukAdet += 1;
                        yerlesimAyrinti.KisiSayisi += 1;
                        reservationRequest.RezervasyonYapilacakKisiSayisi -= 1;
                    }
                    if (yerlesimAyrinti.KisiSayisi != 0)
                    {
                        yerlesimAyrintiList.Add(yerlesimAyrinti);
                        tempKisiSayısı = reservationRequest.RezervasyonYapilacakKisiSayisi;
                    }
                }
                if (reservationRequest.RezervasyonYapilacakKisiSayisi == 0)
                {
                    return new ReservationResponse
                    {
                        RezervasyonYapilabilir = true,
                        YerlesimAyrinti = yerlesimAyrintiList
                    };
                }
                return new ReservationResponse { RezervasyonYapilabilir = false, YerlesimAyrinti = new List<YerlesimAyrinti>() };
            }
            else
            {
                foreach (var vagon in reservationRequest.Tren.Vagonlar)
                {
                    decimal occupancy = ((vagon.DoluKoltukAdet + reservationRequest.RezervasyonYapilacakKisiSayisi) / (decimal)vagon.Kapasite) * 100;
                    if (occupancy >= 70)
                        continue;
                    return new ReservationResponse
                    {
                        RezervasyonYapilabilir = true,
                        YerlesimAyrinti = new List<YerlesimAyrinti> {
                            new YerlesimAyrinti { VagonAdi = vagon.Ad,
                                KisiSayisi = reservationRequest.RezervasyonYapilacakKisiSayisi
                            }
                        }
                    };
                }
                return new ReservationResponse { RezervasyonYapilabilir = false, YerlesimAyrinti = new List<YerlesimAyrinti>() };
            }
        }
        private void CheckTrainExists(ReservationRequest reservationRequest, ref bool result)
        {
            Tren train = trainService.Get(reservationRequest.Tren);
            if (train == null)
            {
                result = false;
            }
        }
        private void CheckWagonsExists(ReservationRequest reservationRequest, ref bool result)
        {
            result = reservationRequest.Tren.Vagonlar == null ? false : wagonService.WagonsExists(reservationRequest.Tren.Vagonlar);
        }

        private void CheckWagonsCapacities(ReservationRequest reservationRequest, ref bool result)
        {
            var tempVagonlar = reservationRequest.Tren.Vagonlar.ToList();
            foreach (var vagon in tempVagonlar)
            {
                decimal occupancy = (vagon.DoluKoltukAdet / (decimal)vagon.Kapasite) * 100;
                if (occupancy >= 70)
                {
                    reservationRequest.Tren.Vagonlar.Remove(vagon);
                }
            }
            if (reservationRequest.Tren.Vagonlar == null)
            {
                result = false;
            }
        }
    }
}
