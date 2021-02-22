using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Data;
using Gestion_Scolarite.Models;
using Microsoft.AspNetCore.Http;

namespace Gestion_Scolarite.Pages.EtudiantVues
{
    public class EtudiantModulesModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EtudiantModulesModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Module> Module { get;set; }

        public Etudiant Etudiant { get; set; }

        public Niveau Niveau { get; set; }

        public int? user { get; set; }

        public async Task OnGetAsync()
        {
            user = HttpContext.Session.GetInt32("user");
            Etudiant = _context.Etudiants.Find(user);
            Niveau = _context.Nivaux.Find(Etudiant.NiveauID);

            Module = await _context.Modules
                .Include(m => m.Niveau)
                .Include(m => m.Responsable)
                .Where(m => m.NiveauID == Niveau.ID)
                .ToListAsync();
        }
    }
}
