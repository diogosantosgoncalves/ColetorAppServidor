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

namespace Pizzaria1
{
    /// <summary>
    /// Interação lógica para UserControlInicio.xam
    /// </summary>
    public partial class UserControlInicio : UserControl
    {
        public UserControlInicio()
        {
            InitializeComponent();
            Conexao conexao = new Conexao();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader_prod = null;
            int cont_prod = 0;
            int cont_usuario= 0;
            int cont_usuario_ativos = 0;

            cmd.CommandText = "select * from Produto";
            cmd.Connection = conexao.conectar();
            reader_prod = cmd.ExecuteReader();
            while(reader_prod.Read() == true)
            {
                cont_prod++;
            }

            qtde_prod.Content = "Quantidade de Produtos: " + cont_prod;
            cmd.Parameters.Clear();
            reader_prod.Close();
            conexao.desconectar();

            cmd.CommandText = "select * from Usuario";
            cmd.Connection = conexao.conectar();
            reader_prod = cmd.ExecuteReader();
            while (reader_prod.Read() == true)
            {
                cont_usuario++;
            }
            qtde_usuario.Content = "Quantidade de Usuários: " + cont_usuario;
            cmd.Parameters.Clear();
            reader_prod.Close();
            conexao.desconectar();

            cmd.CommandText = "select * from Usuario where usu_inativo = 0";
            cmd.Connection = conexao.conectar();
            reader_prod = cmd.ExecuteReader();
            while (reader_prod.Read() == true)
            {
                cont_usuario_ativos++;
            }
            
            qtde_usuario_ativos.Content = "Quantidade de Usuários Ativos: " + cont_usuario_ativos;
            cmd.Parameters.Clear();
            reader_prod.Close();
            conexao.desconectar();

            data_inventario_ultimo.Content = "Data do último Inventário: 01/02/2020";
        }
    }
}
