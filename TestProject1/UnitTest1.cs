using NUnit.Framework;
using FirstMVVMProjDice.ViewModels;
using FluentAssertions;

namespace TestProject1
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserNameAndPasswordAreBobPassword()
        {
            var viewModel = new UserLoginViewModel();
            viewModel.Username = "Bob";
            viewModel.Password = "Password";
            viewModel.LoginCommand.Execute(null);
            Assert.AreEqual($"Username: Bob \nPassword: Password", viewModel.LoginInfo);

        }

        [Test]
        public void CannotExecuteIfUsernameIsNull()
        {
            var viewModel = new UserLoginViewModel();
            viewModel.Username = null;
            viewModel.Password = "Password";
            viewModel.LoginCommand.CanExecute(this).Should().Be(false);
        }

        [Test]
        public void CannotExecuteIfPasswordIsNull()
        {
            var viewModel = new UserLoginViewModel();
            viewModel.Username = "Username";
            viewModel.Password = null;
            viewModel.LoginCommand.CanExecute(this).Should().Be(false);
        }
        [Test]
        public void CannotExecuteIfUsernameAndPasswordAreNull()
        {
            var viewModel = new UserLoginViewModel();
            viewModel.Username = null;
            viewModel.Password = null;
            viewModel.LoginCommand.CanExecute(this).Should().Be(false);
        }
        [Test]
        public void CanExecuteIfUsernameAndPasswordAreNotNull()
        {
            var viewModel = new UserLoginViewModel();
            viewModel.Username = "Username";
            viewModel.Password = "Password";
            viewModel.LoginCommand.CanExecute(this).Should().Be(true);
        }
        [Test]
        public void ResultPropertyShouldShowUsernameAndPassword()
        {
            var viewModel = new UserLoginViewModel();
            viewModel.Username = "Username";
            viewModel.Password = "Password";
            viewModel.LoginCommand.Execute(null);
            viewModel.LoginInfo.Should().Be($"Username: Username \nPassword: Password");
        }
    }
}