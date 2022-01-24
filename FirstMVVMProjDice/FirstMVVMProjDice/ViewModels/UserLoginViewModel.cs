using FirstMVVMProjLogin.Services;
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
        private readonly IClipBoardService clipBoardService;

        public UserLoginViewModel(IClipBoardService clipBoardService)
        {
            this.clipBoardService = clipBoardService;
            LoginCommand = new Command(loginCommand_Execute, loginCommand_CanExecute);

            GetClipBoardContentCommand = new Command(() =>
            {
                var contents = clipBoardService.GetContentsFromTheClipBoardAsync().Result;
                LoginInfo = contents;
            });
        }
        public string Username
        {
            get => username;
            set 
            { 
                if(SetProperty(ref username, value))
                {
                    LoginCommand?.ChangeCanExecute();
                } 
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (SetProperty(ref password, value))
                {
                    LoginCommand?.ChangeCanExecute();
                }
            }
        }
        public string LoginInfo
        {
            get => loginInfo;
            set { SetProperty(ref loginInfo, value);}
        }
        public Command LoginCommand { get; set; }
        private void loginCommand_Execute()
        {
            LoginInfo = $"Username: {Username} \nPassword: {Password}";
        }
        private bool loginCommand_CanExecute()
        {
            return Username != null && Password != null;
        }

        public Command GetClipBoardContentCommand { get; }
    }
}
