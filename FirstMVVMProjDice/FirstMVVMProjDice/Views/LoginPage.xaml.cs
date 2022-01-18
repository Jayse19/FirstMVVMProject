using FirstMVVMProjDice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstMVVMProjDice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private UserLoginViewModel userLoginViewModel;
        public LoginPage()
        {
            InitializeComponent();
            //this.BindingContext = new LoginViewModel();
            userLoginViewModel = new UserLoginViewModel();
            this.BindingContext = userLoginViewModel;
        }
    }
}