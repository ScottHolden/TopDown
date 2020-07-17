using System.Numerics;

namespace TopDown.Core
{
    public interface IStaticPhysics
    {
        bool Collides(Vector2 position);
    }
}
