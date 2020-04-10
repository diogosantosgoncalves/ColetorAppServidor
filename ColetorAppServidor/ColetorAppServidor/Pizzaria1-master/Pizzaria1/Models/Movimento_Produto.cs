using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColetorAppServidor.Models
{
    public class Movimento_Produto
    {
        public int mp_id { get; set; }
        public int mp_inventario { get; set; }
        public string mp_produto { get; set; }
        public int mp_produto_quant { get; set; }
    }
}
