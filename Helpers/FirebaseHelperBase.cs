namespace EcoDive_Integradora.Helpers
{
    public abstract class FirebaseHelperBase
    {
        public abstract async Task<List<Producto>> GetAllProductis();
    }
}