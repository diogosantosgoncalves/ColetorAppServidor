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

namespace Pizzaria1
{


    public partial class UserControlImportarTxt : UserControl
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd_prod = new SqlCommand();
        SqlDataReader reader_exportar = null;
        SqlDataReader reader_prod = null;

        public UserControlImportarTxt()
        {
            InitializeComponent();
        }
        public void importar_Arquivo_Txt(object sender, RoutedEventArgs e)
        {
            ServicesDBProduto servicesDBProduto = new ServicesDBProduto();
            Produto produto = new Produto();
            List<string> list_Setores = new List<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";
            string linha = "";
            string[] linhaseparada = null;
            if (openFileDialog.ShowDialog() == true)
            {
                var result = MessageBox.Show("Deseja importar esse Arquivo? " + openFileDialog.FileName, "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (MessageBoxResult.Yes == result)
                {
                    StreamReader reader = new StreamReader(openFileDialog.FileName, Encoding.UTF8, true);
                    int cont = 0;

                    while (true)
                    {
                        linha = reader.ReadLine();
                        if (linha == null) break;
                        linhaseparada = linha.Split(';');
                        string resultado = string.Format(
                        @"Linha - 
                        Código: {0}
                        Setor: {1}", 
                        linhaseparada[0], linhaseparada[1]);
                        cont = cont + 1;
                        //Conta os setores
                        var temnalista = list_Setores.IndexOf(linhaseparada[1]);
                        if (temnalista == -1)
                        {
                            list_Setores.Add(linhaseparada[1]);
                        }
                        produto = servicesDBProduto.BuscarProduto(linhaseparada[0]);
                        if (produto == null)
                        {
                            servicesDBProduto.Salvar(linhaseparada[0], linhaseparada[1]);
                        }
                        else
                        {
                            servicesDBProduto.AtivarProduto(linhaseparada[0]);
                        }
                    }
                    MessageBox.Show("Quantidade de Produtos Importados: " + cont.ToString());
                    MessageBox.Show("Quantidade de Setores Importados: " + list_Setores.Count);
                }
            }
        }
    }
}

