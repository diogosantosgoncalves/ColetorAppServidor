using ColetorAppServidor.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColetorAppServidor.Services
{
    public class ServicesDBSetorUsuario
    {
        Conexao conexao = new Conexao();
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqldataReader = null;
        public string Statusmessagem { get; set; }

        public List<SetorUsuario> Listar_Setor()
        {
            try
            {
                List<SetorUsuario> lista_setor = new List<SetorUsuario>();
                sqlCommand.CommandText = "select * from SetorUsuario";
                sqlCommand.Connection = conexao.conectar();
                sqldataReader = sqlCommand.ExecuteReader();
                while (sqldataReader.Read())
                {
                    SetorUsuario setorusuario = new SetorUsuario();
                    setorusuario.setorusuario_id = sqldataReader.GetInt32(0);
                    setorusuario.setorusuario_setor_id = sqldataReader.GetInt32(1);
                    setorusuario.setorusuario_usu_id = sqldataReader.GetInt32(2);
                    lista_setor.Add(setorusuario);
                }
                return lista_setor;
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
        public void Salvar_Setor(string nome)
        {
            try
            {
                sqlCommand.CommandText = "insert into SetorUsuario values(@nome)";
                sqlCommand.Parameters.AddWithValue("@nome", nome);
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
        public SetorUsuario Busca_Setor(int usu_id)
        {
            SetorUsuario setorUsuario = new SetorUsuario();
            try
            {
                sqlCommand.CommandText = "select * from SetorUsuario su " +
                "inner join Usuario u on u.usu_id = su.setorusuario_usu_id inner join Setor s on " +
                "s.setor_id = su.setorusuario_setor_id where usu_id = @id";
                sqlCommand.Parameters.AddWithValue("@id", usu_id);
                sqlCommand.Connection = conexao.conectar();
                sqldataReader = sqlCommand.ExecuteReader();
                if (sqldataReader.Read())
                {
                    setorUsuario.setorusuario_id = int.Parse(sqldataReader["usu_id"].ToString());
                    setorUsuario.Usuario.usu_id = int.Parse(sqldataReader["setorusuario_usu_id"].ToString());
                    setorUsuario.Usuario.usu_nome = sqldataReader["setor_nome"].ToString();
                    return setorUsuario;
                }
                else
                {
                    return null;
                }
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
