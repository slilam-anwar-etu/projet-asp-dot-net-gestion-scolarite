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

namespace Gestion_Scolarite.Pages.Matieres
{
    public class EditModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EditModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Matiere Matiere { get; set; }

        [BindProperty]
        public int IdMod { get; set; }

        [BindProperty]
        public int IdNiv { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? idModule, int? idNiveau, int? idFiliere)
        {
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

            Matiere = await _context.Matieres
                .Include(m => m.Module)
                .Include(m => m.Enseignant).FirstOrDefaultAsync(m => m.ID == id);

            if (Matiere == null)
            {
                return NotFound();
            }
            var enseignants = _context.Enseignants
                .Select(e => new
                {
                    ID = e.ID,
                    FullName = e.Nom + " " + e.Prenom
                })
                .ToList();

            ViewData["EnseignantID"] = new SelectList(enseignants, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? idModule, int? idNiveau, int? idFiliere)
        {
            if (idModule != null)
            {
                IdMod = (int)idModule;
                Matiere.ModuleID = (int)idModule;
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

            _context.Attach(Matiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatiereExists(Matiere.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { idFiliere = IdFil, idNiveau = IdNiv, idModule = IdMod });
        }

        private bool MatiereExists(int id)
        {
            return _context.Matieres.Any(e => e.ID == id);
        }
    }
}
