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

            var users = new User[]
            {
                new User{Nom="LAAZIZ", Prenom="Yassin", Email="laaziz@gmail.com", Adresse="nejma tanger", Password="laaziz", Telephone="0606060606", RoleID= 1}
            };
            context.Users.AddRange(users);

            var admins = new Admin[]
            {
                new Admin{ID=1}
            };
            context.Admins.AddRange(admins);

            context.SaveChanges();
        }
    }
}
