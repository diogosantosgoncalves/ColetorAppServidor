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
        public void Salvar(int codigousuario,int codigosetor)
        {
            try
            {
                sqlCommand.CommandText = "insert into SetorUsuario(setorusuario_usu_id,setorusuario_setor_id) values(@usuario,@setor)";
                sqlCommand.Parameters.AddWithValue("@usuario", codigousuario);
                sqlCommand.Parameters.AddWithValue("@setor", codigosetor);
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
        public void Deletar(int codigousuario, string setor)
        {
            try
            {
                sqlCommand.CommandText = "delete su from SetorUsuario su inner join setor s on "+
                "su.setorusuario_setor_id = s.setor_id " +
                "where s.setor_nome = @setor and su.setorusuario_usu_id = @usuario" ;
                sqlCommand.Parameters.AddWithValue("@usuario", codigousuario);
                sqlCommand.Parameters.AddWithValue("@setor", setor);
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
        public List<SetorUsuario> Busca_Setor(int usu_id)
        {
            List<SetorUsuario> lista_setorUsuarios = new List<SetorUsuario>();
            SetorUsuario setorUsuario = new SetorUsuario();
            Setor setor = new Setor();
            try
            {
                sqlCommand.CommandText = "select * from SetorUsuario su " +
                "inner join Usuario u on u.usu_id = su.setorusuario_usu_id inner join Setor s on " +
                "s.setor_id = su.setorusuario_setor_id where usu_id = @id";
                sqlCommand.Parameters.AddWithValue("@id", usu_id);
                sqlCommand.Connection = conexao.conectar();
                sqldataReader = sqlCommand.ExecuteReader();
                while (sqldataReader.Read())
                {
                    Setor setor1 = new Setor();
                    setorUsuario.setorusuario_id = int.Parse(sqldataReader["setorusuario_id"].ToString());
                    setorUsuario.setorusuario_usu_id = int.Parse(sqldataReader["setorusuario_usu_id"].ToString());
                    setorUsuario.setorusuario_setor_id = int.Parse(sqldataReader["setorusuario_setor_id"].ToString());
                    setorUsuario.Usuario.usu_id = int.Parse(sqldataReader["usu_id"].ToString());
                    setorUsuario.Usuario.usu_nome = sqldataReader["usu_nome"].ToString();
                    setor1.setor_id = int.Parse(sqldataReader["setor_id"].ToString());
                    setor1.setor_nome = sqldataReader["setor_nome"].ToString();
                    setorUsuario.Setor.Add(setor1);
                    //setorUsuario.Setor.Add(int.Parse(sqldataReader["setor_id"].ToString());
                    //setorUsuario.Setor.setor_nome = sqldataReader["setor_nome"].ToString();
                    lista_setorUsuarios.Add(setorUsuario);
                    //return lista_setorUsuarios;
                    //return students;
                }
                return lista_setorUsuarios;
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
