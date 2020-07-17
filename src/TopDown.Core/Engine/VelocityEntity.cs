using System.Numerics;

namespace TopDown.Core.Engine
{
    public abstract class VelocityEntity : PositionEntity
    {
        public Vector2 Velocity { get; internal set; }
        public abstract override void Draw(ICanvas canvas);
        public override void Update(float timestep)
        {
            this.Position = Vector2.Add(this.Position, 
                                Vector2.Multiply(timestep, this.Velocity));
        }
    }
}
