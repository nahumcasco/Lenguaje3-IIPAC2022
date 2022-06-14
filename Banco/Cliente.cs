using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Cliente
    {
        public string Identidad { get; set; }
        public string Nombre { get; set; }

        public Cliente()
        {
        }

        public Cliente(string identidad, string nombre)
        {
            Identidad = identidad;
            Nombre = nombre;
        }
    }
}
