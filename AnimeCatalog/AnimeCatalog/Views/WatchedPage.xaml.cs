using AnimeCatalog.ViewModels;
using AnimeCatalog.Models;
using AnimeCatalog.Services;

namespace AnimeCatalog.Views;

public partial class WatchedPage : ContentPage
{
    public List<AnimeWatchList> Animes { get; set; }
    private readonly AudioViewModel audioViewModel = new AudioViewModel();
    public WatchedPage()
    {
        InitializeComponent();

        RefreshRecords();
    }
    public WatchedPage(string animeTitle, string userRating)
	{
		InitializeComponent();

        var viewModel = new WatchedPageViewModel();
        this.BindingContext = viewModel;

        viewModel.AddOrUpdateWatchListAsync(new AnimeWatchList
        {
            AnimeName = animeTitle,
            UserRating = userRating
        });

        RefreshRecords();
    }
    private async void homeClickedAsync(object sender, EventArgs e)
    {
        HomePage homePage = new HomePage();
        await Navigation.PushAsync(homePage, true);
    }
    private void RefreshRecords()
    {
        if (byTitle.IsChecked) Animes = DB.GetWatchlist().OrderBy(ani => ani.AnimeName).ToList();
        else Animes = DB.GetWatchlist().OrderByDescending(ani => Int32.Parse(ani.UserRating)).ToList();
    }

    private async void watchedListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;

        string userSelect = await DisplayActionSheet("Operation", "Cancel", null, "Modify Anime", "Remove Anime");
        AnimeWatchList anime = watchedListView.SelectedItem as AnimeWatchList;

        if (userSelect == "Modify Anime")
        {
            ModifyPage modifyPage = new ModifyPage(anime);
            await Navigation.PushAsync(modifyPage, true);
        }
        else if (userSelect == "Remove Anime")
        {
            string confirm = await DisplayActionSheet("Confirm", "Yes", "No");
            if (confirm == "Yes")
            {
                if (anime != null)
                {
                    int removed = DB.RemoveFromWatchlist(anime.Id);
                    if (audioViewModel != null)
                    {
                        await audioViewModel.PlayAudioAsync("nani.mp3");
                    }
                    if (removed > 0)
                    {
                        RefreshRecords();
                        watchedListView.ItemsSource = Animes;
                    }
                }
            }
        }
        watchedListView.SelectedItem = null;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshRecords();
        watchedListView.ItemsSource = Animes.ToList();
    }

    private void byTitle_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RefreshRecords();
        watchedListView.ItemsSource = Animes;
    }

    private void byRating_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RefreshRecords();
        watchedListView.ItemsSource = Animes;
    }
}