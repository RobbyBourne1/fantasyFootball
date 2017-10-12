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
    public class InputTeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InputTeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InputTeam
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FantasyTeamModel.Include(f => f.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InputTeam/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyTeamModel = await _context.FantasyTeamModel
                .Include(f => f.ApplicationUser)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fantasyTeamModel == null)
            {
                return NotFound();
            }

            return View(fantasyTeamModel);
        }

        // GET: InputTeam/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: InputTeam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamName,ApplicationUserId,fantasySite")] FantasyTeamModel fantasyTeamModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fantasyTeamModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", fantasyTeamModel.ApplicationUserId);
            return RedirectToAction("Create", "PlayersInput");
        }

        // GET: InputTeam/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyTeamModel = await _context.FantasyTeamModel.SingleOrDefaultAsync(m => m.Id == id);
            if (fantasyTeamModel == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", fantasyTeamModel.ApplicationUserId);
            return View(fantasyTeamModel);
        }

        // POST: InputTeam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,TeamName,ApplicationUserId,fantasySite")] FantasyTeamModel fantasyTeamModel)
        {
            if (id != fantasyTeamModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fantasyTeamModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FantasyTeamModelExists(fantasyTeamModel.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", fantasyTeamModel.ApplicationUserId);
            return View(fantasyTeamModel);
        }

        // GET: InputTeam/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyTeamModel = await _context.FantasyTeamModel
                .Include(f => f.ApplicationUser)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fantasyTeamModel == null)
            {
                return NotFound();
            }

            return View(fantasyTeamModel);
        }

        // POST: InputTeam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fantasyTeamModel = await _context.FantasyTeamModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.FantasyTeamModel.Remove(fantasyTeamModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FantasyTeamModelExists(string id)
        {
            return _context.FantasyTeamModel.Any(e => e.Id == id);
        }
    }
}
