using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ColetorAppServidor.Models;

namespace ColetorAppServidor.Services
{
    public class ServicesDBSetor
    {
        Conexao conexao = new Conexao();
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqldataReader = null;
        public string Statusmessagem { get; set; }

        public List<Setor> Listar_Setor()
        {
            try
            {
                List<Setor> lista_setor = new List<Setor>();
                sqlCommand.CommandText = "select * from setor";
                sqlCommand.Connection = conexao.conectar();
                sqldataReader = sqlCommand.ExecuteReader();
                while (sqldataReader.Read())
                {
                    Setor setor = new Setor();
                    setor.setor_id = sqldataReader.GetInt32(0);
                    setor.setor_nome = sqldataReader.GetString(1);
                    lista_setor.Add(setor);
                }
                return lista_setor;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqldataReader.Close();
                sqlCommand.Parameters.Clear();
                conexao.desconectar();
            }
        }
        public void Salvar_Setor(string nome)
        {
            try
            {
                sqlCommand.CommandText = "insert into Setor values(@nome)";
                sqlCommand.Parameters.AddWithValue("@nome", nome);
                sqlCommand.Connection = conexao.conectar();
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                conexao.desconectar();
            }
        }
        public int Busca_Setor(string nome)
        {
            try
            {
                sqlCommand.CommandText = "select * from setor where setor_nome = @nome";
                sqlCommand.Parameters.AddWithValue("@nome", nome);
                sqlCommand.Connection = conexao.conectar();
                sqldataReader = sqlCommand.ExecuteReader();
                if(sqldataReader.Read()){
                    return sqldataReader.GetInt32(0);
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqldataReader.Close();
                sqlCommand.Parameters.Clear();
                conexao.desconectar();
            }
        }

    }
}
