using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AccesoDatos
{
    
    public class Turno
    {
        [Key]
        public DateTime Fecha_Horario  { get; set; }
        public int NroEntrevista { get; set; }
        [ForeignKey("NroEntrevista")]
        public string PsicologoEntrevista { get; set; }
        [ForeignKey("PsicologoEntrevista")]

        public bool Disponible { get; set; }

        public virtual EntrevistaPerfil EntrevistaPerfil { get; set; }
        public virtual Psicologo Psicologo { get; set; }    




    }
}
