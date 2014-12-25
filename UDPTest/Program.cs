using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            var udp = new UdpClient(sender);

            Random rnd = new Random();

            while (true)
            {
                for(int i = 0; i < 256; i++)
                {
                    SetLED(udp, i, 255,0,255, 5);
                    //Thread.Sleep(100);
                }
            }

        }

        private static void SetLED(UdpClient udp, int index, int r, int g, int b, int intensity)
        {
            udp.Send(BitConverter.GetBytes(index), 2, "localhost", 23300);
            udp.Send(BitConverter.GetBytes(r), 1, "localhost", 23300);
            udp.Send(BitConverter.GetBytes(g), 1, "localhost", 23300);
            udp.Send(BitConverter.GetBytes(b), 1, "localhost", 23300);
            udp.Send(BitConverter.GetBytes(intensity), 2, "localhost", 23300);
        }
    }
}
