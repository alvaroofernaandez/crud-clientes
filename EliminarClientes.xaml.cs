using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace UA2TAREA4
{
    public partial class EliminarClientes : Window
    {
        string rutaArchivo = "datos.xml";

        public EliminarClientes(string rutaArchivo)
        {
            InitializeComponent();
            this.rutaArchivo = rutaArchivo;
        }

        private void btnEliminarClientes_click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(rutaArchivo))
            {
                if (rutaArchivo.Length > 0)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(rutaArchivo);

                    int idCliente = int.Parse(txbBuscarPorID.Text);

                    XmlNode clienteNode = xmlDoc.SelectSingleNode($"/clientes/cliente[id='{idCliente}']");


                    if (clienteNode != null)
                    {
                        XmlNode parent = clienteNode.ParentNode;
                        parent.RemoveChild(clienteNode);


                        xmlDoc.Save(rutaArchivo);
                        autoResetear();

                        MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El archivo está vacío.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("El archivo no existe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnReset_click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que quieres borrar el contenido?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                txbBuscarPorID.Text = "";
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

        private void autoResetear()
        {
            txbBuscarPorID.Text = "";
        }
    }
}
