namespace TopDown.Core
{
    public interface IEntity
    {
        void Draw(ICanvas canvas);
        void Update(float timestep);
        bool IsAlive { get; }
    }
}
