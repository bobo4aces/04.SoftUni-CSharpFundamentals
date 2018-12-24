using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Treasure_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                string instructionsPattern = @"(#[^#!]+!)|(![^#!]+#)";
                string streetPattern = @"(?:[^A-Za-z0-9])([A-Za-z]{4})(?:[^A-Za-z0-9])";
                string streetNumberPattern = @"([0-9]{3})\-([0-9]{6}|[0-9]{4})";
                MatchCollection matches = Regex.Matches(text, instructionsPattern);
                string streetName = "";
                string streetNumber = "";
                string pass = "";
                int counter = 0;
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                    if (Regex.IsMatch(match.ToString(), streetPattern) &&
                       Regex.IsMatch(match.ToString(), streetNumberPattern))
                    {
                    if (matches.Count % 2 == 1)
                    {
                        if (counter == matches.Count / 2)
                        {
                            Match streetMatches = Regex.Match(match.ToString(), streetPattern);
                            //foreach (var streetMatch in streetMatches)
                            //{
                            //    streetName = streetMatch.Group(1).ToString().Trim();
                            //}
                                streetName = streetMatches.Groups[1].Value;
                                MatchCollection streetNumberMatches = Regex.Matches(match.ToString(), streetNumberPattern);
                            foreach (var streetNumberMatch in streetNumberMatches)
                            {
                                string[] info = streetNumberMatch.ToString().Split("-").Select(e=>e.Trim()).ToArray();
                                streetNumber = info[0];
                                pass = info[1];
                            }

                        }
                    }
                    else
                    {
                        Match streetMatches = Regex.Match(match.ToString(), streetPattern);
                        //foreach (var streetMatch in streetMatches)
                        //{
                        //    streetName = streetMatch.ToString();
                        //}
                            streetName = streetMatches.Groups[1].Value;
                            MatchCollection streetNumberMatches = Regex.Matches(match.ToString(), streetNumberPattern);
                        foreach (var streetNumberMatch in streetNumberMatches)
                        {
                            string[] info = streetNumberMatch.ToString().Split("-").Select(e=>e.Trim()).ToArray();
                            streetNumber = info[0];
                            pass = info[1];
                        }
                    }

                    }
                    counter++;
                }
                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {pass}.");
            }
        }
    }
}
