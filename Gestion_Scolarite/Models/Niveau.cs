using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Scolarite.Models
{
    public class Niveau
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Designation { get; set; }
        public int FiliereID { get; set; }

        public Filiere Filiere { get; set; }

    }
}
