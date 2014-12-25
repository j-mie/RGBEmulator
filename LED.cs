using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBEmulator
{
    class LED : Drawable
    {
        private readonly CircleShape _led;

        public LED(int size, Vector2f location)
        {
            _led = new CircleShape(size);
            _led.Position = location;
        }

        public void SetColour(Color color)
        {
            _led.FillColor = color;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_led);
        }
    }
}
