using ColetorAppServidor.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColetorAppServidor.Services
{
    class ServicesDBProduto
    {
        Produto produto = new Produto();
        Conexao con = new Conexao();
        SqlCommand sqlcommand = new SqlCommand();
        SqlDataReader sqldataReader = null;
        public string Statusmessagem { get; set; }

        public List<Produto> Listar_Produto()
        {
            try
            {
                List<Produto> list = new List<Produto>();
                sqlcommand.CommandText = "select * from Produto";
                sqlcommand.Connection = con.conectar();
                sqldataReader = sqlcommand.ExecuteReader();
                while (sqldataReader.Read())
                {
                    Produto produto = new Produto();
                    produto.prod_Codigo = int.Parse(sqldataReader["prod_codigo"].ToString());
                    produto.prod_Nome = sqldataReader["prod_nome"].ToString();
                    produto.prod_Quant = int.Parse(sqldataReader["prod_quant"].ToString());
                    produto.prod_Setor = sqldataReader["prod_setor"].ToString();
                    produto.prod_Inativo = sqldataReader.GetBoolean(3);
                    list.Add(produto);
                }
                sqlcommand.Parameters.Clear();
                con.desconectar();
                sqldataReader.Close();
                return list;
            }
            catch(SqlException ex)
            {
                return null;
            }

        }
        public void Salvar(string nome_produto, string setor, int codigo_setor)
        {
            char pr_inativo = '0';
            int pr_quant = 0;
            sqlcommand.CommandText = "insert into Produto(prod_nome,prod_setor,prod_inativo,prod_quant,setor_id) values (@nomeprod,@senha,@inativo,@quant,@setor_id);";

            sqlcommand.Parameters.AddWithValue("@nomeprod", nome_produto);
            sqlcommand.Parameters.AddWithValue("@senha", setor);
            sqlcommand.Parameters.AddWithValue("@inativo", pr_inativo);
            sqlcommand.Parameters.AddWithValue("@quant", pr_quant);
            sqlcommand.Parameters.AddWithValue("@setor_id", codigo_setor);

            try
            {
                sqlcommand.Connection = con.conectar();
                sqlcommand.ExecuteNonQuery();
                sqlcommand.Parameters.Clear();
                con.desconectar();
            }
            catch (SqlException ex)
            {
                Statusmessagem = ex.Message;
            }
        }
        public Produto BuscarProduto(string nome)
        {
            try
            {
                Produto produto = new Produto();
                sqlcommand.CommandText = "select * from Produto where prod_nome =  @produto";
                sqlcommand.Parameters.AddWithValue("@produto", nome);
                sqlcommand.Connection = con.conectar();
                sqldataReader = sqlcommand.ExecuteReader();

                if (sqldataReader.Read() == true)
                {
                    produto.prod_Codigo = int.Parse(sqldataReader[0].ToString());
                    produto.prod_Nome = sqldataReader[1].ToString();
                    produto.prod_Setor = sqldataReader[2].ToString();
                    produto.setor.setor_id = int.Parse(sqldataReader[5].ToString());
                    return produto;
                }
                else
                {
                    return null;
                }
            }catch (SqlException ex)
            {
                Statusmessagem = ex.Message;
                return null;
            }
            finally
            {
                sqlcommand.Parameters.Clear();
                con.desconectar();
                sqldataReader.Close();
            }
        }

        public void AtivarProduto(string nome)
        {
            try
            {
                Produto produto = new Produto();
                sqlcommand.CommandText = "update Produto set prod_inativo = 0 where prod_nome =  @produto";
                sqlcommand.Parameters.AddWithValue("@produto", nome);
                sqlcommand.Connection = con.conectar();
                sqldataReader = sqlcommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Statusmessagem = ex.Message;
            }
            finally
            {
                sqlcommand.Parameters.Clear();
                con.desconectar();
                sqldataReader.Close();
            }
        }

    }
}
