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
        private static List<LED> leds = new List<LED>();
        public static void SetLED(int i, byte r, byte g, byte b, int intensity)
        {
            if (leds[i] != null)
                leds[i].SetColour(new Color(r, g, b), intensity);
            else throw new Exception("LED does not exist");
        }
        public static void Window()
        {
            Stopwatch watch = new Stopwatch();
            int frames = 0;

            ContextSettings contextSettings = new ContextSettings();
            contextSettings.DepthBits = 32;

            RenderWindow window = new RenderWindow(new VideoMode(785, 785), "RGBEmulator");

            window.SetActive();

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
                    window.Draw(led, new RenderStates(BlendMode.Add));
                }

                window.Display();
            }
        }
    }       
}
