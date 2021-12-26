using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

using INT32   = System.Int32;
using FLOAT64 = System.Double;

namespace MVVM_Light_Demo
{
    public class Calisan_Model : ObservableObject
    {
        private INT32   id_s32  ;
        private string  ad_str  ;
        private INT32   yas_s32 ;
        private FLOAT64 maas_f64;

        public INT32 ID
        {
            get
            {
                return id_s32;
            }
            set
            {
                Set(() => this.ID, ref id_s32, value);
            }
        }

        public string Ad_str
        {
            get
            {
                return ad_str;
            }
            set
            {
                Set(() => this.Ad_str, ref ad_str, value);
            }
        }

        public INT32 Yas_s32
        {
            get
            {
                return yas_s32;
            }
            set
            {
                Set(() => this.Yas_s32, ref yas_s32, value);
            }
        }

        public FLOAT64 Maas_f64
        {
            get
            {
                return maas_f64;
            }
            set
            {
                Set(() => this.Maas_f64, ref maas_f64, value);
            }
        }

        public static ObservableCollection<Calisan_Model> Ornek_Calisanlari_Olustur()
        {
            ObservableCollection<Calisan_Model> calisanlar = new ObservableCollection<Calisan_Model>();

            for (int i = 0; i < 30; ++i)
            {
                calisanlar.Add(new Calisan_Model
                {
                    ID       = i + 1,
                    Ad_str   = "Ad " + (i + 1).ToString(),
                    Yas_s32  = 20 + i,
                    Maas_f64 = 20000 + (i * 10)
                });
            }

            return calisanlar;
        }
    }
}