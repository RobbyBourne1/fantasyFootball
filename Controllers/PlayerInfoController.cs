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
            position = position.ToLower().ToString();
            var pos = position;
            var url = $"http://www.footballoutsiders.com/stats/";

            if (pos == "k")
            {
                url = "http://www.footballoutsiders.com/stats/teamst";

            }else if (pos == "def")
            {
                url = "http://www.footballoutsiders.com/stats/teamdef";

            }else
            {
                url = $"http://www.footballoutsiders.com/stats/{pos}";
            }

            var FPName = $"{finitial.ToString()} {lname.ToString()} {team.ToString()}";
            var FPurl = $"https://www.fantasypros.com/nfl/projections/{pos}.php";
            var FPweb = new HtmlWeb();
            var FPdoc = FPweb.Load(FPurl);
            var FPnode = FPdoc.DocumentNode.SelectSingleNode("//table/tbody");
            
            // Console.WriteLine(FOnode.OuterHtml);

            foreach (var nNode in FPnode.Descendants("tr"))
            {
            if (nNode.NodeType == HtmlNodeType.Element)
                {
                    
                        var findName = nNode.ChildNodes.Where(w => w.InnerText == FPName).Select(s => s.InnerText).FirstOrDefault();
                        if (findName != null)
                        {
                          Console.WriteLine(nNode.ChildNodes[0].InnerText);  
                        }
                    // I want it to get the inner text of a and match to FP Name. 
                }
            }

            // Console.WriteLine(url);
            // Console.WriteLine(position);
            // Console.WriteLine(team);
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode("//table");

            if (position == "qb")
            {   
                finitial = finitial.First().ToString();
                var name = $"{finitial}.{lname}";
                foreach (var nNode in node.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText == name);
                        if (_nameNode != null)
                        {
                            var insertViewModel = new FootBallOViewModel();
                                insertViewModel.Position = position;
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

                            // for (var i = 0; i < nNode.ChildNodes.Count(); i++)
                            // {
                            //     Console.WriteLine($"{i}:{nNode.ChildNodes[i]}:{nNode.ChildNodes[i].InnerHtml}");
                            // }
                            return View(insertViewModel);
                        }
                    }
                }                
            }
            if (position == "rb")
            {
                finitial = finitial.First().ToString();
                var name = $"{finitial}.{lname}";
                foreach (var nNode in node.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText == name);
                        if (_nameNode != null)
                        {
                            var insertViewModel = new FootBallOViewModel();
                                insertViewModel.Position = position;
                                insertViewModel.DYAR = nNode.ChildNodes.ElementAt(5).InnerText;
                                insertViewModel.DYARRank = nNode.ChildNodes.ElementAt(7).InnerText;
                                insertViewModel.DVOA = nNode.ChildNodes.ElementAt(13).InnerText;
                                insertViewModel.DVOARank = nNode.ChildNodes.ElementAt(15).InnerText;
                                insertViewModel.Yards = nNode.ChildNodes.ElementAt(21).InnerText;
                                insertViewModel.EYards = nNode.ChildNodes.ElementAt(23).InnerText;
                                insertViewModel.TDs = nNode.ChildNodes.ElementAt(25).InnerText;
                                insertViewModel.FumblesLost = nNode.ChildNodes.ElementAt(27).InnerText;
                                insertViewModel.SuccessRate = nNode.ChildNodes.ElementAt(29).InnerText;

                            for (var i = 0; i < nNode.ChildNodes.Count(); i++)
                            {
                                Console.WriteLine($"{i}:{nNode.ChildNodes[i]}:{nNode.ChildNodes[i].InnerHtml}");
                            }
                            return View(insertViewModel);
                        }
                    }
                }
            }
            if (position == "wr" || position == "te")
            {   
                finitial = finitial.First().ToString();
                var name = $"{finitial}.{lname}";
                foreach (var nNode in node.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText == name);
                        if (_nameNode != null)
                        {
                            var insertViewModel = new FootBallOViewModel();
                            insertViewModel.Position = position;
                            insertViewModel.DYAR = nNode.ChildNodes.ElementAt(5).InnerText;
                            insertViewModel.DYARRank = nNode.ChildNodes.ElementAt(7).InnerText;
                            insertViewModel.DVOA = nNode.ChildNodes.ElementAt(13).InnerText;
                            insertViewModel.DVOARank = nNode.ChildNodes.ElementAt(15).InnerText;
                            insertViewModel.Yards = nNode.ChildNodes.ElementAt(21).InnerText;
                            insertViewModel.EYards = nNode.ChildNodes.ElementAt(23).InnerText;
                            insertViewModel.TDs = nNode.ChildNodes.ElementAt(25).InnerText;
                            insertViewModel.FumblesLost = nNode.ChildNodes.ElementAt(29).InnerText;
                            insertViewModel.CatchRate = nNode.ChildNodes.ElementAt(27).InnerText;
                            insertViewModel.Passes = nNode.ChildNodes.ElementAt(19).InnerText;

                            Console.WriteLine("team is:" + nNode.ChildNodes.ElementAt(3).InnerText);

                            for (var i = 0; i < nNode.ChildNodes.Count(); i++)
                            {
                                Console.WriteLine($"{i}:{nNode.ChildNodes[i]}:{nNode.ChildNodes[i].InnerHtml}");
                            }
                            return View(insertViewModel);
                        }
                    }
                }
            }
            if (position == "k")
            {
                Console.WriteLine(position);
                foreach (var nNode in node.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _teamNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText == team);
                        Console.WriteLine(_teamNode);
                        if (_teamNode != null)
                        {
                            var insertViewModel = new FootBallOViewModel();
                                insertViewModel.Position = position;
                                insertViewModel.FGXPRatio = nNode.ChildNodes.ElementAt(13).InnerText;

                                Console.WriteLine("team is:" + nNode.ChildNodes.ElementAt(3).InnerText);

                            for (var i = 0; i < nNode.ChildNodes.Count(); i++)
                            {
                                Console.WriteLine($"{i}:{nNode.ChildNodes[i]}:{nNode.ChildNodes[i].InnerHtml}");
                            }
                            return View(insertViewModel);
                        }
                    }
                }
            }
            if (position == "def")
            {
                Console.WriteLine(position);
                foreach (var nNode in node.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _teamNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText == team);
                        Console.WriteLine(_teamNode);
                        if (_teamNode != null)
                        {
                            var insertViewModel = new FootBallOViewModel();
                                insertViewModel.Position = position;
                                insertViewModel.DefDVOA = nNode.ChildNodes.ElementAt(5).InnerText;
                                insertViewModel.DefDVOARank = nNode.ChildNodes.ElementAt(7).InnerText;
                                insertViewModel.DefDAVE = nNode.ChildNodes.ElementAt(9).InnerText;
                                insertViewModel.DefDAVERank = nNode.ChildNodes.ElementAt(11).InnerText;
                                insertViewModel.DEFPassRank = nNode.ChildNodes.ElementAt(15).InnerText;
                                insertViewModel.DEFRushRank = nNode.ChildNodes.ElementAt(19).InnerText;

                                Console.WriteLine("team is:" + nNode.ChildNodes.ElementAt(3).InnerText);

                            for (var i = 0; i < nNode.ChildNodes.Count(); i++)
                            {
                                Console.WriteLine($"{i}:{nNode.ChildNodes[i]}:{nNode.ChildNodes[i].InnerHtml}");
                            }
                            return View(insertViewModel);
                        }
                    }
                }
            }
// Here is were I'll Bring in Fantasy Pros Stats

            return View();
        }
    }
}

// foreach(var n in nNode.ChildNodes){
//     Console.WriteLine(n.InnerHtml);
// }