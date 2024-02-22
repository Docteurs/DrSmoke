namespace DrSmoke.Pages;

public partial class DetailProduit : ContentPage
{
    public string SelectedOption { get; set; }
    public string Image0 = "https://drsmoke.fr/wp-content/uploads/2023/11/Deep-Candy-Fleur-CBD-Production-Dr-Smoke-Fond-transparent.png";
	public string Image1 = "https://drsmoke.fr/wp-content/uploads/2023/11/Deep-Candy-Zoom-Fleur-CBD-Production-Dr-Smoke--100x100.png";
	public string Image2 = "https://drsmoke.fr/wp-content/uploads/2023/11/Fleurs-CBD-Production-Dr-Smoke--100x100.png";

    public DetailProduit()
	{
		InitializeComponent();
        picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
    }

    public void ClickImage0(object sender, EventArgs e) 
	{
		ImagePrincipale.Source = Image0;

    }
    public void ClickImage1(object sender, EventArgs e) 
	{
		ImagePrincipale.Source = Image1;

    }
    public void ClickImage2(object sender, EventArgs e)
	{
        ImagePrincipale.Source = Image2;
    }
    void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
        
        _displayLabel.Text = string.Format($"{value}");

    }

    private async void Testing(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "Clicked", "OK");
    }
    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            double prix = 0;
            SelectedOption = picker.SelectedItem.ToString();
            switch (SelectedOption)
            {
                case "1g":
                    prix = 5.99;
                    break;
                case "3g":
                    prix = 14.99;
                    break;
                case "5g":
                    prix = 24.99;
                    break;
                case "10g":
                    prix = 39.99;
                    break;
                case "25g":
                    prix = 89.99;
                    break;
                case "50g":
                    prix = 149.99;
                    break;
                default:
                    prix = 0;
                    break;
            }
            PrixOption.Text = $"{prix.ToString("0.00")} €";
        }
    }

    void OnButtonClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(SelectedOption))
        {
            DisplayAlert("Alert", $"Option sélectionnée : {SelectedOption}", "OK");
        }
        else
        {
            DisplayAlert("Alert", "Aucune option sélectionnée", "OK");
        }
    }
}