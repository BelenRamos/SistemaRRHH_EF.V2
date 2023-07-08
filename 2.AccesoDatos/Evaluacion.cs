using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AccesoDatos
{
    public class Evaluacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numero { get; set; }

        public string Resultado { get; set; }

        public DateTime FechaEvaluacion { get; set; }

        public string Profesional { get; set; }

        public int Tipo { get; set; }
        [ForeignKey("Tipo")]

        public string Observacion { get; set; }
        
        public virtual TipoEvalucion TipoEvalucion { get; set; }
    }

}
