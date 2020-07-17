namespace TopDown.Core
{
    public interface INotifyStaticPhysics : IStaticPhysics
    {
        void NotifyCollision();
    }
}
