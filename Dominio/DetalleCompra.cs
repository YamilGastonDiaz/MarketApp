using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleCompra
    {
        public int id {  get; set; }
        public Compra compra { get; set; }
        public Producto producto { get; set; }
        public Marca marca { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioCompra { get; set; }
        public decimal subTotal { get; set; }

        public DetalleCompra()
        {
            id = 0;
            compra = new Compra();
            producto = new Producto();
            marca = new Marca();
            cantidad = 0;
            precioCompra = 0;
            subTotal = 0;
        }

        public string empaqueDescripcion
        {
            get
            {
                return producto?.empaque?.descripcion ?? "";
            }
        } 
    }
}
