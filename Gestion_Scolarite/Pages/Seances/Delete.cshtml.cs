using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Seances
{
    public class DeleteModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public DeleteModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Seance Seance { get; set; }

        [BindProperty]
        public int IdMat { get; set; }

        [BindProperty]
        public int IdMod { get; set; }

        [BindProperty]
        public int IdNiv { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? idModule, int? idNiveau, int? idFiliere, int? idMatiere)
        {
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
            }
            if (idModule != null)
            {
                IdMod = (int)idModule;
            }
            if (idNiveau != null)
            {
                IdNiv = (int)idNiveau;
            }
            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
            }

            if (id == null)
            {
                return NotFound();
            }

            Seance = await _context.Seances
                .Include(s => s.Matiere).FirstOrDefaultAsync(m => m.ID == id);

            if (Seance == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int? idModule, int? idNiveau, int? idFiliere, int? idMatiere)
        {
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
            }
            if (idModule != null)
            {
                IdMod = (int)idModule;
            }
            if (idNiveau != null)
            {
                IdNiv = (int)idNiveau;
            }
            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
            }

            if (id == null)
            {
                return NotFound();
            }

            Seance = await _context.Seances.FindAsync(id);

            if (Seance != null)
            {
                _context.Seances.Remove(Seance);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { idFiliere = IdFil, idNiveau = IdNiv, idModule = IdMod, idMatiere = IdMat });
        }
    }
}
