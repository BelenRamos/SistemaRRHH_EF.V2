using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AccesoDatos
{
    public class Postulante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NroPostulante { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Mail { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public bool esCandidato { get; set; }

        public int PerfilAsignado { get; set; }
        [ForeignKey("PerfilAsignado")]

        public virtual Perfil Perfil { get; set; }

        public int NumeroEvalucion { get; set; }
        [ForeignKey("NumeroEvaluacion")]

        public virtual Evaluacion Evaluacion { get; set; }

        public virtual ICollection<Evaluacion> EvaluacionesRealizadas { get; set; }

    }
}
