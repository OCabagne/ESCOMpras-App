using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;

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

        static async Task<T> GetTAsync<T>(string url, string key, int mins = 1, bool forceRefresh = false)
        {
            var json = string.Empty;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                json = Barrel.Current.Get<string>(key);
            else if (!forceRefresh && !Barrel.Current.IsExpired(key))
                json = Barrel.Current.Get<string>(key);

            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    json = await client.GetStringAsync(url);

                    Barrel.Current.Add(key, json, TimeSpan.FromMinutes(mins));
                }

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">: Unable to get information from Server." + ex.Message);
                throw ex;
            }
        }

        public static async Task NuevaOrden(Orden pedido)
        {
            try
            {
                var pedidoJson = JsonConvert.SerializeObject(pedido, Formatting.Indented);
                var content = new StringContent(pedidoJson);
                await client.PostAsync("/nuevaOrden", content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Task<Cliente> LogIn(string correo, string password) =>
            GetTAsync<Cliente>($"Login/{correo}/{password}", "Login");

        public static Task<Cliente> GetCliente(int id) =>
            GetTAsync<Cliente>($"/cliente/{id}", "GetCliente", 5);

        public static Task<List<Producto>> GetProductos() =>
            GetTAsync<List<Producto>>("/productos", "GetProductos", 5);

        public static Task<Producto> GetProducto(int idProducto) =>
            GetTAsync<Producto>($"/producto/{idProducto}", "GetProducto");

        /*
        public static Task<List<Orden>> GetOrdenes(int idCliente) =>
            GetTAsync<List<Orden>>($"/verOrdenes/{idCliente}", "GetPedidos");
        */
        public static Task<List<Orden>> GetOrdenes(int idCliente) =>
            GetTAsync<List<Orden>>($"/verOrdenes/%7Bid%7D?idCliente={idCliente}", "GetPedidos");

        public static Task<Compra> GetCompra(int idPedido) =>
            GetTAsync<Compra>($"/verCompras/{idPedido}", "GetCompras");


        public static Task<string> GetNombreEscuela(int idEscuela) =>
            GetTAsync<string>($"/escuelaNombre/{idEscuela}", "GetNombreEscuela");
        public static Task<string> GetNombreCliente(int idCliente) =>
            GetTAsync<string>($"/clienteNombre/{idCliente}", "GetNombreCliente");

        public static Task<string> GetNombreTienda(int idTienda) =>
            GetTAsync<string>($"/tiendaNombre/{idTienda}", "GetNombreTienda");

        /*
        public static async Task<Cliente> LogIn(string correo, string password)
        {
            try
            {
                Cliente usuario = await client.GetFromJsonAsync<Cliente>($"Login/{correo}/{password}");
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        */
        /*
        public static async Task<Cliente> GetCliente(int id)
        {
            try
            {
                Cliente resultado = await client.GetFromJsonAsync<Cliente>($"cliente/{id}");
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        */
        /*
        public static async Task<List<Producto>> GetProductos(int id)
        {

            try
            {
                List<Producto> obtenidos = new List<Producto>();
                string json1 = await client.GetStringAsync($"/tiendaEscuela/{id}"); // Obtiene los Id de las tiendas que ofrecen servicio a la escuela (id)
                List<Horaservicio> lista = JsonConvert.DeserializeObject<List<Horaservicio>>(json1);// Deserializar para obtener los idTienda
                foreach (Horaservicio horservicio in lista)
                {
                    int idTienda = horservicio.TiendaIdtienda;  // id de una tienda que ofrece servicio la escuela
                    string json2 = await client.GetStringAsync($"/productoEscuela/{idTienda}"); // Obtiene los productos vendidos por una tienda especifica
                    List<Producto> productos1 = JsonConvert.DeserializeObject<List<Producto>>(json2);   // Deserializa los productos vendidos por la tienda buscada
                    obtenidos.AddRange(productos1); // Añadimos los productos obtenidos a la lista final

                    productos1.Clear();     // Limpiamos la lista de productos obtenida
                }
                
                //string json = await client.GetStringAsync("/productos");    // Obtiene TODOS los productos registrados
                //List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json);
                

                return obtenidos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        */
    }
}
