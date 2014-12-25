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

            new Thread(() =>
            {
                RGBWindow.Window();
            }).Start();

            Listener listener = new Listener(23300);
            
            listener.Listen(RGBWindow.SetLED);
        }
    }
}
