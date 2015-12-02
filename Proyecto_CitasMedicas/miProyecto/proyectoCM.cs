using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CitasMedicas.miProyecto
{
    public class proyectoCM : DbContext
    {
        public DbSet<Hospital> Hospitales { get; set; }
        //para crear la base de datos, DbSet es la palabra reservada
        public DbSet<Afiliacion> Afiliaciones { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Motivo> Motivos { get; set; }
        public DbSet<Cita> Citas { get; set; }

    }
}
