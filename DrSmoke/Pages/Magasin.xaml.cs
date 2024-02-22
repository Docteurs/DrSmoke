using DrSmoke.Models;
using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;
using System.Text.Json;

namespace DrSmoke.Pages;

public partial class Magasin : ContentPage
{
    public string codePost = string.Empty;
    private Requete.RequeteApi _apiService;
    public Magasin()
    {
        InitializeComponent();
        _apiService = new Requete.RequeteApi();
        allMagasin();
        
    }
    private async void Testing(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "Cliked", "OK");
    }

    private async void GoToMagasin(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.ProduitMagasin());
    }

    private async void allMagasin()
    {
        try
        {
            await _apiService.RefreshDataAsync();

            List<Models.Magasin> magasinList = _apiService.Magasin;

            if (magasinList != null && magasinList.Count > 0) 
            {
                ScrollView scrollView = new ScrollView();
                Content = scrollView;

                Grid grid = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(100) }
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition()
                    }
                };

                BoxView boxView = new BoxView
                {
                    BackgroundColor = Color.FromRgb(249, 246, 246)
                };
                grid.Add(boxView);

                Image image = new Image
                {
                    Source = "logodrsmoke_new.png.webp",
                    Margin = new Thickness(10, 10, 10, 10),
                    HorizontalOptions = LayoutOptions.Start
                };
                grid.Add(image, 0, 0);

                ImageButton imageButton = new ImageButton
                {
                    Source = "user.png",
                    HorizontalOptions = LayoutOptions.End,
                    WidthRequest = 25,
                    HeightRequest = 25,
                    Margin = new Thickness(10, 10, 10, 10),
                    BackgroundColor = Color.FromRgb(249, 246, 246)
                };
                grid.Add(imageButton, 0, 0);

                Label labelTitle = new Label
                {
                    Text = "DÉCOUVRIR TOUTES NOS BOUTIQUES",
                    TextColor = Color.FromRgb(134, 131, 131),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = 22
                };
                grid.Add(labelTitle, 0, 1);

                int rowCount = 2; // Commencez à partir de la troisième ligne
                foreach (var magasin in magasinList)
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                    Frame frame = new Frame
                    {
                        WidthRequest = 300,
                        Margin = new Thickness(10, 10, 10, 10),
                        BorderColor = Color.FromRgb(249, 246, 246)
                    };

                    StackLayout frameLayout = new StackLayout();
                    /*await DisplayAlert("Alert", magasin.ImgUrl, "OK");*/
                    frameLayout.Children.Add(new Image { Source = $"{magasin.ImgUrl}" });
                    frameLayout.Children.Add(new Label { Text = $"Ville: {magasin.Ville}" });

                    if (magasin.Code_postal.ToString().Length >= 3)
                    {
                        codePost = $"0{magasin.Code_postal}";
                    }

                    frameLayout.Children.Add(new Label { Text = $"Code postal: {codePost}" });
                    frameLayout.Children.Add(new Label { Text = "test" });

                    frameLayout.Children.Add(new Label { Text = $"Lundi: {magasin.HoraireLundi}" });
                    frameLayout.Children.Add(new Label { Text = $"Mardi: {magasin.HoraireMardi}" });
                    frameLayout.Children.Add(new Label { Text = $"Mercredi: {magasin.HoraireMercredi}" });
                    frameLayout.Children.Add(new Label { Text = $"Jeudi: {magasin.HoraireJeudi}" });
                    frameLayout.Children.Add(new Label { Text = $"Vendredi: {magasin.HoraireVendredi}" });
                    frameLayout.Children.Add(new Label { Text = $"Samedi: {magasin.HoraireSamedi}" });
                    frameLayout.Children.Add(new Label { Text = $"Dimanche: {magasin.HoraireDimanche}" });
                    Button goBoutique = new Button()
                    {
                        Text = "Voir le magasin"
                    };

                    goBoutique.Clicked += async (sender, args) =>
                    {

                        var navigationParameter = new ShellNavigationQueryParameters
                        {
                            { "Uuid", magasin.Uuid}
                        };

                        await Shell.Current.GoToAsync($"MagasinEtProduit", navigationParameter);

                    };

                    frameLayout.Children.Add(goBoutique);

                    frame.Content = frameLayout;
                    grid.Add(frame, 0, rowCount);
                    rowCount++;
                }

                scrollView.Content = grid;
            }
            else
            {
                await DisplayAlert("Alert", "Aucun magasin pôur le moment", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", $"Une alerte est survenue {ex.ToString()}", "OK");
        }
    }
    private void AllerAuMagasin()
    {
        // Gérer l'événement de clic pour le bouton "Voir le magasin"
        // Vous pouvez utiliser le paramètre 'index' pour identifier lequel des boutons a été cliqué
    }




}