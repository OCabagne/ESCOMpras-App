using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ESCOMpras.Models
{
    internal class internetEscompras
    {
        static string BaseUrl = "https://escompras-api.herokuapp.com";
        static HttpClient client;
        static internetEscompras() 
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public static async Task<Cliente> GetCliente(int id)
        {
            Cliente resultado = await client.GetFromJsonAsync<Cliente>($"cliente/{id}");
            return resultado;
        }
        
        public static async Task<List<Producto>> GetProductos()
        {
            string json = await client.GetStringAsync("/productos");
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json);
            return productos;
        }
    }
}
