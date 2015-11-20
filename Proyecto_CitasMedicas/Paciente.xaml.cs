using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Proyecto_CitasMedicas.miProyecto;

namespace Proyecto_CitasMedicas
{
    /// <summary>
    /// Interaction logic for Paciente.xaml
    /// </summary>
    public partial class Paciente : Window
    {
        public Paciente()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Registrar
            if (Regex.IsMatch(txtnomPaciente.Text, @"^[a-zA-Z]+$"))
            {
                if (Regex.IsMatch(txedad.Text, @"\d+$"))
                {
                    if (Regex.IsMatch(txTelefono.Text, @"\d+$"))
                    {
                        if (Regex.IsMatch(txAfiliacion.Text, @"\d+$"))
                        {
                            if (Regex.IsMatch(txtdirPaciente.Text, @"^[a-zA-Z]+$"))
                            {
                                if (Regex.IsMatch(txtSangre.Text, @"^[a-zA-Z]+$"))
                                {
                                    if (Regex.IsMatch(txtAlergias.Text, @"^[a-zA-Z]+$"))
                                    {
                                        //1.- Instanciar la "Base de Datos"
                                        proyectoCM db = new proyectoCM();
                                        //2.- Instanciar "Tabla Paciente"
                                        Proyecto_CitasMedicas.miProyecto.Paciente pac = new Proyecto_CitasMedicas.miProyecto.Paciente();
                                        pac.numAfiliacion = int.Parse(txAfiliacion.Text);
                                        pac.nomPaciente = txtnomPaciente.Text;
                                        pac.edad = int.Parse(txedad.Text);
                                        pac.telPac = int.Parse(txTelefono.Text);
                                        pac.dirPac = txtdirPaciente.Text;
                                        pac.tipSangre = txtSangre.Text;
                                        pac.alergicoA = txtAlergias.Text;
                                        //agregar los datos capturados
                                        db.Pacientes.Add(pac);
                                        db.SaveChanges();
                                    }
                                    else { MessageBox.Show("Solo letras en el campo #Alergias"); }
                                }
                                else { MessageBox.Show("Solo letras en el campo #Tipo de Sangre"); }
                            }
                            else { MessageBox.Show("Solo letras #Domicilio"); }
                        }
                        else { MessageBox.Show("Solo números #Núm de Afiliación"); }
                    }
                    else { MessageBox.Show("Solo números #Teléfono"); }
                }
                else { MessageBox.Show("Solo números #edad"); }
            }
            else { MessageBox.Show("Solo letras #Nombre del Paciente"); } 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Eliminar
            if (Regex.IsMatch(txid.Text, @"\d+$"))
            {
                proyectoCM db = new proyectoCM();
                //Buscar el id capturado en la caja de texto
                int idPaciente = int.Parse(txid.Text);
                var paci = db.Pacientes.SingleOrDefault(x => x.idPaciente == idPaciente);
                if (paci != null)
                {
                    db.Pacientes.Remove(paci);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo números #id"); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // consultar todo
            proyectoCM db = new proyectoCM();
            var registros = from s in db.Pacientes
                            select s;
            dbgrid.ItemsSource = registros.ToList();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Modificar
            if (Regex.IsMatch(txtnomPaciente.Text, @"^[a-zA-Z]+$"))
            {
                if (Regex.IsMatch(txedad.Text, @"\d+$"))
                {
                    if (Regex.IsMatch(txTelefono.Text, @"\d+$"))
                    {
                        if (Regex.IsMatch(txAfiliacion.Text, @"\d+$"))
                        {
                            if (Regex.IsMatch(txtdirPaciente.Text, @"^[a-zA-Z]+$"))
                            {
                                if (Regex.IsMatch(txtSangre.Text, @"^[a-zA-Z]+$"))
                                {
                                    if (Regex.IsMatch(txtAlergias.Text, @"^[a-zA-Z]+$"))
                                    {
                                        //1.- Instanciar "Base de Datos"
                                        proyectoCM db = new proyectoCM();
                                        //2.- Buscar el id capturado en la caja de texto
                                        int idPaciente = int.Parse(txid.Text);
                                        //var es una variable dinamica
                                        var pac = db.Pacientes.SingleOrDefault(x => x.idPaciente == idPaciente);
                                        if (pac != null)
                                        {
                                            //asignar los nuevos valores
                                            pac.numAfiliacion = int.Parse(txAfiliacion.Text);
                                            pac.nomPaciente = txtnomPaciente.Text;
                                            pac.edad = int.Parse(txedad.Text);
                                            pac.telPac = int.Parse(txTelefono.Text);
                                            pac.dirPac = txtdirPaciente.Text;
                                            pac.tipSangre = txtSangre.Text;
                                            pac.alergicoA = txtAlergias.Text;
                                            db.SaveChanges();
                                        }
                                        else { MessageBox.Show("Solo letras en el campo #Alergias"); }
                                    }
                                    else { MessageBox.Show("Solo letras en el campo #Tipo de Sangre"); }
                                }
                                else { MessageBox.Show("Solo letras #Domicilio"); }
                            }
                            else { MessageBox.Show("Solo números #Núm de Afiliación"); }
                        }
                        else { MessageBox.Show("Solo números #Teléfono"); }
                    }
                    else { MessageBox.Show("Solo números #edad"); }
                }
                else { MessageBox.Show("Solo letras #Nombre del Paciente"); }
            }
        }
    }
}
