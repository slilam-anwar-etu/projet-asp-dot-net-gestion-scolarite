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
    public class EtudiantMatieresModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EtudiantMatieresModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Matiere> Matiere { get;set; }

        public Module Module { get; set; }

        [BindProperty]
        public int IdMod { get; set; }

        public async Task OnGetAsync(int? idModule)
        {
            Matiere = await _context.Matieres
                .Include(m => m.Module)
                .Include(m => m.Enseignant).ToListAsync();
            if (idModule != null)
            {
                Matiere = Matiere.Where(e => e.ModuleID == idModule).ToList();
                IdMod = (int)idModule;
                Module = await _context.Modules.FindAsync(idModule);
            }
        }
    }
}
