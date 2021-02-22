using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Scolarite.Models
{
    public class Etudiant : User
    {
        public int NiveauID { get; set; }

        public Niveau Niveau { get; set; }

    }
}
