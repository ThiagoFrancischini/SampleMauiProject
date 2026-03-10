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
    public class EditViewModel : BaseViewModel
    {
        private readonly ITravelService _travelService;
        private TravelEntry _entry;

        public TravelEntry Entry
        {
            get => _entry;
            set => SetProperty(ref _entry, value);
        }

        public ICommand SaveCommand { get; }

        public EditViewModel(ITravelService travelService)
        {
            _travelService = travelService;

            SaveCommand = new Command(async () => { await OnSaveCommand(); });
        }

        public void LoadEntry(string id)
        {
            if (Guid.TryParse(id, out Guid guidId))
            {
                Entry = _travelService.GetEntries().FirstOrDefault(x => x.Id == guidId);
            }
        }

        private async Task OnSaveCommand()
        {
            bool confirmou = await Application.Current.Windows[0].Page.DisplayAlert(
                "Confirmação",              
                "Deseja alterar este item?",
                "Sim",                       
                "Cancelar"                  
            );

            if (confirmou)
            {
                //Importante: aqui seria uma chamada de API ou Repositorio para alterar o registro, mas como esta tudo em memoria não precisa gravar nada

                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
