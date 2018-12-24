using OnlineRadioDatabase.Exceptions;
using System;
using System.Linq;

namespace OnlineRadioDatabase
{
    public class Song
    {
        private string artistName;
        private string songName;
        private string length;

        public string ArtistName
        {
            get
            {
                return artistName;
            }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }
                artistName = value;
            }
        }
        public string SongName
        {
            get
            {
                return songName;
            }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }
                songName = value;
            }
        }
        public string Length
        {
            get
            {
                return length;
            }
            set
            {
                string[] time = value
                                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
                if (time.Length != 2)
                {
                    throw new InvalidSongLengthException();
                }



                if (!time[0].Any(char.IsDigit) || !time[1].Any(char.IsDigit))
                {
                    throw new InvalidSongLengthException();
                }

                int minutes = int.Parse(time[0]);
                int seconds = int.Parse(time[1]);

                if (minutes < 0 || minutes > 14)
                {
                    throw new InvalidSongMinutesException();
                }
                if (seconds < 0 || seconds > 59)
                {
                    throw new InvalidSongSecondsException();
                }
                length = value;
            }
        }

        public Song(string artistName, string songName, string length)
        {
            ArtistName = artistName;
            SongName = songName;
            Length = length;
        }

        public static string[] ReadSong(string input)
        {
            string[] songInfo = input
                            .Split(";", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            if (songInfo.Length != 3)
            {
                throw new InvalidSongException();
            }

            return songInfo;
        }
    }
}
