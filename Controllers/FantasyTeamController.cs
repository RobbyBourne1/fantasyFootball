using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fantasyFootball.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using fantasyFootball.Data;
using Microsoft.AspNetCore.Authorization;

namespace fantasyFootball.Controllers
{
    
    public class FantasyTeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FantasyTeamController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            new SelectList(_context.FantasyTeams, "Id", "TeamName");
            return View();
        }
    }
}
