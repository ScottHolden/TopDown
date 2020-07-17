using System.Numerics;
using TopDown.Core.Engine;

namespace TopDown.Core
{
    public class RougeDot : VelocityEntity, INotifyStaticPhysics
    {
        private const float Size = 16.0f;
        private const int Speed = 200;
        private int _life;

        public RougeDot(Vector2 position)
        {
            _life = 3;
            this.Position = position;
            this.Velocity = new Vector2(Speed, 0);
        }

        public bool Collides(Vector2 position) =>
            Vector2.Distance(position, this.Position) <= Size;

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawCircle(this.Position, Size, GameColor.Red);
        }

        public void NotifyCollision()
        {
            if(--_life <  1)
            {
                this.IsAlive = false;
            }
        }

        public override void Update(float timestep)
        {
            if(this.Position.X < 200)
            {
                this.Velocity = new Vector2(Speed, 0);
            }
            else if (this.Position.X > 600)
            {
                this.Velocity = new Vector2(-Speed, 0);
            }
            base.Update(timestep);
        }
    }
}
