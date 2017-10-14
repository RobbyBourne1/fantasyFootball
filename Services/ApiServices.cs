using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fantasyFootball.Models;

namespace fantasyFootball.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class ApiService
    {
        private IEnumerable<FantasyProsModel> GetFantasyPros()
        {
            if (position == "qb")
            {
                    foreach (var nNode in FPnode.Descendants("tr"))
                    {
                        if (nNode.NodeType == HtmlNodeType.Element)
                        {
                            var _nameNode = nNode.ChildNodes.FirstOrDefault(n => n.InnerText.Replace(" ", "") == FPName);
                            if (_nameNode != null)
                            {
                                var FPinsertViewModel = new FantasyProsModel();
                                FPinsertViewModel.PassAtt = nNode.ChildNodes.ElementAt(2).InnerText;
                                FPinsertViewModel.PassCMP = nNode.ChildNodes.ElementAt(4).InnerText;
                                FPinsertViewModel.PassYards = nNode.ChildNodes.ElementAt(6).InnerText;
                                FPinsertViewModel.PassINTs = nNode.ChildNodes.ElementAt(8).InnerText;
                                FPinsertViewModel.PassTDs = nNode.ChildNodes.ElementAt(10).InnerText;
                                FPinsertViewModel.RushAtt = nNode.ChildNodes.ElementAt(12).InnerText;
                                FPinsertViewModel.RushYards = nNode.ChildNodes.ElementAt(14).InnerText;
                                FPinsertViewModel.RushTDs = nNode.ChildNodes.ElementAt(16).InnerText;
                                FPinsertViewModel.FumblesLost = nNode.ChildNodes.ElementAt(18).InnerText;
                                FPinsertViewModel.FantasyPoints = nNode.ChildNodes.ElementAt(20).InnerText;

                                for (var i = 0; i < nNode.ChildNodes.Count(); i++)
                                {
                                    Console.WriteLine($"{i}:{nNode.ChildNodes[i]}:{nNode.ChildNodes[i].InnerText}");
                                }
                            }
                        }
                    }
                    return FPinsertViewModel;
                }
                return null; 
        }
    }
}