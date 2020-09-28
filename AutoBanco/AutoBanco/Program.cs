 using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ElmaMado.pin = 14590;
            ElmaMado.saldo = 1900;

            Usuario Eddie = new Usuario();
            Eddie.nombre = "Eddie Herrera";
            Eddie.numCuenta = "224578";
            Eddie.pin = 99880;
            Eddie.saldo = 5000;

            Usuario Roberto = new Usuario();
            Roberto.nombre = "Roberto Peláez";
            Roberto.numCuenta = "313199";
            Roberto.pin = 03190;
            Roberto.saldo = 4500;

            int opcionMenu = 0;
            // Saldo para bóvedas manejado en cantidad de billetes
            int boveda50 = 100, boveda20 = 100, boveda1 = 200, bovedaDolar = 300;
            int tipoCambio = 8;
            int retirosSede1 = 0, depositosSede1 = 0, retirosSede2 = 0, depositosSede2 = 0, dolaresCompr = 0, dolaresVend = 0, dolaresComprados = 0, quetzalesComprados = 0;

            do
            {
                //Mostrar fecha actual
                DateTime thisDay = DateTime.Today;
                Console.WriteLine(thisDay.ToString("d"));

                // Menú principal

                Console.WriteLine("Ingrese 1 si desea ir al área administrativa \nIngrese 2 si desea ir a estaciones de servicio \nIngrese 3 si desea ir a reportes \nIngrese 4 si desea salir");
                opcionMenu = int.Parse(Console.ReadLine());

                switch(opcionMenu)
                {
                    case 1: // Área Administrativa
                        int opcionAdmin = 0;
                        Console.WriteLine("Ingrese 1 si desea acceder a las bóvedas\nIngrese 2 si desea ir a configuración de cuentas para cambiar su PIN\nIngrese 3 si desea editar el tipo de cambio de dólares");
                        opcionAdmin = int.Parse(Console.ReadLine());
                        string opcionBoveda = "";

                        switch(opcionAdmin)
                        {
                            case 1: // Bóvedas
                                // Reporte del saldo actual en las bóvedas
                                Console.WriteLine("\nEl saldo de la bóveda de 50 es: " + boveda50 * 50 + " quetzales \nEl saldo de la bóveda de 20 es: " + boveda20 * 20 + " quetzales \nEl saldo de la bóveda de 1 quetzal es: " + boveda1 + " quetzales\nLa bóveda de dolares tiene: " + bovedaDolar + " dólares");
                                // Menú para realizar cambios en el saldo de las bóvedas
                                Console.WriteLine("\nSi desea cambiar el saldo de alguna bóveda ingrese \n'boveda50' para la de 50 \n'boveda20' para la de 20 \n'boveda1' para la de 1 \n'bovedaDolar' para la de dólares");
                                opcionBoveda = Console.ReadLine();
                                switch(opcionBoveda)
                                {
                                    case "boveda50": int Mnt50 = 0;

                                        Console.WriteLine("\nIngrese el monto que desea agregar a la bóveda");
                                        Mnt50 = int.Parse(Console.ReadLine());

                                        if (Mnt50 % 50 == 0 && Mnt50 > 0)
                                        {
                                            boveda50 = boveda50 + Mnt50 / 50;
                                            Console.WriteLine("La boveda de billetes de 50 quetzales ahora tiene: " + boveda50 * 50);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No es posible agregar esa cantidad\n");
                                        }
                                        break;
                                    case "boveda20": int Mnt20;

                                        Console.WriteLine("\nIngrese el monto que desea agregar a la bóveda");
                                        Mnt20 = int.Parse(Console.ReadLine());

                                        if (Mnt20 % 20 == 0 && Mnt20 > 0)
                                        {
                                            boveda20 = boveda20 + Mnt20 / 20;
                                            Console.WriteLine("La boveda de billetes de 20 quetzales ahora tiene: " + boveda20 * 20);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No es posible agregar esa cantidad\n");
                                        }
                                        break;
                                    case "boveda1": int Mnt1;

                                        Console.WriteLine("\nIngrese el monto que desea agregar a la bóveda");
                                        Mnt1 = int.Parse(Console.ReadLine());

                                        if (Mnt1 % 1 == 0 && Mnt1 > 0)
                                        {
                                            boveda1 = boveda1 + Mnt1;
                                            Console.WriteLine("La boveda de billetes de 1 quetzal ahora tiene: " + boveda1);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No es posible agregar esa cantidad\n");
                                        }
                                        break;
                                    case "bovedaDolar": int MntDolar;

                                        Console.WriteLine("\nIngrese el monto que desea agregar a la bóveda");
                                        MntDolar = int.Parse(Console.ReadLine());

                                        if (MntDolar % 1 == 0 && MntDolar > 0)
                                        {
                                            bovedaDolar = bovedaDolar + MntDolar;
                                            Console.WriteLine("La boveda de dólares ahora tiene: " + bovedaDolar);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No es posible agregar esa cantidad\n");
                                        }
                                        break;
                                    default: Console.WriteLine("Opción no válida");
                                        break;
                                }
                                break;
                            case 2: // Configuración de cuentas

                                string NumCuenta = "";
                                int nuevoPIN = 0;
                                bool validacionConfig = false;
                                while (validacionConfig == false)
                                {
                                    Console.WriteLine("Ingrese su número de cuenta");
                                    NumCuenta = Console.ReadLine();

                                    if (NumCuenta == ElmaMado.numCuenta)
                                    {
                                        int opcionConfigCuenta = 0;
                                        Console.WriteLine("Para cambiar el nombre de su cuenta ingrese 1\nPara cambiar su PIN ingrese 2");
                                        opcionConfigCuenta = int.Parse(Console.ReadLine());

                                        switch (opcionConfigCuenta)
                                        {
                                            case 1:
                                                string nameCuenta = "";

                                                Console.WriteLine("Ingrese el nuevo Nombre para su cuenta");
                                                nameCuenta = Console.ReadLine();

                                                ElmaMado.nombre = nameCuenta;
                                                Console.WriteLine("Su nombre de usuario ahora es: " + ElmaMado.nombre);
                                                validacionConfig = true;
                                                break;
                                            case 2:
                                                Console.WriteLine("Ingrese el nuevo PIN");
                                                nuevoPIN = int.Parse(Console.ReadLine());
                                                ElmaMado.pin = nuevoPIN;

                                                Console.WriteLine("Su PIN ahora es: " + ElmaMado.pin);
                                                validacionConfig = true;
                                                break;
                                            default:
                                                Console.WriteLine("Opción inexistente");
                                                break;
                                        }
                                    }
                                    else if (NumCuenta == Eddie.numCuenta)
                                    {
                                        int opcionConfigCuenta = 0;
                                        Console.WriteLine("Para cambiar el nombre de su cuenta ingrese 1\nPara cambiar su PIN ingrese 2");
                                        opcionConfigCuenta = int.Parse(Console.ReadLine());

                                        switch (opcionConfigCuenta)
                                        {
                                            case 1:
                                                string nameCuenta = "";

                                                Console.WriteLine("Ingrese el nuevo Nombre para su cuenta");
                                                nameCuenta = Console.ReadLine();

                                                Eddie.nombre = nameCuenta;
                                                Console.WriteLine("Su nombre de usuario ahora es: " + Eddie.nombre);
                                                validacionConfig = true;
                                                break;
                                            case 2:
                                                Console.WriteLine("Ingrese el nuevo PIN");
                                                nuevoPIN = int.Parse(Console.ReadLine());
                                                Eddie.pin = nuevoPIN;

                                                Console.WriteLine("Su PIN ahora es: " + Eddie.pin);
                                                validacionConfig = true;
                                                break;
                                            default:
                                                Console.WriteLine("Opción inexistente");
                                                break;
                                        }
                                    }
                                    else if (NumCuenta == Roberto.numCuenta)
                                    {
                                        int opcionConfigCuenta = 0;
                                        Console.WriteLine("Para cambiar el nombre de su cuenta ingrese 1\nPara cambiar su PIN ingrese 2");
                                        opcionConfigCuenta = int.Parse(Console.ReadLine());

                                        switch (opcionConfigCuenta)
                                        {
                                            case 1:
                                                string nameCuenta = "";

                                                Console.WriteLine("Ingrese el nuevo Nombre para su cuenta");
                                                nameCuenta = Console.ReadLine();

                                                Roberto.nombre = nameCuenta;
                                                Console.WriteLine("Su nombre de usuario ahora es: " + Roberto.nombre);
                                                validacionConfig = true;
                                                break;
                                            case 2:
                                                Console.WriteLine("Ingrese el nuevo PIN");
                                                nuevoPIN = int.Parse(Console.ReadLine());
                                                Roberto.pin = nuevoPIN;

                                                Console.WriteLine("Su PIN ahora es: " + Roberto.pin);
                                                validacionConfig = true;
                                                break;
                                            default:
                                                Console.WriteLine("Opción inexistente");
                                                break;
                                        }
                                    }
                                }

                                break;
                            case 3: // Tipo de cambio
                                int tipCambio;
                                Console.WriteLine("Ingrese el tipo de cambio que desea");
                                tipCambio = int.Parse(Console.ReadLine());

                                if (tipCambio > 0)
                                {
                                    tipoCambio = tipCambio;
                                    Console.WriteLine("Ahora el cambio es: " + tipoCambio);
                                }
                                else
                                {
                                    Console.WriteLine("No se puede tomar ese valor");
                                }
                                break;
                            default: Console.WriteLine("Opción no válida");
                                break;
                        }

                        break;
                    case 2: // Estaciones de servicio
                        Console.WriteLine("Ingrese 1 si se encuentra en la estación 1 o 2 si está en la estación 2");
                        int sedeServ = 0;
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

                                while (cont < 4 && flag == false)
                                {
                                    Console.WriteLine("Ingrese su PIN");
                                    pin = int.Parse(Console.ReadLine());

                                    if ((numCuenta == ElmaMado.numCuenta && pin == ElmaMado.pin) || (numCuenta == Eddie.numCuenta && pin == Eddie.pin) || (numCuenta == Roberto.numCuenta && pin == Roberto.pin))
                                    {
                                        flag = true;
                                        cont = 0;
                                    }
                                    else
                                    {
                                        flag = false;
                                        cont++;

                                        if(cont == 3)
                                        {
                                            Console.WriteLine("Ingrese su nombre");
                                            nombreCuenta = Console.ReadLine();
                                            Console.WriteLine("Ingrese nuevamente su pin");
                                            pin = int.Parse(Console.ReadLine());

                                            if((numCuenta == ElmaMado.numCuenta && pin == ElmaMado.pin) || (numCuenta == Eddie.numCuenta && pin == Eddie.pin) || (numCuenta == Roberto.numCuenta && pin == Roberto.pin))
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

                                    int billetes50, billetes20, billetes1, montoCompra, montoVenta;
                                    int res50, res20;

                                    Console.WriteLine("Ingrese 1 para Compra/Venta de dólares \nIngrese 2 para retiros \nIngrese 3 para" +
                                        " depósitos \nIngrese 4 para transferencias");
                                    menuServicio = int.Parse(Console.ReadLine());

                                    if(sedeServ == 1 && menuServicio == 2)
                                    {
                                        retirosSede1++;
                                    }
                                    else if(sedeServ == 1 && menuServicio == 3)
                                    {
                                        depositosSede1++;
                                    }
                                    else if(sedeServ == 2 && menuServicio == 2)
                                    {
                                        retirosSede2++;
                                    }
                                    else if(sedeServ == 2 && menuServicio == 3)
                                    {
                                        depositosSede2++;
                                    }

                                    switch (menuServicio)
                                    {
                                        case 1: //Compra/Venta de dólares
                                            Console.WriteLine("Ingrese 1 para COMPRAR dólares\nIngrese 2 para la VENTA de dólares");
                                            int opcionCompraVenta = 0;
                                            opcionCompraVenta = int.Parse(Console.ReadLine());

                                            

                                            switch (opcionCompraVenta)
                                            {
                                                case 1: // Compra
                                                    bool valorValido = false;

                                                    while (valorValido == false)
                                                    {
                                                        Console.WriteLine("Ingrese el monto que desea comprar");
                                                        montoCompra = int.Parse(Console.ReadLine());

                                                        if (montoCompra <= 0 || montoCompra % 1 != 0 || montoCompra % tipoCambio != 0)
                                                        {
                                                            Console.WriteLine("No se puede realizar la compra");
                                                            valorValido = false;
                                                        }
                                                        else
                                                        {
                                                            // Cantidad comprada
                                                            dolaresComprados = montoCompra / tipoCambio;

                                                            // División del dinero en billetes de 50, 20 y 1

                                                            billetes50 = montoCompra / 50;
                                                            res50 = montoCompra % 50;
                                                            billetes20 = res50 / 20;
                                                            res20 = res50 % 20;
                                                            billetes1 = res20 / 1;
                                                           
                                                            // Aumento en bóvedas en quetzales y Disminución en bóveda en dólares
                                                            boveda50 = boveda50 + billetes50;
                                                            boveda20 = boveda20 + billetes20;
                                                            boveda1 = boveda1 + billetes1;
                                                            if (dolaresComprados < bovedaDolar)
                                                            {
                                                                bovedaDolar = bovedaDolar - dolaresComprados;

                                                                Console.WriteLine("Se le entregrán " + dolaresComprados + " dólares");
                                                                valorValido = true;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("No se puede realizar esta acción, solo trabajamos con números enteros");
                                                                valorValido = false;
                                                            }

                                                        }
                                                       
                                                    }
                                                    dolaresCompr += dolaresComprados;
                                                    break;
                                                case 2: // Venta
                                                    bool validacion = false;

                                                    while(validacion == false)
                                                    {
                                                        Console.WriteLine("Ingrese el monto que desea Vender");
                                                        montoVenta = int.Parse(Console.ReadLine());

                                                        if (montoVenta <= 0 || montoVenta % tipoCambio != 0)
                                                        {
                                                            Console.WriteLine("No se puede realizar la Venta");
                                                            validacion = false;
                                                        }
                                                        else if(montoVenta % tipoCambio == 0)
                                                        {
                                                            // Cantidad comprada
                                                            quetzalesComprados = montoVenta * tipoCambio;
                                                            // División del dinero en billetes de 50, 20 y 1

                                                            billetes50 = quetzalesComprados / 50;
                                                            res50 = quetzalesComprados % 50;
                                                            billetes20 = res50 / 20;
                                                            res20 = res50 % 20;
                                                            billetes1 = res20 / 1;

                                                            // Disminución en bóvedas en quetzales y aumento en bóveda en dólares
                                                            if (billetes50 < boveda50 && billetes20 < boveda20 && billetes1 < boveda1)
                                                            {
                                                                boveda50 = boveda50 - billetes50;
                                                                boveda20 = boveda20 - billetes20;
                                                                boveda1 = boveda1 - billetes1;
                                                                bovedaDolar += montoVenta;
                                                                Console.WriteLine("Se le entregrán " + quetzalesComprados + " quetzales");
                                                                validacion = true;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("No se puede realizar la venta, no contamos con la cantidad que necesita");
                                                                validacion = false;
                                                            }

                                                            
                                                        }
                                                    }
                                                    dolaresVend += quetzalesComprados / tipoCambio; 
                                                    break;
                                                default: Console.WriteLine("Opción inexistente");
                                                    break;
                                            }
                                            break;
                                        case 2: //Retiros
                                            string numeroCuenta;
                                            int PIN, montoRetiro;
                                            bool validacionRetiros = false;

                                            while(validacionRetiros == false)
                                            {
                                                Console.WriteLine("Ingrese su número de cuenta");
                                                numeroCuenta = Console.ReadLine();
                                                if(numeroCuenta == ElmaMado.numCuenta)
                                                {
                                                    Console.WriteLine("Ingrese su PIN");
                                                    PIN = int.Parse(Console.ReadLine());
                                                    if(PIN == ElmaMado.pin)
                                                    {
                                                        Console.WriteLine("Ingrese el monto que desea retirar");
                                                        montoRetiro = int.Parse(Console.ReadLine());
                                                        if(montoRetiro < ElmaMado.saldo && montoRetiro > 0)
                                                        {
                                                            billetes50 = montoRetiro / 50;
                                                            res50 = montoRetiro % 50;
                                                            billetes20 = res50 / 20;
                                                            res20 = res50 % 20;
                                                            billetes1 = res20 / 1;

                                                            if (billetes50 < boveda50 && billetes20 < boveda20 && billetes1 < boveda1)
                                                            {

                                                                boveda50 = boveda50 - billetes50;
                                                                boveda20 = boveda20 - billetes20;
                                                                boveda1 = boveda1 - billetes1;
                                                                ElmaMado.saldo -= montoRetiro;
                                                                Console.WriteLine("Se han retirado " + montoRetiro + " quetzales de su cuenta, su saldo actual es de " + ElmaMado.saldo + " quetzales");
                                                                validacionRetiros = true;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("En este momento no contamos con los fondos necesario, regrese en otro momento");
                                                                validacionRetiros = true;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Su cuenta no tiene el saldo suficiente, intente con una cantidad más pequeña");
                                                            validacionRetiros = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("PIN incorrecto");
                                                        validacionRetiros = false;
                                                    }
                                                }
                                                else if (numeroCuenta == Eddie.numCuenta)
                                                {
                                                    Console.WriteLine("Ingrese su PIN");
                                                    PIN = int.Parse(Console.ReadLine());
                                                    if (PIN == Eddie.pin)
                                                    {
                                                        Console.WriteLine("Ingrese el monto que desea retirar");
                                                        montoRetiro = int.Parse(Console.ReadLine());
                                                        if (montoRetiro < Eddie.saldo && montoRetiro > 0)
                                                        {
                                                            billetes50 = montoRetiro / 50;
                                                            res50 = montoRetiro % 50;
                                                            billetes20 = res50 / 20;
                                                            res20 = res50 % 20;
                                                            billetes1 = res20 / 1;
                                                            if (billetes50 < boveda50 && billetes20 < boveda20 && billetes1 < boveda1)
                                                            {
                                                                boveda50 = boveda50 - billetes50;
                                                                boveda20 = boveda20 - billetes20;
                                                                boveda1 = boveda1 - billetes1;
                                                                Eddie.saldo -= montoRetiro;
                                                                Console.WriteLine("Se han retirado " + montoRetiro + " quetzales de su cuenta, su saldo actual es de " + Eddie.saldo + " quetzales");
                                                                validacionRetiros = true;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("En este momento no contamos con los fondos necesario, regrese en otro momento");
                                                                validacionRetiros = true;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Su cuenta no tiene el saldo suficiente, intente con una cantidad más pequeña");
                                                            validacionRetiros = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("PIN incorrecto");
                                                        validacionRetiros = false;
                                                    }
                                                }
                                                else if (numeroCuenta == Roberto.numCuenta)
                                                {
                                                    Console.WriteLine("Ingrese su PIN");
                                                    PIN = int.Parse(Console.ReadLine());
                                                    if (PIN == Roberto.pin)
                                                    {
                                                        Console.WriteLine("Ingrese el monto que desea retirar");
                                                        montoRetiro = int.Parse(Console.ReadLine());
                                                        if (montoRetiro < Roberto.saldo && montoRetiro > 0)
                                                        {
                                                            billetes50 = montoRetiro / 50;
                                                            res50 = montoRetiro % 50;
                                                            billetes20 = res50 / 20;
                                                            res20 = res50 % 20;
                                                            billetes1 = res20 / 1;
                                                            if (billetes50 < boveda50 && billetes20 < boveda20 && billetes1 < boveda1)
                                                            {
                                                                boveda50 = boveda50 - billetes50;
                                                                boveda20 = boveda20 - billetes20;
                                                                boveda1 = boveda1 - billetes1;
                                                                Roberto.saldo -= montoRetiro;
                                                                Console.WriteLine("Se han retirado " + montoRetiro + " quetzales de su cuenta, su saldo actual es de " + Roberto.saldo + " quetzales");
                                                                validacionRetiros = true;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("En este momento no contamos con los fondos necesario, regrese en otro momento");
                                                                validacionRetiros = true;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Su cuenta no tiene el saldo suficiente, intente con una cantidad más pequeña");
                                                            validacionRetiros = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("PIN incorrecto");
                                                        validacionRetiros = false;
                                                    }
                                                }
                                                else if(numeroCuenta != ElmaMado.numCuenta && numeroCuenta != Eddie.numCuenta && numeroCuenta != Roberto.numCuenta)
                                                {
                                                    Console.WriteLine("La cuenta no existe");
                                                    validacionRetiros = false;
                                                }
                                            }
                                            break;
                                        case 3: //Depósitos

                                            string usuarioDep;
                                            int mntDep = 0;
                                            bool valido = false;
                                            

                                            while (valido == false)
                                            {
                                                Console.WriteLine("Ingrese el número de cuenta al que realizara el depósito");
                                                usuarioDep = Console.ReadLine();

                                                if (usuarioDep == ElmaMado.numCuenta)
                                                {
                                                    Console.WriteLine("Ingrese el monto que depositará");
                                                    mntDep = int.Parse(Console.ReadLine());
                                                    ElmaMado.saldo = mntDep + ElmaMado.saldo;
                                                    Console.WriteLine("Se ha realizado el depósito con éxito \n");
                                                    valido = true;
                                                }
                                                else if (usuarioDep == Eddie.numCuenta)
                                                {
                                                    Console.WriteLine("Ingrese el monto que depositará");
                                                    mntDep = int.Parse(Console.ReadLine());
                                                    Eddie.saldo = mntDep + Eddie.saldo;
                                                    Console.WriteLine("Se ha realizado el depósito con éxito \n");
                                                    valido = true;
                                                }
                                                else if (usuarioDep == Roberto.numCuenta)
                                                {
                                                    Console.WriteLine("Ingrese el monto que depositará");
                                                    mntDep = int.Parse(Console.ReadLine());
                                                    Roberto.saldo = mntDep + Roberto.saldo;
                                                    Console.WriteLine("Se ha realizado el depósito con éxito \n");
                                                    valido = true;
                                                }
                                                else if (usuarioDep != ElmaMado.numCuenta && usuarioDep != Eddie.numCuenta && usuarioDep != Roberto.numCuenta)
                                                {
                                                    Console.WriteLine("Datos no coinciden");
                                                    valido = false;
                                                }
                                            }
                                            billetes50 = mntDep / 50;
                                            res50 = mntDep % 50;
                                            billetes20 = res50 / 20;
                                            res20 = res50 % 20;
                                            billetes1 = res20 / 1;
                                            boveda50 = boveda50 + billetes50;
                                            boveda20 = boveda20 + billetes20;
                                            boveda1 = boveda1 + billetes1;

                                            break;
                                        case 4: //Transferencias
                                            string nCuenta, cuentaDestino;
                                            int pinCuenta, mntTranferencia;
                                            bool validacionTransferencias = false;

                                            while (validacionTransferencias == false)
                                            {
                                                Console.WriteLine("Ingrese su número de cuenta");
                                                nCuenta = Console.ReadLine();
                                                if (nCuenta == ElmaMado.numCuenta || nCuenta == Eddie.numCuenta || nCuenta == Roberto.numCuenta)
                                                {
                                                    Console.WriteLine("Ingrese su PIN");
                                                    pinCuenta = int.Parse(Console.ReadLine());

                                                    if(nCuenta == ElmaMado.numCuenta && pinCuenta == ElmaMado.pin)
                                                    {
                                                        Console.WriteLine("Ingrese el monto que desea transferir");
                                                        mntTranferencia = int.Parse(Console.ReadLine());
                                                        Console.WriteLine("Ingrese el número de cuenta de la cuenta destsino");
                                                        cuentaDestino = Console.ReadLine();

                                                        if(mntTranferencia > 0 && cuentaDestino == Eddie.numCuenta && mntTranferencia < ElmaMado.saldo)
                                                        {   
                                                                Eddie.saldo = Eddie.saldo + mntTranferencia;
                                                                ElmaMado.saldo = ElmaMado.saldo - mntTranferencia;
                                                                Console.WriteLine("Se han transferido " + mntTranferencia + " quetzales a " + Eddie.nombre);
                                                                validacionTransferencias = true;    
                                                        }
                                                        else if (mntTranferencia > 0 && cuentaDestino == Roberto.numCuenta && mntTranferencia < ElmaMado.saldo)
                                                        {
                                                            Roberto.saldo = Roberto.saldo + mntTranferencia;
                                                            ElmaMado.saldo = ElmaMado.saldo - mntTranferencia;
                                                            Console.WriteLine("Se han transferido " + mntTranferencia + " quetzales a " + Roberto.nombre);
                                                            validacionTransferencias = true;
                                                        }
                                                        else if (cuentaDestino == nCuenta)
                                                        {
                                                            Console.WriteLine("No puede realizar una transferencia a usted mismo");
                                                            validacionTransferencias = false;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("No se puede transferir esa cantidad, su cuenta no posee el capital necesario");
                                                            validacionTransferencias = false;
                                                        }
                                                    }
                                                    else if (nCuenta == Eddie.numCuenta && pinCuenta == Eddie.pin)
                                                    {
                                                        Console.WriteLine("Ingrese el monto que desea transferir");
                                                        mntTranferencia = int.Parse(Console.ReadLine());
                                                        Console.WriteLine("Ingrese el número de cuenta de la cuenta destsino");
                                                        cuentaDestino = Console.ReadLine();

                                                        if (mntTranferencia > 0 && cuentaDestino == ElmaMado.numCuenta && mntTranferencia < Eddie.saldo)
                                                        {
                                                            ElmaMado.saldo = ElmaMado.saldo + mntTranferencia;
                                                            Eddie.saldo = Eddie.saldo - mntTranferencia;
                                                            Console.WriteLine("Se han transferido " + mntTranferencia + " quetzales a " + ElmaMado.nombre);
                                                            validacionTransferencias = true;
                                                        }
                                                        else if (mntTranferencia > 0 && cuentaDestino == Roberto.numCuenta && mntTranferencia < Eddie.saldo)
                                                        {
                                                            Roberto.saldo = Roberto.saldo + mntTranferencia;
                                                            Eddie.saldo = Eddie.saldo - mntTranferencia;
                                                            Console.WriteLine("Se han transferido " + mntTranferencia + " quetzales a " + Roberto.nombre);
                                                            validacionTransferencias = true;
                                                        }
                                                        else if (cuentaDestino == nCuenta)
                                                        {
                                                            Console.WriteLine("No puede realizar una transferencia a usted mismo");
                                                            validacionTransferencias = false;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("No se puede transferir esa cantidad, su cuenta no posee el capital necesario");
                                                            validacionTransferencias = false;
                                                        }
                                                    }
                                                    else if (nCuenta == Roberto.numCuenta && pinCuenta == Roberto.pin)
                                                    {
                                                        Console.WriteLine("Ingrese el monto que desea transferir");
                                                        mntTranferencia = int.Parse(Console.ReadLine());
                                                        Console.WriteLine("Ingrese el número de cuenta de la cuenta destsino");
                                                        cuentaDestino = Console.ReadLine();

                                                        if (mntTranferencia > 0 && cuentaDestino == ElmaMado.numCuenta && mntTranferencia < Roberto.saldo)
                                                        {
                                                            ElmaMado.saldo = ElmaMado.saldo + mntTranferencia;
                                                            Roberto.saldo = Roberto.saldo - mntTranferencia;
                                                            Console.WriteLine("Se han transferido " + mntTranferencia + " quetzales a " + ElmaMado.nombre);
                                                            validacionTransferencias = true;
                                                        }
                                                        else if (mntTranferencia > 0 && cuentaDestino == Eddie.numCuenta && mntTranferencia < Roberto.saldo)
                                                        {
                                                            Eddie.saldo = Eddie.saldo + mntTranferencia;
                                                            Roberto.saldo = Roberto.saldo - mntTranferencia;
                                                            Console.WriteLine("Se han transferido " + mntTranferencia + " quetzales a " + Eddie.nombre);
                                                            validacionTransferencias = true;
                                                        }
                                                        else if(cuentaDestino == nCuenta)
                                                        {
                                                            Console.WriteLine("No puede realizar una transferencia a usted mismo");
                                                            validacionTransferencias = false;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("No se puede transferir esa cantidad, su cuenta no posee el capital necesario");
                                                            validacionTransferencias = false;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Cuenta inexistente");
                                                    validacionTransferencias = false;
                                                }
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("La opción que ingresó no existe");
                                            break;
                                    }
                                }
                                else
                                {
                                    // REINICIAR PROGRAMA
                                    Console.WriteLine("Sus tres intentos han fallado, se le recomienda apuntar su PIN \n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("La cuenta no existe");
                            }
                        }
                        break;
                    case 3: // Reporte
                        Console.WriteLine("\nSaldo total por bóveda: ");
                        Console.WriteLine("\nEl saldo de la bóveda de billetes de 50 quetzales es de: " + boveda50 * 50 + " quetzales");
                        Console.WriteLine("El saldo de la bóveda de billetes de 20 quetzales es de: " + boveda20 * 20 + " quetzales");
                        Console.WriteLine("El saldo de la bóveda de billetes de 1 quetzal es de: " + boveda1 * 1 + " quetzales");
                        Console.WriteLine("El saldo de la bóveda de dólares es de: " + bovedaDolar * 1 + " dólares");
                        Console.WriteLine("\nSaldo por cuenta: ");
                        Console.WriteLine("\nEl saldo en la cuenta de " + ElmaMado.nombre + " es de: " + ElmaMado.saldo + " quetzales");
                        Console.WriteLine("El saldo en la cuenta de " + Eddie.nombre + " es de: " + Eddie.saldo + " quetzales");
                        Console.WriteLine("El saldo en la cuenta de " + Roberto.nombre + " es de: " + Roberto.saldo + " quetzales");
                        Console.WriteLine("\nRetiros por sede:");
                        Console.WriteLine("\nRetiros en la sede 1: " + retirosSede1);
                        Console.WriteLine("Retiros en la sede 2: " + retirosSede2);
                        Console.WriteLine("\nDepósitos por sede:");
                        Console.WriteLine("\nDepósitos en la sede 1: " + depositosSede1);
                        Console.WriteLine("\nDepósitos en la sede 2: " + depositosSede2);
                        Console.WriteLine("\nDólares comprados:");
                        Console.WriteLine("\n" + dolaresCompr);
                        Console.WriteLine("\nDólares vendidos:");
                        Console.WriteLine("\n" + dolaresVend);
                        Console.WriteLine("\nPrograma hecho por: Roberto Peláez, con la colaboración de Eddie Herrera\nVersión 1.0\n");

                        break;
                    case 4: // Salida
                        Environment.Exit(0);
                        break;
                    default: Console.WriteLine("Datos incorrectos");
                        break;
                }
            }
            while (opcionMenu != 4);
            Console.ReadKey();
        }
    }
}
