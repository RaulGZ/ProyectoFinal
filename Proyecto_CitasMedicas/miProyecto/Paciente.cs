using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_CitasMedicas.miProyecto
{
    public class Paciente
    {
        [Key]
        public int idPaciente { get; set; }
        public int numAfiliacion { get; set; }
        public string nomPaciente { get; set; }
        public int edad { get; set; }
        public int telPac { get; set; }
        public string dirPac { get; set; }
        public string tipSangre { get; set; }
        public string alergicoA { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
