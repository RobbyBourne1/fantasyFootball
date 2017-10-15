using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fantasyFootball.Models;
using Microsoft.AspNetCore.Authorization;

namespace fantasyFootball.Controllers
{   
    [Authorize]
    public class AvailablePlayersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}