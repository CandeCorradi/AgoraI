using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class InscripcionesView : Form
    {
        GenericService<Capacitacion> _capacitacionService = new();
        InscripcionService _inscripcionService = new();

        public InscripcionesView()
        {
            InitializeComponent();
            _ = GetAllData();
        }
        private async Task GetAllData()
        {
            var capacitaciones = await _capacitacionService.GetAllAsync();
            CmbCapacitacion.DataSource = capacitaciones?.Where(c => c.InscripcionAbierta).ToList();
            CmbCapacitacion.DisplayMember = "Nombre"; //que campo de esa lista se usa para mostrar
            CmbCapacitacion.ValueMember = "Id"; //que campo de esa lista se usa como valor
            //cargamos las inscripciones de la capacitacion seleccionada


        }

        private async void CmbCapacitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //controlamos que no sea null y haya una capacitacion seleccionada
            if (CmbCapacitacion.SelectedItem is Capacitacion selectedCapacitacion)
            {
                var capacitacion = (Capacitacion)CmbCapacitacion.SelectedItem;
                GridInscripciones.DataSource = await _inscripcionService.GetInscriptosAsync(selectedCapacitacion.Id);
            }
        }
    }
}
