using ColetorAppServidor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColetorAppServidor.Services
{
    class ServicesDBUsuario
    {
        Conexao con = new Conexao();
        SqlCommand sqlcommand = new SqlCommand();
        SqlDataReader sqldataReader = null;
        public string Statusmessagem { get; set; }

        public Usuario CadastrarNovoUsuario(Usuario usuario)
        {
            try
            {
                sqlcommand.CommandText = "insert into Usuario(usu_nome,usu_senha,usu_deslogado,usu_inativo) values (@nome,@senha,@deslogado,@inativo);";
                sqlcommand.Parameters.AddWithValue("@nome", usuario.usu_nome);
                sqlcommand.Parameters.AddWithValue("@senha", usuario.usu_senha);
                sqlcommand.Parameters.AddWithValue("@deslogado", usuario.usu_deslogado);
                sqlcommand.Parameters.AddWithValue("@inativo", usuario.usu_inativo);

                sqlcommand.Connection = con.conectar();
                sqlcommand.ExecuteNonQuery();
                Statusmessagem = "Usuário Cadastrado";

                return usuario;
            }
            catch (SqlException ex)
            {
                Statusmessagem = ex.Message;
                return usuario;
            }
            finally
            {
                sqlcommand.Parameters.Clear();
                con.desconectar();
            }
        }

        public void AlterarUsuario(Usuario usuario)
        {
            try
            {
                sqlcommand.CommandText = "UPDATE Usuario SET usu_nome = '" + usuario.usu_nome + "', usu_senha = '" + usuario.usu_senha + "' ,usu_inativo = '" + usuario.usu_inativo + "' WHERE usu_id = '" + usuario.usu_id + "'";
                sqlcommand.Parameters.AddWithValue("@usu_id", usuario.usu_id);
                sqlcommand.Parameters.AddWithValue("@usu_nome", usuario.usu_nome);
                sqlcommand.Parameters.AddWithValue("@usu_senha", usuario.usu_senha);
                sqlcommand.Parameters.AddWithValue("@usu_inativo", usuario.usu_inativo);
                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = con.conectar();
                sqlcommand.ExecuteNonQuery();

                Statusmessagem ="Usuario alterado com sucesso!";
            }
            catch (SqlException ex)
            {
                Statusmessagem = ex.Message;
            }
            finally
            {
                sqlcommand.Parameters.Clear();
                con.desconectar();
            }

        }

        public List<Usuario> BuscarUsuario(String nomeUsuario)
        {
            try {
                Conexao con = new Conexao();
                List<Usuario> list = new List<Usuario>();
                SqlCommand cmd = new SqlCommand(String.Format("select usu_id,usu_nome,usu_senha,usu_deslogado,usu_inativo from Usuario where usu_nome like '%{0}%'", nomeUsuario), con.conectar());
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usu = new Usuario();
                    usu.usu_id = Convert.ToInt32(reader.GetInt32(0));
                    usu.usu_nome = reader.GetString(1);
                    usu.usu_senha = reader.GetString(2);
                    usu.usu_deslogado = reader.GetBoolean(3);
                    usu.usu_inativo = reader.GetBoolean(4);
                    list.Add(usu);
                }
                con.desconectar();
                return list;
            }
            catch(SqlException ex)
            {
                Statusmessagem = ex.Message;
                return null;
            }

        }
        public void Excluir(int id)
        {
            try
            {
                sqlcommand.CommandText = "delete Usuario where usu_id = @codigo";
                sqlcommand.Parameters.AddWithValue("@codigo", id);
                sqlcommand.Connection = con.conectar();
                sqldataReader = sqlcommand.ExecuteReader();
                sqlcommand.Parameters.Clear();
                con.desconectar();
                sqldataReader.Close();
                Statusmessagem = "Usuario Deletado!";
            }
            catch(SqlException ex)
            {
                Statusmessagem = ex.Message;
                throw new Exception(string.Format("Erro: {0} ", ex.Message));
            }

        }
        public Usuario Editar(int codigo)
        {
            Usuario usuario = new Usuario();
            sqlcommand.CommandText = "select * from Usuario where usu_id =  @usuario";
            sqlcommand.Parameters.AddWithValue("@usuario", codigo);
            sqlcommand.Connection = con.conectar();
            sqldataReader = sqlcommand.ExecuteReader();
            if (sqldataReader.Read())
            {
                usuario.usu_id = int.Parse(sqldataReader["usu_id"].ToString());
                usuario.usu_nome = sqldataReader["usu_nome"].ToString();
                usuario.usu_senha = sqldataReader["usu_senha"].ToString();
                usuario.usu_inativo = sqldataReader.GetBoolean(4);
            }
            sqlcommand.Parameters.Clear();
            con.desconectar();
            sqldataReader.Close();
            return usuario;
        }
    }
}
