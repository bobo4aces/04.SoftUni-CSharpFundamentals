using P01.Stream_Progress.Contacts;
using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStreamable music = new Music("DMX", "The Great Depression", 3, 3);
            IStreamable file = new File("Lab",4,4);
        }
    }
}
