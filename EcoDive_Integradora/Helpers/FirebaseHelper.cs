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

        // Agregar nuevo producto
        public async Task AddProducto(Producto producto)
        {
            await firebaseClient
                .Child("Productos")
                .PostAsync(producto);
        }

        // Obtener todos los productos
        public async Task<List<Producto>> GetAllProductos()
        {
            var productos = await firebaseClient
                .Child("Productos")
                .OnceAsync<Producto>();

            return productos.Select(p =>
            {
                var producto = p.Object;
                producto.Id = p.Key; // Asignamos la clave de Firebase como Id
                return producto;
            }).ToList();
        }

        // Obtener producto por ID
        public async Task<Producto> GetProductoById(string id)
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

        // Actualizar producto
        public async Task UpdateProducto(string id, Producto producto)
        {
            await firebaseClient
                .Child("Productos")
                .Child(id)
                .PutAsync(producto);
        }

        // Eliminar producto
        public async Task DeleteProducto(string id)
        {
            await firebaseClient
                .Child("Productos")
                .Child(id)
                .DeleteAsync();
        }

        // Guardar comentario (opcional)
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
        public async Task<bool> RegisterUser(User user)
        {
            await firebaseClient
                .Child("Users")
                .PostAsync(user);
            return true;
        }

        public async Task<User> GetUser(string username, string password)
        {
            var users = await firebaseClient
                .Child("Users")
                .OnceAsync<User>();

            return users
                .Where(u => u.Object.Username == username && u.Object.Password == password)
                .Select(u =>
                {
                    var usr = u.Object;
                    usr.Id = u.Key;
                    return usr;
                })
                .FirstOrDefault();
        }

    }
}
