using System;
using System.IO;

namespace LABORATORIO
{
    class Program
    {
        static string ruta = "Us_administradores.txt";
        static string ruta2 = "Us_trabajadores.txt";
        static string facturas1 = "Facturas.txt";
        static FileStream Archivo;
        static StreamReader Leer;
        static StreamWriter Escribir;
        static int x = 0;
        static Persona p = new Persona();
        static Menu_admin ma = new Menu_admin();
        static Menu_tra mt = new Menu_tra();
        static Inventario intra = new Inventario();
        static User u = new User();
        static void Main(string[] args)
        {
            if (p.us() == "administrador")
            {
                if ((buscara(u.usad(), u.coad())) == "Usuario y contraseña correctos")
                {
                    char Op = 'S';
                    while (Op != 'N')
                    {
                        acciona(ma.mena());
                        Console.Write("Desea realizar otra acción? [S/N]: ");
                        Op = char.Parse(Console.ReadLine());

                    }
                }
                else
                {
                    Console.WriteLine("Usuario y contraseña incorrectos");
                }
            }
            else
            {
                if ((buscart(u.usad(), u.coad())) == "Usuario y contraseña correctos")
                {
                    char Ope = 'S';
                    while (Ope != 'N')
                    {
                        acciont(mt.ment());
                        Console.Write("Desea realizar otra acción? [S/N]: ");
                        Ope = char.Parse(Console.ReadLine());

                    }
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        static string llenar(string dato)
        {
            Console.Write("Ingrese " + dato + ": ");
            return (Console.ReadLine());
        }
        static void GU(string Usuario, string contraseña)
        {
            Escribir = File.AppendText(ruta);
            Escribir.WriteLine(Usuario + "*" + contraseña + "*");
            Escribir.Close();
        }
        static void GUT(string Usuario, string contraseña)
        {
            Escribir = File.AppendText(ruta2);
            Escribir.WriteLine(Usuario + "*" + contraseña + "*");
            Escribir.Close();
        }
        static string buscara(string usua, string contra)
        {
            string linea = "";
            string n = "Usuario o contraseña incorrectos";
            Leer = File.OpenText(ruta);
            linea = Leer.ReadLine();
            while (linea != null)
            {
                string[] vec = linea.Split('*');
                if (vec[0] == usua && vec[1] == contra)
                {
                    n = "Usuario y contraseña correctos";
                }
                linea = Leer.ReadLine();
            }
            Leer.Close();
            return n;
        }
        static string buscart(string usua, string contra)
        {
            string linea = "";
            string n = "Usuario o contraseña incorrectos";
            Leer = File.OpenText(ruta2);
            linea = Leer.ReadLine();
            while (linea != null)
            {
                string[] vec = linea.Split('*');
                if (vec[0] == usua && vec[1] == contra)
                {
                    n = "Usuario y contraseña correctos";
                }
                linea = Leer.ReadLine();
            }
            Leer.Close();
            return n;
        }
        static void acciona(int numero)
        {
            if (numero == 1)
            {
                GU(llenar("Usuario"), llenar("contraseña"));
            }
            else if (numero == 2)
            {
                GUT(llenar("Usuario"), llenar("contraseña"));
            }
            else if (numero == 3)
            {
                intra.mosin();
            }
            else if (numero == 3)
            {
                intra.mostrarin();
            }
            else if (numero == 4)
            {
                mostrara();
                mostrart();
            }
            else if (numero == 5)
            {
                intra.mostrarfac();
            }
            else
            {
                Console.WriteLine("Ingrese un número que esté fuera del rango");
            }

        }
        static void acciont(int numero)
        {
            if (numero == 1)
            {
                int tra;
                Console.Write("\n1. Producto ya en existencia \n2. Desea ingresar un nuevo producto \nSeleccione el numero de la acción que desea realizar : ");
                tra = int.Parse(Console.ReadLine());
                if (tra == 1)
                {
                    char In = 'S';
                    while (In != 'N')
                    {
                        intra.GPN(llenar("Producto"), llenar("Cantidad"));
                        Console.Write("Desea cargar otro producto en existencia? [S/N]: ");
                        In = char.Parse(Console.ReadLine());
                    }
                }
                if (tra == 2)
                {
                    char Pn = 'S';
                    while (Pn != 'N')
                    {
                        intra.GP(llenar("Producto"), llenar("Cantidad"), llenar("Precio"));
                        Console.Write("Desea ingresar otro nuevo producto? [S/N]: ");
                        Pn = char.Parse(Console.ReadLine());
                    }
                }
            }
            else if (numero == 2)
            {
                char Op = 'S';
                while (Op != 'N')
                {
                    intra.fac(llenar(" No. de factura "), llenar(" Nombre "), llenar(" NIT "), llenar(" fecha "));
                    char p = 'S';
                    double S = 0;
                    while (p != 'N')
                    {
                        S = S + (intra.factura(intra.lleno("Nombre "), llenar("Cantidad ")));
                        Console.Write("Desea ingresar otro producto? [S/N]: ");
                        p = char.Parse(Console.ReadLine());
                    }
                    intra.compra(S);
                    Console.Write("Desea realizar otra factura? [S/N]: ");
                    Op = char.Parse(Console.ReadLine());
                }
            }
            else
            {
                Console.WriteLine("Ingrese un número que esté dentro del rango");
            }
        }
        static void mostrara()
        {
            Console.WriteLine("\n \n__Administradores__\n \n");
            string fila = "";
            Leer = File.OpenText(ruta);
            fila = Leer.ReadLine();
            while (fila != null)
            {
                string[] vec = fila.Split('*');
                Console.WriteLine("Usuario: " + vec[0]);
                fila = Leer.ReadLine();
            }
            Leer.Close();
        }
        static void mostrart()
        {
            Console.WriteLine("\n \n__Trabajadores__\n \n");
            string fila = "";
            Leer = File.OpenText(ruta2);
            fila = Leer.ReadLine();
            while (fila != null)
            {
                string[] vec = fila.Split('*');
                Console.WriteLine("Usuario: " + vec[0]);
                fila = Leer.ReadLine();
            }
            Leer.Close();
        }
    }
}
