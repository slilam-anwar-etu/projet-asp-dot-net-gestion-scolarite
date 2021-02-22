using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Modules
{
    public class IndexModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public IndexModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Module> Module { get;set; }

        [BindProperty]
        public int IdNiv { get; set; }
        public Niveau Niveau { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public async Task OnGetAsync(int? idNiveau, int? idFiliere)
        {
            Module = await _context.Modules
                .Include(r => r.Responsable)
                .Include(n => n.Niveau).ToListAsync();
            if (idNiveau != null)
            {
                Module = Module.Where(e => e.NiveauID == idNiveau).OrderBy(e => e.Code).ToList();
                IdNiv = (int)idNiveau;
                Niveau = await _context.Nivaux.FindAsync(idNiveau);
            }
            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
            }
        }
    }
}
