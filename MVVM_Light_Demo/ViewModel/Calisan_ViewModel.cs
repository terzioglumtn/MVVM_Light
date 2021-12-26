using System.Windows.Input;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace MVVM_Light_Demo.ViewModel
{
    public class Calisan_ViewModel : ViewModelBase
    {
        public string Baslik_str { get; set; }

        private ObservableCollection<Calisan_Model> calisanlar      ;
        private Calisan_Model                       secilmis_calisan;

        public ICommand Calisanlari_Yukle_Command { get; private set; }
        public ICommand Calisani_Kaydet_Command   { get; private set; }

        public Calisan_ViewModel()
        {
            if (true == IsInDesignMode)
            {
                Baslik_str = "Design Mode";
            }
            else
            {
                Baslik_str = "Runtime Mode";
            }

            Calisanlari_Yukle_Command = new RelayCommand(Calisanlari_Yukle);
            Calisani_Kaydet_Command   = new RelayCommand(Calisani_Kaydet);
        }

        public ObservableCollection<Calisan_Model> Calisanlar_Listesi
        {
            get
            {
                return calisanlar;
            }
        }

        public Calisan_Model Secilmis_Calisan
        {
            get
            {
                return secilmis_calisan;
            }
            set
            {
                secilmis_calisan = value;
                RaisePropertyChanged("Secilmis_Calisan");
            }
        }

        private void Calisanlari_Yukle()
        {
            calisanlar = Calisan_Model.Ornek_Calisanlari_Olustur();

            this.RaisePropertyChanged(() => this.Calisanlar_Listesi); //RaisePropertyChanged("Calisanlar_Listesi");

            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Çalýþanlar Yüklendi."));
        }

        private void Calisani_Kaydet()
        {
            if (null != secilmis_calisan)
            {
                if (secilmis_calisan.Ad_str != "AD")
                {
                    secilmis_calisan.Ad_str = "AD";

                }
                else
                {
                    secilmis_calisan.Ad_str = "SOYAD";
                }
            }

            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Çalýþan Kayýt Edildi."));
        }
    }
}