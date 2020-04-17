using ColetorAppServidor.Models;
using ColetorAppServidor.Services;
using ColetorAppServidor.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Pizzaria1
{
    public partial class UserControlCadastro : UserControl
    {
        ServicesDBUsuario dBUsuario = new ServicesDBUsuario();
        public UserControlCadastro()
        {
            InitializeComponent();
            txt_nomeUsuario.Focus();
        }
        public void CadastrarUsuario(object sender, RoutedEventArgs e)
        {
            TelaCadastrarUsuario tela1 = new TelaCadastrarUsuario();
            tela1.ShowDialog();
        }
        public void ConsultarUsuario(object sender, RoutedEventArgs e)
        {
            dtgr_ConsultaUsuario.ItemsSource = dBUsuario.BuscarUsuario(txt_nomeUsuario.Text.ToString());
        }
        public void bt_ExcluiUsuario(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Deseja realmente excluir esse Usuário?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if(result == MessageBoxResult.Yes)
            {
                dBUsuario.Excluir(int.Parse(PegarLinhaGrid(0)));
                MessageBox.Show(dBUsuario.Statusmessagem);
                dtgr_ConsultaUsuario.ItemsSource = dBUsuario.BuscarUsuario(txt_nomeUsuario.Text.ToString());
            }
        }
        
        public void bt_EditarUsuario(object sender, RoutedEventArgs e)
        {
            Usuario usu =  dBUsuario.Editar(int.Parse(PegarLinhaGrid(0)));
            TelaCadastrarUsuario tela1 = new TelaCadastrarUsuario(usu.usu_nome, usu.usu_senha, usu.usu_id,usu.usu_inativo);
            tela1.ShowDialog();           
        }
        public void bt_TelaPermissaoUsuario(object sender, RoutedEventArgs e)
        {
            int codigo = int.Parse(PegarLinhaGrid(0));
            TelaPermissaoUsuario tela1 = new TelaPermissaoUsuario(codigo, PegarLinhaGrid(1));
            tela1.ShowDialog();
        }
        public string PegarLinhaGrid(int linha)
        {
            var selectedItem = dtgr_ConsultaUsuario.SelectedItem.ToString();
            Type t = dtgr_ConsultaUsuario.SelectedItem.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            string propertyValue = props[linha].GetValue(dtgr_ConsultaUsuario.SelectedItem, null).ToString();
            return propertyValue;
        }
    }
}
