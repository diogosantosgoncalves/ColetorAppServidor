using ColetorAppServidor.Services;
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

namespace ColetorAppServidor.Views
{
    /// <summary>
    /// Interaction logic for RelatorioInventario.xaml
    /// </summary>
    public partial class RelatorioInventario : Window
    {

        ServicesDBUsuario servicesDB = new ServicesDBUsuario();
        ServicesDBInventario servicesDBInventario = new ServicesDBInventario();
        public RelatorioInventario()
        {
            InitializeComponent();
            cb_inventario.ItemsSource = servicesDBInventario.ListarInventarios();
        }

        public void bt_CarregarRelatorio(object sender, RoutedEventArgs e)
        {
            ServicesDBMovimentoProduto servicesDBmp = new ServicesDBMovimentoProduto();
            int? codigoSelecionado;

            if (cb_inventario.SelectedIndex >= 0)
            {
                codigoSelecionado = Convert.ToInt32(cb_inventario.SelectedValue);
            }
            else
            {
                MessageBox.Show("Selecione um inventário!");
                return;
            }
            ReportViewer.Reset();
            _ = DateTime.Now;
            var datasource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetTeste", servicesDBmp.Listar(codigoSelecionado));
            ReportViewer.LocalReport.DataSources.Add(datasource);
            ReportViewer.LocalReport.ReportEmbeddedResource = "ColetorAppServidor.Relatorios.RelatorioMovimentoProduto.rdlc";
            ReportViewer.RefreshReport();

            codigoSelecionado = null;

        }

    }
}
