using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_CitasMedicas.miProyecto
{
    public class Cita
    {
        [Key]
        public int idCita { get; set; }
        public DateTime hrCita { get; set; }
        public virtual int MotivoidMotivo { get; set; }
        public virtual int MedicoidMedico { get; set; }
        public virtual int PacienteidPaciente { get; set; }
        public virtual int HospitalidHospital { get; set; }
        //public virtual int AfiliacionidAfiliacion { get; set; }
    }
}
