using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentación
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                insertar();

                modificar();

                eliminar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            Console.ReadKey();
        }

        private static void insertar()
        {
            try
            {
                Persona persona = new Persona();

                persona.Nombre = "Diego";
                persona.Apellido = "Baldomir";
                persona.DNI = 21266901;
                persona.Direccion = "Vive muy lejos";
                persona.Email = "diego.baldomir@hotmail.com";
                persona.EstadoCivil = Negocio.Enumerables.EstadoCivil.Casado;

                int idPersona = persona.Grabar();

                Console.WriteLine(String.Format("Se inserto la persona con éxito Id:{0}", idPersona));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static void modificar()
        {
            try
            {
                //Obtenemos a la persona que deseamos modificar
                Persona persona = Persona.Obtener(5);

                persona.Nombre = "Analia";
                persona.Apellido = "Sanabria";
                persona.DNI = 31798510;
                persona.Direccion = "Griveo 1998";
                persona.Email = "ani.gabi.sani@hotmail.com";
                persona.EstadoCivil = Negocio.Enumerables.EstadoCivil.Soltero;

                int idPersona = persona.Grabar();

                Console.WriteLine(String.Format("Se modificaron los datos de la persona con éxito Id:{0}", idPersona));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static void eliminar()
        {
            try
            {
                Persona persona = new Persona();
                Persona.Eliminar(3);
                
                Console.WriteLine(String.Format("¡Se elimino a la persona con éxito!"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
