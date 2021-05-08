using Restaurante.Domain.Entities;
using System.Collections.Generic;

namespace Restaurante.Domain.Queries
{
    public interface IQueryFormaEntrega
    {
        List<FormaEntrega> ListarFormaEntrega();
        string ObtenerFormaEntrega(int idEntrega);
    }
}
