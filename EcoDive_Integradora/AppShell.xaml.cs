namespace EcoDive_Integradora
{
    public partial class AppShell : Shell
    {
        public string UsuarioCorreo { get; private set; }

        public AppShell(string correoUsuario)
        {
            InitializeComponent();
            UsuarioCorreo = correoUsuario;
        }

        public AppShell() : this("correo@desconocido.com") { }
    }
}