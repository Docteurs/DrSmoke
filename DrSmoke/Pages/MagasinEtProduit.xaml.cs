using System;

namespace DrSmoke.Pages;

[QueryProperty(nameof(Uuid), "Uuid")]
public partial class MagasinEtProduit : ContentPage
{
    private string uuid = string.Empty;
    public string Uuid
    {
        get => uuid;
        set
        {
            uuid = value;
            OnPropertyChanged();
        }
    }

    public MagasinEtProduit()
	{
		InitializeComponent();
        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        testUuid();
    }

    public async void testUuid()
    {
        if (!string.IsNullOrEmpty(Uuid))
        {
            await DisplayAlert("Alert", Uuid, "OK");
        }
        else
        {
            await DisplayAlert("Alert", "Une erreur de navigation est survenue", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}