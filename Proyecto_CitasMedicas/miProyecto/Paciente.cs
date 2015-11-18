using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CitasMedicas.miProyecto
{
    public class Paciente
    {
        public int id { get; set; }
        public int numAfiliacion { get; set; }
        public string nomPaciente { get; set; }
        public int edad { get; set; }
        public int telPac { get; set; }
        public string dirPac { get; set; }
        public string tipSangre { get; set; }
        public string alergicoA { get; set; }
    }
}
