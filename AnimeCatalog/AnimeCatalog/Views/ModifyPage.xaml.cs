using AnimeCatalog.Models;
using AnimeCatalog.Services;

namespace AnimeCatalog.Views;

public partial class ModifyPage : ContentPage
{
    private AnimeWatchList animeWatchList;
    public ModifyPage(AnimeWatchList anime)
	{
		InitializeComponent();

        animeWatchList = anime;
		animeLabel.Text = animeWatchList.AnimeName;
        ratingPicker.SelectedItem = animeWatchList.UserRating;
    }

    private async void Button_ClickedAsync(object sender, EventArgs e)
    {
        animeWatchList.UserRating = ratingPicker.SelectedItem.ToString();
        DB.UpdateWatchlistItem(animeWatchList);
        await Navigation.PopAsync();
    }
}