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
        ServicesDBMovimentoProduto servicesDBmp = new ServicesDBMovimentoProduto();
        ServicesDBUsuario servicesDB = new ServicesDBUsuario();
        public RelatorioInventario()
        {
            InitializeComponent();
        }

        public void bt_CarregarRelatorio(object sender, RoutedEventArgs e)
        {
            // ReportViewer.Reset();
            
            var datasource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetMovimentoProduto", servicesDBmp.Listar());
            ReportViewer.LocalReport.DataSources.Add(datasource);
            ReportViewer.LocalReport.ReportEmbeddedResource = "ColetorAppServidor.Relatorios.RelatorioMovimentoProduto.rdlc";
            ReportViewer.RefreshReport();

        }

    }
}
