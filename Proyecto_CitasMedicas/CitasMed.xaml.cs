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

        private void btLimpiar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtAfiliacion.Text.Trim(), @"^\d+$"))
            {
                proyectoCM db = new proyectoCM();
                Proyecto_CitasMedicas.miProyecto.Paciente pac = new Proyecto_CitasMedicas.miProyecto.Paciente();
                /*pac.numAfiliacion = int.Parse(txtAfiliacion.Text);
                int numAfiliacion = int.Parse(txtAfiliacion.Text);
                var registros = from s in db.Pacientes
                                where s.numAfiliacion == numAfiliacion
                                select new
                                {
                                    s.numAfiliacion,
                                    s.nomPaciente,
                                    s.alergicoA
                                };
                dbgrid.ItemsSource = registros.ToList();*/
            }
        }
    }
}
