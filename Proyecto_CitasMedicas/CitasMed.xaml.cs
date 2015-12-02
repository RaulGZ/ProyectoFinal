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
        //private Paciente tmpProduct = null;
        private List<CitasMed> ShoppingCart;

        public CitasMed()
        {
            InitializeComponent();
            ShoppingCart = new List<CitasMed>();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            proyectoCM db = new proyectoCM();
            //combobox del Motivo de Consulta
            cbMotivo.ItemsSource = db.Motivos.ToList();
            cbMotivo.DisplayMemberPath = "nomMotivo";
            cbMotivo.SelectedValuePath = "idMotivo";
            //cbMotivo.SelectedIndex = 0;

            //Medico
            cbMedico.ItemsSource = db.Medicos.ToList();
            cbMedico.DisplayMemberPath = "nomMedico";
            cbMedico.SelectedValuePath = "idMedico";
            //cbMedico.SelectedIndex = 0;

            //Hospital
            cbHospital.ItemsSource = db.Hospitales.ToList();
            cbHospital.DisplayMemberPath = "NomHospital";
            cbHospital.SelectedValuePath = "idHospital";
            //cbHospital.SelectedIndex = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtAfiliacion.Text.Trim(), @"^\d+$"))
            {
                proyectoCM db = new proyectoCM();
                int numAfiliacion = int.Parse(txtAfiliacion.Text);

                Proyecto_CitasMedicas.miProyecto.Paciente s = db.Pacientes.SingleOrDefault(x => x.numAfiliacion == numAfiliacion);
                if (s != null) //if product was found
                {
                    //tmpProduct = s;
                    lbPaciente.Content = string.Format("Nombre del Paciente: {0}", s.nomPaciente);
                    cbHospital.IsEnabled = true;
                    cbMedico.IsEnabled = true;
                    cbMotivo.IsEnabled = true;
                    calCita.IsEnabled = true;
                }
                else
                {
                    //if product was not found we display a user notification window
                    MessageBox.Show("Afiliación no encontrada.", "Error de número de afiliación", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else { MessageBox.Show("Capture el No. de Afiliación \n Solo NÚMEROS"); }

        }

        private void CleanUp()
        {
            //shopping cart = a new empty list
            ShoppingCart = new List<CitasMed>();
            //Textboxes and labels are set to defaults
            txtAfiliacion.Text = string.Empty;
            lbPaciente.Content = "Nombre de Paciente: ";
            //DataGrid items are set to null
            dbgrid.ItemsSource = null;
            dbgrid.Items.Refresh();
            //Tmp variable is erased using null
            //tmpProduct = null;
            cbMotivo.IsEnabled = false;
            cbMedico.IsEnabled = false;
            cbHospital.IsEnabled = false;
            calCita.IsEnabled = false;
        }

        private void btLimpiar_Click(object sender, RoutedEventArgs e)
        {
            CleanUp();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (cbMedico.SelectedIndex > -1 && cbHospital.SelectedIndex > -1 && cbMotivo.SelectedIndex > -1)
            {
                proyectoCM db = new proyectoCM();
                Cita cit = new Cita();
                //cit.hrCita = calCita.ToString("MM/dd/yyyy");
                cit.MedicoidMedico = (int)cbMedico.SelectedValue;
                cit.PacienteidPaciente = int.Parse(txtAfiliacion.Text);
                cit.MotivoidMotivo = (int)cbMotivo.SelectedValue;
                cit.HospitalidHospital = (int)cbHospital.SelectedValue;
                db.Citas.Add(cit);
                MessageBox.Show("Cita Generada Correctamente");

                //Muestra las citas registradas.
                /*var registros = from s in db.Citas
                                select s;
                dbgrid.ItemsSource = registros.ToList();*/
                //db.SaveChanges();
                
            }//if
            else {
                MessageBox.Show("Verifique que se hayan seleccionado todos los campos");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
