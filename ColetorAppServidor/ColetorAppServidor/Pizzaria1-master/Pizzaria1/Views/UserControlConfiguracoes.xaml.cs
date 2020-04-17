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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColetorAppServidor.Views
{
    /// <summary>
    /// Interação lógica para UserControlConfiguracoes.xam
    /// </summary>
    public partial class UserControlConfiguracoes : UserControl
    {
        public UserControlConfiguracoes()
        {
            InitializeComponent();
        }

        private void bt_RelatorioProduto(object sender, RoutedEventArgs e)
        {
            RelatorioProduto tela = new RelatorioProduto();
            tela.Show();
        }

        private void bt_RelatorioUsuario(object sender, RoutedEventArgs e)
        {
            RelatorioUsuario tela = new RelatorioUsuario();
            tela.Show();
        }

        private void bt_RelatorioInventario(object sender, RoutedEventArgs e)
        {
            RelatorioInventario tela = new RelatorioInventario();
            tela.Show();
        }
    }
}
