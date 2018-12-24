using System;
using System.Globalization;
using System.Linq;

namespace OnlineRadioDatabase
{
    class StartUp
    {
        static void Main()
        {
            int songsCount = int.Parse(Console.ReadLine());

            Playlist playlist = new Playlist();

            for (int i = 0; i < songsCount; i++)
            {
                string input = Console.ReadLine();
                try
                {
                    string[] currentSong = Song.ReadSong(input);
                    Song song = new Song(currentSong[0], currentSong[1], currentSong[2]);
                    playlist.AddSong(song);
                    Console.WriteLine("Song added.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

            Console.WriteLine(playlist);
        }
    }
}
