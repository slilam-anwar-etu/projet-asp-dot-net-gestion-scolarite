using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Matieres
{
    public class IndexModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public IndexModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Matiere> Matiere { get;set; }

        public Module Module { get; set; }

        [BindProperty]
        public int IdMod { get; set; }

        [BindProperty]
        public int IdNiv { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public async Task OnGetAsync(int? idModule, int? idNiveau, int? idFiliere)
        {
            Matiere = await _context.Matieres
                .Include(m => m.Module)
                .Include(m => m.Enseignant).ToListAsync();
            if (idModule != null)
            {
                Matiere = Matiere.Where(e => e.ModuleID == idModule).OrderBy(m => m.Code).ToList();
                IdMod = (int)idModule;
                Module = await _context.Modules.FindAsync(idModule);
            }
            if (idNiveau != null)
            {
                IdNiv = (int)idNiveau;
            }
            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
            }
        }
    }
}
