using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Scolarite.Models;

namespace Gestion_Scolarite.Data
{
    public class DbInitializer
    {
        public static void Initialize(Gestion_ScolariteContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Roles.Any())
            {
                return;   // DB has been seeded
            }

            var roles = new Role[]
            {
                new Role{Designation="Admin"},
                new Role{Designation="Enseignant"},
                new Role{Designation="Etudiant"}
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();

        }
    }
}
