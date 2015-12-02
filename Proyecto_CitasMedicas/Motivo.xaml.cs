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
    /// Interaction logic for Motivo.xaml
    /// </summary>
    public partial class Motivo : Window
    {
        public Motivo()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Registrar
            if (Regex.IsMatch(txtNumeroAf.Text, @"^[ a-zA-Z]+$"))
            {
                //1.- Instanciar la "Base de Datos"
                proyectoCM db = new proyectoCM();
                //2.- Instanciar 
                Proyecto_CitasMedicas.miProyecto.Motivo mot = new Proyecto_CitasMedicas.miProyecto.Motivo();
                mot.nomMotivo = txtNumeroAf.Text;
                //agregar los datos capturados
                db.Motivos.Add(mot);
                db.SaveChanges();
                MessageBox.Show("Registro Exitoso");
                txtNumeroAf.Clear();
                
            }
            else { MessageBox.Show("Revisar que solo sean letras en #Nombre de Motivo"); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txtid.IsEnabled = true;
            //Eliminar
            if (Regex.IsMatch(txtid.Text, @"\d+$"))
            {
                proyectoCM db = new proyectoCM();
                //Buscar el id capturado en la caja de texto
                int idMotivo = int.Parse(txtid.Text);
                var mot = db.Motivos.SingleOrDefault(x => x.idMotivo == idMotivo);
                if (mot != null)
                {
                    db.Motivos.Remove(mot);
                    db.SaveChanges();
                    MessageBox.Show("Registro Eliminado");
                    txtid.Clear();
                }
            }
            else { MessageBox.Show("Solo números en el campo ID"); }
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
                int idMotivo = int.Parse(txtid.Text);
                //var es una variable dinamica
                var mot = db.Motivos.SingleOrDefault(x => x.idMotivo == idMotivo);
                if (mot != null)
                {
                    //asignar los nuevos valores
                    if (Regex.IsMatch(txtNumeroAf.Text, @"^[ a-zA-Z]+$"))
                    {
                    mot.nomMotivo = txtNumeroAf.Text;
                    db.SaveChanges();
                    MessageBox.Show("Registro Modificado Correctamente");
                    txtNumeroAf.Clear();
                    txtid.Clear();
                    }
                    else { MessageBox.Show("Captura solo letras en el Nombre del Motivo"); }
                }
            }
            else { MessageBox.Show("Solo números en el campo ID"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Consultar Todo
            proyectoCM db = new proyectoCM();
            var registros = from s in db.Motivos
                            select s;
            dbgrid.ItemsSource = registros.ToList();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
