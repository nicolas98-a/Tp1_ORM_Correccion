using Restaurante.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.AccessData.Queries
{
    public class QueryTipoMercaderia 
    {
        public List<TipoMercaderia> ListarTipo()
        {
            using (RestauranteContext _context = new RestauranteContext())
            {
                var listaTipo = _context.TipoMercaderias.ToList();
                return listaTipo;
            }
        }

        public string ObtenerTipoMercaderia (int tipoId)
        {
            using (RestauranteContext _context = new RestauranteContext())
            {
                string tipo = _context.TipoMercaderias.Find(tipoId).Descripcion;
                return tipo;
            }
        }
    }
}
