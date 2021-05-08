using Restaurante.Domain.Entities;
using System.Collections.Generic;

namespace Restaurante.Domain.Queries
{
    public interface IQueryMercaderia
    {
        List<Mercaderia> ListarMercaderia();
    }
}
