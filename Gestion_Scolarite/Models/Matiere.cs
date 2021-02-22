using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Scolarite.Models
{
    public class Matiere
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Designation { get; set; }
        public int EnseignantID { get; set; }
        public int ModuleID { get; set; }
        public int VolumeHoraire { get; set; }

        public Enseignant Enseignant { get; set; }
        public Module Module { get; set; }
    }
}
