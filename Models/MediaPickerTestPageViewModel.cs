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
        public ICommand TakePictureCommand { get; private set; }

        public MediaPickerTestPageViewModel()
        {
            OpenImageCommand = new Command(async () => await OpenImage());

            TakePictureCommand = new Command(async () => await TakePicture());
        }

        private async Task<FileResult> OpenImage()
        {
            var result = await MediaPicker.PickPhotoAsync();

            return result;
        }

        private async Task<FileResult> TakePicture()
        {
            PermissionStatus cameraStatus = await Permissions.CheckStatusAsync<Permissions.Camera>();

            if(cameraStatus != PermissionStatus.Granted)
            {
                cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
            }

            var result = await MediaPicker.CapturePhotoAsync();

            return result;
        }
    }
}
