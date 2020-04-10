using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColetorAppServidor.Models
{
    public class Inventario
    {
        public int inv_id { get; set; }
        public DateTime? inv_dtabertura { get; set; }
        public Nullable<DateTime> inv_dtfechamento { get; set; }

    }
}
