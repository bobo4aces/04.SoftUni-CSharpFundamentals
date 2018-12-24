using System;

namespace OnlineRadioDatabase.Exceptions
{
    public class InvalidSongException : ArgumentException
    {
        public override string Message => "Invalid song.";
    }
}
