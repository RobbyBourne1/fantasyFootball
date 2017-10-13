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
            position = position.ToLower().ToString();
            var pos = position;
            var url = $"http://www.footballoutsiders.com/stats/{pos}";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode("//table");

            if (position == "qb")
            {
                foreach (var nNode in node.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText == name);
                        if (_nameNode != null)
                        {
                            var insertViewModel = new FootBallOViewModel();
                                insertViewModel.DYAR = nNode.ChildNodes.ElementAt(5).InnerText;
                                insertViewModel.DYARRank = nNode.ChildNodes.ElementAt(7).InnerText;
                                insertViewModel.DVOA = nNode.ChildNodes.ElementAt(13).InnerText;
                                insertViewModel.DVOARank = nNode.ChildNodes.ElementAt(15).InnerText;
                                insertViewModel.QBR = nNode.ChildNodes.ElementAt(19).InnerText;
                                insertViewModel.QBRRank = nNode.ChildNodes.ElementAt(21).InnerText;
                                insertViewModel.Yards = nNode.ChildNodes.ElementAt(25).InnerText;
                                insertViewModel.EYards = nNode.ChildNodes.ElementAt(27).InnerText;
                                insertViewModel.TDs = nNode.ChildNodes.ElementAt(29).InnerText;
                                insertViewModel.FumblesLost = nNode.ChildNodes.ElementAt(33).InnerText;
                                insertViewModel.INTs = nNode.ChildNodes.ElementAt(35).InnerText;
                            
                            Console.WriteLine("team is:" + nNode.ChildNodes.ElementAt(3).InnerText);
                            Console.WriteLine("DYAR is:" + nNode.ChildNodes.ElementAt(5).InnerText);
                            Console.WriteLine("DYARRank is:" + nNode.ChildNodes.ElementAt(7).InnerText);
                            Console.WriteLine("DVOA is:" + nNode.ChildNodes.ElementAt(13).InnerText);
                            Console.WriteLine("DVOARank is:" + nNode.ChildNodes.ElementAt(15).InnerText);
                            Console.WriteLine("QBR is:" + nNode.ChildNodes.ElementAt(19).InnerText);
                            Console.WriteLine("QBRRank is:" + nNode.ChildNodes.ElementAt(21).InnerText);
                            Console.WriteLine("Yards is:" + nNode.ChildNodes.ElementAt(25).InnerText);
                            Console.WriteLine("EYards is:" + nNode.ChildNodes.ElementAt(27).InnerText);
                            Console.WriteLine("TD is:" + nNode.ChildNodes.ElementAt(29).InnerText);
                            Console.WriteLine("FumblesLost is:" + nNode.ChildNodes.ElementAt(33).InnerText);
                            Console.WriteLine("INT is:" + nNode.ChildNodes.ElementAt(35).InnerText);

                            for (var i = 0; i < nNode.ChildNodes.Count(); i++)
                            {
                                Console.WriteLine($"{i}:{nNode.ChildNodes[i]}:{nNode.ChildNodes[i].InnerHtml}");
                            }
                            return View(insertViewModel);
                        }
                    }
                }
            }
            return View();
        }
    }
}

// foreach(var n in nNode.ChildNodes){
//     Console.WriteLine(n.InnerHtml);
// }