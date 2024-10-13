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

namespace UA2TAREA4
{
    public partial class AgregarClientes : Window
    {
        public AgregarClientes()
        {
            InitializeComponent();
        }

        private void btnAddClientes_click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReset_click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que quieres borrar el contenido?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                txbNombre.Text = "";
                txbCorreo.Text = "";
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que quieres cerrar el programa?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
