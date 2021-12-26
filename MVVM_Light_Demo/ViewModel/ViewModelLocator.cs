using System.Windows;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;

namespace MVVM_Light_Demo.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<Calisan_ViewModel>();

            Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
        }

        public Calisan_ViewModel Calisan_ViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Calisan_ViewModel>();
            }
        }

        private void NotifyUserMethod(NotificationMessage message)
        {
            MessageBox.Show(message.Notification);
        }
    }
}