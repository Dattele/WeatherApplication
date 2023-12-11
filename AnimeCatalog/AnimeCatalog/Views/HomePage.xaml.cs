using AnimeCatalog.ViewModels;
using AnimeCatalog.Models;

namespace AnimeCatalog.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        LoadHomePageAsync();
    }
    private async void LoadHomePageAsync()
    {
        var viewModel = new AnimeViewModel();
        this.BindingContext = viewModel;
        await viewModel.LoadDataAsync();
    }

    private async void SearchBar_SearchButtonPressedAsync(object sender, EventArgs e)
    {
        string searchText = AnimeSearchBar.Text;
        AnimePage animePage = new AnimePage(searchText);
        await Navigation.PushAsync(animePage, true);
    }

    private async void FallListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
    {
        if (FallListView.SelectedItem != null)
        {
            Anime anime = FallListView.SelectedItem as Anime;
            DetailsPage detailsPage = new DetailsPage(anime);
            await Navigation.PushAsync(detailsPage, true);

            FallListView.SelectedItem = null;
        }
    }

    private async void AnimeListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
    {
        if (AnimeListView.SelectedItem != null)
        {
            Anime anime = AnimeListView.SelectedItem as Anime;
            DetailsPage detailsPage = new DetailsPage(anime);
            await Navigation.PushAsync(detailsPage, true);

            AnimeListView.SelectedItem = null;
        }
    }

    private async void Button_ClickedAsync(object sender, EventArgs e)
    {
        WatchedPage watchedPage = new WatchedPage();
        await Navigation.PushAsync(watchedPage, true);
    }
}