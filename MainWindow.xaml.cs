using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace UA2TAREA4
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que quieres cerrar el programa?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnVerClientes_Click(object sender, RoutedEventArgs e)
        {
            VerClientes ventanaVerClientes = new VerClientes();
            ventanaVerClientes.Show();
        }

        private void btnAgregarClientes_Click(object sender, RoutedEventArgs e)
        {
            AgregarClientes ventanaAgregarClientes = new AgregarClientes();
            ventanaAgregarClientes.Show();
        }

        private void btnEditarClientes_Click(object sender, RoutedEventArgs e)
        {
            EditarClientes ventanaEditarClientes = new EditarClientes();
            ventanaEditarClientes.Show();
        }

        private void btnEliminarClientes_Click(object sender, RoutedEventArgs e)
        {
            EliminarClientes ventanaEliminarClientes = new EliminarClientes();
            ventanaEliminarClientes.Show();
        }
    }
}