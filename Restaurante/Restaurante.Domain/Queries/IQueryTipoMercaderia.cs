using Restaurante.Domain.Entities;
using System.Collections.Generic;

namespace Restaurante.Domain.Queries
{
    public interface IQueryTipoMercaderia
    {
        List<TipoMercaderia> ListarTipo();
        string ObtenerTipoMercaderia(int tipoId);
    }
}
