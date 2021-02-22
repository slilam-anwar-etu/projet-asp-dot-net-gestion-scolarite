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
    public class EtudiantNotesModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EtudiantNotesModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public int? user { get; set; }

        public IList<Note> Note { get;set; }

        public async Task OnGetAsync()
        {
            user = HttpContext.Session.GetInt32("user");

            Note = await _context.Notes
                .Include(n => n.Etudiant)
                .Include(n => n.Matiere)
                   .ThenInclude(n => n.Module)
                .Where(n => n.EtudiantID == user)
                .OrderBy(n => n.Matiere.ModuleID)
                .ToListAsync();
        }
    }
}
