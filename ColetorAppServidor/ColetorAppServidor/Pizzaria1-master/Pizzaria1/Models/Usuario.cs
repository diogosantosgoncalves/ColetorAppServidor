using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColetorAppServidor.Models
{
    public class Usuario
    {
        public int usu_id { get; set; }
        public string usu_nome { get; set; }
        public string usu_senha { get; set; }
        public Boolean usu_deslogado { get; set; }
        public Boolean usu_inativo { get; set; }
        public Usuario()
        {
        }
        public Usuario(string nome,string senha,Boolean deslogado,Boolean inativo)
        {
            this.usu_nome = nome;
            this.usu_senha = senha;
            this.usu_deslogado = deslogado;
            this.usu_inativo = inativo;
        }
    }
}
