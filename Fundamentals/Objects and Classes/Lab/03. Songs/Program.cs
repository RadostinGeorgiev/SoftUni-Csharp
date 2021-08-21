using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int songsNumber = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 1; i <= songsNumber; i++)
            {
                string[] songData = Console.ReadLine()
                    .Split('_', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Song song = new Song();
                song.TypeList = songData[0];
                song.Name = songData[1];
                song.Time = songData[2];

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (var item in songs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                List<Song> filteredSongs = songs.Where(s => s.TypeList == typeList).ToList();
                foreach (var item in filteredSongs)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }

    public class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

}
