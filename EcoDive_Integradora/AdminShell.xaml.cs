namespace EcoDive_Integradora
{
    public partial class AdminShell : Shell
    {
        public string AdminCorreo { get; private set; }

        public AdminShell(string correoAdmin)
        {
            InitializeComponent();
            AdminCorreo = correoAdmin;
        }

        public AdminShell() : this("admin@gmail.com") { }
    }
}