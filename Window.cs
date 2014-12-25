using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RGBEmulator
{
    class RGBWindow
    {
        static Random random = new Random();
        public static Color RandomColour()
        {
            int r = random.Next(0, 255);
            int g = random.Next(0, 255);
            int b = random.Next(0, 255);

            return new Color((byte)r, (byte)g, (byte)b);
        }
        public static void Window()
        {
            Stopwatch watch = new Stopwatch();
            int frames = 0;

            ContextSettings contextSettings = new ContextSettings();
            contextSettings.DepthBits = 32;

            RenderWindow window = new RenderWindow(new VideoMode(800, 800), "RGBEmulator");
            window.SetActive();

            var leds = new List<LED>();

            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    leds.Add(new LED(10, new Vector2f(45 + (45 * x), 45 + (45 * y))));
                }
            }

            watch.Start();
            window.SetFramerateLimit(60);

            while (window.IsOpen())
            {
                if (watch.ElapsedMilliseconds >= 1000)
                {
                    window.SetTitle(string.Format("RGBEmulator - FPS: {0}", frames));
                    watch.Restart();
                    frames = 0;
                }
                else
                {
                    frames++;
                }

                window.DispatchEvents();

                foreach (LED led in leds)
                {
                    led.SetColour(RandomColour(), 4);
                    window.Draw(led);
                }

                window.Display();
            }
        }
    }       
}
