using System.Numerics;

namespace TopDown.Core
{
    public class MouseDot : IEntity
    {
        public Vector2 Pos => _pos;
        private Vector2 _pos;
        private readonly IInput _input;
        public MouseDot(IInput input)
        {
            _input = input;
            _pos = new Vector2(100, 100);
        }

        public void Draw(ICanvas canvas)
        {
            canvas.DrawCircle(_pos, 2.5f, GameColor.Red);
        }

        public void Update(int timestep)
        {
            var mousePosition = _input.GetMousePosition();
            _pos.X = mousePosition.X;
            _pos.Y = mousePosition.Y;
        }
    }
}
