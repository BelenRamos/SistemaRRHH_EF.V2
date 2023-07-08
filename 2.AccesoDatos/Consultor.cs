using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AccesoDatos
{
    public class Consultor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Legajo { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TelefonoContacto { get; set; }

        public int IdOfertaLaboral { get; set; }
        [ForeignKey("IdOfertaLaboral")]

        public virtual ICollection<OfertaLaboral> OfertasLaboralesAsignadas { get; set; }



    }
}
