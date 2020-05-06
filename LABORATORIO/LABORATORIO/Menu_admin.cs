using System;
using System.Collections.Generic;
using System.Text;

namespace LABORATORIO
{
    class Menu_admin
    {
        public int mena()
        {
            Console.Write("Bienvenido al menú de administradores\n1. Crear usuario de administrador\n" +
                "2. Crear usuario de trabajador \n3. Mostrar inventario " +
                "\n4. Mostrar Usuarios registrados\n5. Mostrar facturas generadas" +
                "\nIngrese el numero de la acción que desea realizar: ");
            return (int.Parse(Console.ReadLine()));
        }
    }
}
