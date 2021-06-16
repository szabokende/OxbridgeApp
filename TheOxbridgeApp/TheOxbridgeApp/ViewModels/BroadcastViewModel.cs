using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TheOxbridgeApp.Models;
using TheOxbridgeApp.Services;
using TheOxbridgeApp.Views.Popups;
using Xamarin.Forms;

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
            SendMessageCMD = new Command(SendMessage);
        }
        //commands
        public ICommand SendMessageCMD { get; set; } 
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
            set { selectedBroadcast = value; OnPropertyChanged(); NavigateToBroadcast(); }
        }
        private String messageText;
        public String MessageText
        {
            get { return messageText; }
            set { messageText = value; OnPropertyChanged(); }
        }
        private ISerializable sendableMsg;
        public ISerializable SendableMsg
        {
            get { return sendableMsg; }
            set { sendableMsg = value; }
        }
        //fill up the list view
        public async void OnAppearing()
        {
            await PopupNavigation.PushAsync(new LoadingPopupView()).ConfigureAwait(false); 
            unHandledBroadcast = serverClient.GetMessages(); // not sure if this collection needed
            Broadcasts = new ObservableCollection<Broadcast>(unHandledBroadcast);
            await PopupNavigation.PopAllAsync().ConfigureAwait(false);
        }
        //navigate to popup page with selected message
        private async void NavigateToBroadcast()
        {
            if (selectedBroadcast != null)
            {
                Broadcast tempSelectedBroadcast = selectedBroadcast;
                SelectedBroadcast = null;
                await PopupNavigation.PushAsync(new LoadingPopupView());
                await PopupNavigation.PushAsync(new BroadcastPopupView(tempSelectedBroadcast)); 
            }
        }
        //sending the value from entry field
        private void SendMessage()
        {
            Broadcasts.Add(new Broadcast {Message = MessageText});
            serverClient.PostData(SendableMsg,Target.Broadcasts);
        }

    }
}
