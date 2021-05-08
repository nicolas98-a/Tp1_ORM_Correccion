using Restaurante.AccessData.Commands;
using Restaurante.AccessData.Queries;
using Restaurante.Application.Services;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.ABM_CRUD
{
    public class Abm_Comanda
    {
        GenericsRepository _repository;
        QueryFormaEntrega _queryFormaEntrega;
        ComandaMercaderiaService _comandaMercaderiaService;
        IQueryComanda _queryComanda;
        IQueryTipoMercaderia _queryTipoMercaderia;
        static Abm_Comanda unicoabmComanda = null;

        private Abm_Comanda()
        {
            _repository = new GenericsRepository();
            _queryFormaEntrega = new QueryFormaEntrega();
            _comandaMercaderiaService = new ComandaMercaderiaService();
            _queryComanda = new QueryComanda();
            _queryTipoMercaderia = new QueryTipoMercaderia();
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
            int total = CalcularPrecioTotal(listaMercaderias);
            int idFormaEntrega = SeleccionarFormaEntrega();
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

        public int SeleccionarFormaEntrega()
        {
            Console.WriteLine("Seleccione la forma de entrega de su comanda: ");
            List<FormaEntrega> lista = _queryFormaEntrega.ListarFormaEntrega();
            foreach (var item in lista)
            {
                Console.WriteLine(item.FormaEntregaId.ToString() + " )  " + item.Descripcion);
            }
            int opc = int.Parse(Console.ReadLine());
            if (opc <= lista.Count)
            {
                return opc;
            }
            else
            {
                return 0;
            }
        }

        public int CalcularPrecioTotal(List<Mercaderia> mercaderias)
        {
            int total = 0;
            List<Mercaderia> aux = mercaderias;
            foreach (var item in aux)
            {
                total += item.Precio;
            }

            return total;
        }
    }
}
