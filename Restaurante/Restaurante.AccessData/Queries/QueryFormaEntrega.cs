using Restaurante.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.AccessData.Queries
{
    public class QueryFormaEntrega 
    {
        public List<FormaEntrega> ListarFormaEntrega()
        {
            using (RestauranteContext _context = new RestauranteContext())
            {
                var listaFormaEntrega = _context.FormaEntregas.ToList();
                return listaFormaEntrega;
            }
        }

        public string ObtenerFormaEntrega (int idEntrega)
        {
            using (RestauranteContext _context = new RestauranteContext())
            {
                string forma = _context.FormaEntregas.Find(idEntrega).Descripcion;
                return forma;
            }
        }
    }
}
