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
    /// <summary>
    /// Interação lógica para UserControlExportarTxt.xam
    /// </summary>
    public partial class UserControlExportarTxt : UserControl
    {
        SqlCommand cmd = new SqlCommand();
        Conexao conexao = new Conexao();
        List<Produto> list_produtos = new List<Produto>();
        ServicesDBProduto dBProduto = new ServicesDBProduto();
        public UserControlExportarTxt()
        {
            InitializeComponent();
        }
        public void exportar_Arquivo_Txt(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "file CSV (*.csv)|*.csv|Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                list_produtos = dBProduto.Listar_Produto();

                using (StreamWriter sw = File.CreateText(saveFileDialog.FileName))
                {
                    foreach (var Produto in list_produtos)
                    {
                        sw.WriteLine(Produto.prod_Nome + ";" + Produto.prod_Quant + ";" + Produto.prod_Setor);
                    }
                }
                MessageBox.Show("Quantidade de Produtos Exportados: " + list_produtos.Count.ToString()); ;
                MessageBox.Show("Arquivo Exportado com Sucesso!");
            }
        }
    }
}
