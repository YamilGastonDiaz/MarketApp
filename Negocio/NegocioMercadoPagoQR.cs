using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Negocio
{
    public class NegocioMercadoPagoQR
    {
        private readonly string accessToken = "";
        private readonly string userId = "";
        private readonly string external_pos_id = "";

        public string CrearQR(decimal total, string referencia_idVenta)
        {
            string url = $"https://api.mercadopago.com/instore/orders/qr/seller/collectors/{userId}/pos/{external_pos_id}/qrs";

            var body = new
            {
                external_reference = referencia_idVenta,
                title = "Venta mostrador",
                description = "Pago en caja",
                total_amount = Math.Round(total, 2),
                items = new[]
                {
                new {
                    title = "Compra general",
                    quantity = 1,
                    unit_price = Math.Round(total, 2),
                    unit_measure = "unit",
                    total_amount = Math.Round(total, 2)
                }
            }
            };

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al generar QR: " + result);

            var responseString = response.Content.ReadAsStringAsync().Result;
            dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);

            return jsonResponse.qr_data;
        }

        public string ConsultarEstadoPago(string referencia) 
        {
            string url = $"https://api.mercadopago.com/merchant_orders/search?external_reference={referencia}";


            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = client.GetAsync(url).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al consultar pago: " + result);

            dynamic jsonResponse = JsonConvert.DeserializeObject(result);

            if (jsonResponse["elements"] == null || jsonResponse["elements"].Count == 0)
                return "pending"; // aún no hay pago

            var order = jsonResponse["elements"][0];

            // Validamos si hay pagos dentro de la orden
            if (order["payments"] == null || order["payments"].Count == 0)
                return order["status"]?.ToString() ?? "pending";


            string estado = order["payments"][0]["status"]?.ToString() ?? "pending";
            return estado; // puede ser: pending, approved, rejected, in_process, etc.
        }
    }    
}
 
