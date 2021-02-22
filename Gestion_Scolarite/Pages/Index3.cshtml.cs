using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Scolarite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Scolarite.Pages
{
    public class Index3Model : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public Index3Model(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public Etudiant Etudiant { get; set; }

        public Niveau Niveau { get; set; }

        public int? user { get; set; }
        public void OnGet()
        {
            user = HttpContext.Session.GetInt32("user");
            Etudiant = _context.Etudiants.Find(user);
            Niveau = _context.Nivaux.Find(Etudiant.NiveauID);
        }
    }
}
