using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fantasyFootball.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;

namespace fantasyFootball.Controllers
{
    [Authorize]
    public class PlayerInfoController : Controller
    {
        public IActionResult Index(int Id, [FromQuery]string finitial, [FromQuery]string lname, [FromQuery]string team, [FromQuery]string position)
        {
            position = position.ToLower().ToString();
            var pos = position;
            var FOurl = $"http://www.footballoutsiders.com/stats/{pos}";

            if (pos == "k")
            {
                FOurl = "http://www.footballoutsiders.com/stats/teamst";

            }
            else if (pos == "def")
            {
                FOurl = "http://www.footballoutsiders.com/stats/teamdef";
            }

            var FOweb = new HtmlWeb();
            var FOdoc = FOweb.Load(FOurl);
            var FOnode = FOdoc.DocumentNode.SelectSingleNode("//table");

            var FPName = $"{finitial.ToString()}{lname.ToString()}{team.ToString()}";
            var FPurl = $"https://www.fantasypros.com/nfl/projections/{pos}.php";
            if (pos == "def")
            {
                FPurl = $"https://www.fantasypros.com/nfl/projections/dst.php";
            }

            var FPweb = new HtmlWeb();
            var FPdoc = FPweb.Load(FPurl);
            var FPnode = FPdoc.DocumentNode.SelectSingleNode("//table/tbody");

            var FPMurl = $"https://www.fantasypros.com/nfl/matchups/{pos}.php";
            if (pos == "def")
            {
               FPMurl = "https://www.fantasypros.com/nfl/matchups/dst.php";
            }

            var FPMweb = new HtmlWeb();
            var FPMdoc = FPMweb.Load(FPMurl);
            var FPMnode = FPMdoc.DocumentNode.SelectSingleNode("//tbody");

            
            if (position == "qb")
            {
                var myviewmodel = new PlayerInfoViewModel();
                foreach (var nNode in FPnode.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText.Replace(" ", "") == FPName);
                        if (_nameNode != null)
                        {
                            myviewmodel.FantasyPros = new List<FantasyProsModel>();
                            myviewmodel.FantasyPros.Add(new FantasyProsModel
                            {
                                Position = position,
                                PassCMP = nNode.ChildNodes.ElementAt(4).InnerText,
                                PassYards = nNode.ChildNodes.ElementAt(6).InnerText,
                                PassAtt = nNode.ChildNodes.ElementAt(2).InnerText,
                                PassINTs = nNode.ChildNodes.ElementAt(8).InnerText,
                                PassTDs = nNode.ChildNodes.ElementAt(10).InnerText,
                                RushAtt = nNode.ChildNodes.ElementAt(12).InnerText,
                                RushYards = nNode.ChildNodes.ElementAt(14).InnerText,
                                RushTDs = nNode.ChildNodes.ElementAt(16).InnerText,
                                FumblesLost = nNode.ChildNodes.ElementAt(18).InnerText,
                                FantasyPoints = nNode.ChildNodes.ElementAt(20).InnerText
                            });
                            // Code to check Element Placement on Page
                        }
                    }
                }
                foreach (var nNode in FOnode.Descendants("tr"))
                {
                    finitial = finitial.First().ToString();
                    var name = $"{finitial}.{lname}";
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText == name);
                        if (_nameNode != null)
                        {
                            myviewmodel.FootBallO = new List<FootBallOModel>();
                            myviewmodel.FootBallO.Add(new FootBallOModel
                            {
                                IsNull = "false",
                                Position = position,
                                DYAR = nNode.ChildNodes.ElementAt(5).InnerText,
                                DYARRank = nNode.ChildNodes.ElementAt(7).InnerText,
                                DVOA = nNode.ChildNodes.ElementAt(13).InnerText,
                                DVOARank = nNode.ChildNodes.ElementAt(15).InnerText,
                                QBR = nNode.ChildNodes.ElementAt(19).InnerText,
                                QBRRank = nNode.ChildNodes.ElementAt(21).InnerText,
                                Yards = nNode.ChildNodes.ElementAt(25).InnerText,
                                EYards = nNode.ChildNodes.ElementAt(27).InnerText,
                                TDs = nNode.ChildNodes.ElementAt(29).InnerText,
                                FumblesLost = nNode.ChildNodes.ElementAt(33).InnerText,
                                INTs = nNode.ChildNodes.ElementAt(35).InnerText,

                            });

                        }
                    }
                }
                return View(myviewmodel);
            }
            if (position == "rb")
            {
                var myviewmodel = new PlayerInfoViewModel();
                foreach (var nNode in FPnode.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText.Replace(" ", "") == FPName);
                        if (_nameNode != null)
                        {
                            myviewmodel.FantasyPros = new List<FantasyProsModel>();
                            myviewmodel.FantasyPros.Add(new FantasyProsModel
                            {
                                Position = position,
                                RushAtt = nNode.ChildNodes.ElementAt(2).InnerText,
                                RushYards = nNode.ChildNodes.ElementAt(4).InnerText,
                                RushTDs = nNode.ChildNodes.ElementAt(6).InnerText,
                                Receptions = nNode.ChildNodes.ElementAt(8).InnerText,
                                ReceivingYards = nNode.ChildNodes.ElementAt(10).InnerText,
                                ReceivingTDs = nNode.ChildNodes.ElementAt(12).InnerText,
                                FumblesLost = nNode.ChildNodes.ElementAt(14).InnerText,
                                FantasyPoints = nNode.ChildNodes.ElementAt(16).InnerText
                            });

                            for (var i = 0; i < nNode.ChildNodes.Count(); i++)
                            {
                                Console.WriteLine($"{i}:{nNode.ChildNodes[i]}:{nNode.ChildNodes[i].InnerText}");
                            }

                        }
                    }
                }
                finitial = finitial.First().ToString();
                var name = $"{finitial}.{lname}";
                foreach (var nNode in FOnode.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText == name);
                        if (_nameNode != null)
                        {
                            myviewmodel.FootBallO = new List<FootBallOModel>();
                            myviewmodel.FootBallO.Add(new FootBallOModel
                            {
                                IsNull = "false",
                                Position = position,
                                DYAR = nNode.ChildNodes.ElementAt(5).InnerText,
                                DYARRank = nNode.ChildNodes.ElementAt(7).InnerText,
                                DVOA = nNode.ChildNodes.ElementAt(13).InnerText,
                                DVOARank = nNode.ChildNodes.ElementAt(15).InnerText,
                                Yards = nNode.ChildNodes.ElementAt(21).InnerText,
                                EYards = nNode.ChildNodes.ElementAt(23).InnerText,
                                TDs = nNode.ChildNodes.ElementAt(25).InnerText,
                                FumblesLost = nNode.ChildNodes.ElementAt(27).InnerText,
                                SuccessRate = nNode.ChildNodes.ElementAt(29).InnerText
                            });
                            for (var i = 0; i < nNode.ChildNodes.Count(); i++)
                            {
                                Console.WriteLine($"{i}:{nNode.ChildNodes[i]}:{nNode.ChildNodes[i].InnerText}");
                            }
                        }
                    }
                }
                return View(myviewmodel);
            }
            if (position == "wr" || position == "te")
            {
                var myviewmodel = new PlayerInfoViewModel();
                foreach (var nNode in FPnode.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText.Replace(" ", "") == FPName);
                        if (_nameNode != null)
                        {
                            if (position == "wr")
                            {
                                myviewmodel.FantasyPros = new List<FantasyProsModel>();
                                myviewmodel.FantasyPros.Add(new FantasyProsModel
                                {
                                    Position = position,
                                    RushAtt = nNode.ChildNodes.ElementAt(2).InnerText,
                                    RushYards = nNode.ChildNodes.ElementAt(4).InnerText,
                                    RushTDs = nNode.ChildNodes.ElementAt(6).InnerText,
                                    Receptions = nNode.ChildNodes.ElementAt(8).InnerText,
                                    ReceivingYards = nNode.ChildNodes.ElementAt(10).InnerText,
                                    ReceivingTDs = nNode.ChildNodes.ElementAt(12).InnerText,
                                    FumblesLost = nNode.ChildNodes.ElementAt(14).InnerText,
                                    FantasyPoints = nNode.ChildNodes.ElementAt(16).InnerText
                                });

                            }

                            if (position == "te")
                            {
                                myviewmodel.FantasyPros = new List<FantasyProsModel>();
                                myviewmodel.FantasyPros.Add(new FantasyProsModel
                                {
                                    Position = position,
                                    Receptions = nNode.ChildNodes.ElementAt(2).InnerText,
                                    ReceivingYards = nNode.ChildNodes.ElementAt(4).InnerText,
                                    ReceivingTDs = nNode.ChildNodes.ElementAt(6).InnerText,
                                    FumblesLost = nNode.ChildNodes.ElementAt(8).InnerText,
                                    FantasyPoints = nNode.ChildNodes.ElementAt(10).InnerText
                                });

                            }
                        }
                    }
                }
                finitial = finitial.First().ToString();
                var name = $"{finitial}.{lname}";
                foreach (var nNode in FOnode.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText == name);
                        if (_nameNode != null)
                        {
                            myviewmodel.FootBallO = new List<FootBallOModel>();
                            myviewmodel.FootBallO.Add(new FootBallOModel
                            {
                                IsNull = "false",
                                Position = position,
                                DYAR = nNode.ChildNodes.ElementAt(5).InnerText,
                                DYARRank = nNode.ChildNodes.ElementAt(7).InnerText,
                                DVOA = nNode.ChildNodes.ElementAt(13).InnerText,
                                DVOARank = nNode.ChildNodes.ElementAt(15).InnerText,
                                Yards = nNode.ChildNodes.ElementAt(21).InnerText,
                                EYards = nNode.ChildNodes.ElementAt(23).InnerText,
                                TDs = nNode.ChildNodes.ElementAt(25).InnerText,
                                FumblesLost = nNode.ChildNodes.ElementAt(29).InnerText,
                                CatchRate = nNode.ChildNodes.ElementAt(27).InnerText,
                                Passes = nNode.ChildNodes.ElementAt(19).InnerText
                            });

                        }
                    }
                }
                return View(myviewmodel);
            }
            if (position == "k")
            {
                var myviewmodel = new PlayerInfoViewModel();
                foreach (var nNode in FPnode.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText.Replace(" ", "") == FPName);
                        if (_nameNode != null)
                        {
                            myviewmodel.FantasyPros = new List<FantasyProsModel>();
                            myviewmodel.FantasyPros.Add(new FantasyProsModel
                            {
                                Position = position,
                                FGs = nNode.ChildNodes.ElementAt(2).InnerText,
                                FGAttempted = nNode.ChildNodes.ElementAt(4).InnerText,
                                XPTs = nNode.ChildNodes.ElementAt(6).InnerText,
                                FantasyPoints = nNode.ChildNodes.ElementAt(8).InnerText
                            });

                        }
                    }
                }
                foreach (var nNode in FOnode.Descendants("tr"))
                {

                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _teamNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText == team);
                        Console.WriteLine(_teamNode);
                        if (_teamNode != null)
                        {
                            myviewmodel.FootBallO = new List<FootBallOModel>();
                            myviewmodel.FootBallO.Add(new FootBallOModel
                            {
                                IsNull = "false",
                                Position = position,
                                FGXPRatio = nNode.ChildNodes.ElementAt(13).InnerText
                            });
                        }
                    }
                }
                return View(myviewmodel);
            }
            if (position == "def")
            {
                var myviewmodel = new PlayerInfoViewModel();
                Console.WriteLine(FPurl);
                FPName = $"{finitial}{lname}";
                foreach (var nNode in FPnode.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText.Replace(" ", "") == FPName);
                        if (_nameNode != null)
                        {
                            myviewmodel.FantasyPros = new List<FantasyProsModel>();
                            myviewmodel.FantasyPros.Add(new FantasyProsModel
                            {
                                Position = position,
                                Sacks = nNode.ChildNodes.ElementAt(2).InnerText,
                                INTs = nNode.ChildNodes.ElementAt(4).InnerText,
                                FRs = nNode.ChildNodes.ElementAt(6).InnerText,
                                Safetys = nNode.ChildNodes.ElementAt(14).InnerText,
                                PointsAllowed = nNode.ChildNodes.ElementAt(16).InnerText,
                                FantasyPoints = nNode.ChildNodes.ElementAt(20).InnerText
                            });

                        }
                    }
                }
                foreach (var nNode in FOnode.Descendants("tr"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        var _teamNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText == team);
                        if (_teamNode != null)
                        {
                            myviewmodel.FootBallO = new List<FootBallOModel>();
                            myviewmodel.FootBallO.Add(new FootBallOModel
                            {
                                IsNull = "false",
                                Position = position,
                                DefDVOA = nNode.ChildNodes.ElementAt(5).InnerText,
                                DefDVOARank = nNode.ChildNodes.ElementAt(7).InnerText,
                                DefDAVE = nNode.ChildNodes.ElementAt(9).InnerText,
                                DefDAVERank = nNode.ChildNodes.ElementAt(11).InnerText,
                                DEFPassRank = nNode.ChildNodes.ElementAt(15).InnerText,
                                DEFRushRank = nNode.ChildNodes.ElementAt(19).InnerText
                            });
                        }
                    }
                }
                return View(myviewmodel);
            }

            return View();
        }
    }
}
