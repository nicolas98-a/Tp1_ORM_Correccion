using Restaurante.AccessData.Commands;
using Restaurante.AccessData.Queries;
using Restaurante.Domain.Commands;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.ABM_CRUD
{
    public class Abm_Mercaderia
    {
        GenericsRepository _repository;
        QueryTipoMercaderia _queryTipoMercaderia;

        static Abm_Mercaderia unicoabmMercaderia = null;


        private Abm_Mercaderia()
        {
            _repository = new GenericsRepository();
            _queryTipoMercaderia = new QueryTipoMercaderia();

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

                if (nombre != "" && precio.ToString() != "" && ingredientes != "" && preparacion != "" && imagen != "")
                {
                    int idTipo = SeleccionarTipoMercaderia();
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
                    Console.WriteLine("Error mal ingresado, no puede haber campos vacios");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error mal ingresado");
            }

        }

        public int SeleccionarTipoMercaderia()
        {
            Console.WriteLine("Seleccione el tipo de mercaderia: ");
            List<TipoMercaderia> lista = _queryTipoMercaderia.ListarTipo();
            foreach (var item in lista)
            {
                Console.WriteLine(item.TipoMercaderiaId.ToString() + ")  " + item.Descripcion);
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
    }
}
