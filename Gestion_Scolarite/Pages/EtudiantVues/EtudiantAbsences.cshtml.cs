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
    public class EtudiantAbsencesModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EtudiantAbsencesModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Absence> Absence { get;set; }

        public int? user { get; set; }

        public async Task OnGetAsync()
        {
            user = HttpContext.Session.GetInt32("user");

            Absence = await _context.Absences
                .Include(a => a.Etudiant)
                .Include(a => a.Seance)
                   .ThenInclude(a => a.Matiere)
                      .ThenInclude(a => a.Module)
                .Where(a => a.EtudiantID == user)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDownloadAsync(int? id)
        {
            var Abs = await _context.Absences
                .Include(a => a.Etudiant)
                .Include(a => a.Seance)
                   .ThenInclude(a => a.Matiere)
                .FirstOrDefaultAsync(a => a.ID == id);
            if (Abs == null)
            {
                return NotFound();
            }

            if (Abs.Fichier == null)
            {
                return Page();
            }
            else
            {
                byte[] byteArr = Abs.Fichier;
                string mimeType = "application/pdf";
                return new FileContentResult(byteArr, mimeType)
                {
                    FileDownloadName = $"Justification {Abs.Seance.Matiere.Code} {Abs.Etudiant.Nom} {Abs.Etudiant.Prenom} Seance_{Abs.Seance.Date_Seance}.pdf"
                };
            }

        }
    }
}
