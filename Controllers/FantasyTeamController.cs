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
        [Route("FantasyTeam/Index/{userTeam}")]
        public async Task<IActionResult> Index([FromRoute]string userTeam)
        {
            var TeamSelect = new SelectList(_context.FantasyTeams, "Id", "TeamName");
            var user = await _userManager.GetUserAsync(HttpContext.User);
           
            var TeamUser = _context.FantasyTeams.Where(w => w.ApplicationUserId == user.Id).ToList();
            var players = _context.PlayersModel.Where(w =>  w.FantasyTeamModelId == userTeam).ToList();

            var playerTeamViewModel = new PlayerTeamViewModel{
                FantasyPlayers = players,
                FantasyTeam = TeamUser
            };

            if (userTeam == "all")
            {
                try
                {
                    userTeam = _context.FantasyTeams.FirstOrDefault(f => f.ApplicationUserId == user.Id).Id;
                }
                catch (System.Exception)
                {
                    
                    return View(nameof(Sorry));
                }
                
            }

            return View(playerTeamViewModel);
        }
        public IActionResult Sorry()
        {
            return View();
        }
    }
}
