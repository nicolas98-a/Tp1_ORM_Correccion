using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.AccessData.Queries
{
    public class QueryComanda : IQueryComanda
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
