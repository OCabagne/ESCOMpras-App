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

        private static async Task<T> GetTAsync<T>(string url, string key, int mins = 1, bool forceRefresh = false)
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
            catch (Exception ex)
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

        public static Task<List<Producto>> GetProductosTipo(int id) =>
            GetTAsync<List<Producto>>($"/productosTipo/{id}", "GetProductos", 5, true);

        public static Task<List<Producto>> RefreshProductos() =>
            GetTAsync<List<Producto>>("/productos", "GetProductos", 5, true);

        public static Task<Producto> GetProducto(int idProducto) =>
            GetTAsync<Producto>($"/producto/{idProducto}", "GetProducto", 0);

        public static Task<List<Producto>> GetProductosByTienda(int idTienda) =>
            GetTAsync<List<Producto>>($"/productoTienda/{idTienda}", "GetProductosByTienda", 5, true);

        public static Task<List<Producto>> SearchProducto(string buscar) =>
            GetTAsync<List<Producto>>($"/buscarSimilar/{buscar}", "buscarProducto", 1, true);
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

        public static Task<List<Producto>> GetProductos(int id) =>
            GetTAsync<List<Producto>>($"/getProductosEscuela/{id}", "GetProductos", 5, true);

        public static async void FinalizarOrden(int id)
        {
            var json = JsonConvert.SerializeObject(id);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/RecibirOrden/{id}", content);

            if (!response.IsSuccessStatusCode)
                Console.WriteLine(">: Error");
        }

        public static async void CancelarOrden(int id)
        {
            var json = JsonConvert.SerializeObject(id);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/CancelarOrden/{id}", content);

            if (!response.IsSuccessStatusCode)
                Console.WriteLine(">: Error");
        }

        public static async void EnviarOrden(int id)
        {
            var json = JsonConvert.SerializeObject(id);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/EnviarOrden/{id}", content);

            if (!response.IsSuccessStatusCode)
                Console.WriteLine(">: Error");
        }

        public static async void AceptarOrden(int id)
        {
            var json = JsonConvert.SerializeObject(id);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/AprobarOrden/{id}", content);

            if (!response.IsSuccessStatusCode)
                Console.WriteLine(">: Error");
        }

        public static async void RechazarOrden(int id)
        {
            var json = JsonConvert.SerializeObject(id);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/RechazarOrden/{id}", content);

            if (!response.IsSuccessStatusCode)
                Console.WriteLine(">: Error");
        }

        public static async Task<bool> ConfirmarClave(int id, string key)
        {
            var json = JsonConvert.SerializeObject(id);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/ConfirmarClave/{id}/{key}", content);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public static async Task<bool> GenerarClave(int id)
        {
            var json = JsonConvert.SerializeObject(id);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/GenerarClave/{id}", content);

            if (!response.IsSuccessStatusCode)
                return false;

            return true;
        }

        public static Task<string> GetClave(int id) =>
            GetTAsync<string>($"/GetClave/{id}", "GetClave", 0, true);
    }
}
