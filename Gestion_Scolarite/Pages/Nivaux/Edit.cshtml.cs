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

namespace Gestion_Scolarite.Pages.Nivaux
{
    public class EditModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EditModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Niveau Niveau { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? idFiliere)
        {
            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
            }

            if (id == null)
            {
                return NotFound();
            }

            Niveau = await _context.Nivaux
                .Include(n => n.Filiere).FirstOrDefaultAsync(m => m.ID == id);

            if (Niveau == null)
            {
                return NotFound();
            }
            ViewData["FiliereID"] = new SelectList(_context.Filieres, "ID", "ID");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? idFiliere)
        {
            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
                Niveau.FiliereID = (int)idFiliere;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Niveau).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NiveauExists(Niveau.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { idFiliere = IdFil });
        }

        private bool NiveauExists(int id)
        {
            return _context.Nivaux.Any(e => e.ID == id);
        }
    }
}
