using AnimeCatalog.ViewModels;
using AnimeCatalog.Models;

namespace AnimeCatalog.Views;

public partial class AnimePage : ContentPage
{
	public AnimePage(string searchText)
	{
		InitializeComponent();
        ResultsSearchBar.Text = searchText;

        var viewModel = new SearchAnimeViewModel();
        this.BindingContext = viewModel;
        viewModel.LoadSearchResults(searchText);
    }
    private async void homeClickedAsync(object sender, EventArgs e)
    {
        HomePage homePage = new HomePage();
        await Navigation.PushAsync(homePage, true);
    }

    private void ResultsSearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        string searchText = ResultsSearchBar.Text;
        var viewModel = new SearchAnimeViewModel();
        this.BindingContext = viewModel;
        viewModel.LoadSearchResults(searchText);
    }

    private async void SearchResultsListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
    {
        if (SearchResultsListView.SelectedItem != null)
        {
            Anime anime = SearchResultsListView.SelectedItem as Anime;
            DetailsPage detailsPage = new DetailsPage(anime);
            await Navigation.PushAsync(detailsPage, true);

            SearchResultsListView.SelectedItem = null;
        }
    }
}