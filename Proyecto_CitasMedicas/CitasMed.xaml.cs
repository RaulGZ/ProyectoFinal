using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Proyecto_CitasMedicas.miProyecto;

namespace Proyecto_CitasMedicas
{
    /// <summary>
    /// Interaction logic for CitasMed.xaml
    /// </summary>
    public partial class CitasMed : Window
    {
        public CitasMed()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtAfiliacion.Text.Trim(), @"^\d+$"))
            {
                proyectoCM db = new proyectoCM();
                int numAfiliacion = int.Parse(txtAfiliacion.Text);
                var registros = from s in db.Pacientes
                                where s.numAfiliacion == numAfiliacion
                                select new
                                {
                                    s.numAfiliacion,
                                    s.nomPaciente,
                                    s.alergicoA
                                };
                dbgrid.ItemsSource = registros.ToList();
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            proyectoCM db = new proyectoCM();
            //combobox del Motivo de Consulta
            cbMotivo.ItemsSource = db.Motivos.ToList();
            cbMotivo.DisplayMemberPath = "nomMotivo";
            cbMotivo.SelectedValuePath = "idMotivo";
            cbMotivo.SelectedIndex = 0;

            //Medico
            cbMedico.ItemsSource = db.Medicos.ToList();
            cbMedico.DisplayMemberPath = "nomMedico";
            cbMedico.SelectedValuePath = "idMedico";
            cbMedico.SelectedIndex = 0;

            //Hospital
            cbHospital.ItemsSource = db.Hospitales.ToList();
            cbHospital.DisplayMemberPath = "NomHospital";
            cbHospital.SelectedValuePath = "idHospital";
            cbHospital.SelectedIndex = 0;
        }

        private void btLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
