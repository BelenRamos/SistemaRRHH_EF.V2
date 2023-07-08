using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AccesoDatos
{
    [PrimaryKey(nameof(Telefono), nameof(IdCliente))]
    public class ClientesTelefonos
    {
      
        public string Telefono { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]

        public virtual Cliente Cliente { get; set; }



    }
}
