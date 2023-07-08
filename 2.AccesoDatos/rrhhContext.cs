using Microsoft.EntityFrameworkCore;

namespace _2.AccesoDatos
{
    public class rrhhContext : DbContext
    {
        public rrhhContext(DbContextOptions<rrhhContext> options) 
            :base(options)
        {
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<ClientesTelefonos> clientesTelefonos { get; set; }
        public DbSet<Consultor> consultor { get; set; } 
        public DbSet<EntrevistaPerfil> entrevistaPerfiles { get; set; }
        public DbSet<Estado> estados { get; set; }
        public DbSet<Evaluacion> evalaciones { get; set;}
        public DbSet<OfertaLaboral>  ofertasLaborales { get; set;}
        public DbSet<Perfil> perfiles { get; set; }
        public DbSet<Postulante> postulantes { get; set;}
        public DbSet<Psicologo> psicologos { get; set; }
        public DbSet<Requisito> requisitos{ get; set; } 
        public DbSet<TipoEvalucion> tiposEvaluciones { get;set; }
        public DbSet<Turno> turnos { get; set; }    

    }
}