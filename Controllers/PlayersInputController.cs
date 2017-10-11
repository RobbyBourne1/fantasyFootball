using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fantasyFootball.Data;
using fantasyFootball.Models;

namespace fantasyFootball.Controllers
{
    public class PlayersInputController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayersInputController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlayersInput
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FantasyPlayers.Include(p => p.FantasyTeamModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PlayersInput/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playersModel = await _context.FantasyPlayers
                .Include(p => p.FantasyTeamModel)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (playersModel == null)
            {
                return NotFound();
            }

            return View(playersModel);
        }

        // GET: PlayersInput/Create
        public IActionResult Create()
        {
            ViewData["FantasyTeamModelId"] = new SelectList(_context.FantasyTeams, "Id", "Id");
            return View();
        }

        // POST: PlayersInput/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FantasyTeamModelId,active,jersey,lname,fname,displayName,team,position,dob,college")] PlayersModel playersModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playersModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FantasyTeamModelId"] = new SelectList(_context.FantasyTeams, "Id", "Id", playersModel.FantasyTeamModelId);
            return View(playersModel);
        }

        // GET: PlayersInput/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playersModel = await _context.FantasyPlayers.SingleOrDefaultAsync(m => m.Id == id);
            if (playersModel == null)
            {
                return NotFound();
            }
            ViewData["FantasyTeamModelId"] = new SelectList(_context.FantasyTeams, "Id", "Id", playersModel.FantasyTeamModelId);
            return View(playersModel);
        }

        // POST: PlayersInput/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FantasyTeamModelId,active,jersey,lname,fname,displayName,team,position,dob,college")] PlayersModel playersModel)
        {
            if (id != playersModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playersModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayersModelExists(playersModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FantasyTeamModelId"] = new SelectList(_context.FantasyTeams, "Id", "Id", playersModel.FantasyTeamModelId);
            return View(playersModel);
        }

        // GET: PlayersInput/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playersModel = await _context.FantasyPlayers
                .Include(p => p.FantasyTeamModel)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (playersModel == null)
            {
                return NotFound();
            }

            return View(playersModel);
        }

        // POST: PlayersInput/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var playersModel = await _context.FantasyPlayers.SingleOrDefaultAsync(m => m.Id == id);
            _context.FantasyPlayers.Remove(playersModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayersModelExists(string id)
        {
            return _context.FantasyPlayers.Any(e => e.Id == id);
        }
    }
}
