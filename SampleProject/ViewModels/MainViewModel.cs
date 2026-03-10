using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SampleProject.Models;
using SampleProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleProject.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly ITravelService _travelService;

        private ObservableCollection<TravelEntry> _items;
        public ICommand GoToAddPageCommand { get; }
        public ICommand EditEntryCommand { get; }

        public ObservableCollection<TravelEntry> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public MainViewModel(ITravelService travelService)
        {
            _travelService = travelService;
            Items = _travelService.GetEntries();

            GoToAddPageCommand = new Command(
                execute: async () => await OnGoToAddPageCommand(),
                canExecute: () => true
            );

            EditEntryCommand = new Command<TravelEntry>(async (TravelEntry model) =>
            {
                await OnEditEntryCommand(model);
            });
        }

        private async Task OnGoToAddPageCommand()
        {
            await Shell.Current.GoToAsync("AddPage");
        }

        private async Task OnEditEntryCommand(TravelEntry entry)
        {
            await Shell.Current.GoToAsync($"EditPage?id={entry.Id}");
        }
    }
}
