using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.AccessData.Queries
{
    public class QueryComanda 
    {
        public List<Comanda> ListarComandas()
        {
            using (RestauranteContext _context = new RestauranteContext())
            {
                var listaDeComandas = _context.Comandas.ToList();
                return listaDeComandas;
            }
        }

        public List<Mercaderia> ListarMercaderiaDeComanda(Guid idComanda)
        {
            using (RestauranteContext _context = new RestauranteContext())
            {
                var mercaderiasEnComanda = _context.Mercaderias.Include(x => x.ComandasNavigator)
                            .Where(mercaderia => mercaderia.ComandasNavigator.Select(comanda => comanda.ComandaId)
                            .Contains(idComanda)).ToList();

                return mercaderiasEnComanda;
            }
        }
    }
}
