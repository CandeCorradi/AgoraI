using Microsoft.EntityFrameworkCore;
using Service.Enums;
using Service.Models;

namespace Backend.DataContext
{
    public class AgoraContext : DbContext
    {
        public DbSet<TipoInscripcion> TipoInscripciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<TipoInscripcionCapacitacion> TiposInscripcionesCapacitaciones { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }

        public AgoraContext() { }

        public AgoraContext(DbContextOptions<AgoraContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cargamos los datos iniciales de tipo de inscripciones(Público en general, Docentes, Estudiantes, Jubilados)
            modelBuilder.Entity<TipoInscripcion>().HasData(
                new TipoInscripcion { Id = 1, Nombre = "Público en general" },
                new TipoInscripcion { Id = 2, Nombre = "Docentes" },
                new TipoInscripcion { Id = 3, Nombre = "Estudiantes" },
                new TipoInscripcion { Id = 4, Nombre = "Jubilados" },
                new TipoInscripcion { Id = 5, Nombre = "Tecnicos" }
            );

            //cargamos los datos iniciales de usuarios

            modelBuilder.Entity<Usuario>().HasData(
new Usuario { Id = 1, Nombre = "Juan", Apellido = "Pérez", Dni = "30111222", Email = "juan.perez@example.com", TipoUsuario = TipoUsuarioEnum.Estudiante, DeleteDate = DateTime.MinValue, IsDeleted = false },
new Usuario { Id = 2, Nombre = "María", Apellido = "Gómez", Dni = "28999888", Email = "maria.gomez@example.com", TipoUsuario = TipoUsuarioEnum.Docente, DeleteDate = DateTime.MinValue, IsDeleted = false },
new Usuario { Id = 3, Nombre = "Carlos", Apellido = "Fernández", Dni = "32555111", Email = "carlos.fernandez@example.com", TipoUsuario = TipoUsuarioEnum.Administrador, DeleteDate = DateTime.MinValue, IsDeleted = false },
new Usuario { Id = 4, Nombre = "Lucía", Apellido = "Martínez", Dni = "33444666", Email = "lucia.martinez@example.com", TipoUsuario = TipoUsuarioEnum.Estudiante, DeleteDate = DateTime.MinValue, IsDeleted = false },
new Usuario { Id = 5, Nombre = "Diego", Apellido = "López", Dni = "31222999", Email = "diego.lopez@example.com", TipoUsuario = TipoUsuarioEnum.Docente, DeleteDate = DateTime.MinValue, IsDeleted = false }

            );

            //cargamos los datos iniciales de capacitaciones
            modelBuilder.Entity<Capacitacion>().HasData(
                new Capacitacion { Id = 1, Nombre = "Introducción a la Programación", Detalle = "Aprende los conceptos básicos de programación.", Ponente = "Carlos Gómez", FechaHora = DateTime.Now.AddDays(10), Cupo = 30, InscripcionAbierta = true },
                new Capacitacion { Id = 2, Nombre = "Desarrollo Web con ASP.NET Core", Detalle = "Crea aplicaciones web modernas con ASP.NET Core.", Ponente = "Ana Martínez", FechaHora = DateTime.Now.AddDays(20), Cupo = 25, InscripcionAbierta = true },
                new Capacitacion { Id = 3, Nombre = "Bases de Datos SQL", Detalle = "Aprende a diseñar y gestionar bases de datos SQL.", Ponente = "Luis Rodríguez", FechaHora = DateTime.Now.AddDays(15), Cupo = 20, InscripcionAbierta = true },
                new Capacitacion { Id = 4, Nombre = "Desarrollo de Aplicaciones Móviles", Detalle = "Crea aplicaciones móviles para Android e iOS.", Ponente = "Marta Fernández", FechaHora = DateTime.Now.AddDays(30), Cupo = 15, InscripcionAbierta = true },
                new Capacitacion { Id = 5, Nombre = "Ciberseguridad Básica", Detalle = "Protege tus datos y dispositivos con buenas prácticas de ciberseguridad.", Ponente = "Javier Sánchez", FechaHora = DateTime.Now.AddDays(25), Cupo = 40, InscripcionAbierta = true }
            );

            // cargamos los datos iniciales de tipos de inscripciones para capacitaciones, definiendo el costo de inscripción paracada tipo
            modelBuilder.Entity<TipoInscripcionCapacitacion>().HasData(
                new TipoInscripcionCapacitacion { Id = 1, TipoInscripcionId = 1, CapacitacionId = 1, Costo = 10000 },
                new TipoInscripcionCapacitacion { Id = 2, TipoInscripcionId = 2, CapacitacionId = 1, Costo = 5000 },
                new TipoInscripcionCapacitacion { Id = 3, TipoInscripcionId = 3, CapacitacionId = 1, Costo = 3000 },
                new TipoInscripcionCapacitacion { Id = 4, TipoInscripcionId = 4, CapacitacionId = 1, Costo = 2000 },
                new TipoInscripcionCapacitacion { Id = 5, TipoInscripcionId = 1, CapacitacionId = 2, Costo = 12000 },
                new TipoInscripcionCapacitacion { Id = 6, TipoInscripcionId = 2, CapacitacionId = 2, Costo = 6000 },
                new TipoInscripcionCapacitacion { Id = 7, TipoInscripcionId = 3, CapacitacionId = 2, Costo = 4000 },
                new TipoInscripcionCapacitacion { Id = 8, TipoInscripcionId = 4, CapacitacionId = 2, Costo = 3000 }
            );

            // cargamos los datos iniciales de inscripciones con el email
            modelBuilder.Entity<Inscripcion>().HasData(
    new Inscripcion { Id = 1, UsuarioId = 1, TipoInscripcionId = 1, CapacitacionId = 1, Acreditado = false, Importe = 5000, Pagado = false, UsuarioCobroId = 3, IsDeleted = false },
    new Inscripcion { Id = 2, UsuarioId = 2, TipoInscripcionId = 2, CapacitacionId = 2, Acreditado = false, Importe = 0, Pagado = false, UsuarioCobroId = null, IsDeleted = false },
    new Inscripcion { Id = 3, UsuarioId = 3, TipoInscripcionId = 3, CapacitacionId = 3, Acreditado = false, Importe = 3000, Pagado = false, UsuarioCobroId = 5, IsDeleted = false },
    new Inscripcion { Id = 4, UsuarioId = 4, TipoInscripcionId = 4, CapacitacionId = 4, Acreditado = false, Importe = 10000, Pagado = false, UsuarioCobroId = 2, IsDeleted = false },
    new Inscripcion { Id = 5, UsuarioId = 5, TipoInscripcionId = 5, CapacitacionId = 5, Acreditado = false, Importe = 0, Pagado = false, UsuarioCobroId = null, IsDeleted = false }
);















            // Configuramos las querys para que no devuelvan los elementos eliminados
            modelBuilder.Entity<TipoInscripcion>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Usuario>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Capacitacion>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<TipoInscripcionCapacitacion>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Inscripcion>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
