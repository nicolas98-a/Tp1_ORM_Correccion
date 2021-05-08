using Restaurante.Domain.Entities;
using Restaurante.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.AccessData.Queries
{
    public class QueryMercaderia : IQueryMercaderia
    {
        public List<Mercaderia> ListarMercaderia()
        {
            using (RestauranteContext _context = new RestauranteContext())
            {
                var listaMercaderia = _context.Mercaderias.ToList();
                return listaMercaderia;
            }
        }
    }
}
