using System.Collections.ObjectModel;
using System.ComponentModel;
using AnimeCatalog.Models;
using AnimeCatalog.Services;

namespace AnimeCatalog.ViewModels;

public class AnimeViewModel : INotifyPropertyChanged
{
    private JikanApiClient client = new JikanApiClient();
    public ObservableCollection<Anime> TopAnimes { get; set; } = new ObservableCollection<Anime>();
    public ObservableCollection<Anime> FallAnimes { get; set; } = new ObservableCollection<Anime>();

    public event PropertyChangedEventHandler PropertyChanged;

    public async Task LoadTopAnimeAsync()
    {
        var animeList = await client.GetTopAnimeAsync();
        if (animeList != null)
        {
            TopAnimes.Clear();
            foreach (var anime in animeList)
            {
                TopAnimes.Add(anime);
            }
            OnPropertyChanged(nameof(TopAnimes));
        }
    }
    public async Task LoadFallAnimeAsync()
    {
        var animeList = await client.GetFallAnimeAsync();
        if (animeList != null)
        {
            FallAnimes.Clear();
            foreach (var anime in animeList)
            {
                FallAnimes.Add(anime);
            }
            OnPropertyChanged(nameof(FallAnimes));
        }
    }
    public async Task LoadDataAsync()
    {
        await LoadTopAnimeAsync();
        await LoadFallAnimeAsync();
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}