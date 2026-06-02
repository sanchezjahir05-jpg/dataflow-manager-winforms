using DataFlowManager.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlowManager.Controlador
{
    public class IncidenciaController
    {
        public static List<Incidencia> listaIncidencias = new List<Incidencia>();
        public static List<Trabajador> listaTrabajadores = new List<Trabajador>();

        private static bool trabajadoresCargados = false;

        public static void CargarTrabajadores()
        {
            if (trabajadoresCargados)
            {
                return;
            }

            listaTrabajadores.Add(new Trabajador("0700000001", "Hector", "Villavicencio", "Zaruma", "Desarrollador"));
            listaTrabajadores.Add(new Trabajador("0700000002", "Hector", "Villavicencio", "Machala", "Analista QA"));
            listaTrabajadores.Add(new Trabajador("0700000003", "Andrea", "Mendoza", "Pasaje", "Project Manager"));
            listaTrabajadores.Add(new Trabajador("0700000004", "Luis", "Torres", "Santa Rosa", "DevOps"));
            listaTrabajadores.Add(new Trabajador("0700000005", "María", "Cedeño", "Machala", "Diseñadora UI"));

            trabajadoresCargados = true;
        }

        public static List<Trabajador> ObtenerTrabajadores()
        {
            CargarTrabajadores();
            return listaTrabajadores;
        }

        public static void Agregar(Incidencia incidencia)
        {
            ValidarIncidencia(incidencia);

            if (Buscar(incidencia.Id) != -1)
            {
                throw new Exception("Ya existe una incidencia registrada con ese ID.");
            }

            listaIncidencias.Add(incidencia);
        }

        public static void Editar(int pos, Incidencia incidencia)
        {
            ValidarIncidencia(incidencia);

            if (pos >= 0 && pos < listaIncidencias.Count)
            {
                listaIncidencias[pos] = incidencia;
            }
            else
            {
                throw new Exception("No se encontró la posición de la incidencia.");
            }
        }

        public static void Eliminar(int pos)
        {
            if (pos >= 0 && pos < listaIncidencias.Count)
            {
                listaIncidencias.RemoveAt(pos);
            }
            else
            {
                throw new Exception("No se encontró la posición de la incidencia.");
            }
        }

        public static Incidencia GetIncidencia(int pos)
        {
            if (pos >= 0 && pos < listaIncidencias.Count)
            {
                return listaIncidencias[pos];
            }

            return null;
        }

        public static int Buscar(int id)
        {
            for (int i = 0; i < listaIncidencias.Count; i++)
            {
                if (listaIncidencias[i].Id == id)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int GenerarNuevoId()
        {
            if (listaIncidencias.Count == 0)
            {
                return 1;
            }

            return listaIncidencias.Max(i => i.Id) + 1;
        }

        public static List<Incidencia> BuscarPorCriterio(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
            {
                return listaIncidencias.ToList();
            }

            criterio = criterio.ToLower();

            return listaIncidencias
                .Where(i => i.Titulo.ToLower().Contains(criterio)
                         || i.Descripcion.ToLower().Contains(criterio)
                         || i.Prioridad.ToLower().Contains(criterio)
                         || i.Estado.ToLower().Contains(criterio)
                         || i.Responsable.Nombre.ToLower().Contains(criterio)
                         || i.Responsable.Apellido.ToLower().Contains(criterio)
                         || i.Responsable.Cargo.ToLower().Contains(criterio)
                         || i.Responsable.Ciudad.ToLower().Contains(criterio)
                         || i.Responsable.Cedula.Contains(criterio))
                .ToList();
        }

        public static int ContarTotal()
        {
            return listaIncidencias.Count;
        }

        public static int ContarPorEstado(string estado)
        {
            return listaIncidencias.Count(i => i.Estado == estado);
        }

        public static int ContarPorPrioridad(string prioridad)
        {
            return listaIncidencias.Count(i => i.Prioridad == prioridad);
        }

        private static void ValidarIncidencia(Incidencia incidencia)
        {
            if (incidencia == null)
            {
                throw new Exception("La incidencia no puede ser nula.");
            }

            if (incidencia.Id <= 0)
            {
                throw new Exception("El ID debe ser mayor a cero.");
            }

            if (string.IsNullOrWhiteSpace(incidencia.Titulo))
            {
                throw new Exception("El título es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(incidencia.Descripcion))
            {
                throw new Exception("La descripción es obligatoria.");
            }

            if (incidencia.Responsable == null)
            {
                throw new Exception("Debe seleccionar un trabajador responsable.");
            }

            if (string.IsNullOrWhiteSpace(incidencia.Prioridad))
            {
                throw new Exception("La prioridad es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(incidencia.Estado))
            {
                throw new Exception("El estado es obligatorio.");
            }

            if (incidencia.FechaLimite.Date < DateTime.Now.Date)
            {
                throw new Exception("La fecha límite no puede ser menor a la fecha actual.");
            }
        }
    }
}