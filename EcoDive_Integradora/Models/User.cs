namespace EcoDive_Integradora.Models
{
    public class User
    {
        public string Id { get; set; } // Clave generada por Firebase
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; } // "admin" o "usuario"
    }
}