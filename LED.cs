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
        private readonly CircleShape _blendGlow;
        private readonly int _size;

        public LED(int size, Vector2f location)
        {
            _led = new CircleShape(size);
            _led.Position = location;

            _blendGlow = new CircleShape(size);
            _size = size;
        }

        public void SetColour(Color color, int intensity)
        {
            _led.FillColor = color;
            _blendGlow.FillColor = new Color(color.R, color.G, color.B, 100);

            _blendGlow.Radius = _led.Radius * intensity;

            _blendGlow.Position = _led.Position - new Vector2f((_size * intensity) - _size, (_size * intensity) - _size);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_led);

            target.Draw(_blendGlow);
        }
    }
}
