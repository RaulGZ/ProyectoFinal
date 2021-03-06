﻿using System;
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
    /// Interaction logic for Hospital.xaml
    /// </summary>
    public partial class Hospital : Window
    {
        public Hospital()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Registrar
            if (Regex.IsMatch(txtnomHospital.Text, @"^[ .a-zA-Z0123456789]+$"))
            {
                if (Regex.IsMatch(txtdirHospital.Text, @"^[ .a-zA-Z0123456789]+$"))
                {
                    //1.- Instanciar la "Base de Datos"
                    proyectoCM db = new proyectoCM();
                    //2.- Instanciar 
                    Proyecto_CitasMedicas.miProyecto.Hospital hosp = new Proyecto_CitasMedicas.miProyecto.Hospital();
                    hosp.NomHospital = txtnomHospital.Text;
                    hosp.DirHospital = txtdirHospital.Text;
                    //agregar los datos capturados
                    db.Hospitales.Add(hosp);
                    db.SaveChanges();
                    MessageBox.Show("Registro Exitoso");
                    txtdirHospital.Clear();
                    txtnomHospital.Clear();
                }
                else { MessageBox.Show("Captura Solo letras #Dirección de Hospital"); }
            }
            else { MessageBox.Show("Captura #Nombre de Hospital \n solo LETRAS"); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txtid.IsEnabled = true;
            //Eliminar
            if (Regex.IsMatch(txtid.Text, @"\d+$"))
            {
                proyectoCM db = new proyectoCM();
                //Buscar el id capturado en la caja de texto
                int idHospital = int.Parse(txtid.Text);
                var hosp = db.Hospitales.SingleOrDefault(x => x.idHospital == idHospital);
                if (hosp != null)
                {
                    db.Hospitales.Remove(hosp);
                    db.SaveChanges();
                    MessageBox.Show("Registro Eliminado");
                    txtid.Clear();
                }
            }
            else { MessageBox.Show("Debe capturar el ID \n solo números"); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            txtid.IsEnabled = true;
            //Modificar
            if (Regex.IsMatch(txtid.Text, @"\d+$"))
            {
                    //1.- Instanciar "Base de Datos"
                    proyectoCM db = new proyectoCM();
                    //2.- Buscar el id capturado en la caja de texto
                    int idHospital = int.Parse(txtid.Text);
                    //var es una variable dinamica
                    var hosp = db.Hospitales.SingleOrDefault(x => x.idHospital == idHospital);
                    if (hosp != null)
                    {
                        if (Regex.IsMatch(txtnomHospital.Text, @"^[ .a-zA-Z0123456789]+$"))
                        {
                            if (Regex.IsMatch(txtdirHospital.Text, @"^[ a-zA-Z0123456789]+$"))
                            {
                                //asignar los nuevos valores
                                hosp.NomHospital = txtnomHospital.Text;
                                hosp.DirHospital = txtdirHospital.Text;
                                db.SaveChanges();
                                MessageBox.Show("Registro Modificado Correctamente");
                                txtdirHospital.Clear();
                                txtnomHospital.Clear();
                                txtid.Clear();
                            }
                            else { MessageBox.Show("Solo letras #Dirección de Hospital"); }
                        }
                        else { MessageBox.Show("Solo letras #Nombre de Hospital"); }
                    }//if
            }
            else { MessageBox.Show("Captura el ID \n Solo números"); }

        }//boton modificar 

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Consultar TODO
            proyectoCM db = new proyectoCM();
            var registros = from s in db.Hospitales
                            select s;
            dbgrid.ItemsSource = registros.ToList();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
