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

namespace Gestion_Scolarite.Pages.Etudiants
{
    public class EditModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EditModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Etudiant Etudiant { get; set; }

        [BindProperty]
        public int IdNiv { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? idNiveau, int? idFiliere)
        {
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

            Etudiant = await _context.Etudiants
                .Include(e => e.Role)
                .Include(e => e.Niveau).FirstOrDefaultAsync(m => m.ID == id);

            if (Etudiant == null)
            {
                return NotFound();
            }
           ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "ID");
           ViewData["NiveauID"] = new SelectList(_context.Nivaux, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? idNiveau, int? idFiliere)
        {
            if (idNiveau != null)
            {
                IdNiv = (int)idNiveau;
                Etudiant.NiveauID = (int)idNiveau;
                Etudiant.RoleID = 3;
            }
            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(Etudiant.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { idFiliere = IdFil, idNiveau = IdNiv });
        }

        private bool EtudiantExists(int id)
        {
            return _context.Etudiants.Any(e => e.ID == id);
        }
    }
}
