using System.Collections.Generic;
using System.Numerics;
using TopDown.Core.Engine;

namespace TopDown.Core
{
    public class MovingEntity : VelocityEntity, IDynamicPhysics
    {
        private const int DefaultSpeed = 1000;

        public MovingEntity(Vector2 position, Vector2 target)
        {
            this.Position = position;
            this.Velocity = Vector2.Multiply(DefaultSpeed, 
                                Vector2.Normalize(
                                    Vector2.Subtract(target, position)));
        }

        public void CheckCollisions(List<IStaticPhysics> entities)
        {
            for(int i = 0; i < entities.Count; i++)
                if(entities[i].Collides(this.Position))
                {
                    if (entities[i] is INotifyStaticPhysics nsp)
                        nsp.NotifyCollision();
                    this.IsAlive = false;
                    return;
                }
        }

        public override void Draw(ICanvas canvas)
        {
            var endPoint = Vector2.Add(this.Position, 
                                Vector2.Multiply(-12,
                                    Vector2.Normalize(this.Velocity)));

            canvas.DrawLine(this.Position, endPoint, GameColor.Yellow);
        }
    }
}
