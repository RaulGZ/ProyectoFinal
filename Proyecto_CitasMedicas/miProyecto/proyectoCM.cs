using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CitasMedicas.miProyecto
{
    class proyectoCM : DbContext
    {
        public DbSet<Hospital> Hospital { get; set; }
        //para crear la base de datos, DbSet es la palabra reservada
        public DbSet<Afiliacion> Afiliacion { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Motivo> Motivo { get; set; }

    }
}
