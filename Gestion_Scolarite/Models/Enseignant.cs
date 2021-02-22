using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Scolarite.Models
{
    public class Enseignant : User
    {
        public int DepartementID { get; set; }
        public Departement Departement { get; set; }

        public static implicit operator Task<object>(Enseignant v)
        {
            throw new NotImplementedException();
        }
    }
}
