using System.Net.Http.Json;
using System.Text.Json;

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
            //string jsonString = await client.GetStringAsync($"/cliente/{id}");
            Cliente resultado = await client.GetFromJsonAsync<Cliente>($"/cliente/{id}");
            //var result = JsonConvert.DeserializeObject<List<Cliente>>(json);
            //Cliente result = JsonSerializer.Deserialize<Cliente>(jsonString);
            return resultado;
        }
        
        /*
        public static async Task<IEnumerable<Producto>> GetProductos()
        {
            var json = await client.GetStringAsync("productos");
            var result = JsonConvert.DeserializeObject<IEnumerable<Producto>>(json);
            return result;
        }
        */
    }
}
