using System.Collections.ObjectModel;
using System.ComponentModel;
using AnimeCatalog.Models;
using AnimeCatalog.Services;
using Plugin.Maui.Audio;

namespace AnimeCatalog.ViewModels;

public class WatchedPageViewModel : INotifyPropertyChanged
{
    public ObservableCollection<AnimeWatchList> AnimeWatchListItems { get; set; } = new ObservableCollection<AnimeWatchList>();

    private readonly AudioViewModel audioViewModel = new AudioViewModel();

    public event PropertyChangedEventHandler PropertyChanged;

    public async void AddOrUpdateWatchListAsync(AnimeWatchList animeWatchList)
    {
        var existingItem = DB.GetAnimeWatchListItem(animeWatchList.AnimeName);

        if (existingItem != null)
        {
            existingItem.UserRating = animeWatchList.UserRating;
            DB.UpdateWatchlistItem(existingItem);
        }
        else
        {
            DB.AddToWatchlist(animeWatchList);
        }

        if (audioViewModel != null)
        {
            await audioViewModel.PlayAudioAsync("strongpunch.mp3");
        }

        LoadAnimeWatchList();
    }

    public void LoadAnimeWatchList()
    {
        AnimeWatchListItems.Clear();
        var items = DB.GetWatchlist();
        foreach (var item in items)
        {
            AnimeWatchListItems.Add(item);
        }
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
