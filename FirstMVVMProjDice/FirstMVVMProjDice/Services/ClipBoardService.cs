using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FirstMVVMProjLogin.Services
{
    public interface IClipBoardService
    {
        Task<string> GetContentsFromTheClipBoardAsync();
        Task SetTheContentsToTheClipBoardAsync(string contents);
    }

    public class XamarinEssentialsClipBoardService : IClipBoardService
    {
        public Task<string> GetContentsFromTheClipBoardAsync()
        {
            return Clipboard.GetTextAsync();
        }

        public Task SetTheContentsToTheClipBoardAsync(string contents)
        {
            return Clipboard.SetTextAsync(contents);
        }
    }
}
