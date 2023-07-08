using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AccesoDatos
{
    public class TipoEvalucion
    {
        [Key]
        public int Id { get; set; }

        public string Detalle { get; set; }

    }
}
