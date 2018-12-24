using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Task02
{
    class Task02
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" -> ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, Dictionary<string, int>> usernameTagLikes = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> totals = new Dictionary<string, int>();
            while (input[0]?.ToLower() != "end")
            {
                if (input.Length == 1)
                {
                    string usernameToBan = input[0].Substring(4);
                    if (usernameTagLikes.ContainsKey(usernameToBan))
                    {
                        usernameTagLikes.Remove(usernameToBan);
                    }
                    if (totals.ContainsKey(usernameToBan))
                    {
                        totals.Remove(usernameToBan);
                    }
                }
                else if (input.Length == 3)
                {
                    string username = input[0];
                    string tag = input[1];
                    int likes = int.Parse(input[2]);

                    if (!usernameTagLikes.ContainsKey(username))
                    {
                        usernameTagLikes.Add(username, new Dictionary<string, int>());
                    }
                    if (!usernameTagLikes[username].ContainsKey(tag))
                    {
                        usernameTagLikes[username].Add(tag, 0);
                    }
                    usernameTagLikes[username][tag] += likes;
                    if (!totals.ContainsKey(username))
                    {
                        totals.Add(username, 0);
                    }
                    totals[username] += likes;
                }

                input = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            //totals = totals.OrderBy(k => k.Value).ToDictionary((k,v)=>k,v);
            foreach (var username in totals.OrderByDescending(k => k.Value).ThenBy(v=>usernameTagLikes[v.Key].Keys.Count()))
            {
                Console.WriteLine(username.Key);
                foreach (var tag in usernameTagLikes[username.Key])
                {
                    Console.WriteLine($" - {tag.Key}: { tag.Value}");
                }
            }
        }
    }
}
