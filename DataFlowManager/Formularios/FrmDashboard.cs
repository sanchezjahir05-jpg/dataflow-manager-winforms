using DataFlowManager.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataFlowManager.Formularios
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
            controlador = new IncidenciaController();
        }

        private IncidenciaController controlador;

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;

            button1.Text = "Actualizar";
            button2.Text = "Cerrar";

            CargarResumen();
        }

        private void CargarResumen()
        {
            label1.Text = "Dashboard de Incidencias";

            label2.Text = "Total de incidencias: " + IncidenciaController.ContarTotal();
            label3.Text = "Pendientes: " + IncidenciaController.ContarPorEstado("Pendiente");
            label4.Text = "En proceso: " + IncidenciaController.ContarPorEstado("En proceso");
            label5.Text = "En revisión: " + IncidenciaController.ContarPorEstado("En revisión");
            label6.Text = "Resueltas: " + IncidenciaController.ContarPorEstado("Resuelta");
            label7.Text = "Canceladas: " + IncidenciaController.ContarPorEstado("Cancelada");
            label8.Text = "Prioridad crítica: " + IncidenciaController.ContarPorPrioridad("Crítica");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarResumen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
