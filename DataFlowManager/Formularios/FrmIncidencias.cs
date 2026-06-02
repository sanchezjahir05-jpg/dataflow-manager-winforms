using DataFlowManager.Controlador;
using DataFlowManager.Entidades;
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
    public partial class FrmIncidencias : Form
    {
        public FrmIncidencias()
        {
            InitializeComponent();
            controlador = new IncidenciaController();
        }

        private IncidenciaController controlador;
        private int pos = -1;
        private bool cargandoTabla = false;

        private void FrmIncidencias_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;

            CargarCombos();
            ConfigurarDataGridView();
            CargarTabla();
            GenerarIdAutomatico();
        }

    

        private void CargarCombos()
        {
            comboBox1.DataSource = null;
            comboBox1.DisplayMember = "NombreCompleto";
            comboBox1.ValueMember = "Cedula";
            comboBox1.DataSource = IncidenciaController.ObtenerTrabajadores();

            comboBox2.Items.Clear();
            comboBox2.Items.Add("Baja");
            comboBox2.Items.Add("Media");
            comboBox2.Items.Add("Alta");
            comboBox2.Items.Add("Crítica");
            comboBox2.SelectedIndex = 1;

            comboBox3.Items.Clear();
            comboBox3.Items.Add("Pendiente");
            comboBox3.Items.Add("En proceso");
            comboBox3.Items.Add("En revisión");
            comboBox3.Items.Add("Resuelta");
            comboBox3.Items.Add("Cancelada");
            comboBox3.SelectedIndex = 0;
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarTabla()
        {
            cargandoTabla = true;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = IncidenciaController.listaIncidencias.ToList();

            FormatearColumnas();

            cargandoTabla = false;
        }

        private void CargarTabla(List<Incidencia> lista)
        {
            cargandoTabla = true;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista.ToList();

            FormatearColumnas();

            cargandoTabla = false;
        }

        private void CargarDatosEnFormulario(Incidencia incidencia)
        {
            textBox1.Text = incidencia.Id.ToString();
            textBox2.Text = incidencia.Titulo;
            textBox3.Text = incidencia.Descripcion;

            SeleccionarTrabajador(incidencia.Responsable.Cedula);

            comboBox2.Text = incidencia.Prioridad;
            comboBox3.Text = incidencia.Estado;

            dateTimePicker1.Value = incidencia.FechaLimite;
        }

        private void SeleccionarTrabajador(string cedula)
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                Trabajador trabajador = comboBox1.Items[i] as Trabajador;

                if (trabajador != null && trabajador.Cedula == cedula)
                {
                    comboBox1.SelectedIndex = i;
                    return;
                }
            }
        }

        private void FormatearColumnas()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                return;
            }

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].HeaderText = "ID";

            if (dataGridView1.Columns["Titulo"] != null)
                dataGridView1.Columns["Titulo"].HeaderText = "Título";

            if (dataGridView1.Columns["Descripcion"] != null)
                dataGridView1.Columns["Descripcion"].HeaderText = "Descripción";

            if (dataGridView1.Columns["Responsable"] != null)
                dataGridView1.Columns["Responsable"].HeaderText = "Responsable";

            if (dataGridView1.Columns["Prioridad"] != null)
                dataGridView1.Columns["Prioridad"].HeaderText = "Prioridad";

            if (dataGridView1.Columns["Estado"] != null)
                dataGridView1.Columns["Estado"].HeaderText = "Estado";

            if (dataGridView1.Columns["FechaCreacion"] != null)
                dataGridView1.Columns["FechaCreacion"].HeaderText = "Fecha creación";

            if (dataGridView1.Columns["FechaLimite"] != null)
                dataGridView1.Columns["FechaLimite"].HeaderText = "Fecha límite";

            if (dataGridView1.Columns["ResponsableTexto"] != null)
                dataGridView1.Columns["ResponsableTexto"].HeaderText = "Nombre responsable";

            if (dataGridView1.Columns["CargoResponsable"] != null)
                dataGridView1.Columns["CargoResponsable"].HeaderText = "Cargo";
        }

        private void GenerarIdAutomatico()
        {
            textBox1.Text = IncidenciaController.GenerarNuevoId().ToString();
            textBox1.Enabled = false;
        }

        private void LimpiarCampos()
        {
            pos = -1;

            textBox1.Text = IncidenciaController.GenerarNuevoId().ToString();
            textBox1.Enabled = false;

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 1;
            }

            if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
            }

            dateTimePicker1.Value = DateTime.Now.AddDays(7);
        }

        private Incidencia ObtenerDatosFormulario()
        {
            Trabajador trabajador = comboBox1.SelectedItem as Trabajador;

            Incidencia incidencia = new Incidencia();

            incidencia.Id = int.Parse(textBox1.Text);
            incidencia.Titulo = textBox2.Text.Trim();
            incidencia.Descripcion = textBox3.Text.Trim();
            incidencia.Responsable = trabajador;
            incidencia.Prioridad = comboBox2.Text;
            incidencia.Estado = comboBox3.Text;
            incidencia.FechaLimite = dateTimePicker1.Value;

            return incidencia;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Incidencia incidencia = ObtenerDatosFormulario();

                IncidenciaController.Agregar(incidencia);

                CargarTabla();
                LimpiarCampos();

                MessageBox.Show("Incidencia registrada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (pos == -1)
                {
                    MessageBox.Show("Seleccione una incidencia de la tabla.");
                    return;
                }

                Incidencia anterior = IncidenciaController.GetIncidencia(pos);

                if (anterior == null)
                {
                    MessageBox.Show("No se encontró la incidencia seleccionada.");
                    return;
                }

                Incidencia editada = ObtenerDatosFormulario();

                editada.Id = anterior.Id;
                editada.FechaCreacion = anterior.FechaCreacion;

                IncidenciaController.Editar(pos, editada);

                CargarTabla();
                LimpiarCampos();

                MessageBox.Show("Incidencia editada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al editar");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (pos == -1)
                {
                    MessageBox.Show("Seleccione una incidencia de la tabla.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de eliminar esta incidencia?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    IncidenciaController.Eliminar(pos);

                    CargarTabla();
                    LimpiarCampos();

                    MessageBox.Show("Incidencia eliminada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                List<Incidencia> resultado = IncidenciaController.BuscarPorCriterio(textBox4.Text.Trim());
                CargarTabla(resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al buscar");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (cargandoTabla)
                {
                    return;
                }

                if (e.RowIndex < 0)
                {
                    return;
                }

                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                pos = IncidenciaController.Buscar(id);

                if (pos == -1)
                {
                    MessageBox.Show("No se encontró la incidencia seleccionada.");
                    return;
                }

                Incidencia incidencia = IncidenciaController.GetIncidencia(pos);

                if (incidencia != null)
                {
                    CargarDatosEnFormulario(incidencia);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar: " + ex.Message);
            }
        }

     


    }
}
