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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace fantasyFootball.Controllers
{
    [Authorize]
    public class FantasyTeamController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FantasyTeamController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string userTeam)
        {
            var TeamSelect = new SelectList(_context.FantasyTeams, "Id", "TeamName");

            var user = await _userManager.GetUserAsync(HttpContext.User);

            var userTeams = new FantasyTeamModel()
            {
                TeamName = userTeam
            };

            var TeamUser = _context.FantasyTeams.Where(w => w.ApplicationUserId == user.Id).ToList();
            
            Console.WriteLine(user.Id);
            Console.WriteLine(TeamSelect.Count());
            Console.WriteLine(TeamUser.Count());
            return View(TeamUser);
        }
        // [HttpGet]
        // public async Task<IActionResult> Index()
        // {
        //     var user = await _userManager.GetUserAsync(HttpContext.User);

        //     var applicationDbContext = _context.FantasyTeams.Include(p => p.ApplicationUser).Where(w => w.ApplicationUserId == user.Id);
        //     return View(await applicationDbContext.ToListAsync());
        // }
    }
}
