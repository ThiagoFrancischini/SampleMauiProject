using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Services
{
    public interface ITravelService
    {
        ObservableCollection<TravelEntry> GetEntries();
        void AddEntry(TravelEntry entry);
        void UpdateEntry(TravelEntry entry);
    }

    public class TravelService : ITravelService
    {
        private readonly ObservableCollection<TravelEntry> _entries = new();

        public ObservableCollection<TravelEntry> GetEntries() => _entries;

        public void AddEntry(TravelEntry entry) => _entries.Add(entry);

        public void UpdateEntry(TravelEntry entry)
        {
            var existing = _entries.FirstOrDefault(e => e.Id == entry.Id);
            if (existing != null)
            {
                var index = _entries.IndexOf(existing);
                _entries[index] = entry;
            }
        }
    }
}
