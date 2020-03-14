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
    public partial class TelaCadastrarUsuario : Window
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public string mensagem = "";
        public TelaCadastrarUsuario()
        {
            InitializeComponent();
            txt_NomeUsuario.Focus();
        }
        public TelaCadastrarUsuario(string nome, string senha, int id,Boolean inativo)
        {
            InitializeComponent();
            txt_id.Text = id.ToString();
            txt_NomeUsuario.Text = nome;
            txt_SenhaUsuario.Password = senha;
            txt_inativo.IsChecked = inativo;
            bt_CadastrarUsuario.Content = "Alterar";
            txt_NomeUsuario.Focus();
        }
        public void Botao_Cadastrar_Alterar(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            ServicesDBUsuario servicesDBUsuario = new ServicesDBUsuario();
            if(bt_CadastrarUsuario.Content.ToString() == "Alterar")
            {
                usuario.usu_id = int.Parse(txt_id.Text);
                usuario.usu_nome = txt_NomeUsuario.Text;
                usuario.usu_senha = txt_SenhaUsuario.Password;
                usuario.usu_inativo = txt_inativo.IsChecked.Value;
                servicesDBUsuario.AlterarUsuario(usuario);
                MessageBox.Show(servicesDBUsuario.Statusmessagem);
            }
            else
            {
                usuario.usu_nome = txt_NomeUsuario.Text;
                usuario.usu_senha = txt_SenhaUsuario.Password;
                usuario.usu_deslogado = true;
                usuario.usu_inativo = txt_inativo.IsChecked.Value;

                servicesDBUsuario.CadastrarNovoUsuario(usuario);
                MessageBox.Show(servicesDBUsuario.Statusmessagem);
                
                txt_NomeUsuario.Text = "";
                txt_SenhaUsuario.Password = "";
                txt_NomeUsuario.Focus();
                txt_inativo.IsChecked = false;
            }
        }
    }
}
