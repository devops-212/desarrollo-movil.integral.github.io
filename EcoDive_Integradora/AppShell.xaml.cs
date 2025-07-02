using EcoDive_Integradora.Views;

namespace EcoDive_Integradora
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registrar la ruta para navegación por Shell
            Routing.RegisterRoute(nameof(AddProductPage), typeof(AddProductPage));
            Routing.RegisterRoute(nameof(EditProductPage), typeof(EditProductPage));
            Routing.RegisterRoute(nameof(SearchProductPage), typeof(SearchProductPage));
            Routing.RegisterRoute(nameof(ListProductsPage), typeof(ListProductsPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));

        }
    }
}
