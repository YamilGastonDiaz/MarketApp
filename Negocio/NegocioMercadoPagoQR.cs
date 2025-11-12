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
        private readonly string accessToken = "APP_USR-6093676824884938-110516-5b0b3c61f6eea604e72a13e285f8790d-2175041084";
        private readonly string userId = "2175041084";
        private readonly string external_pos_id = "CAJA001";

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

        public string ConsultarEstadoPago(string ordenId) 
        {
            string url = $"https://api.mercadopago.com/merchant_orders/{ordenId}";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = client.GetAsync(url).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al consultar pago: " + result);

            dynamic jsonResponse = JsonConvert.DeserializeObject(result);

            if (jsonResponse["payments"] == null || jsonResponse["results"].Count == 0)
                return "pending"; // aún no hay pago

            string estado = jsonResponse["results"][0]["status"];
            return estado; // puede ser: pending, approved, rejected, in_process, etc.
        }
    }    
}
 
