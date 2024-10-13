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
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace UA2TAREA4
{
    public partial class VerClientes : Window
    {
        public string rutaArchivo = "datos.xml";
        public List<Cliente> clientes = new List<Cliente>();

        public VerClientes()
        {
            InitializeComponent();
        }

        private void btnMostrarClientes_click(object sender, RoutedEventArgs e)
        {
            try
            {   
                clientes.Clear();

                if (File.Exists(rutaArchivo) == true)
                {
                    if (rutaArchivo.Length > 0)
                    {
                        using (XmlReader reader = XmlReader.Create(rutaArchivo))
                        {
                            Cliente cliente = null;

                            while (reader.Read())
                            {
                                if (reader.IsStartElement() && reader.IsEmptyElement == false)
                                {
                                    switch (reader.Name)
                                    {
                                        case "cliente":
                                            cliente = new Cliente();
                                            break;

                                        case "id":
                                            if(reader.Read() && cliente != null)
                                            {
                                                cliente.id = int.Parse(reader.Value.Trim());
                                            }
                                            break;

                                        case "nombre":
                                            if(reader.Read() && cliente != null)
                                            {
                                                cliente.nombre = reader.Value.Trim();
                                            }
                                            break;

                                        case "correo":
                                            if(reader.Read() && cliente != null)
                                            {
                                                cliente.correo = reader.Value.Trim();
                                            }
                                            break;
                                    }
                                }

                                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "cliente" && cliente != null)
                                {
                                    clientes.Add(cliente);
                                } 
                            }
                        }

                        StringBuilder datos = new StringBuilder();
                        foreach (var cliente in clientes)
                        {
                            datos.AppendLine($"Id: {cliente.id}");
                            datos.AppendLine($"Nombre: {cliente.nombre}");
                            datos.AppendLine($"Correo: {cliente.correo}");
                            datos.AppendLine();
                        }

                        txbClientes.Text = datos.ToString();

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
            catch (Exception ex) 
            {
                MessageBox.Show("Ha habido un error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void btnReset_click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que quieres borrar el contenido?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                txbClientes.Text = "";
            }
        }
    }
}
