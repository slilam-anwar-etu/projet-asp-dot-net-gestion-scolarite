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

namespace Gestion_Scolarite.Pages.EnseignantVues
{
    public class EnseignantMatieresModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EnseignantMatieresModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Matiere> Matiere { get;set; }

        public int? user { get; set; }

        public async Task OnGetAsync()
        {
            user = HttpContext.Session.GetInt32("user");

            Matiere = await _context.Matieres
                .Include(m => m.Enseignant)
                .Include(m => m.Module)
                   .ThenInclude(m => m.Niveau)
                .Where( m => m.EnseignantID == user)
                .OrderBy (m => m.Module.Niveau.Code)
                   .ThenBy (m => m.Module.Code)
                      .ThenBy (m => m.Code)
                .ToListAsync();
        }
    }
}
