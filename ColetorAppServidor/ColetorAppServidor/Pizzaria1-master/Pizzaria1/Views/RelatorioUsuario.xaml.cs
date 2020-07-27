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
    public partial class RelatorioUsuario : Window
    {
        ServicesDBUsuario servicesDBUsuario = new ServicesDBUsuario();
        public RelatorioUsuario()
        {
            InitializeComponent();
        }

        public void ReportViewer_Load(object sender, EventArgs e)
        {
            var datasources = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetUsuario", servicesDBUsuario.BuscarUsuario(""));
            ReportViewer.LocalReport.DataSources.Add(datasources);
            ReportViewer.LocalReport.ReportEmbeddedResource = "ColetorAppServidor.Relatorios.RelatorioUsuario.rdlc";
            ReportViewer.RefreshReport();
        }
    }
}
