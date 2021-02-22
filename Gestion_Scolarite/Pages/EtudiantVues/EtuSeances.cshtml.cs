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
    public class EtuSeancesModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EtuSeancesModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Seance> Seance { get;set; }

        public Etudiant Etudiant { get; set; }

        public Niveau Niveau { get; set; }

        public int? user { get; set; }

        public async Task OnGetAsync()
        {
            user = HttpContext.Session.GetInt32("user");
            Etudiant = _context.Etudiants.Find(user);
            Niveau = _context.Nivaux.Find(Etudiant.NiveauID);
            Seance = await _context.Seances
                .Include(s => s.Matiere)
                   .ThenInclude(s => s.Module)
                      .ThenInclude(s => s.Niveau)
                .Include(s => s.Matiere)
                   .ThenInclude(s => s.Enseignant)
                .Where(s => s.Matiere.Module.Niveau.ID == Niveau.ID && s.Date_Seance >= DateTime.Today)
                .OrderBy(s => s.Date_Seance)
                .ToListAsync();
        }
    }
}
