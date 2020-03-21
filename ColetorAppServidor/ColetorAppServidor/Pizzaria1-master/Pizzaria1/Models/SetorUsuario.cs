using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColetorAppServidor.Models
{
    public class SetorUsuario
    {
        public SetorUsuario()
        {
            Usuario = new Usuario();
            Setor = new List<Setor>();
        }
        public int setorusuario_id { get; set; }
        public int setorusuario_setor_id { get; set; }
        public int setorusuario_usu_id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<Setor> Setor { get; set; }
    }
}
