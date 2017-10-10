using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fantasyFootball.Models;
using System.Net;
using System.IO;

namespace fantasyFootball.Controllers
{
    
    public class ProxyController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var url = "https://www.fantasyfootballnerd.com/service/players/json/yftn2uw58qsv/";
            var request = WebRequest.Create(url);
            request.Method = "GET";
            var response = await request.GetResponseAsync();
            Console.WriteLine(response.ContentLength);
            var rawResponse = String.Empty;
        
            // read the raw res
            rawResponse = await (new StreamReader(response.GetResponseStream())).ReadToEndAsync();
            return Ok(rawResponse);
        }
    }
}