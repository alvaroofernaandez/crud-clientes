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
    public partial class AgregarClientes : Window
    {
        string rutaArchivo = "datos.xml";
        public AgregarClientes(string rutaArchivo)
        {
            InitializeComponent();
        }

        private void btnAddClientes_click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(rutaArchivo))
            {
                if (rutaArchivo.Length > 0)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(rutaArchivo);

                    XmlElement newCliente = xmlDoc.CreateElement("cliente");
                    XmlElement newId = xmlDoc.CreateElement("id");
                    XmlElement newNombre = xmlDoc.CreateElement("nombre");
                    XmlElement newCorreo = xmlDoc.CreateElement("correo");

                    XmlNode clientes = xmlDoc.DocumentElement;
                    XmlNode cliente = xmlDoc.DocumentElement;
                    XmlNode id = xmlDoc.DocumentElement;
                    XmlNode nombre = xmlDoc.DocumentElement;
                    XmlNode correo = xmlDoc.DocumentElement;


                    newId.InnerText = txbId.Text;
                    newNombre.InnerText = txbNombre.Text;
                    newCorreo.InnerText = txbCorreo.Text;

                    if (clientes != null)
                    {
                        clientes.AppendChild(newCliente);
                        newCliente.AppendChild(newId);
                        newCliente.AppendChild(newNombre);
                        newCliente.AppendChild(newCorreo);


                        xmlDoc.Save(rutaArchivo);
                        autoResetear();

                        MessageBox.Show("Archivo modificado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("No se encontró la etiqueta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

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
                autoResetear();
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
            txbId.Text = "";
            txbNombre.Text = "";
            txbCorreo.Text = "";
        }
    }
}
