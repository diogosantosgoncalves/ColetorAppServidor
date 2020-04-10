using ColetorAppServidor.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColetorAppServidor.Services
{
    public class ServicesDBInventario
    {
        Conexao conexao = new Conexao();
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqldataReader = null;
        public string Statusmessagem { get; set; }
        public void Criar_Inventario()
        {
            //DateTime.Now.ToString("MM/dd/yyyy")
            //DateTime hoje = DateTime.Today;
            try
            {
                sqlCommand.CommandText = "insert into Inventario (inv_dtabertura) values(@dt_abertura)";
                sqlCommand.Parameters.AddWithValue("@dt_abertura", DateTime.Now.ToString("dd/MM/yyyy"));
                sqlCommand.Connection = conexao.conectar();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                conexao.desconectar();
            }
        }
        public Inventario Buscar_Contagem_Atual()
        {
            Inventario inventario = new Inventario();
            try
            {
                sqlCommand.CommandText = "select * from inventario where inv_dtabertura is not null and inv_dtfechamento is null";
                sqlCommand.Connection = conexao.conectar();
                sqldataReader = sqlCommand.ExecuteReader();
                if (sqldataReader.Read())
                {
                    inventario.inv_id =  sqldataReader.GetInt32(0);
                    inventario.inv_dtabertura = sqldataReader.GetDateTime(1);
                    inventario.inv_dtfechamento = sqldataReader["inv_dtfechamento"].ToString().Length > 0 ? DateTime.Parse(sqldataReader["inv_dtfechamento"].ToString()) : DateTime.MinValue;

            }
                return inventario;

            }
            catch (Exception ex)
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
        public void Fechar_Contagem_Atual()
        {
            Inventario inventario = new Inventario();
            //DateTime hoje = DateTime.Today;
            try
            {
                sqlCommand.CommandText = "update inventario set inv_dtfechamento = @dtfechamento";
                sqlCommand.Parameters.AddWithValue("@dtfechamento", DateTime.Now.ToString("dd/MM/yyyy"));
                sqlCommand.Connection = conexao.conectar();
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
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
