using EcoDive_Integradora.Views;

namespace EcoDive_Integradora
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Inicia solo al menu//  MainPage = new NavigationPage(new AppShell());

            //Inicia con login 
            MainPage = new NavigationPage(new LoginPage());

        }
    }

}
