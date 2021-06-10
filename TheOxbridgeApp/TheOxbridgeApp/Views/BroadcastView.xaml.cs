using System;
using TheOxbridgeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TheOxbridgeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BroadcastView : ContentPage
    {
        public BroadcastView()
        {
            InitializeComponent();
        }
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            ((BroadcastViewModel)this.BindingContext).OnAppearing();
        }
    }
    
}
