using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RGBEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            RGBWindow.Window();

            Listener listener = new Listener(23300);

            new Thread(() =>
            {
                listener.Listen(RGBWindow.SetLED);
            }).Start();
        }
    }
}
