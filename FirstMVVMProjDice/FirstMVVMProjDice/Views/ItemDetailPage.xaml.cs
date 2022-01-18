using FirstMVVMProjDice.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FirstMVVMProjDice.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}