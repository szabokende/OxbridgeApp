using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using TheOxbridgeApp.Models;
using TheOxbridgeApp.Services;
using Xamarin.Forms;

namespace TheOxbridgeApp.ViewModels.Popups
{
    public class BroadcastPopupViewModel : BaseViewModel
    {
        //local variables
        private ServerClient serverClient;
        private SingletonSharedData sharedData;

        public BroadcastPopupViewModel(Broadcast selectedBroadcast)
        {
            sharedData = SingletonSharedData.GetInstance();
            serverClient = new ServerClient();
            this.SelectedBroadcast = selectedBroadcast;

            SetupBinding();
            PopupNavigation.PopAllAsync();
        }
        private Broadcast selectedBroadcast;
        public Broadcast SelectedBroadcast
        {
            get { return selectedBroadcast; }
            set { selectedBroadcast = value; OnPropertyChanged(); }
        }
    }
}
