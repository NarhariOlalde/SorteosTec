using System;
using Microsoft.EntityFrameworkCore;

namespace Web.Model
{
    public class SorteosTecContext : DbContext
    {
        public SorteosTecContext(DbContextOptions<SorteosTecContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Microtransaccion> Microtransacciones { get; set; }
        public DbSet<Puntuacion> Puntuaciones { get; set; }
        public DbSet<Referrals> Referrals { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
    }
}

