using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColetorAppServidor.Models
{
    class Produto
    {
        public int prod_Codigo { get; set; }
        public string prod_Nome { get; set; }
        public string prod_Setor { get; set; }
        public Boolean prod_Inativo { get; set; }
        public int prod_Quant { get; set; }
        public virtual Setor setor { get; set; }

        public Produto()
        {
            setor = new Setor();
        }


    }
}
