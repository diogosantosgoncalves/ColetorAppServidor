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

namespace ColetorServidor
{
    public partial class UserControlImportarTxt : UserControl
    {
        ServicesDBProduto servicesDBProduto = new ServicesDBProduto();
        ServicesDBSetor servicesDBSetor = new ServicesDBSetor();
        Produto produto = new Produto();
        public UserControlImportarTxt()
        {
            InitializeComponent();
        }
        public void importar_Arquivo_Txt(object sender, RoutedEventArgs e)
        {
            List<string> list_Setores = new List<string>();
            int codigo_setor = 0;

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
                        Produto: {0}
                        Setor: {1}", 
                        linhaseparada[0], linhaseparada[1]);
                        if (linhaseparada[0] == "") continue;
                        cont = cont + 1;
                        //Conta os setores e Salvo no banco caso não esteja Cadastrado
                        var temnalista = list_Setores.IndexOf(linhaseparada[1]);
                        if (temnalista == -1)
                        {
                            if(servicesDBSetor.Busca_Setor(linhaseparada[1]) == 0)
                            {
                                servicesDBSetor.Salvar_Setor(linhaseparada[1]);
                                codigo_setor = servicesDBSetor.Busca_Setor(linhaseparada[1]);
                            }
                            else
                            {
                                codigo_setor = servicesDBSetor.Busca_Setor(linhaseparada[1]);
                            }
                            list_Setores.Add(linhaseparada[1]);
                        }
                        // Se o produto já estiver no Banco de Dados eu apenas Ativo
                        produto = servicesDBProduto.BuscarProduto(linhaseparada[0]);
                        if (produto == null)
                        {
                            servicesDBProduto.Salvar(linhaseparada[0], linhaseparada[1],codigo_setor);
                        }
                        else
                        {
                            servicesDBProduto.AtivarProduto(linhaseparada[0]);
                        }
                    }
                    MessageBox.Show("Quantidade de Produtos Importados: " + cont.ToString());
                    MessageBox.Show("Quantidade de Setores Encontrados: " + list_Setores.Count);
                }
            }
        }
    }
}

