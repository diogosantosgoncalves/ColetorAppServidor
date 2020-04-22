using ColetorAppServidor.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColetorAppServidor.Services
{

    public class ServicesDBMovimentoProduto
    {
        Conexao con = new Conexao();
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader sqlReader;

        List<Movimento_Produto> lista_mp_Produto = new List<Movimento_Produto>();

        public List<Movimento_Produto> Listar(int? inventario)
        {
            try
            {
                cmd.CommandText = "select * from movimento_produto where mp_inventario = @inv";
                cmd.Parameters.AddWithValue("@inv", inventario);
                cmd.Connection = con.conectar();
                sqlReader = cmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    Movimento_Produto mp_Produto = new Movimento_Produto();
                    mp_Produto.mp_id = sqlReader.GetInt32(0);
                    mp_Produto.mp_inventario = sqlReader.GetInt32(1);
                    mp_Produto.mp_produto = sqlReader.GetString(2);
                    mp_Produto.mp_produto_quant = sqlReader.GetInt32(3);
                    lista_mp_Produto.Add(mp_Produto);
                }
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd.ExecuteReader());
                return lista_mp_Produto;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.desconectar();
                sqlReader.Close();
                cmd.Parameters.Clear();
            }
        }
        public int Contar_Total_Produtos(int inventario)
        {
            try
            {
                int cont = 0;
                cmd.CommandText = "select count(*) from movimento_produto where mp_inventario = @inv";
                cmd.Parameters.AddWithValue("@inv", inventario);
                cmd.Connection = con.conectar();
                sqlReader = cmd.ExecuteReader();
                if (sqlReader.Read())
                {
                    cont = sqlReader.GetInt32(0);
                }
                return cont;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlReader.Close();
                cmd.Parameters.Clear();
                con.desconectar();
            }

        }
    }
}
