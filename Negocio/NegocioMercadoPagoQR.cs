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
        private readonly string accessToken = "TU_ACCESS_TOKEN"; // Reemplazá por el tuyo
        private readonly string userId = "TU_USER_ID";            // Lo obtenés del panel de Mercado Pago
        private readonly string posId = "TU_POS_ID";              // El ID del punto de venta creado

        public string CrearQR(decimal total, string referencia_idVenta)
        {
            string url = $"https://api.mercadopago.com/instore/orders/qr/seller/collectors/{userId}/pos/{posId}/qrs";

            var body = new
            {
                external_reference = referencia_idVenta,
                title = "Pago QR desde App",
                total_amount = total,
                items = new[]
                {
                    new {
                        title = "Pago desde app",
                        unit_price = total,
                        quantity = 1
                    }
                }
            };

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al generar QR: " + response.Content.ReadAsStringAsync().Result);

            var responseString = response.Content.ReadAsStringAsync().Result;
            dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);

            return jsonResponse.qr_data;
        }
    }
}
 
