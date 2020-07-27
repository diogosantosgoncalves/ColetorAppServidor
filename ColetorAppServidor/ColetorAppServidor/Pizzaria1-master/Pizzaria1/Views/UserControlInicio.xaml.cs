using ColetorAppServidor.Models;
using ColetorAppServidor.Services;
using System;
using System.Collections.Generic;
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

namespace ColetorServidor
{
    /// <summary>
    /// Interação lógica para UserControlInicio.xam
    /// </summary>
    public partial class UserControlInicio : UserControl
    {
        ServicesDBInventario servicesDBInventario = new ServicesDBInventario();
        ServicesDBProduto servicesDBProduto = new ServicesDBProduto();
        ServicesDBUsuario servicesDBUsuario = new ServicesDBUsuario();
        ServicesDBMovimentoProduto movimentoProduto = new ServicesDBMovimentoProduto();
        Inventario inventario = new Inventario();
        public UserControlInicio()
        {
            InitializeComponent();

            qtde_prod.Content = "Quantidade de Produtos: " + servicesDBProduto.Listar_Produto().Count.ToString();

            qtde_usuario.Content = "Quantidade de Usuários: " + servicesDBUsuario.BuscarUsuario("").Count.ToString();

            qtde_usuario_ativos.Content = "Quantidade de Usuários Ativos: " + servicesDBUsuario.Usuarios_Ativos().ToString();

            data_inventario_ultimo.Content = "Data do último Inventário: " + String.Format("{0:d/M/yyyy HH:mm:ss}", servicesDBInventario.Buscar_Ultimo_Inventario().inv_dtfechamento); 
            
            inventario = servicesDBInventario.Buscar_Contagem_Atual();
            if(inventario.inv_dtabertura != null)
            {
                bt_InicioContagem.Content = "Fechar Contagem";
                lb_total_produtos_contados.Content = "Total de Produtos Contados: " + movimentoProduto.Contar_Total_Produtos(inventario.inv_id);
            }
            else
            {
                bt_InicioContagem.Content = "Iniciar Contagem";
            }
            if(inventario.inv_dtfechamento != DateTime.MinValue)
            {
                lb_dtfechamento.Content = "Data Fechamento: " +  String.Format("{0:d/M/yyyy HH:mm:ss}", inventario.inv_dtfechamento);
            }
            dtabertura.Content = "Data Abertura: " + String.Format("{0:d/M/yyyy HH:mm:ss}", inventario.inv_dtabertura);
        }

        public void bt_IniciarContagem(object sender, RoutedEventArgs e)
        {
            DateTime hoje = DateTime.Today;
            if (bt_InicioContagem.Content.ToString() == "Iniciar Contagem")
            {
                
                servicesDBInventario.Criar_Inventario();
                Inventario inventario = servicesDBInventario.Buscar_Contagem_Atual();
                MessageBox.Show("Iniciando Contagem...");
                bt_InicioContagem.Content = "Fechar Contagem";
                dtabertura.Content = "Data Abertura: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                lb_dtfechamento.Content = "Data Fechamento: ";
                lb_total_produtos_contados.Content = "Total de Produtos Contados: " + movimentoProduto.Contar_Total_Produtos(inventario.inv_id);
            }
            else
            {
                servicesDBInventario.Fechar_Contagem_Atual();
                MessageBox.Show("Contagem Fechada!");
                lb_dtfechamento.Content = "Data Fechamento: " + String.Format("{0:d/M/yyyy HH:mm:ss}", servicesDBInventario.Buscar_Ultimo_Inventario().inv_dtfechamento);
                bt_InicioContagem.Content = "Iniciar Contagem";
                data_inventario_ultimo.Content = "Data do último Inventário: " + String.Format("{0:d/M/yyyy HH:mm:ss}", servicesDBInventario.Buscar_Ultimo_Inventario().inv_dtfechamento);
                lb_total_produtos_contados.Content = "Total de Produtos Contados: 0";
            }
        }
    }
}
