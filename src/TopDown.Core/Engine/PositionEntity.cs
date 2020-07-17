using System.Numerics;

namespace TopDown.Core.Engine
{
    public abstract class PositionEntity : IEntity
    {
        public Vector2 Position { get; internal set; }
        public bool IsAlive { get; internal set; } = true;
        public abstract void Draw(ICanvas canvas);
        public abstract void Update(float timestep);
    }
}
