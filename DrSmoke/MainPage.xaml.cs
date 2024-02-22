using DrSmoke.Models;
using DrSmoke.Requete;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace DrSmoke
{
    public partial class MainPage : ContentPage
    {
        public bool FormConnexion = true;
        public bool FormEnregistrer = false;
        private Requete.RequeteApi _apiService;
        public MainPage()
        {
            InitializeComponent();

            _apiService = new Requete.RequeteApi();

            ConnexionForm.IsVisible = true;
            EnregsitrementForm.IsVisible = false;
        }
        private async void Testing(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Cliked", "OK");
        }

        private void ButtonConnexion(object sender, EventArgs e)
        {
            // Activer le formulaire de connexion
            FormConnexion = true;
            ConnexionForm.IsVisible = true;

            // Désactiver le formulaire d'enregistrement
            FormEnregistrer = false;
            EnregsitrementForm.IsVisible = false;
        }

        private void ButtonEnregistrer(object sender, EventArgs e)
        {
            // Activer le formulaire d'enregistrement
            FormEnregistrer = true;
            EnregsitrementForm.IsVisible = true;

            // Désactiver le formulaire de connexion
            FormConnexion = false;
            ConnexionForm.IsVisible = false;
        }

        private async void OnConnexion(object sender, EventArgs e)
        {
            string email = EntryEmailConnection.Text;
            string password = EntryPasswordConnection.Text;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) )
            {
                Models.Connexion connexion = new Models.Connexion 
                { 
                    Email = email, 
                    Password = password
                };

                try
                {
                    var response = await _apiService.ConnexionUser(connexion);
                    if (response == true)
                    {
                        var token = await SecureStorage.GetAsync("oauth_token");
                        await DisplayAlert("Alert", "Vous êtes connecter", "OK");
                        await Navigation.PushAsync(new Pages.Magasin());
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Veuillez verifier vos identifiant", "OK");
                    }
                }
                catch
                {
                    await DisplayAlert("Alert", "Une erreur est survenue", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alert", "Tout les champs sont requit", "OK");
            }

        }

        private async void OnEnregistrement(object sender, EventArgs e)
        {
            string email = EntryEmail.Text;
            string password = EntryPassword.Text;
            string confirmPassword = EntryConfirmPassword.Text;
            string name = EntryName.Text;
            string prenom = EntryPrenom.Text;
            string addresse = EntryAddresse.Text;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(confirmPassword) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(prenom) && !string.IsNullOrEmpty(addresse) )
            {
                if (password == confirmPassword)
                {
                    Models.Inscription inscription = new Models.Inscription()
                    {
                        Email = email,
                        Password = password,
                        Nom = name,
                        Prenom = prenom,
                        Address = addresse,
                    };
                    try
                    {
                        var response = await _apiService.InscriptionUser(inscription);
                        await DisplayAlert("Alert", $"{response.ToString()}", "OK");
                    }
                    catch   
                    {
                        await DisplayAlert("Alert", "Une erreur est survenue", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Les mots de passe ne correspondent pas", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alert", "Tout les champs sont requit", "OK");
            }
        }
    }

}
