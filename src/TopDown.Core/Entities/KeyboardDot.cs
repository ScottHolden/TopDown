using System;
using System.Numerics;
using TopDown.Core.Engine;

namespace TopDown.Core
{
    public class KeyboardDot : VelocityEntity
    {
        private readonly IInput _input;
        private const float Speed = 400;
        public KeyboardDot(IInput input)
        {
            _input = input;
            this.Position = new Vector2(500, 500);
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawCircle(this.Position, 20.0f, GameColor.LightBlue);
        }

        public override void Update(float timestep)
        {
            this.Velocity = Vector2.Multiply(Speed, GetKeyboardAsVector());
            base.Update(timestep);
        }

        private Vector2 GetKeyboardAsVector()
        {
            var keyboardState = _input.GetInputState();

            float x = 0.0f;
            float y = 0.0f;

            if (keyboardState.HasFlag(InputButton.W))
            {
                y -= 1;
            }
            if (keyboardState.HasFlag(InputButton.S))
            {
                y += 1;
            }
            if (keyboardState.HasFlag(InputButton.A))
            {
                x -= 1;
            }
            if (keyboardState.HasFlag(InputButton.D))
            {
                x += 1;
            }

            if(Math.Abs(x) < 0.1f && Math.Abs(y) < 0.1f)
            {
                return Vector2.Zero;
            }

            return Vector2.Normalize(new Vector2(x, y));
        }
    }
}
