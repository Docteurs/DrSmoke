namespace DrSmoke.Pages;

public partial class ProduitMagasin : ContentPage
{
	public ProduitMagasin()
	{
		InitializeComponent();
	}
    private async void Testing(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "Cliked", "OK");
    }
    private async void GoToProduitDetail(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.DetailProduit());
    }
}