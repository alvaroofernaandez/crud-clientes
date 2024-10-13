using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA2TAREA4
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public string correo { get; set; }

        public Cliente(int id, string nombre, string correo)
        {
            this.id = id;
            this.nombre = nombre;
            this.correo = correo;
        }
    }
}
