using Restaurante.AccessData.Commands;
using Restaurante.AccessData.Queries;
using Restaurante.Application.Services;
using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Restaurante.ABM_CRUD
{
    public class Abm_Comanda
    {
        private readonly GenericsRepository _repository;
        private readonly QueryFormaEntrega _queryFormaEntrega;
        private readonly ComandaMercaderiaService _comandaMercaderiaService;
        private readonly QueryComanda _queryComanda;
        private readonly QueryTipoMercaderia _queryTipoMercaderia;
        private readonly ComandaService _comandaService;

        static Abm_Comanda unicoabmComanda = null;

        private Abm_Comanda()
        {
            _repository = new GenericsRepository();
            _queryFormaEntrega = new QueryFormaEntrega();
            _comandaMercaderiaService = new ComandaMercaderiaService();
            _queryComanda = new QueryComanda();
            _queryTipoMercaderia = new QueryTipoMercaderia();
            _comandaService = new ComandaService();
        }
        public static Abm_Comanda getInstance()
        {
            if (unicoabmComanda == null)
            {
                unicoabmComanda = new Abm_Comanda();
            }
            return unicoabmComanda;
        }

        public void RegistrarComanda()
        {

            List<Mercaderia> listaMercaderias = _comandaMercaderiaService.SeleccionarMercaderia();
            int total = _comandaService.CalcularPrecioTotal(listaMercaderias);
            int idFormaEntrega = _comandaService.SeleccionarFormaEntrega();
            if (idFormaEntrega == 0)
            {
                Console.WriteLine("Mal ingresado, no corresponde a ninguna forma de entrega");
            }
            else
            {
                var entity = new Comanda
                {
                    ComandaId = new Guid(),
                    FormaEntregaId = idFormaEntrega,
                    PrecioTotal = total,
                    Fecha = new DateTime()
                };

                _repository.Add(entity);

                Console.WriteLine("Se registro con exito la comanda");
                foreach (var item in listaMercaderias)
                {
                    Abm_ComandaMercaderia.getInstance().RegistrarComandaMercaderia(item.MercaderiaId, entity.ComandaId);
                }


            }

        }

        public void ImprimirComanda()
        {
            var lista = _queryComanda.ListarComandas();
            foreach (var item in lista)
            {
                string forma = _queryFormaEntrega.ObtenerFormaEntrega(item.FormaEntregaId);
                var a = _queryComanda.ListarMercaderiaDeComanda(item.ComandaId);

                Console.WriteLine("Codigo de la comanda: " + item.ComandaId.ToString());
                foreach (var m in a)
                {
                    string tipo = _queryTipoMercaderia.ObtenerTipoMercaderia(m.TipoMercaderiaId);
                    Console.WriteLine(m.Nombre + "  " + tipo);
                }

                Console.WriteLine
                    (
                        "Precio total: " + item.PrecioTotal.ToString() + "\n" +
                        "Forma de entrega: " + forma + "\n"
                    );
            }
        }




    }
}
