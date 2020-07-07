using System.Numerics;

namespace TopDown.Core
{
    public class MovingEntity : IEntity
    {
        private const int DefaultSpeed = 20;
        private Vector2 _position;
        private Vector2 _velocity;

        public MovingEntity(Vector2 position, Vector2 target)
        {
            _position = position;
            _velocity = Vector2.Multiply(DefaultSpeed, 
                            Vector2.Normalize(
                                Vector2.Subtract(target, position)));
        }

        public void Draw(ICanvas canvas)
        {
            canvas.DrawCircle(_position, 1.0f, GameColor.Yellow);
        }

        public void Update(int timestep)
        {
            _position = Vector2.Add(_position, Vector2.Multiply(timestep / 16.0f, _velocity));
        }
    }
}
