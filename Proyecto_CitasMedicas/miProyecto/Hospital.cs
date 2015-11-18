﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_CitasMedicas.miProyecto
{
    public class Hospital
    {
        [Key]
        public int idHospital { get; set; }
        public String NomHospital { get; set; }
        public string DirHospital { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }

    }
}
