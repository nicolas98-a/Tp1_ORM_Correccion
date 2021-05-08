using Restaurante.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.AccessData.Queries
{
    public class QueryMercaderia 
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
