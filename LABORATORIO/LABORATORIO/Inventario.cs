using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LABORATORIO
{
    class Inventario
    {
        static string inventario = "Inventario.txt";
        static string inventario2 = "Inventario2.txt";
        static string facturas1 = "Facturas.txt";
        static FileStream Archivo;
        static StreamReader Leer;
        static StreamWriter Escribir;

        public void GPN(string producto, string cantidad)
        {
            string linea = "";
            Leer = File.OpenText(inventario);
            linea = Leer.ReadLine();
            while (linea != null)
            {
                string[] vec = linea.Split('*');
                if (vec[0] == producto && vec[1]!=cantidad)
                {
                    Escribir = File.AppendText(inventario2);
                    Escribir.WriteLine(vec[0] + "*" + ((double.Parse(vec[1])) + (double.Parse(cantidad))) + "*" + vec[2] + "*");
                    Escribir.Close();
                }
                if(vec[0]!=producto)
                {
                    Escribir = File.AppendText(inventario2);
                    Escribir.WriteLine(vec[0] + "*" + vec[1] + "*" + vec[2] + "*");
                    Escribir.Close();
                }
                linea = Leer.ReadLine();
            }
            Leer.Close();
            File.Delete(inventario);
            string dato = "";
            Leer = File.OpenText(inventario2);
            dato = Leer.ReadLine();
            while (dato != null)
            {
                string[] vec = dato.Split('*');
                Escribir = File.AppendText(inventario);
                Escribir.WriteLine(vec[0] + "*" + vec[1] + "*" + vec[2] + "*");
                Escribir.Close();
                dato = Leer.ReadLine();
            }
            Leer.Close();
            File.Delete(inventario2);
        }
        public string llenar(string dato)
        {
            Console.Write("Ingrese " + dato + ": ");
            return (Console.ReadLine());
        }
        public void mosin()
        {
            string linea = "";
            Leer = File.OpenText(inventario);
            linea = Leer.ReadLine();
            while (linea != null)
            {
                string[] vec = linea.Split('*');
                Console.WriteLine("\n Producto: " + vec[0] + "    ----    Cantidad: " + vec[1] + "    ----    Precio: " + vec[2]);
            }
            Leer.Close();
        }
        public string lleno(string dato)
        { 
                Console.Write( dato +" del producto: ");
            return (Console.ReadLine());
        }
        public double factura(string producto, string cantidad)
        {
            double T=0;
            string linea = "";
            Leer = File.OpenText(inventario);
            linea = Leer.ReadLine();
            while (linea != null)
            {
                string[] vec = linea.Split('*');
                if (vec[0] == producto)
                {
                    Escribir = File.AppendText(inventario2);
                    Escribir.WriteLine(vec[0] + "*" + ((double.Parse(vec[1])) - (double.Parse(cantidad))) + "*" + vec[2] + "*");
                    Escribir.Close();
                }
                else
                {
                    Escribir = File.AppendText(inventario2);
                    Escribir.WriteLine(vec[0] + "*" + vec[1] + "*" + vec[2] + "*");
                    Escribir.Close();
                }
                linea = Leer.ReadLine();
            }
            Leer.Close();
            File.Delete(inventario);
            string dato = "";
            Leer = File.OpenText(inventario2);
            dato = Leer.ReadLine();
            while (dato != null)
            {
               string[] vec = dato.Split('*');
                Escribir = File.AppendText(inventario);
                Escribir.WriteLine(vec[0] + "*" + vec[1] + "*" + vec[2] + "*");
                Escribir.Close();
                dato = Leer.ReadLine();
            }
            Leer.Close();
            File.Delete(inventario2);
            Escribir = File.AppendText(facturas1);
            Escribir.Write(producto + "      Cantidad__ ");
            Escribir.Close();
            Escribir = File.AppendText(facturas1);
            Escribir.Write(cantidad + "      Precio__ Q");
            Escribir.Close();
            string fila = "";
            Leer = File.OpenText(inventario);
            fila = Leer.ReadLine();
            while (fila != null)
            {
                string[] vec = fila.Split('*');
                if (vec[0] == producto)
                {
                    Escribir = File.AppendText(facturas1);
                    Escribir.WriteLine(vec[2]);
                    Escribir.Close();
                    T = ((double.Parse(vec[2]) * (double.Parse(cantidad))));
                    Leer.Close();
                    return T;
                }
                fila = Leer.ReadLine();
            }
            Leer.Close();
            return T;
        }
        public void fac(string num, string nombre, string nit, string fecha)
        {
            Escribir = File.AppendText(facturas1);
            Escribir.WriteLine("No. de factura: " + num + "\nNombre: " + nombre + "\nNIT:" + nit + "\nFecha: " + fecha + "\n" );
            Escribir.Close();
        }
        public void compra(double total)    
        {
            Escribir = File.AppendText(facturas1);
            Console.WriteLine("El total de la compra es: Q" + total);
            Escribir.WriteLine("El total de la compra es: Q" + total + "°" + "\n \n \n \n ");
            Escribir.Close();
        }
        public void GP(string producto, string cantidad, string precio)
        {
            Escribir = File.AppendText(inventario);
            Escribir.WriteLine(producto + "*" + cantidad + "*" + precio + "*");
            Escribir.Close();
        }
        public void mostrarin()
        {
            Console.WriteLine("\n \n__Inventario__\n \n");
            string fila = "";
            Leer = File.OpenText(inventario);
            fila = Leer.ReadLine();
            string[] vec = fila.Split('*');
            while (fila != null)
            {
                Console.WriteLine("Producto: " + vec[0] + "    ----    Cantidad: " + vec[1] + "    ----    Precio: Q" + vec[2] );
                fila = Leer.ReadLine();
            }
            Leer.Close();
        }               
        public void mostrarfac()
        {
            string fila = "";
            Leer = File.OpenText(facturas1);
            fila = Leer.ReadLine();
            while (fila != null)
            {
                Console.WriteLine("\n \n__Facturas__\n \n");
                string[] vec = fila.Split('°');
                Console.WriteLine(vec[0]);
                fila = Leer.ReadLine();
            }
            Leer.Close();
        }
    }
}
