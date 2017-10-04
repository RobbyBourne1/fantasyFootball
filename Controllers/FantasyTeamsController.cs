using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fantasyFootball.Models;
using System.Net;

namespace fantasyFootball.Controllers
{
    public class FantasyTeamsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult GetTeam()
        {
            var url = "http://api.fantasy.nfl.com/v1/application/login?appKey=sampleapp&timestamp=1268089312&signature=c21bdddc4d4b33f1764c38b9200248d8";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var rawResponse = String.Empty;
            return View();
        }
    }
}