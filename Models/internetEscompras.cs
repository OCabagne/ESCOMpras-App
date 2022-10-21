using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System.Diagnostics;
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

        public static async Task<int> NuevaOrden(Orden pedido)
        {
            try
            {
                var pedidoJson = JsonConvert.SerializeObject(pedido);
                //var content = new StringContent(pedidoJson);
                //var message = await client.PostAsync("/nuevaOrden", content);

                //var message = await client.PostAsJsonAsync("/nuevaOrden", pedido);

                var content = new StringContent(pedidoJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/nuevaOrden", content);

                var message = await response.Content.ReadAsStringAsync();
                int id = Int32.Parse(message);
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public static async Task<bool> NuevaCompra(Compra compra)
        {
            try
            {
                var pedidoJson = JsonConvert.SerializeObject(compra);
                var content = new StringContent(pedidoJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/nuevaCompra", content);
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static async Task BorrarOrden(int idOrden)
        {
            try
            {
                var cmd = await client.DeleteAsync($"/borrarOrden/{idOrden}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static async Task NuevoProducto(ProductoVM producto)
        {
            try
            {
                var Json = JsonConvert.SerializeObject(producto);
                var content = new StringContent(Json, Encoding.UTF8, "application/json");
                await client.PostAsync("/nuevoProducto", content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Task<Cliente> LogIn(string correo, string password) =>
            GetTAsync<Cliente>($"Login/{correo}/{password}", "Login", 0, true);

        public static Task<Tiendum> LogInTienda(string correo, string password) =>
            GetTAsync<Tiendum>($"LoginTienda/{correo}/{password}", "Login", 0, true);

        public static Task<Cliente> GetCliente(int id) =>
            GetTAsync<Cliente>($"/cliente/{id}", "GetCliente", 0, true);

        public static Task<List<Producto>> GetProductos() =>
            GetTAsync<List<Producto>>("/productos", "GetProductos", 5, true);

        public static Task<List<Producto>> RefreshProductos() =>
            GetTAsync<List<Producto>>("/productos", "GetProductos", 5, true);

        public static Task<Producto> GetProducto(int idProducto) =>
            GetTAsync<Producto>($"/producto/{idProducto}", "GetProducto", 0);

        public static Task<List<Producto>> GetProductosByTienda(int idTienda) =>
            GetTAsync<List<Producto>>($"/productoEscuela/{idTienda}", "GetProductosByTienda", 5, true);

        public static Task<List<OrdenVM>> GetOrdenes(int idCliente) =>
            GetTAsync<List<OrdenVM>>($"/verOrdenes/%7Bid%7D?idCliente={idCliente}", "GetPedidos", 0);

        public static Task<List<OrdenVM>> GetOrdenesTienda(int idTienda) =>
            GetTAsync<List<OrdenVM>>($"/verOrdenesTienda/{idTienda}", "GetPedidosTienda", 0);

        public static Task<Compra> GetCompra(int idPedido) =>
            GetTAsync<Compra>($"/verCompras/{idPedido}", "GetCompras", 0);

        public static Task<List<Escuela>> getEscuelas() =>
            GetTAsync<List<Escuela>>("/escuelas", "GetEscuelas");
        public static Task<string> GetNombreEscuela(int idEscuela) =>
            GetTAsync<string>($"/escuelaNombre/{idEscuela}", "GetNombreEscuela", 0);
        public static Task<string> GetNombreCliente(int idCliente) =>
            GetTAsync<string>($"/clienteNombre/{idCliente}", "GetNombreCliente", 5, true);

        public static Task<string> GetNombreTienda(int idTienda) =>
            GetTAsync<string>($"/tiendaNombre/{idTienda}", "GetNombreTienda");

        public static Task<Tiendum> GetTienda(int idTienda) =>
            GetTAsync<Tiendum>($"/tienda/{idTienda}", "GetTienda", 0, true);

        public async static void UpdateCliente(ClienteVM cliente)
        {
            var json = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/clienteActualizar/{cliente.Idcliente}", content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(">: ERROR");
            }
        }

        public async static void UpdateProducto(Producto _producto)
        {
            var json = JsonConvert.SerializeObject(_producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/actualizarProducto/{_producto.Idproducto}", content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(">: ERROR");
            }
        }

        public static async Task<List<Producto>> GetProductos(int id)
        {
            try
            {
                List<Producto> obtenidos = new List<Producto>();
                List<int> idTiendas = new List<int>();
                string json1 = await client.GetStringAsync($"/tiendaEscuela/{id}"); // Obtiene los Id de las tiendas que ofrecen servicio a la escuela (id)
                List<Horaservicio> lista = JsonConvert.DeserializeObject<List<Horaservicio>>(json1);// Deserializar para obtener los idTienda
                foreach (Horaservicio horservicio in lista)
                {
                    int idTienda = horservicio.TiendaIdtienda;  // id de una tienda que ofrece servicio la escuela
                    if (!idTiendas.Contains(idTienda))
                    {
                        idTiendas.Add(idTienda);
                        string json2 = await client.GetStringAsync($"/productoEscuela/{idTienda}"); // Obtiene los productos vendidos por una tienda especifica
                        List<Producto> productos1 = JsonConvert.DeserializeObject<List<Producto>>(json2);   // Deserializa los productos vendidos por la tienda buscada
                        foreach (Producto producto in productos1)
                        {
                            if (obtenidos.Contains(producto))
                            {
                                productos1.Remove(producto);
                            }
                        }
                        obtenidos.AddRange(productos1); // Añadimos los productos obtenidos a la lista final

                        productos1.Clear();     // Limpiamos la lista de productos obtenida
                    }
                }

                var json = JsonConvert.SerializeObject(obtenidos);

                return obtenidos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
