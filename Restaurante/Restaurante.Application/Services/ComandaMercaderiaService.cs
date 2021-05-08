using Restaurante.AccessData.Queries;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Restaurante.Application.Services
{

    public class ComandaMercaderiaService 
    {
        QueryMercaderia _queryMercaderia = new QueryMercaderia();
        public List<Mercaderia> SeleccionarMercaderia()
        {
            List<Mercaderia> mercaderiaSeleccionada = new List<Mercaderia>();
            Console.WriteLine("Seleccione la mercaderia que desea agregar a su pedido: ");
            Console.WriteLine("Ingrese 0 para terminar ");
            List<Mercaderia> lista = _queryMercaderia.ListarMercaderia();
            foreach (var item in lista)
            {
                Console.WriteLine(item.MercaderiaId.ToString() + " ) " + item.Nombre + "  precio: " + item.Precio.ToString());
            }

            int opc = int.Parse(Console.ReadLine());
            while (opc != 0)
            {
                if (opc <= lista.Count)
                {
                    mercaderiaSeleccionada.Add(lista[opc - 1]);
                }
                else
                {
                    Console.WriteLine("Mal ingresado, no corresponde a una mercaderia");
                }
                opc = int.Parse(Console.ReadLine());
            }

            return mercaderiaSeleccionada;
        }
    }
}
