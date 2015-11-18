using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_CitasMedicas.miProyecto
{
    public class Motivo
    {
    [Key]
        public int idMotivo { get; set; }
        public string nomMotivo { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
