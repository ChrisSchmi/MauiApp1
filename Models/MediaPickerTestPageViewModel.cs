using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.Models
{
    public class MediaPickerTestPageViewModel
    {

        public ICommand OpenImageCommand { get; private set; }


        public MediaPickerTestPageViewModel()
        {
            OpenImageCommand = new Command(async () => await OpenImage());
        }


        private async Task<FileResult> OpenImage()
        {
            var result = await MediaPicker.PickPhotoAsync();


            return result;
        }
    }
}
