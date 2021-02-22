using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Scolarite.Models
{
    public class Module
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Designation { get; set; }
        public string Semestre { get; set; }
        public int EnseignantID { get; set; }
        public int NiveauID { get; set; }

        public Enseignant Responsable { get; set; }
        public Niveau Niveau { get; set; }
    }
}
