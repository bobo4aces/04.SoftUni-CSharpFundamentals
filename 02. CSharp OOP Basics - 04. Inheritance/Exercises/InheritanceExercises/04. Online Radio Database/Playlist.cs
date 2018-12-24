using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRadioDatabase
{
    public class Playlist
    {
        public List<Song> Songs { get; set; }

        public Playlist()
        {
            Songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            Songs.Add(song);
        }

        internal int GetTotalSongs()
        {
            return Songs.Count;
        }

        internal TimeSpan GetTotalLength()
        {
            double totalSeconds = 0;
            foreach (var song in Songs)
            {
                int[] time = song.Length.Split(":").Select(int.Parse).ToArray();
                totalSeconds += time[0] * 60 + time[1];
            }
            return TimeSpan.FromSeconds(totalSeconds);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Songs added: {this.GetTotalSongs()}");
            stringBuilder.AppendLine(
                                    $"Playlist length: {this.GetTotalLength().Hours}h " +
                                    $"{this.GetTotalLength().Minutes}m " +
                                    $"{this.GetTotalLength().Seconds}s");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
