using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dominio.ChatRooms;
using Dominio.Common;
using Dominio.Personas;
using Dominio.Seguridad;
using Dominio.Usuarios;
using Microsoft.AspNet.Identity.EntityFramework;
using Persistencia.Mappers;

namespace Persistencia.Contextos
{
   
    public class ApplicationDbContext : IdentityDbContext<Usuario,Role,int,UserLogin,UserRole,UserClaim>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Accion> Accions { get; set; }
        public DbSet<ModuloAccion> ModuloAccions { get; set; }
        
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
       
        public DbSet<Estado> Estado { get; set; }
        
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<Ubicacion> Ubicacions { get; set; }
        public DbSet<EstadoCivil> EstadoCivils { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AdjuntoMap());
            modelBuilder.Configurations.Add(new EstadoMap());
            modelBuilder.Configurations.Add(new UbicacionMap());
            modelBuilder.Configurations.Add(new PersonaMap());
            modelBuilder.Configurations.Add(new AccionMap());
            modelBuilder.Configurations.Add(new ModuloMap());
            modelBuilder.Configurations.Add(new ModuloAccionMap());
            modelBuilder.Configurations.Add(new ModuloUsuarioAccionMap());
            modelBuilder.Configurations.Add(new RolMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new TipoDocumentoMap());
            modelBuilder.Configurations.Add(new ErrorLogMap());
            modelBuilder.Configurations.Add(new ChatRoomMap());
            modelBuilder.Configurations.Add(new ChatRoomParticipantMap());
            modelBuilder.Configurations.Add(new MessageMap());
        }
    }
}
