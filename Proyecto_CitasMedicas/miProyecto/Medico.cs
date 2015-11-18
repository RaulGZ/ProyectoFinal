using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_CitasMedicas.miProyecto
{
    public class Medico
    {
        [Key]
        public int idMedico { get; set; }
        public string nomMedico { get; set; }
        public string tipoMedico { get; set; }
        public int cedProfes { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
  
    }
}
