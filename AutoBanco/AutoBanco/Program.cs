 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoBanco
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Usuario Roberto = new Usuario();
            Roberto.nombre = "Roberto Peláez";
            Roberto.numCuenta = "313199";
            Roberto.pin = 0319;
            Roberto.saldo = 4500;

            int opcionMenu = 0;

            do
            {
                //Mostrar fecha actual
                DateTime thisDay = DateTime.Today;
                Console.WriteLine(thisDay.ToString("d"));

                Console.WriteLine("Ingrese 1 si desea ir al área administrativa \nIngrese 2 si desea ir a estaciones de servicio \nIngrese 3 si desea ir a reportes \nIngrese 4 si desea salir");
                opcionMenu = int.Parse(Console.ReadLine());

                switch(opcionMenu)
                {
                    case 1:
                        break;
                    case 2:
                        Console.WriteLine("Ingrese 1 si se encuentra en la estación 1 o 2 si está en la estación 2");
                        int sedeServ = 0, retirosSede1 = 0, transferenciasSede1 = 0 ;
                        string numCuenta = "";
                        int pin = 0;
                        sedeServ = int.Parse(Console.ReadLine());

                        if(sedeServ == 1 || sedeServ == 2)
                        {
                            Console.WriteLine("Ingrese su número de cuenta");
                            numCuenta = Console.ReadLine();
                            
                            string nombreCuenta = "";

                            if ((numCuenta == ElmaMado.numCuenta) || (numCuenta == Eddie.numCuenta) || (numCuenta == Roberto.numCuenta))
                            {
                                int cont = 0;
                                bool flag = false;

                                while (cont < 5 && flag == false)
                                {
                                    Console.WriteLine("Ingrese su PIN");
                                    pin = int.Parse(Console.ReadLine());

                                    if ((pin == ElmaMado.pin) || (pin == Eddie.pin) || (pin == Roberto.pin))
                                    {
                                        flag = true;
                                        cont = 0;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingrese su PIN");
                                        pin = int.Parse(Console.ReadLine());
                                        cont++;

                                        if(cont <= 4)
                                        {
                                            Console.WriteLine("Ingrese su nombre");
                                            nombreCuenta = Console.ReadLine();
                                            Console.WriteLine("Ingrese nuevamente su pin");
                                            pin = int.Parse(Console.ReadLine());

                                            if((pin == ElmaMado.pin) || (pin == Eddie.pin) || (pin == Roberto.pin))
                                            {
                                                flag = true;
                                                cont = 0;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Datos incorrectos, no puede continuar");
                                                flag = false;
                                                cont = 5;
                                            }
                                        }
                                    }
                                }

                                if (flag == true)
                                {
                                    int menuServicio = 0;
                                    Console.WriteLine("Ingrese 1 para Compra/Venta de dólares \nIngrese 2 para retiros \nIngrese 3 para" +
                                        " depósitos \nIngrese 4 para transferencias");
                                    menuServicio = int.Parse(Console.ReadLine());

                                    switch (menuServicio)
                                    {
                                        case 1: //Compra/Venta de dólares
                                            break;
                                        case 2: //Retiros
                                            break;
                                        case 3: //Depósitos

                                            string usuarioDep = "";
                                            int mntDep = 0;

                                            Console.WriteLine("Ingrese el número de cuenta al que realizara el depósito");
                                            usuarioDep = Console.ReadLine();

                                            Console.WriteLine("Ingrese el monto que depositará");
                                            mntDep = int.Parse(Console.ReadLine());
                                            if (usuarioDep == ElmaMado.numCuenta)
                                            {
                                                ElmaMado.saldo = mntDep + ElmaMado.saldo;
                                                Console.WriteLine("Se ha realizado el depósito con éxito \n");
                                            }
                                            else if (usuarioDep == Eddie.numCuenta)
                                            {
                                                Eddie.saldo = mntDep + Eddie.saldo;
                                                Console.WriteLine("Se ha realizado el depósito con éxito \n");
                                            }
                                            else if (usuarioDep == Roberto.numCuenta)
                                            {
                                                Roberto.saldo = mntDep + Roberto.saldo;
                                                Console.WriteLine("Se ha realizado el depósito con éxito \n");
                                            }
                                            else if (usuarioDep != ElmaMado.numCuenta && usuarioDep != Eddie.numCuenta && usuarioDep != Roberto.numCuenta)
                                            {
                                                Console.WriteLine("Datos no coinciden");
                                            }
                                            break;
                                        case 4: //Transferencias
                                            break;
                                        default:
                                            Console.WriteLine("Opción no válida");
                                            break;
                                    }
                                }
                                else
                                {
                                    // REINICIAR PROGRAMA
                                    Console.WriteLine("Sus tres intentos han fallado, se le recomienda apuntar su PIN \n");
                                }







                            }
                        }
                        break;
                    case 3:
                        break;
                    case 4: Environment.Exit(0);
                        break;
                    default: Console.WriteLine("Datos incorrectos");
                        break;
                }
            }
            while (opcionMenu != 4);
            Console.ReadKey();
        }
        //Métodos
        static int Depositos(Usuario u1, int monto)
        {
            u1.saldo = u1.saldo + monto;
            return u1.saldo;
        }
        static int Transferencias(Usuario u1, Usuario u2, int monto)
        {
            u1.saldo = u1.saldo - monto;
            u2.saldo = u2.saldo + monto;
            return monto;
        }
    }
}
