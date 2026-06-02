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
    public partial class FrmAcercaDe : Form
    {
        public FrmAcercaDe()
        {
            InitializeComponent();
        }

        private void FrmAcercaDe_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;

            label2.Text =
                "Sistema de gestión de tareas e incidencias para una empresa de software.\n" +
                "El objetivo del sistema es registrar, organizar y controlar incidencias \n" +
                "asignadas a trabajadores del equipo de desarrollo, permitiendo mejorar \n" +
                "la coordinación, el seguimiento de errores y la gestión del trabajo.";

            label3.Text =
                "Herramientas aplicadas:\n" +
                "- C# con Windows Forms\n" +
                "- Programación orientada a objetos\n" +
                "- Git y GitHub\n" +
                "- Ramas de desarrollo\n" +
                "- Pull Requests\n" +
                "- GitHub Actions\n" +
                "- GitHub Copilot\n" +
                "- Spec Driven Development";

            label4.Text =
                "Proyecto de Programación Avanzada en C#\n" +
                "Integrantes: Jahir Sánchez, Darwin Herrera, Angel Ortega.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
