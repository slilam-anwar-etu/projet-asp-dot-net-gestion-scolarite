using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Nivaux
{
    public class IndexModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public IndexModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Niveau> Niveau { get;set; }

        public Filiere Filiere { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public async Task OnGetAsync(int? idFiliere)
        {
            Niveau = await _context.Nivaux
                .Include(n => n.Filiere).ToListAsync();

            if (idFiliere != null)
            {
                Niveau = Niveau.Where(e => e.FiliereID == idFiliere).OrderBy(n => n.Code).ToList();
                IdFil = (int)idFiliere;
                Filiere = await _context.Filieres.FindAsync(idFiliere);
            }
        }
    }
}
