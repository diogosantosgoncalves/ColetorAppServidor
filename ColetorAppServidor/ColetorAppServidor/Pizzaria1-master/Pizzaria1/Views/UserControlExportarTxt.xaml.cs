using ColetorAppServidor.Models;
using ColetorAppServidor.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
    public partial class UserControlExportarTxt : UserControl
    {
        SqlCommand cmd = new SqlCommand();
        Conexao conexao = new Conexao();
        ServicesDBInventario servicesDBInventario = new ServicesDBInventario();
        ServicesDBMovimentoProduto servicesDBMovimentoProduto = new ServicesDBMovimentoProduto();

        public UserControlExportarTxt()
        {
            InitializeComponent();
        }
        public void exportar_Arquivo_Txt(object sender, RoutedEventArgs e)
        {
            Inventario inventario = servicesDBInventario.Buscar_Ultimo_Inventario();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "file CSV (*.csv)|*.csv|Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                List<Movimento_Produto> lista_movimento_Produtos = servicesDBMovimentoProduto.Listar(inventario.inv_id);

                using (StreamWriter sw = File.CreateText(saveFileDialog.FileName))
                {
                    foreach (var Produto in lista_movimento_Produtos)
                    {
                        sw.WriteLine(Produto.mp_produto + ";" + Produto.mp_produto_quant + ";");
                    }
                }
                MessageBox.Show("Quantidade de Produtos Exportados: " + lista_movimento_Produtos.Count.ToString());
                MessageBox.Show("Inventário: " + inventario.inv_id +  ". Arquivo Exportado com Sucesso!");
                lista_movimento_Produtos.Clear();
            }
        }
    }
}
