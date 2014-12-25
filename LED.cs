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
        private readonly List<CircleShape> _blendGlow = new List<CircleShape>();
        private readonly int _size;

        public LED(int size, Vector2f location)
        {
            _led = new CircleShape(size);
            _led.Position = location;

            _size = size;

            for (int i = 0; i <= 4; i++)
            {
                 _blendGlow.Add(new CircleShape(size));
            }
        }

        public void SetColour(Color color, int intensity)
        {
            _led.FillColor = color;

            for (int i = 0; i <= 4; i++)
            {
                byte alpha = (byte)((i * 1));

                _blendGlow[i].FillColor = new Color(color.R, color.G, color.B, alpha);

                _blendGlow[i].Radius = (_size) + 8 * i;

                _blendGlow[i].Position = _led.Position - new Vector2f(_blendGlow[i].Radius - _size, _blendGlow[i].Radius - _size);
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states = new RenderStates(BlendMode.Add);

            target.Draw(_led);

            foreach(var circle in _blendGlow)
                target.Draw(circle, states);
        }
    }
}
