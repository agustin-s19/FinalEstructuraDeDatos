using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



namespace Prueba_Final
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue miCola = new Queue();
            int opcion;

            do
            {

                Console.Clear();
                opcion = menu();
                switch (opcion)
                {
                    case 1: //Crear Cola
                        CrearCola(ref miCola);
                        break;
                    case 2: //Limpia/Vacia/Borra la cola
                        BorrarCola(ref miCola);
                        break;
                    case 3: //Agrega un pedido a la cola
                        AgregarPedido(ref miCola);
                        break;
                    case 4: //Borra el último pedido que se encontraba en la cola
                        BorrarPedido(ref miCola);
                        break;
                    case 5: //Muestra todos los elementos de la cola
                        ListarTodosPedidos(miCola);
                        break;
                    case 6: //Muestra el ultimo pedido que se encuentra en la cola
                        ListarUltimoPedido(miCola);
                        break;
                    case 7: //Muestra el primer pedido que se encuentra en la cola
                        ListarPrimerPedido(ref miCola);
                        break;
                    case 8: //Muestra la cantidad de elementos que se encuentran en el pedido
                        CantidadDelPedido(ref miCola);
                        break;
                    case 9: //Mueve el primer pedido hacia la ultima posicion de la cola
                        MoverPrimerPedido(ref miCola);
                        break;
                    case 10: //Guia para el usuario que dice las funciones que tiene el programa
                        GuiaDelPrograma();
                        break;
                    case 11: break; // Salir del programa con el número 11

                    default://Mensaje en caso de que no se escriba ninguno de los anteriores cases
                        mensaje("ERROR: Ingresá una opción válida.");
                        break;
                }



            }
            while (opcion != 11);
            Console.WriteLine("\nEl programa a finalizado.\n");


        }
        static int menu() //Interfaz gráfica
        {
            int valor;

            Console.Clear();
            Console.WriteLine("                                   ...............................                                   ");
            Console.WriteLine("...................................Trabajo Practico Final C# Colas...................................");
            Console.WriteLine("               Profesor            ...............................           Martin Santoro          ");
            Console.WriteLine("                Alumno             ...............................           Agustin Sabia          ");
            Console.WriteLine("...................................Tema 2 - 1er Año B - 29/11/2019...................................");

            Console.WriteLine(" \n 1) Crear Cola \n 2) Borrar Cola \n 3) Agregar Pedido \n 4) Borrar Pedido \n 5) Listar Todos los Pedidos \n 6) Listar Último Pedido \n 7) Listar Primer Pedido \n 8) Cantidad De Pedido \n 9) Mover hacia la ultima posicion el primer Pedido \n 10) Guia del Programa \n 11) Salir");
            Console.Write("\nIngresa tu opción: ");

            do
            {
                try
                {
                    //funcion para que si ingresa cualquier numero distinto a los del programa vuelva al menú
                    valor = Convert.ToInt32(Console.ReadLine());
                    if (valor <= 11) ;


                    return valor;

                }
                //funcion para que si ingresa cualquier cosa distinta a un numero le tire error y vuelva al menú
                catch
                {

                    mensaje("\r\nERROR: Elegí una opción correcta. Presione una tecla para volver al Menú.\r\n");
                    Console.ReadKey();
                    return menu();

                }

            } while (valor != 11);
        }
        static void mensaje(String texto)
        {
            if (texto.Length != 0)
            {
                Console.WriteLine(" {0}", texto);
                Console.WriteLine("\nPresione cualquier tecla para continuar...");


            }
        }


        /////////////////////////// CREAR COLA - OPCION 1 //////////////////////////////////////////////
        static void CrearCola(ref Queue cola)
        {
            Queue miCola1 = new Queue();

            int valor = (int)cola.Count;
            if (valor != 0)
            {
                Console.WriteLine("\nLa Cola ya fue creada.");
                mensaje("\n Para ver cuales son sus pedidos ingrese la opcion 5 ");


            }
            else
            {
                mensaje("\n La cola ha sido creada.");
            }
            Console.ReadKey();

        }

        /////////////////////////// BORRAR COLA - OPCION 2 //////////////////////////////////////////////
        static void BorrarCola(ref Queue cola)
        {
            cola.Clear();
            mensaje("\nLa Cola ha sido borrada");
            Console.ReadKey();
        }

        /////////////////////////// AGREGAR PEDIDO - OPCION 3 //////////////////////////////////////////////
        static void AgregarPedido(ref Queue cola)
        {


            try
            {
                Console.Write("\nIngrese valor: ");
                int valor = Convert.ToInt32(Console.ReadLine());

                if (valor > 0 && valor < 999)
                {
                    int indice = cola.Count + 1;
                    string pedido = valor.ToString(); //indice + " – " + valor;
                    cola.Enqueue(pedido);
                    Console.WriteLine("\nEl pedido '{0}' se agrego exitosamente.", string.Format("{0} - {1}", cola.ToArray().ToList().IndexOf(pedido) + 1, pedido));
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nError: Ingresar un pedido mayor a 0 y menor a 999.\n");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("\nError: El pedido ingresado debe ser un número entero.\n");


            }


        }


        /////////////////////////// BORRAR PEDIDO - OPCION 4 //////////////////////////////////////////////
        static void BorrarPedido(ref Queue cola)
        {
            if (cola.Count != 0)
            {

                string valor = (string)cola.Dequeue();
                Console.WriteLine("\nEl primer pedido era: {0} ", valor);
                mensaje("\nEste ha sido borrado");


            }
            else
            {
                mensaje("\nLa cola ahora se encuentra vacia");

                Console.ReadKey();
            }
            Console.ReadKey();

        }
        /////////////////////////// LISTAR TODOS LOS PEDIDOS - OPCION 5 //////////////////////////////////////////////
        static void ListarTodosPedidos(Queue cola)
        {
            if (cola.Count != 0)
            {
                Console.WriteLine("\nLista completa de pedidos: \n");
                foreach (string dato in cola)
                {
                    Console.WriteLine(string.Format("{0} - {1}", cola.ToArray().ToList().IndexOf(dato) + 1, dato));
                }
            }

            else
            {
                Console.WriteLine("\nError: La cola esta esta vacía.");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        /////////////////////////// LISTAR ULTIMO PEDIDO - OPCION 6 //////////////////////////////////////////////
        static void ListarUltimoPedido(Queue cola)
        {
            int i = 0;
            if (cola.Count != 0)
            {
                mensaje("\nEl último pedido es: \n" + "    " + cola.ToArray().Last());
                //foreach (string dato in cola)
                //{
                //    i++;
                //    if (cola.Count == i)
                //    {
                //        mensaje("\nEl último pedido es: \n" + "    " + dato); ;
                //    }
                //}
            }
            else
            {
                mensaje("\nError: La cola esta vacía");
            }

            Console.ReadKey();

        }

        /////////////////////////// LISTAR PRIMER PEDIDO - OPCION 7 //////////////////////////////////////////////
        static void ListarPrimerPedido(ref Queue cola)
        {
            try
            {

                mensaje("\nEl primer pedido es: \n " + "    " + cola.ToArray().First());
                //mensaje("\nEl primer pedido es: \n " + "    " + cola.Peek());


            }
            catch
            {
                mensaje("\nError: La cola está vacía.");
            }

            Console.ReadKey();
        }

        /////////////////////////// MOSTRAR CANTIDAD DEL PEDIDO - OPCION 8 //////////////////////////////////////////////
        static void CantidadDelPedido(ref Queue cola)
        {
            try
            {
                int valor = (int)cola.Count;
                Console.WriteLine("\nLa cola tiene " + valor + " pedidos.");
                ListarTodosPedidos(cola);
            }
            catch
            {
                mensaje("\nError: La cola está vacía.");

            }



        }
        /////////////////////////// MOVER EL PRIMER PEDIDO - OPCION 9 //////////////////////////////////////////////
        static void MoverPrimerPedido(ref Queue cola)
        {
            try
            {
                string valor = (string)cola.Dequeue();
                Console.WriteLine("\nEl primer pedido era:{0} ", valor);
                cola.Enqueue(valor);
                Console.WriteLine("\nSe cambio a la ultima posición este pedido.\nLa lista ahora quedo así:");
                ListarTodosPedidos(cola);

            }
            catch
            {
                mensaje("\nError: La cola está vacía.");
                Console.ReadKey();
            }
        }


        /////////////////////////// GUIA DEL PROGRAMA - OPCION 10 //////////////////////////////////////////////////
        static void GuiaDelPrograma()
        {
            Console.WriteLine("\n ______________________________________________________________");
            Console.WriteLine(" |                                                             |");
            Console.WriteLine(" | Para usar el programa debera introducir una opcion del menú |");
            Console.WriteLine(" | Con el mismo podrá Crear, borrar Colas, como tambien  ______|");
            Console.WriteLine(" | ver, modificar, contar, listar el contenido de ella. |");
            Console.WriteLine(" |_____________________________________________________/");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }







    }






}
