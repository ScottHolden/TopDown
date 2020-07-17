using System.Numerics;
using TopDown.Core.Engine;

namespace TopDown.Core
{
    public class BlockEntity : PositionEntity, IStaticPhysics
    {
        public Vector2 Size { get;}
        public BlockEntity(Vector2 position, Vector2 size)
        {
            this.Position = position;
            Size = size;
        }
        public override void Draw(ICanvas canvas)
        {
            canvas.DrawRect(this.Position, Size, GameColor.LightBlue);
        }

        public override void Update(float timestep)
        {
        }

        public bool Collides(Vector2 position)
        {
            return position.X >= this.Position.X &&
                    position.X <= this.Position.X + this.Size.X &&
                    position.Y >= this.Position.Y &&
                    position.Y <= this.Position.Y + this.Size.Y;
        }
    }
}
