using NUnit.Framework;
using FirstMVVMProjDice.ViewModels;
using FluentAssertions;
using Moq;
using FirstMVVMProjLogin.Services;

namespace TestProject1
{
    public class Tests
    {
        IClipBoardService clipBoardService;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserNameAndPasswordAreBobPassword()
        {
            var viewModel = new UserLoginViewModel(clipBoardService);
            viewModel.Username = "Bob";
            viewModel.Password = "Password";
            viewModel.LoginCommand.Execute(null);
            Assert.AreEqual($"Username: Bob \nPassword: Password", viewModel.LoginInfo);

        }

        [Test]
        public void CannotExecuteIfUsernameIsNull()
        {
            var viewModel = new UserLoginViewModel(clipBoardService);
            viewModel.Username = null;
            viewModel.Password = "Password";
            viewModel.LoginCommand.CanExecute(this).Should().Be(false);
        }

        [Test]
        public void CannotExecuteIfPasswordIsNull()
        {
            var viewModel = new UserLoginViewModel(clipBoardService);
            viewModel.Username = "Username";
            viewModel.Password = null;
            viewModel.LoginCommand.CanExecute(this).Should().Be(false);
        }
        [Test]
        public void CannotExecuteIfUsernameAndPasswordAreNull()
        {
            var viewModel = new UserLoginViewModel(clipBoardService);
            viewModel.Username = null;
            viewModel.Password = null;
            viewModel.LoginCommand.CanExecute(this).Should().Be(false);
        }
        [Test]
        public void CanExecuteIfUsernameAndPasswordAreNotNull()
        {
            var viewModel = new UserLoginViewModel(clipBoardService);
            viewModel.Username = "Username";
            viewModel.Password = "Password";
            viewModel.LoginCommand.CanExecute(this).Should().Be(true);
        }
        [Test]
        public void ResultPropertyShouldShowUsernameAndPassword()
        {
            var viewModel = new UserLoginViewModel(clipBoardService);
            viewModel.Username = "Username";
            viewModel.Password = "Password";
            viewModel.LoginCommand.Execute(null);
            viewModel.LoginInfo.Should().Be($"Username: Username \nPassword: Password");
        }

        [Test]
        public void TestClipBoardWithMoq()
        {
            string contentsSavedInClipBoard = "Hey there ;)";

            var mockClipBoardService = new Mock<IClipBoardService>();
            mockClipBoardService.Setup(m => m.GetContentsFromTheClipBoardAsync())
                .ReturnsAsync(contentsSavedInClipBoard);

            mockClipBoardService.Setup(m => m.SetTheContentsToTheClipBoardAsync(It.IsAny<string>()))
                .Callback<string>(content => contentsSavedInClipBoard = content);
            var viewModel = new UserLoginViewModel(mockClipBoardService.Object);

            viewModel.GetClipBoardContentCommand.Execute(null);
            viewModel.LoginInfo.Should().Be("Hey there ;)");
        }
    }
}