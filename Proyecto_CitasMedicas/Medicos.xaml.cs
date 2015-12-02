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
    /// Interaction logic for Medicos.xaml
    /// </summary>
    public partial class Medicos : Window
    {
        public Medicos()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Registrar
            if (Regex.IsMatch(txtNumeroAf.Text, @"^[ .a-zA-Z]+$"))
            {
                if (Regex.IsMatch(txtipoMedico.Text, @"^[ .a-zA-Z]+$"))
                {
                    if (Regex.IsMatch(txCedula.Text, @"\d+$"))
                    {
                        //1.- Instanciar la "Base de Datos"
                        proyectoCM db = new proyectoCM();
                        //2.- Instanciar 
                        Proyecto_CitasMedicas.miProyecto.Medico med = new Proyecto_CitasMedicas.miProyecto.Medico();
                        med.nomMedico = txtNumeroAf.Text;
                        med.tipoMedico = txtipoMedico.Text;
                        med.cedProfes = int.Parse(txCedula.Text);
                        //agregar los datos capturados
                        db.Medicos.Add(med);
                        db.SaveChanges();
                        MessageBox.Show("Registro realizado correctamente");
                        txtipoMedico.Clear();
                        txtNumeroAf.Clear();
                        txCedula.Clear();
                    }//CEDULA
                    else { MessageBox.Show("Captura Solo números en la #Cedula Profesional"); }
                }//TIPO
                else { MessageBox.Show("Captura Solo letras #Tipo de Médico"); }
            }//NOMBRE
            else { MessageBox.Show("Captura el Nombre de Médico \n Solo letras"); }
        }//BOTON

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txtid.IsEnabled = true;
            //Eliminar
            if (Regex.IsMatch(txtid.Text, @"\d+$"))
            {
                proyectoCM db = new proyectoCM();
                //Buscar el id capturado en la caja de texto
                int idMedico = int.Parse(txtid.Text);
                var med = db.Medicos.SingleOrDefault(x => x.idMedico == idMedico);
                if (med != null)
                {
                    db.Medicos.Remove(med);
                    db.SaveChanges();
                    MessageBox.Show("Registro eliminado correctamente");
                    txtid.Clear();
                }
            }
            else { MessageBox.Show("Introduce solo números en ID"); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            txtid.IsEnabled = true;
            //modificar
            if (Regex.IsMatch(txtid.Text, @"\d+$"))
            {
                        //1.- Instanciar "Base de Datos"
                        proyectoCM db = new proyectoCM();
                        //2.- Buscar el id capturado en la caja de texto
                        int idMedico = int.Parse(txtid.Text);
                        //var es una variable dinamica
                        var med = db.Medicos.SingleOrDefault(x => x.idMedico == idMedico);
                        if (med != null)
                        {

                            if (Regex.IsMatch(txtNumeroAf.Text, @"^[ .a-zA-Z]+$")) //nombre del Medico
                            {
                                if (Regex.IsMatch(txtipoMedico.Text, @"^[ .a-zA-Z]+$"))
                                {
                                    if (Regex.IsMatch(txCedula.Text, @"\d+$"))
                                    {
                            //asignar los nuevos valores
                            med.nomMedico = txtNumeroAf.Text;
                            med.tipoMedico = txtipoMedico.Text;
                            med.cedProfes = int.Parse(txCedula.Text);
                            db.SaveChanges();
                            MessageBox.Show("Registro modificado correctamente");
                            txtNumeroAf.Clear();
                            txCedula.Clear();
                            txtid.Clear();
                            txtipoMedico.Clear();
                                    }
                                    else { MessageBox.Show("Solo números #Cedula Profesional"); }
                                }   
                                else { MessageBox.Show("Solo letras #Tipo de Médico"); }
                            }
                            else { MessageBox.Show("Solo letras #Nombre de Médico"); }
                        }//if
            }
            else { MessageBox.Show("Captura el ID \n Solo números"); }

        }//boton modificar

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Consultar
            proyectoCM db = new proyectoCM();
            var registros = from s in db.Medicos
                            select s;
            dbgrid.ItemsSource = registros.ToList();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
