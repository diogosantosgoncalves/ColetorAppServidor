using ColetorAppServidor.Models;
using ColetorAppServidor.Services;
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
using System.Windows.Shapes;

namespace ColetorAppServidor.Views
{
    /// <summary>
    /// Interação lógica para PagePermissaoUsuario.xam
    /// </summary>
    public partial class TelaPermissaoUsuario : Window
    {
        public int codigosetor;
        ServicesDBSetorUsuario servicesDBSetorUsuario = new ServicesDBSetorUsuario();
        List<SetorUsuario> lista_setorUsuarios = new List<SetorUsuario>();
        ServicesDBSetor servicesDBSetor = new ServicesDBSetor();
        SetorUsuario setorUsuario = new SetorUsuario();
        public TelaPermissaoUsuario()
        {
            InitializeComponent();
        }
        public TelaPermissaoUsuario(int codigo,string nome)
        {

            InitializeComponent();
            List<String> listasetorescompletos = new List<String>();
            foreach (var setor in servicesDBSetor.Listar_Setor())
            {
                listasetorescompletos.Add(setor.setor_nome);
            }
            List<String> lista_setor = new List<String>();
            lista_setorUsuarios = servicesDBSetorUsuario.Busca_Setor(codigo);
            //txt_CodigoUsuario.Text = setorUsuario.setorusuario_id.ToString();
            txt_CodigoUsuario.Text = codigo.ToString();
            txt_NomeUsuario.Text = nome;
            foreach(var i in lista_setorUsuarios)
            {
                lista_setor.Add(i.Setor.setor_nome);
                //txt_NomeUsuario.Text = i.Usuario.usu_nome;
                txt_CodigoUsuario.Text = i.Usuario.usu_id.ToString();
            }
            cb_setor.ItemsSource = listasetorescompletos;
            lb_setores.ItemsSource = lista_setor;
        }
        public void bt_CadastrarPermissao(object sender, RoutedEventArgs e)
        {
            //public int codigosetor;
            if(cb_setor.SelectedIndex >= 0)
            {
                codigosetor = cb_setor.SelectedIndex + 1;
                servicesDBSetorUsuario.Salvar(int.Parse(txt_CodigoUsuario.Text), codigosetor);
            }
            else
            {
                MessageBox.Show("Selecione alguma permissão");
            }
            TelaPermissaoUsuario tela1 = new TelaPermissaoUsuario(int.Parse(txt_CodigoUsuario.Text), txt_NomeUsuario.Text);
            tela1.Show();
        }

    }
}
