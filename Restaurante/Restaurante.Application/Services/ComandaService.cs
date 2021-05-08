using Restaurante.AccessData.Queries;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Restaurante.Application.Services
{
    public class ComandaService
    {
        QueryFormaEntrega _queryFormaEntrega = new QueryFormaEntrega();
        public int SeleccionarFormaEntrega()
        {
            Console.WriteLine("Seleccione la forma de entrega de su comanda: ");
            List<FormaEntrega> lista = _queryFormaEntrega.ListarFormaEntrega();
            foreach (var item in lista)
            {
                Console.WriteLine(item.FormaEntregaId.ToString() + " )  " + item.Descripcion);
            }
            int opc = int.Parse(Console.ReadLine());
            if (opc <= lista.Count)
            {
                return opc;
            }
            else
            {
                return 0;
            }
        }

        public int CalcularPrecioTotal(List<Mercaderia> mercaderias)
        {
            int total = 0;
            List<Mercaderia> aux = mercaderias;
            foreach (var item in aux)
            {
                total += item.Precio;
            }

            return total;
        }
    }
}
