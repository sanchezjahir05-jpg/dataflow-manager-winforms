using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlowManager.Entidades
{
    public class Incidencia
    {
        private int id;
        private string titulo;
        private string descripcion;
        private Trabajador responsable;
        private string prioridad;
        private string estado;
        private DateTime fechaCreacion;
        private DateTime fechaLimite;

        public Incidencia()
        {
            id = 0;
            titulo = string.Empty;
            descripcion = string.Empty;
            responsable = new Trabajador();
            prioridad = "Media";
            estado = "Pendiente";
            fechaCreacion = DateTime.Now;
            fechaLimite = DateTime.Now.AddDays(7);
        }

        public Incidencia(int id, string titulo, string descripcion, Trabajador responsable, string prioridad, string estado, DateTime fechaCreacion, DateTime fechaLimite)
        {
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.responsable = responsable;
            this.prioridad = prioridad;
            this.estado = estado;
            this.fechaCreacion = fechaCreacion;
            this.fechaLimite = fechaLimite;
        }

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Trabajador Responsable { get => responsable; set => responsable = value; }
        public string Prioridad { get => prioridad; set => prioridad = value; }
        public string Estado { get => estado; set => estado = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public DateTime FechaLimite { get => fechaLimite; set => fechaLimite = value; }
    }
}
