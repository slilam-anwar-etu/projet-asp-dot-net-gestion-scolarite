﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public DetailsModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
