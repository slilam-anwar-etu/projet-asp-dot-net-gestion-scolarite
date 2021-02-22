using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Scolarite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Gestion_Scolarite.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public PrivacyModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        //private readonly ILogger<PrivacyModel> _logger;

        //public PrivacyModel(ILogger<PrivacyModel> logger)
        //{
        //    _logger = logger;
        //}

        public User Userr { get; set; }

        public int? user { get; set; }

        public void OnGet()
        {
            user = HttpContext.Session.GetInt32("user");
            Userr = _context.Users.Find(user);
        }
    }
}
