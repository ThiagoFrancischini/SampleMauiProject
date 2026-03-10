using SampleProject.Models;
using SampleProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleProject.ViewModels
{
    public class AddViewModel : BaseViewModel
    {
        private readonly ITravelService _travelService;
        public TravelEntry Entry { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand TakePhotoCommand { get; }

        public AddViewModel(ITravelService travelService)
        {
            _travelService = travelService;
            Entry = new TravelEntry();

            SaveCommand = new Command(async () =>
            {
                await OnSaveCommand();
            });

            TakePhotoCommand = new Command(async () => await TakePhotoAsync());
        }

        private async Task TakePhotoAsync()
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo != null) Entry.ImagePath = photo.FullPath;
        }

        private async Task OnSaveCommand()
        {
            Entry.Id = Guid.NewGuid();

            _travelService.AddEntry(Entry);

            await Application.Current.MainPage.DisplayAlert("Aviso", "Gravação concluída com sucesso!", "Ok");

            await Shell.Current.GoToAsync("..");
        }
    }
}
