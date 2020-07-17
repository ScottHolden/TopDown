using System.Numerics;

namespace TopDown.Core
{
    public interface IInput
    {
        Vector2 GetMousePosition();
        InputButton GetInputState();
    }
}
