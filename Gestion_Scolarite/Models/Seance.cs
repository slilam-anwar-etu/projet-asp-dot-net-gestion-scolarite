using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Scolarite.Models
{
    public class Seance
    {
        public int ID { get; set; }
        public int MatiereID { get; set; }
        public DateTime Date_Seance { get; set; }

        public int Heures { get; set; }
        public int Minutes { get; set; }
        public string Type { get; set; }

        public Matiere Matiere { get; set; }
    }
}
