using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fantasyFootball.Models;

namespace fantasyFootball.Controllers
{
    public class FantasyTeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}