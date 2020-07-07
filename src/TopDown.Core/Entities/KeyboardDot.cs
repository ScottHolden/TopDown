using System;
using System.Numerics;

namespace TopDown.Core
{
    public class KeyboardDot : IEntity
    {
        public Vector2 Pos => _pos;
        private Vector2 _pos;
        private readonly IInput _input;
        private const float Speed = 10;
        public KeyboardDot(IInput input)
        {
            _input = input;
            _pos = new Vector2(100, 100);
        }

        public void Draw(ICanvas canvas)
        {
            canvas.DrawCircle(_pos, 5.0f, GameColor.LightBlue);
        }

        public void Update(int timestep)
        {
            float distance = Speed * timestep / 16.0f;

            var kbVector = GetKeyboardAsVector();
            kbVector = Vector2.Multiply(distance, kbVector);
            _pos = Vector2.Add(_pos, kbVector);
        }

        private Vector2 GetKeyboardAsVector()
        {
            var keyboardState = _input.GetKeyboardState();

            float x = 0.0f;
            float y = 0.0f;

            if (keyboardState.HasFlag(KeyboardKey.W))
            {
                y -= 1;
            }
            if (keyboardState.HasFlag(KeyboardKey.S))
            {
                y += 1;
            }
            if (keyboardState.HasFlag(KeyboardKey.A))
            {
                x -= 1;
            }
            if (keyboardState.HasFlag(KeyboardKey.D))
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
