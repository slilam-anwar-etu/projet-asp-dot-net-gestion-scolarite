using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Nivaux
{
    public class CreateModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public CreateModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int IdFil { get; set; }   

        public IActionResult OnGet(int? idFiliere)
        {

            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
            }

            ViewData["FiliereID"] = new SelectList(_context.Filieres, "ID", "ID");

            return Page();
        }

        [BindProperty]
        public Niveau Niveau { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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

            _context.Nivaux.Add(Niveau);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { idFiliere = IdFil });
        }
    }
}
