using Restaurante.AccessData.Queries;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Restaurante.Application.Services
{

    public class MercaderiaService
    {
        private readonly QueryTipoMercaderia _queryTipoMercaderia = new QueryTipoMercaderia();
        public int SeleccionarTipoMercaderia()
        {
            Console.WriteLine("Seleccione el tipo de mercaderia: ");
            List<TipoMercaderia> lista = _queryTipoMercaderia.ListarTipo();
            foreach (var item in lista)
            {
                Console.WriteLine(item.TipoMercaderiaId.ToString() + ")  " + item.Descripcion);
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
    }
}
