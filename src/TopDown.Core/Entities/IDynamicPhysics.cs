using System.Collections.Generic;

namespace TopDown.Core
{
    public interface IDynamicPhysics
    {
        void CheckCollisions(List<IStaticPhysics> entities);
    }
}
