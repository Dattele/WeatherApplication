using AnimeCatalog.Models;

namespace AnimeCatalog.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(Anime anime)
	{
		InitializeComponent();

        animeLabel.Text = anime.Title;
        summaryLabel.Text = anime.Synopsis;
        genreEntry.Text = string.Join(", ", anime.Genres.Select(g => g.GenreName));
        ratingEntry.Text = anime.Score;
	}
    private async void homeClickedAsync(object sender, EventArgs e)
    {
        HomePage homePage = new HomePage();
        await Navigation.PushAsync(homePage, true);
    }

    private async void Button_ClickedAsync(object sender, EventArgs e)
    {
        string animeTitle = animeLabel.Text;
        if (ratingPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Select a rating", "OK");
            return;
        }
        string userRating = ratingPicker.SelectedItem.ToString();
        WatchedPage watchedPage = new WatchedPage(animeTitle, userRating);
        await Navigation.PushAsync(watchedPage, true);
    }
}