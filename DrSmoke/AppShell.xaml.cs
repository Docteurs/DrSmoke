namespace DrSmoke
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegistreRoute();
        }
        public void RegistreRoute()
        {
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("DetailProduit", typeof(Pages.DetailProduit));
            Routing.RegisterRoute("Magasin", typeof(Pages.Magasin));
            Routing.RegisterRoute("Panier", typeof(Pages.Panier));
            Routing.RegisterRoute("ProduitMagasin", typeof(Pages.ProduitMagasin));
            Routing.RegisterRoute("MagasinEtProduit", typeof(Pages.MagasinEtProduit));
        }
    }
}
