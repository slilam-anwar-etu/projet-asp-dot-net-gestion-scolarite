using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Seances
{
    public class EditModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EditModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
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

        public List<SelectListItem> Types { get; set; }

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
            Types = new List<SelectListItem>
            {
                new SelectListItem{ Text="Cours", Value = "Cours" },
                new SelectListItem{ Text="TD", Value = "TD" },
                new SelectListItem{ Text="TP", Value = "TP" },
            };
            ViewData["Type"] = new SelectList(Types, "Value", "Text");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? idModule, int? idNiveau, int? idFiliere, int? idMatiere)
        {
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
                Seance.MatiereID = (int)idMatiere;
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

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Seance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeanceExists(Seance.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { idFiliere = IdFil, idNiveau = IdNiv, idModule = IdMod, idMatiere = IdMat });
        }

        private bool SeanceExists(int id)
        {
            return _context.Seances.Any(e => e.ID == id);
        }
    }
}
