using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fantasyFootball.Models;
using HtmlAgilityPack;

namespace fantasyFootball.Controllers
{
    public class PlayerInfoController : Controller
    {
        public IActionResult Index(int Id, [FromQuery]string finitial, [FromQuery]string lname, [FromQuery]string team, [FromQuery]string position)
        {
            finitial = finitial.First().ToString();
            var name = $"{finitial}.{lname}";
            var url = "http://www.footballoutsiders.com/stats/qb";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode("//table");
            foreach (var nNode in node.Descendants("tr"))
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {   
                    var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText ==name);
                    if (_nameNode != null){
                        // foreach(var n in nNode.ChildNodes){
                        //     Console.WriteLine(n.InnerHtml);
                        // }
                        Console.WriteLine("position is:" + nNode.ChildNodes.ElementAt(3).InnerText);
                        for(var i = 0; i < nNode.ChildNodes.Count(); i++){
                            Console.WriteLine($"{i}:{nNode.ChildNodes[i]}:{nNode.ChildNodes[i].InnerHtml}");
                        }
                  
                    }
                }
            }

            return View();
        }
    }
}