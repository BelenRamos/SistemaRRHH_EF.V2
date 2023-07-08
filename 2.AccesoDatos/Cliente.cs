using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AccesoDatos
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Mail { get; set; }

        public int IdOfertaLaboral { get; set; }
        [ForeignKey("IdOfertaLaboral")]

        public virtual ICollection<ClientesTelefonos> Telefonos { get; set; }

        public virtual OfertaLaboral OfertaLaboral { get; set; }

        public virtual ICollection<OfertaLaboral> OfertasLaborales { get; set; }

    }
}
