using System;
using System.Collections.Generic;
using System.Text;

namespace LABORATORIO
{
    class Persona
    {
        public string us()
        {
            string p;
            Console.Write("¿Es usted un trabajador o administrador?: ");
            p = Console.ReadLine();
            return p;
        }
    }
}
