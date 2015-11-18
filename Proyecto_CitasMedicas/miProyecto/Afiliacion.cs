using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_CitasMedicas.miProyecto
{
    public class Afiliacion
    {
        [Key]
        public int idAfiliacion { get; set; }
        public int numAfiliacion { get; set; }
        public string tipoAf { get; set; }
       // public virtual ICollection<Cita> Cita { get; set; }

    }
}
