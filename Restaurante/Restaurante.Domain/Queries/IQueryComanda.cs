using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Domain.Queries
{
    public interface IQueryComanda
    {
        List<Comanda> ListarComandas();
        List<Mercaderia> ListarMercaderiaDeComanda(Guid idComanda);

    }
}
