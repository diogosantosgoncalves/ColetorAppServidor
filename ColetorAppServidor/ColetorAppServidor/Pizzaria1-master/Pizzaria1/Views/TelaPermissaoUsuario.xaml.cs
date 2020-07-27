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
    public partial class TelaPermissaoUsuario : Window
    {
        public string nome_usuario;
        int codigoSelecionado;
        ServicesDBSetorUsuario servicesDBSetorUsuario = new ServicesDBSetorUsuario();
        List<SetorUsuario> lista_setorUsuarios = new List<SetorUsuario>();
        ServicesDBSetor servicesDBSetor = new ServicesDBSetor();
        public TelaPermissaoUsuario()
        {
            InitializeComponent();
        }
        public TelaPermissaoUsuario(int codigo_usuario, string nome)
        {

            InitializeComponent();
            // Carrega todos os setores
            cb_setor.ItemsSource = servicesDBSetor.Listar_Setor();

            // Carrega os setores do Usuário
            List<String> lista_setor = new List<String>();
            lista_setorUsuarios = servicesDBSetorUsuario.BuscaSetorPorUsuario(codigo_usuario);

            txt_CodigoUsuario.Text = codigo_usuario.ToString();
            txt_NomeUsuario.Text = nome;
            
            foreach (var i in lista_setorUsuarios)
            {
                foreach (var o in i.Setor)
                {
                    lista_setor.Add(o.setor_nome);
                }
                
                lb_setores.ItemsSource = lista_setor;
                return;
            }

        }
        public void bt_CadastrarPermissao(object sender, RoutedEventArgs e)
        {
            codigoSelecionado = Convert.ToInt32(cb_setor.SelectedValue);

            int codigosetor;
            // Verifica se tem alguma combo selecionada
            if(cb_setor.SelectedIndex >= 0)
            {
                codigosetor = codigoSelecionado;
                // verifica se já está cadastrado
                if(servicesDBSetorUsuario.BuscaSetorPorUsuarioeSetor(int.Parse(txt_CodigoUsuario.Text), codigosetor).Count != 0)
                {
                    MessageBox.Show("Permissão já cadastrada!");
                    return;
                }
                else
                {
                    servicesDBSetorUsuario.Salvar(int.Parse(txt_CodigoUsuario.Text), codigosetor);
                }
            }
            else
            {
                MessageBox.Show("Selecione alguma permissão");
            }
            this.Close();
            TelaPermissaoUsuario tela1 = new TelaPermissaoUsuario(int.Parse(txt_CodigoUsuario.Text), txt_NomeUsuario.Text);
            tela1.Show();
        }
        public void bt_DeletarPermissao(object sender, RoutedEventArgs e)
        {

            codigoSelecionado = Convert.ToInt32(cb_setor.SelectedValue);
            int nomesetor;
            try
            {
                foreach (object o in lb_setores.SelectedItems)
                    nome_usuario = (o as String).ToString();

                if (lb_setores.SelectedIndex >= 0)
                {
                    nomesetor = codigoSelecionado;
                    servicesDBSetorUsuario.Deletar(int.Parse(txt_CodigoUsuario.Text), nome_usuario);
                    MessageBox.Show("Permissão deletada com Sucesso");
                }
                else
                {
                    MessageBox.Show("Selecione alguma permissão");
                }
                this.Close();
                TelaPermissaoUsuario tela1 = new TelaPermissaoUsuario(int.Parse(txt_CodigoUsuario.Text), txt_NomeUsuario.Text);
                tela1.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
