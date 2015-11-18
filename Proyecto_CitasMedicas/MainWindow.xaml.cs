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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_CitasMedicas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hospital vta = new Hospital();
            vta.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Paciente pac = new Paciente();
            pac.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Medicos med = new Medicos();
            med.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Motivo mo = new Motivo();
            mo.Show();
        }
    }
}
