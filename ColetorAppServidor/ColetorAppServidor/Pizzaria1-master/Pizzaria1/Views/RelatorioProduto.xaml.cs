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
    public partial class RelatorioProduto : Window
    {
        Conexao con = new Conexao();
        ServicesDBProduto servicesDBProduto = new ServicesDBProduto();
        public RelatorioProduto()
        {
            InitializeComponent();
        }

        public void ReportViewer_Load(object sender, EventArgs e)
        {
           var dataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetProduto", servicesDBProduto.Listar_Produto());
           ReportViewer.LocalReport.DataSources.Add(dataSource);
           ReportViewer.LocalReport.ReportEmbeddedResource = "ColetorAppServidor.Relatorios.RelatorioProduto.rdlc";

           ReportViewer.RefreshReport();
        }
    }
}
