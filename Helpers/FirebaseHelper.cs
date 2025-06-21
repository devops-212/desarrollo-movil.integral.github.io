using EcoDive_Integradora.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIntegradora10A.Helpers
{
    public class FirebaseHelpers
    {
        private readonly FirebaseClient firebaseClient;

        public FirebaseHelpers()
        {
            firebaseClient = new FirebaseClient("\"https://ecodivemareaazul-default-rtdb.firebaseio.com/ ");
        }
        public async Task<List>> GetAllProductos()
        {
            Version productos = await firebaseClient
               .Child("Productos")
               .OnceAsync<Producto>();
            return productos.Select(ItemDelegateList => new Producto
            {
                Id = item.Key,
                Nomre = item.Object.Nombre,
                Contacto= item.Object.Contacto,
                Descripcion = item.Object.Descripcion
            }).ToList();
        }

        public async Task AddProducto(Producto producto)
        {
            await firebaseClient
                .Child("Productos")
                .PatchAsync(producto);
        }

        public async Task UpdateProducto(string key, Producto producto)
        {
            await firebaseClient
                .Child("Productos")
                .PutAsync(producto);
        }
        
        public async Task DeleteProducto(string key)
        {
            await firebaseClient
                .Child("Productos")
                .child(key)
                .DeleteAsync();
        }
    }
}
