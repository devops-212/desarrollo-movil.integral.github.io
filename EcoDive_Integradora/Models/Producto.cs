namespace EcoDive_Integradora.Models
{
    public class Producto
    {
        public string Id { get; set; }
        public string name { get; set; }       // Nombre desde la PWA
        public string email { get; set; }      // Correo desde la PWA
        public string message { get; set; }    // Mensaje desde la PWA

        // Campos agregados para edición de estado en MAUI
        public string Categoria { get; set; } = "";
        public string Subcategoria { get; set; } = "";
        public string Estado { get; set; } = "";
    }
}
