using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AccesoDatos
{
    public class OfertaLaboral
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public DateTime FechaCierre { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]

        public virtual Estado Estado { get; set; }

        public int IdRequisito { get; set; }
        [ForeignKey("IdRequisito")]

        public virtual Requisito Requisito { get; set; }

        public virtual ICollection<Requisito> Requisitos { get; set; }

        public int NroPostulante { get; set; }
        [ForeignKey("NroPostulante")]

        public virtual ICollection<Postulante> Postulantes { get; set; }


    }


}
