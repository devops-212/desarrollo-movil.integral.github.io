using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoDive_Integradora.Models;



namespace EcoDive_Integradora.Helpers
{
    public class FirebaseHelper
    {
        private readonly FirebaseClient firebaseClient = new FirebaseClient("https://ecodivemareaazul-default-rtdb.firebaseio.com/");

        // ✅ Obtener mensajes del formulario (desde la PWA)
        public async Task<List<Producto>> GetMensajesFormulario()
        {
            var mensajes = await firebaseClient
                .Child("Productos") // Firebase ya guarda los datos del formulario aquí
                .OnceAsync<Producto>();

            return mensajes.Select(p =>
            {
                var msg = p.Object;
                msg.Id = p.Key;
                return msg;
            }).ToList();
        }

        // ✅ Obtener comentarios de la app (con categorías)
        public async Task<List<Interno>> GetComentariosApp()
        {
            var comentarios = await firebaseClient
                .Child("Comentarios")
                .OnceAsync<Interno>();

            return comentarios.Select(c =>
            {
                var comentario = c.Object;
                comentario.Id = c.Key;
                return comentario;
            }).ToList();
        }


        // ✅ CRUD para productos
        public async Task<List<Producto>> GetAllProductos()
        {
            var productos = await firebaseClient
                .Child("Productos")
                .OnceAsync<Producto>();

            return productos.Select(p =>
            {
                var producto = p.Object;
                producto.Id = p.Key;
                return producto;
            }).ToList();
        }

        public async Task<Producto?> GetProductoById(string id)
        {
            var productos = await firebaseClient
                .Child("Productos")
                .OnceAsync<Producto>();

            var productoData = productos.FirstOrDefault(p => p.Key == id);

            if (productoData != null)
            {
                var producto = productoData.Object;
                producto.Id = productoData.Key;
                return producto;
            }

            return null;
        }

        public async Task UpdateInterno(string id, Interno interno)
        {
            await firebaseClient
                .Child("Comentarios") // Asegúrate de que el nodo coincida con tu base de datos
                .Child(id)
                .PutAsync(interno);
        }
        public async Task UpdateProducto(string id, Producto producto)
        {
            await firebaseClient
                .Child("Productos")
                .Child(id)
                .PutAsync(producto);
        }
        public async Task DeleteProducto(string id)
        {
            await firebaseClient
                .Child("Productos")
                .Child(id)
                .DeleteAsync();
        }

        // ✅ Guardar comentario desde la app con categoría
        public async Task GuardarComentario(string nombre, string contacto, string comentario)
        {
            await firebaseClient
                .Child("Comentarios")
                .PostAsync(new
                {
                    Nombre = nombre,
                    Contacto = contacto,
                    Comentario = comentario
                });
        }

        // ✅ Autenticación de usuarios
        public async Task<bool> RegisterUser(User user)
        {
            await firebaseClient
                .Child("Users")
                .PostAsync(user);
            return true;
        }

        public async Task<User?> GetUser(string username, string password)
        {
            var users = await firebaseClient
                .Child("Users")
                .OnceAsync<User>();

            return users
                .Where(u => u.Object.Email == username && u.Object.Password == password)
                .Select(u =>
                {
                    var usr = u.Object;
                    usr.Id = u.Key;
                    return usr;
                })
                .FirstOrDefault();
        }

        public async Task<string?> ObtenerRolPorCorreo(string correo)
        {
            var usuarios = await firebaseClient
                .Child("Users")
                .OnceAsync<User>();

            var usuario = usuarios
                .FirstOrDefault(u => u.Object.Email.Equals(correo, System.StringComparison.OrdinalIgnoreCase));

            return usuario?.Object?.Rol;
        }

        public async Task<bool> ExisteUsuario(string correo)
        {
            var usuarios = await firebaseClient
                .Child("Users")
                .OnceAsync<User>();

            return usuarios
                .Any(u => u.Object.Email.Equals(correo, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
