using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Scolarite.Models
{
    public class Note
    {
        public int ID { get; set; }
        public int MatiereID { get; set; }
        public int EtudiantID { get; set; }
        public int Note_Initiale { get; set; }
        public int Note_Finale { get; set; }

        public Matiere Matiere { get; set; }
        public Etudiant Etudiant { get; set; }
    }
}
