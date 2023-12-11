using System.Collections.ObjectModel;
using System.ComponentModel;
using AnimeCatalog.Models;
using AnimeCatalog.Services;

namespace AnimeCatalog.ViewModels
{
    public class SearchAnimeViewModel : INotifyPropertyChanged
    {
        private JikanApiClient client = new JikanApiClient();
        public ObservableCollection<Anime> SearchResults { get; set; } = new ObservableCollection<Anime>();

        public event PropertyChangedEventHandler PropertyChanged;
        public async void LoadSearchResults(string searchText)
        {
            var resultsList = await client.SearchAnimeAsync(searchText);
            SearchResults.Clear();
            foreach (var anime in resultsList)
            {
                SearchResults.Add(anime);
            }
            OnPropertyChanged(nameof(SearchResults));
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
