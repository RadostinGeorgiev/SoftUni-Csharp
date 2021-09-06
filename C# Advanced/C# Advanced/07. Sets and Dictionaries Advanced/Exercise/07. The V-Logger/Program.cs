using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, VLogger> vloggers = new Dictionary<string, VLogger>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] info = input.Split();
                string name = info[0];
                string action = info[1];

                switch (action)
                {
                    case "joined":
                        if (!vloggers.ContainsKey(name))
                        {
                            vloggers.Add(name, new VLogger());
                        }
                        break;
                    case "followed":
                        string followedVlogger = info[2];
                        if (followedVlogger != name
                            && vloggers.ContainsKey(name)
                            && vloggers.ContainsKey(followedVlogger)
                            && !vloggers[followedVlogger].Followers.Contains(name))
                        {
                            vloggers[name].Following.Add(followedVlogger);
                            vloggers[followedVlogger].Followers.Add(name);
                        }
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int number = 1;
            foreach (var kVP in vloggers
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count))
            {
                Console.WriteLine($"{number}. {kVP.Key} : {kVP.Value.Followers.Count} followers, {kVP.Value.Following.Count} following");
                if (number == 1)
                {
                    foreach (var Follower in kVP.Value.Followers.OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {Follower}");
                    }
                }
                number++;
            }
        }
    }

    class VLogger
    {
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }

        public VLogger()
        {
            Followers = new List<string>();
            Following = new List<string>();
        }
    }
}