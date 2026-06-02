using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlowManager.Entidades
{
    public class Trabajador
    {
        private string cedula;
        private string nombre;
        private string apellido;
        private string ciudad;
        private string cargo;

        public Trabajador()
        {
            cedula = string.Empty;
            nombre = string.Empty;
            apellido = string.Empty;
            ciudad = string.Empty;
            cargo = string.Empty;
        }

        public Trabajador(string cedula, string nombre, string apellido, string ciudad, string cargo)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido = apellido;
            this.ciudad = ciudad;
            this.cargo = cargo;
        }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Cargo { get => cargo; set => cargo = value; }

        public string NombreCompleto
        {
            get { return nombre + " " + apellido; }
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
