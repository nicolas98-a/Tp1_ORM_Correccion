﻿using Restaurante.Domain.Entities;
using Restaurante.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.AccessData.Queries
{
    public class QueryTipoMercaderia : IQueryTipoMercaderia
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
