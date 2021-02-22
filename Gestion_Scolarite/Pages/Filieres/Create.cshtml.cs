using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Filieres
{
    public class CreateModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public CreateModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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

        [BindProperty]
        public Filiere Filiere { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Filieres.Add(Filiere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
