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
    /// <summary>
    /// Lógica de interacción para VerClientes.xaml
    /// </summary>
    public partial class VerClientes : Window
    {
        string rutaArchivo = "datos.xml";
        List<Cliente> clientes = new List<Cliente>();
        int contadorClientes = 0;

        public VerClientes()
        {
            InitializeComponent();
        }

        private void btnMostrarClientes_click(object sender, RoutedEventArgs e)
        {

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
