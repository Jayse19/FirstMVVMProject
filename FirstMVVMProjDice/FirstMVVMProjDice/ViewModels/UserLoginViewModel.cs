using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FirstMVVMProjDice.ViewModels
{
    public class UserLoginViewModel : BaseViewModel
    {
        private string loginInfo;
        private string username;
        private string password;

        public UserLoginViewModel()
        {
            LoginCommand = new Command(loginCommand);
        }
        public string Username
        {
            get => username;
            set { SetProperty(ref username, value); }
        }
        public string Password
        {
            get => password;
            set { SetProperty(ref password, value); }
        }
        public string LoginInfo
        {
            get => loginInfo;
            set { SetProperty(ref loginInfo, value);}
        }
        public Command LoginCommand { get; set; }
        private void loginCommand()
        {
            LoginInfo = $"Username: {Username} \nPassword: {Password}";
        }
    }
}
