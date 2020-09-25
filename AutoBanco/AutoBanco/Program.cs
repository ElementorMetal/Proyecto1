using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mostrar fecha actual
            DateTime thisDay = DateTime.Today;
            Console.WriteLine(thisDay.ToString("d"));

            //Declarando usuarios
            Usuario ElmaMado = new Usuario();
            ElmaMado.nombre = "Elma Mado";
            ElmaMado.numCuenta = "112235";
            ElmaMado.pin = 1459;
            ElmaMado.saldo = 1900;

            Usuario Eddie = new Usuario();
            Eddie.nombre = "Eddie Herrera";
            Eddie.numCuenta = "224578";
            Eddie.pin = 9988;
            Eddie.saldo = 5000;

            Console.ReadKey();
        }
        //Métodos
        static string Depositos(Usuario u1, int monto)
        {

        }
        
    }
}
