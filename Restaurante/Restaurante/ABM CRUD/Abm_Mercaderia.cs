using Restaurante.AccessData.Commands;
using Restaurante.AccessData.Queries;
using Restaurante.Application.Services;
using Restaurante.Domain.Entities;
using System;

namespace Restaurante.ABM_CRUD
{
    public class Abm_Mercaderia
    {
        GenericsRepository _repository;
        QueryTipoMercaderia _queryTipoMercaderia;
        QueryMercaderia _queryMercaderia;
        private readonly MercaderiaService _mercaderiaService;

        static Abm_Mercaderia unicoabmMercaderia = null;


        private Abm_Mercaderia()
        {
            _repository = new GenericsRepository();
            _queryTipoMercaderia = new QueryTipoMercaderia();
            _queryMercaderia = new QueryMercaderia();
            _mercaderiaService = new MercaderiaService();
        }

        public static Abm_Mercaderia getInstance()
        {
            if (unicoabmMercaderia == null)
            {
                unicoabmMercaderia = new Abm_Mercaderia();
            }
            return unicoabmMercaderia;
        }

        public void RegistrarMercaderia()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la mercaderia: ");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el precio de la mercaderia: ");
                int precio = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese los ingredientes: ");
                string ingredientes = Console.ReadLine();

                Console.WriteLine("Ingrese la preparacion: ");
                string preparacion = Console.ReadLine();

                Console.WriteLine("Ingrese la imagen de la preparacion: ");
                string imagen = Console.ReadLine();

                if (nombre != "" && precio.ToString() != ""  && ingredientes != "" && preparacion != "" && imagen != "")
                {
                    if (precio >= 0)
                    {
                        int idTipo = _mercaderiaService.SeleccionarTipoMercaderia();
                        if (idTipo == 0)
                        {
                            Console.WriteLine("Mal ingresado, no corresponde a ningun tipo");
                        }
                        else
                        {
                            var entity = new Mercaderia
                            {
                                Nombre = nombre,
                                Precio = precio,
                                Ingredientes = ingredientes,
                                Preparacion = preparacion,
                                Imagen = imagen,
                                TipoMercaderiaId = idTipo

                            };
                            _repository.Add(entity);

                            Console.WriteLine("Mercaderia registrada con exito");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error, el precio no puede ser negativo");
                    }

                }
                else
                {
                    Console.WriteLine("Error mal ingresado, no puede haber campos vacios");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error mal ingresado");
            }

        }

        public void ImprimirMercaderia()
        {
            var lista = _queryMercaderia.ListarMercaderia();
            foreach (var item in lista)
            {
                string tipo = _queryTipoMercaderia.ObtenerTipoMercaderia(item.TipoMercaderiaId);
                Console.WriteLine
                    (
                       "            Tipo de mercaderia: " + tipo + "\n" +
                       "Mercaderia : " + item.Nombre + "\n" +
                       "Precio: " + item.Precio.ToString() + "\n" +
                       "Ingredientes: " + item.Ingredientes + "\n" +
                       "Preparacion: " + item.Preparacion + "\n" +
                       "Imagen: " + item.Imagen + "\n"
                    );
            }
        }

    }
}
