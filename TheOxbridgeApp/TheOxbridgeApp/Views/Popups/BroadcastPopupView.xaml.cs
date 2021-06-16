using Rg.Plugins.Popup.Pages;
using TheOxbridgeApp.Models;
using TheOxbridgeApp.ViewModels.Popups;
using Xamarin.Forms.Xaml;

namespace TheOxbridgeApp.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BroadcastPopupView : PopupPage
    {
        public BroadcastPopupView(Broadcast selectedBroadcast)
        {
            InitializeComponent();
            this.BindingContext = new BroadcastPopupViewModel(selectedBroadcast);
        }
        
    }
}
