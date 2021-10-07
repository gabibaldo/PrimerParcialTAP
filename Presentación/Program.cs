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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static void insertar()
        {
            try
            {
                Persona persona = new Persona();

                persona.Nombre = "Gabriel";
                persona.Apellido = "Baldomir";
                persona.DNI = 36400231;
                persona.Direccion = "Tinogasta 3246";
                persona.Email = "gabrielbaldomir05@gmail.com";
                persona.EstadoCivil = Negocio.Enumerables.EstadoCivil.Soltero;

                int idPersona = persona.Grabar();

                Console.WriteLine(String.Format("Se inserto la persona con éxito Id:{0}", idPersona));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
