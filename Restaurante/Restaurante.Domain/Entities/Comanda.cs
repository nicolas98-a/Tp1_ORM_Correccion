using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Domain.Entities
{
    public class Comanda
    {
        [Required]
        public Guid ComandaId { get; set; }

        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }

        public int FormaEntregaId { get; set; }
        public FormaEntrega FormaEntregaNavigator { get; set; }

        public IList<Mercaderia> MercaderiasNavigator { get; set; }
    }
}
