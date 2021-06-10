using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TheOxbridgeApp.Models;
using TheOxbridgeApp.Services;
using TheOxbridgeApp.Views.Popups;

namespace TheOxbridgeApp.ViewModels
{
    public class BroadcastViewModel : BaseViewModel
    {
        //local variables
        private ServerClient serverClient;
        private List<Broadcast> unHandledBroadcast;
        
        public BroadcastViewModel()
        {
            serverClient = new ServerClient();
        }

        //binding values
        private ObservableCollection<Broadcast> broadcasts;
        public ObservableCollection<Broadcast> Broadcasts
        {
            get { return broadcasts; }
            set { broadcasts = value; OnPropertyChanged(); }
        }

        private Broadcast selectedBroadcast;
        public Broadcast SelectedBroadcast
        {
            get { return selectedBroadcast; }
            set { selectedBroadcast = value; OnPropertyChanged(); }
        }

        public async void OnAppearing()
        {
            await PopupNavigation.PushAsync(new LoadingPopupView()).ConfigureAwait(false); 
            unHandledBroadcast = serverClient.GetMessages(); // not sure if this collection needed
            await PopupNavigation.PopAllAsync().ConfigureAwait(false);
        }

        private async void NavigateToMessage()
        {
            if (selectedBroadcast != null)
            {
                Broadcast tempSelectedBroadcast = selectedBroadcast;
                SelectedBroadcast = null;
                await PopupNavigation.PushAsync(new LoadingPopupView());
                await PopupNavigation.PushAsync(new BroadcastPopupView(tempSelectedBroadcast)); // create message popup page
            }
        }

    }
}
