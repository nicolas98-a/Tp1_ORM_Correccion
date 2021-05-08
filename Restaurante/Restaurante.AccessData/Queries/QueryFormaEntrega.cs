using Restaurante.Domain.Entities;
using Restaurante.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.AccessData.Queries
{
    public class QueryFormaEntrega : IQueryFormaEntrega
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
