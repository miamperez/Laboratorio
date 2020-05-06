using System;
using System.Collections.Generic;
using System.Text;

namespace LABORATORIO
{
    class Menu_tra
    {
        public int ment()
        {
            Console.WriteLine("Bienvenido al menú de trabajadores\n1. Cargar inventario\n" +
                "2. Facturar productos \nIngrese el numero de la acción que desea realizar: ");
            return (int.Parse(Console.ReadLine()));
        }
    }
}
