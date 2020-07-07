namespace TopDown.Core
{
    public interface IEntity
    {
        void Draw(ICanvas canvas);
        void Update(int timestep);
    }
}
