using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Scolarite.Models
{
    public class Absence
    {
        public int ID { get; set; }
        public int SeanceID { get; set; }
        public int EtudiantID { get; set; }
        public string Absence_Justifie { get; set; }
        public string justification { get; set; }
        public byte[] Fichier { get; set; }

        public Seance Seance { get; set; }
        public Etudiant Etudiant { get; set; }
    }
}
