using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AccesoDatos
{
    public class EntrevistaPerfil

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numero { get; set; }
        public string Observaciones { get; set; }

        public Perfil PerfilResultado { get; set; }
        [ForeignKey ("perfilResultado")]
        public virtual Perfil Perfil { get; set; }


    }
}
